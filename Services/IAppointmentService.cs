using AppointmentScheduling.Models.ViewModels;
using System.Collections.Generic;

namespace AppointmentScheduling.Services
{
    public interface IAppointmentService
    {
        public List<DoctorVM> GetDoctorList();
        public List<PatientVM> GetPatientList();

    }
}
