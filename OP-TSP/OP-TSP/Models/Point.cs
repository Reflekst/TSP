using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_TSP.Models
{
    public class Point
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Distance { get; set; }
    }
}