using AppointmentScheduling.Data;
using AppointmentScheduling.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AppointmentScheduling.Utility;

namespace AppointmentScheduling.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<DoctorVM> GetDoctorList()
        {
            var doctors = _db.Users.Join(
                _db.UserRoles
                , mainUser => mainUser.Id
                , userRole => userRole.UserId                
                , (mainUser, userRole) => new { mainUser, userRole })
                .Join(
                    _db.Roles,
                    intermediateUser => intermediateUser.userRole.RoleId,
                    role => role.Id,                    
                    (intermediateUser, role) => new { intermediateUser, role })
                .Where(i => i.role.Name == Helper.DOCTOR)
                .Select(u => new DoctorVM
                    {
                        Id = u.intermediateUser.mainUser.Id,
                        Name = u.intermediateUser.mainUser.Name
                    })
                .ToList();
            
            return doctors;
        }

        public List<PatientVM> GetPatientList()
        {
            throw new System.NotImplementedException();
        }
    }
}
