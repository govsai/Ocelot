
using HospitalManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class MockPracticeRepository : IHospitalRepository
    {
        private List<Hospital> _hospital;
        public MockPracticeRepository()
        {
            _hospital = new List<Hospital>()
            {
                new Hospital(){HospitalId=1,HospitalName="KMS",Address="Chennai",Email="kms@gmail.com", Active=true,ContactNumber="987652",CreatedBy="Admin",CreatedDate=DateTime.Now, UpdatedBy="Admin",UpdatedDate=DateTime.Now}
            };

        }
        public Hospital Add(Hospital hospital)
        {
            hospital.HospitalId= _hospital.Max(p => p.HospitalId) + 1;
            _hospital.Add(hospital);
            return hospital;
        }

        public bool Delete(int id)
        {
            bool delete = false;
            Hospital practice = _hospital.FirstOrDefault(p => p.HospitalId == id);
            if (practice != null)
            {
                _hospital.Remove(practice);
            }
            delete = true;
            return delete;
        }

        public Hospital Get(int id)
        {
            return _hospital.FirstOrDefault(p => p.HospitalId == id);
        }

        public IEnumerable<Hospital> GetAll()
        {
            return _hospital;
        }

        public Hospital Update(Hospital hospitalUpdated)
        {
            Hospital hospital = _hospital.FirstOrDefault(p => p.HospitalId == hospitalUpdated.HospitalId);
            if (hospital != null)
            {
                hospital.HospitalName = hospitalUpdated.HospitalName;
                hospital.Address = hospitalUpdated.Address;
                hospital.Active = hospitalUpdated.Active;
                hospital.ContactNumber = hospitalUpdated.ContactNumber;
                hospital.Email = hospitalUpdated.Email;
                hospital.CreatedBy = hospitalUpdated.CreatedBy;
                hospital.CreatedDate = hospitalUpdated.CreatedDate;
                hospital.UpdatedBy = hospitalUpdated.UpdatedBy;
                hospital.UpdatedDate = hospitalUpdated.UpdatedDate;
            }
            return hospital;
        }
    }
}
