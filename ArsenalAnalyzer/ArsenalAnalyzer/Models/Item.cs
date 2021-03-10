using System;
using SQLite;

namespace ArsenalAnalyzer.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BallBrand { get; set; }
        public string BallModel { get; set; }
        public string Layout { get; set; }
        public string CoverType { get; set; }
        public string CoreType { get; set; }
        public string SurfaceFinish { get; set; }
        public int HookPotential { get; set; }
        public string BallSerialNumber { get; set; }
        public string Notes { get; set; }
        public bool HasBeenPlugged { get; set; }
        public string CoreRG { get; set; }
        public string CoreDiff { get; set; }
        public string CoreIntDiff { get; set; }
        public string Image1 { get; set; } // Image of balls NAme Logo
        public string Image2 { get; set; } // Image of Layout
        //ball image??
    }
}