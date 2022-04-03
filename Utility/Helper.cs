using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AppointmentScheduling.Utility
{
    public static class Helper
    {
        public static string ADMIN = "Admin";
        public static string PATIENT = "Patient";
        public static string DOCTOR = "Doctor";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            { 
                new SelectListItem { Text = ADMIN, Value = ADMIN },
                new SelectListItem { Text = PATIENT, Value = PATIENT },
                new SelectListItem { Text = DOCTOR, Value = DOCTOR }
            };
        }
    }
}
