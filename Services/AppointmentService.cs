using Appoinment_Schedule.Models;
using Appoinment_Schedule.Models.ViewModels;
using Appoinment_Schedule.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddUpdate(AppointmentVM model)
        {
          var  startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));
            if(model!=null && model.Id>0)
            {

                return 1;
            }
            else
            {

                Appointment obj = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    DoctorId=model.DoctorId,
                    PattientId=model.PattientId,
                    IsDoctorApproved=model.IsDoctorApproved,
                    AdminId=model.AdminId
           };
                _db.Appointments.Add(obj); 
                
                await  _db.SaveChangesAsync();
                return 2;
            }
        }

        public List<DoctorVM> GetDoctorList()
        {
           

            var doctors = (from users in _db.Users
                           join userRoles in _db.UserRoles
 on users.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(a => a.Name == Helper.doctor) on userRoles.RoleId equals roles.Id
                           select new DoctorVM
                           {
                               Id = users.Id,
                               Name = users.Name
                           }).ToList();

          
            return doctors;
        }

        public List<PatientVM> GetPatientList()
        {
            var patients = (from s in _db.Users
                           join userRoles in _db.UserRoles on s.Id equals userRoles.RoleId
                           join roles in _db.Roles.Where(x => x.Name == Helper.patient) on userRoles.RoleId equals roles.Id
                           select new PatientVM
                           {
                               Id = s.Id,
                               Name = s.Name
                           }
                        ).ToList();

            return patients;
        }
    }
}
