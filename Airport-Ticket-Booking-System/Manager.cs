﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System
{
    public class Manager
    {       
        public string Name { get; set; }
        public List<Booking> bookings;

        public Manager(string name)
        {
            Name = name;
        }
    }
}
