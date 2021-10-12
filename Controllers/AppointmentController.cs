using Appoinment_Schedule.Models;
using Appoinment_Schedule.Services;
using Appoinment_Schedule.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;    
        }
        public IActionResult Index()
        {
            ViewBag.duration = Helper.GetTimeDropDown();
            ViewBag.doctorlist = _appointmentService.GetDoctorList();
            ViewBag.patientlist = _appointmentService.GetPatientList();
            return View();
        }
    }
}
