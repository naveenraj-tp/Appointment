using Appoinment_Schedule.Models.ViewModels;
using Appoinment_Schedule.Services;
using Appoinment_Schedule.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Controllers.API
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {

        private readonly IAppointmentService _appointmentService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string loginUserId;
        private readonly string role;
        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentVM data)
        {
            CommonResponse<int> CommonResponse = new CommonResponse<int>();
            try
            {
                CommonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if(CommonResponse.Status==1)
                {
                    CommonResponse.message = Helper.appointmentUpdated;
                }
                if (CommonResponse.Status == 2)
                {
                    CommonResponse.message = Helper.appointmentAdded;
                }
            }
            catch(Exception ex)
            {
                CommonResponse.message = ex.Message;
                CommonResponse.Status = Helper.failure_code;
            }
            return View();
        }
 
    }
}
