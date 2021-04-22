using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageGamesCollector.Models;

namespace VintageGamesCollector.Controllers
{
    public class GameController : Controller
    {
        private readonly GamesDBContext _context;



        public GameController(GamesDBContext context)
        {
            _context = context;
        }



        // GET: GameController
        public async Task<ActionResult> Index()
        {
            var myData = await _context.Games.Where(g => g.GameId != 0).ToListAsync();
            var test = (from g in _context.Games
                       join m in _context.Manufacturers on g.ManufacturerId equals m.ManufacturerId
                       join p in _context.GamePlatforms on g.PlatformId equals p.PlatformId
                       join r in _context.Grades on g.GradeId equals r.GradeId
                       join t in _context.GameTypes on g.GameTypeId equals t.GameTypeId
                       select new { 
                           Name = g.GameName,
                           Type = t.GameTypeName,
                           Platform= p.PlatformName,
                           Version = p.PlatformVersion,
                           Manufacturer = m.ManufacturerName,
                           Grade = r.GradeText,
                           LastPlayed = g.LastPlayed,
                           PlayLevel = g.PlayedLevel,
                           Image = g.GameImage
                       }).ToListAsync();


            //return View(myData);
            return View(test);
        }



        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
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
        public ActionResult Edit(int id)
        {

            var GType = _context.GameTypes.Where(g => g.GameTypeId != 0).ToList();
            return View();
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
