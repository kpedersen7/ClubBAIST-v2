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
    public int ReservationID { get; set; }
    public string UserEmail { get; set; }
    public int[] Scores { get; set; }
    public int RoundTotal { get; set; }
    public decimal HandicapDifferential { get; set; }
}