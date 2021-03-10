using System;
using SQLite;

namespace ProShop.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Bowler_Name { get; set; }
        public string Bowler_Hand { get; set; }
        public string Bowler_PAP { get; set; }
        public string Bowler_RevRate { get; set; }
        public string Bowler_BallSpeed { get; set; }
        public string Bowler_AxisTilt { get; set; }
        public string Bowler_AxisRotation { get; set; }

        public string ReverseLeft { get; set; }
        public string LatLeft { get; set; }
        public string ForwardLeft { get; set; }
        public string ReverseRight { get; set; }
        public string LatRight { get; set; }
        public string ForwardRight { get; set; }
        public string ReverseThumb { get; set; }
        public string AwayThumb { get; set; }
        public string ForwardThumb { get; set; }
        public string IntoThumb { get; set; }

        public string Bowler_LeftFingerSize { get; set; }
        public string Bowler_RightFingerSize { get; set; }
        public string Bowler_ThumbSize { get; set; }
        public string Bowler_ThumbGripSize { get; set; }
        public string Bowler_SpanLeft { get; set; }
        public string Bowler_SpanRight { get; set; }
        public string Bowler_LeftInsert { get; set; }
        public string Bowler_RightInsert { get; set; }
        public string Bowler_Bridge { get; set; }

        public string Notes { get; set; }
    }
}