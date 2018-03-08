using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Score
/// </summary>
public class Score
{
    public int ScoreID { get; set; }
    public int UserID { get; set; }
    public int CourseID { get; set; }
    public int[] Scores { get; set; }
}