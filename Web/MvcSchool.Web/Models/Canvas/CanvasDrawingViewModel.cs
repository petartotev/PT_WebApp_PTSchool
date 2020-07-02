using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Canvas
{
    public class CanvasDrawingViewModel
    {
        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        public int brushSize { get; set; }

        //public int zero { get; set; }

        public string brushColor { get; set; }
    }
}
