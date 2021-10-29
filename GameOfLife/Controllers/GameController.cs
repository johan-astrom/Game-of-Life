using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameViewController gameViewController = new GameViewController();

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(gameViewController);
        }
        [HttpPost]
        public IActionResult Grid(int number)
        {
            gameViewController.GridAxisSize = number;
            gameViewController.HideGrid = false;

            return View(gameViewController);
        }

        [HttpPost]
        public void NextGeneration(string[] coordinates)
        {
            gameViewController.Coordinates = coordinates;

            RedirectToAction("Grid");
        }
    }
}
