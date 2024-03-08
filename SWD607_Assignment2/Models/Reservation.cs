using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD607_Assignment2.Models
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int ReservationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string username { get; set; }
        public string TableNumber { get; set; }       
        
    }
}
