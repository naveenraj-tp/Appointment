using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Utility
{
    public static class Helper
    {
        public static string admin = "Admin";
        public static string patient = "Patient";
        public static string doctor = "Doctor";

        public static string appointmentAdded = "Appointment added Successfully";
        public static string appointmentUpdated = "Appointment Updated Successfully";
        public static string appointmentDeleted = "Appointment Deleted Successfully";

        public static string appointmentExists = "Appointment for selected date and time already Exists";
        public static string appointmentNotExists = "Appointment not Exists";


        public static string appointmentAddError = "Something Went Wrong, Please try again";
        public static string appointmentUpdateError= "Something Went Wrong, Please try again";
        public static string somethingWentWrong = "Something Went Wrong, Please try again";

        public static int success_code = 1;
        public static int failure_code = 0;
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 0; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr 30 min" });
                minute = minute + 30;
            }
            return duration;
        }
        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem> {

            new SelectListItem{Value=Helper.admin,Text=Helper.admin},
            new SelectListItem{Value=Helper.doctor,Text=Helper.doctor},
            new SelectListItem{Value=Helper.patient,Text=Helper.patient}
        };
        }
    }
}
