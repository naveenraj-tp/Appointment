using Appoinment_Schedule.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Services
{
 public   interface IAppointmentService
    {
        public List<DoctorVM> GetDoctorList();

        public List<PatientVM> GetPatientList();

        public Task<int> AddUpdate(AppointmentVM model);
    }
}
