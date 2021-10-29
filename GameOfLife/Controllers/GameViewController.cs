using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Controllers
{
    public class GameViewController
    {
        [BindProperty]
        public int GridAxisSize { get; set; } = 33;
        public bool HideGrid { get; set; } = true;
        public string[] Coordinates { get; set; } = Array.Empty<string>();
    }
}
