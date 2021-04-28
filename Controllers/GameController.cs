using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VintageGamesCollector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VintageGamesCollector.Controllers
{
    public class GameController : Controller
    {
        private readonly GamesDBContext _context;
        private byte[] imageBuffer;

        public GameController(GamesDBContext context)
        {
            _context = context;
        }



        // GET: GameController
        public async Task<ActionResult> Index()
        {
            //var myData = await _context.Games.Where(g => g.GameId != 0).ToListAsync();
            var gameFull = await (from g in _context.Games
                                  join m in _context.Manufacturers on g.ManufacturerId equals m.ManufacturerId
                                  join p in _context.GamePlatforms on g.PlatformId equals p.PlatformId
                                  join r in _context.Grades on g.GradeId equals r.GradeId
                                  join t in _context.GameTypes on g.GameTypeId equals t.GameTypeId
                                  select new GameFull
                                  {   GameId = g.GameId,
                                      Name = g.GameName,
                                      Type = t.GameTypeName,
                                      Platform = p.PlatformName,
                                      Version = p.PlatformVersion,
                                      Manufacturer = m.ManufacturerName,
                                      Grade = r.GradeText,
                                      LastPlayed = g.LastPlayed,
                                      PlayedLevel = g.PlayedLevel,
                                      GameImage = g.GameImage
                                  }).ToListAsync();

            //return View(myData);
            return View(gameFull);
        }



        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: GameController/Create
        public async Task<ActionResult> Create()
        {
            Game newGame = new Game();
            newGame.GameName = "Name of the game";
            newGame.LastPlayed = DateTime.Today;

            //Create Gametype dropdownlist
            List<SelectListItem> GameTypeSelectList = await CreateDropDowns("GameType");
            ViewBag.GameTypes = GameTypeSelectList;

            //Create Manufacturer dropdownlist
            List<SelectListItem> ManufacturerSelectList = await CreateDropDowns("Manufacturer"); 
            ViewBag.Manufacturer = ManufacturerSelectList;

            //Create Platform dropdownlist
            List<SelectListItem> PlatformSelectList = await CreateDropDowns("Platform");
            ViewBag.Platforms = PlatformSelectList;

            //Create Grade dropdownlist
            List<SelectListItem> GradeSelectList = await CreateDropDowns("Grade");
            ViewBag.Grades = GradeSelectList;

            return View(newGame);
        }




        // POST: GameController/Create
        [HttpPost]
        //        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Game NewGame = new Game();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    // case "GameId":    //DB set, don't touch!!! 

                    case "GameName": NewGame.GameName = item.Value; break;
                    case "Manufacturer": NewGame.ManufacturerId = Convert.ToInt32(item.Value); break;
                    case "Grades": NewGame.GradeId = Convert.ToInt32(item.Value); break;
                    case "GameTypes": NewGame.GameTypeId = Convert.ToInt32(item.Value); break;
                    case "Platforms": NewGame.PlatformId = Convert.ToInt32(item.Value); break;
                    case "LastPlayed": NewGame.LastPlayed = Convert.ToDateTime(item.Value); break;
                    case "PlayedLevel": NewGame.PlayedLevel = item.Value; break;
                    case "Image":
                        if (item.Value != "")
                        {
                            //This is a temporary cheat, it will be fixed, if time permits!
                            //The image OR the full filepath should be available here!!
                            ToDo Remember;
                            var filePath = "../VintageGamesCollector/Images/" + item.Value;
                            FileInfo fileInfo = new FileInfo(filePath);
                            byte[] imageToDB = new byte[fileInfo.Length];
                            //convert the image to byte table
                            using (FileStream fs = fileInfo.OpenRead())    // Load a filestream and put its content into the byte[]
                            {
                                fs.Read(imageToDB, 0, imageToDB.Length);
                            }
                            NewGame.GameImage = imageToDB;
                        }
                        break;
                    default:
                        break;
                }
            }
            ToDo remember;   //Validation ???

            _context.Games.Add(NewGame);
            _context.SaveChanges();

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: GameController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // var game = await _context.Games.Where(g => g.GameTypeId == id).ToListAsync();
            var GameFull = await (from g in _context.Games.Where(g => g.GameId == id)
                                  join m in _context.Manufacturers on g.ManufacturerId equals m.ManufacturerId
                                  join p in _context.GamePlatforms on g.PlatformId equals p.PlatformId
                                  join r in _context.Grades on g.GradeId equals r.GradeId
                                  join t in _context.GameTypes on g.GameTypeId equals t.GameTypeId
                                  //where g.GameId == id
                                  select new GameFull
                                  {
                                      GameId = g.GameId,
                                      Name = g.GameName,
                                      Type = t.GameTypeName,
                                      Platform = p.PlatformName,
                                      Version = p.PlatformVersion,
                                      Manufacturer = m.ManufacturerName,
                                      Grade = r.GradeText,
                                      LastPlayed = g.LastPlayed,
                                      PlayedLevel = g.PlayedLevel,
                                      GameImage = g.GameImage
                                  }).SingleOrDefaultAsync();

            //Create Gametype dropdownlist
            List<SelectListItem> GameTypeSelectList = await CreateDropDowns("GameType");
            ViewBag.GameTypes = GameTypeSelectList;

            //Create Manufacturer dropdownlist
            List<SelectListItem> ManufacturerSelectList = await CreateDropDowns("Manufacturer");
            ViewBag.Manufacturer = ManufacturerSelectList;

            //Create Platform dropdownlist
            List<SelectListItem> PlatformSelectList = await CreateDropDowns("Platform");
            ViewBag.Platforms = PlatformSelectList;

            //Create Grade dropdownlist
            List<SelectListItem> GradeSelectList = await CreateDropDowns("Grade");
            ViewBag.Grades = GradeSelectList;

            return View(GameFull);
        }


        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            bool changed = false;
            Game original = _context.Games.Find(id);  //Load the original record
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "Name":
                        if (original.GameName != item.Value)
                        {
                            changed = true;
                            original.GameName = item.Value;
                        }
                        break;
                    case "Type": original.GameTypeId = Convert.ToInt32(item.Value); break;
                    case "Platform": original.PlatformId = Convert.ToInt32(item.Value); break;
                    case "Manufacturer": original.ManufacturerId = Convert.ToInt32(item.Value); break;
                    case "Grade": original.GradeId = Convert.ToInt32(item.Value); break;
                    case "LastPlayed":
                        if (original.LastPlayed != item.Value)
                        {
                            changed = true;
                            original.LastPlayed = Convert.ToDateTime(item.Value);
                        }
                        break;
                    case "PlayedLevel":
                        if (original.PlayedLevel != item.Value)
                        {
                            changed = true;
                            original.PlayedLevel = item.Value;
                        }
                        break;
                    case "Image":
                        if (item.Value != "")
                        {
                            //The full filepath is seldom present in the browsers so it is a
                            //requirement that the image is put in the '../Image/' folder!!!
                            var filePath = "../VintageGamesCollector/Images/" + item.Value;
                            FileInfo fileInfo = new FileInfo(filePath);
                            byte[] imageToDB = new byte[fileInfo.Length];
                            //convert the image to byte table
                            using (FileStream fs = fileInfo.OpenRead())    // Load a filestream and put its content into the byte[]
                            {
                                fs.Read(imageToDB, 0, imageToDB.Length);
                            }
                            original.GameImage = imageToDB;
                            changed = true;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (changed)  // If the original record was changed, do an update!!!
            {
                _context.Games.Update(original);
                _context.SaveChanges();
            }

            try
            {
                return RedirectToAction(nameof(Index));
                //return RedirectToAction(Index);
            }
            catch
            {
                return View();
            }
        }



        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                Game delGame = _context.Games.Find(id);
                _context.Games.Remove(delGame);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }



        private async Task<List<SelectListItem>> CreateDropDowns(string type)
        {
            //Since these are used BOTH by "Create" and "EDIT",
            //the original values is lost during an "edit" :-(
            switch (type)
            {
                case "GameType":
                    List<SelectListItem> GameTypeSelectList = new List<SelectListItem>();
                    List<GameType> GameTypeList = await _context.GameTypes.Where(t => t.GameTypeId != 0).ToListAsync();
                    foreach (var item in GameTypeList)
                    {
                        GameTypeSelectList.Add(new SelectListItem { Text = item.GameTypeName, Value = item.GameTypeId.ToString(), Selected = false });
                    }

                    return GameTypeSelectList;

                case "Manufacturer":
                    List<SelectListItem> ManufacturerSelectList = new List<SelectListItem>();
                    List<Manufacturer> ManufacturerList = await _context.Manufacturers.Where(t => t.ManufacturerId != 0).ToListAsync();
                    foreach (var item in ManufacturerList)
                    {
                        ManufacturerSelectList.Add(new SelectListItem { Text = item.ManufacturerName, Value = item.ManufacturerId.ToString(), Selected = false });
                    }
                    return ManufacturerSelectList;

                case "Platform":
                    List<SelectListItem> PlatformSelectList = new List<SelectListItem>();
                    List<GamePlatform> PlatformList = await _context.GamePlatforms.Where(t => t.PlatformId != 0).ToListAsync();
                    foreach (var item in PlatformList)
                    {
                        PlatformSelectList.Add(new SelectListItem
                        {
                            Text = item.PlatformName +
                                             " - Version " + item.PlatformVersion
                                             ,
                            Value = item.PlatformId.ToString(),
                            Selected = false
                        });
                    }
                    return PlatformSelectList;

                case "Grade":
                    List<SelectListItem> GradeSelectList = new List<SelectListItem>();
                    List<Grade> GradeList = await _context.Grades.Where(t => t.GradeId != 0).ToListAsync();
                    foreach (var item in GradeList)
                    {
                        GradeSelectList.Add(new SelectListItem
                        {
                            Text = item.GradeNumber +
                                            " " + item.GradeText,
                            Value = item.GradeId.ToString(),
                            Selected = false
                        });
                    }
                    return GradeSelectList;
                default:
                    return null;
            }

        }
    }
}
