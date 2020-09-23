
using HospitalManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public interface IHospitalRepository
    {
        Hospital Add(Hospital hospital);
        Hospital Get(int id);
        IEnumerable<Hospital> GetAll();
        Hospital Update(Hospital hospital);
        bool Delete(int id);
    }
}
