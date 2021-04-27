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


            //Gametype dropdownlist create
            List<SelectListItem> GameTypeSelectList = new List<SelectListItem>();
            List<GameType> GameTypeList = await _context.GameTypes.Where(t => t.GameTypeId != 0).ToListAsync();
            foreach (var item in GameTypeList)
            {
                GameTypeSelectList.Add(new SelectListItem { Text = item.GameTypeName, Value = item.GameTypeId.ToString(), Selected = false });
            }
            ViewBag.GameTypes = GameTypeSelectList;


            //Manufacturer dropdownlist create
            List<SelectListItem> ManufacturerSelectList = new List<SelectListItem>();
            List<Manufacturer> ManufacturerList = await _context.Manufacturers.Where(t => t.ManufacturerId != 0).ToListAsync();
            foreach (var item in ManufacturerList)
            {
                ManufacturerSelectList.Add(new SelectListItem { Text = item.ManufacturerName, Value = item.ManufacturerId.ToString(), Selected = false });
            }
            ViewBag.Manufacturer = ManufacturerSelectList;

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
                    //These will be done at a later time, currently only have "default" values :-(
                    case "GameTypeID": NewGame.GameTypeId = 1; break;
                    case "PlatformID": NewGame.PlatformId = 1; break;
                    case "Version": break;
                    case "ManufacturerI": NewGame.ManufacturerId = 2; break;
                    case "GradeId": NewGame.GradeId = 2; break;
                    default:
                        break;
                }
            }
            //Validation and check for "cancel"? button?
            ToDo remember;

            //temporary test solution, to be removed!!!
            NewGame.GameTypeId = 1;
            NewGame.PlatformId = 1;
            NewGame.ManufacturerId = 2;
            NewGame.GradeId = 2;

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
                    // case "GameId":    //Cannot be changed!!! 

                    case "Name":
                        if (original.GameName != item.Value)
                        {
                            changed = true;
                            original.GameName = item.Value;
                        }
                        break;
                    case "Type":
                    case "Platform":
                    case "Version":
                    case "Manufacturer":
                    case "Grade":
                        //These will be done at a later time
                        break;
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



        //// POST: GameController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
