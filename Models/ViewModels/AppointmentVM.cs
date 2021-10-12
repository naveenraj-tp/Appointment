using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Models.ViewModels
{
    public class AppointmentVM
    {

        public int? Id { get; set; }

        public string Title { get; set; }


        public int Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int Duration { get; set; }
        public string DoctorId { get; set; }

        public string PattientId { get; set; }

        public bool IsDoctorApproved { get; set; }

        public string AdminId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        public string AdminName { get; set; }
        public string IsForClient { get; set; }
    }
}
