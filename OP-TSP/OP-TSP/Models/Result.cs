using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_TSP.Models
{
    public class Result
    {
        public int PointsCount { get; set; }
        public decimal Time { get; set; }
        public List<Point> SortPoints { get; set; }
        public double Distance { get; set; }
        public double GreedyDistance { get; set; }
    }
}
