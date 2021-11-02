using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Models;

namespace GameOfLife.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameViewController gameViewController;
        private readonly GameRules gameRules;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
            gameViewController = new GameViewController();
            gameRules = new GameRules();
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
        public IActionResult NextGeneration(string[] coordinates, int number)
        {
            var firstGeneration = gameRules.Parse(coordinates);
            var secondGeneration = gameRules.ComputeGeneration(firstGeneration);

            coordinates = secondGeneration.ToList()
                .Select(node => node.Coordinates.XCoordinate + ", " + node.Coordinates.YCoordinate)
                .ToArray();

            gameViewController.Coordinates = coordinates;
            gameViewController.GridAxisSize = number;

            return View(gameViewController);
        }
    }
}
