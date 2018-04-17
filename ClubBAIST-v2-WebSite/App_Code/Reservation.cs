using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    public int ReservationID { get; set; }
    public int UserID { get; set; }
    public int CourseID { get; set; }
    public DateTime ReservedTime { get; set; }
    public int NumberHoles { get; set; }
    public int NumberCarts { get; set; }
    public string Player2 { get; set; }
    public string Player3 { get; set; }
    public string Player4 { get; set; }
    public int IsStandingReservation { get; set; }
}