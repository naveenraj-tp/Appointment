﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public int Description  { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }
        public string DoctorId { get; set; }

        public string PattientId { get; set; }

        public bool IsDoctorApproved { get; set; }

        public string AdminId { get; set; }
    }
}
