using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Models
{
    public class Seat
    {
        //Id – integer, Primary Key
        // – integer, foreign key(required)
        //Hall – the seaHallIdt’s hall
        public int Id { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
