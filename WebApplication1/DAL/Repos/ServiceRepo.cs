using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ServiceRepo : Repo, IRepo<Service, int, bool>
    {
        public void Create(Service obj)
        {
            db.services.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.services.Remove(exobj);
            return db.SaveChanges() > 0;
            //throw new NotImplementedException();
        }

        public Service Get(int id)
        {
            return db.services.Find(id);
            //throw new NotImplementedException();
        }

        public List<Service> Get()
        {
            return db.services.ToList();
            //throw new NotImplementedException();
        }

        public bool Update(int id, Service updatedUser)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.service_title = updatedUser.service_title;
            existingUser.service_description = updatedUser.service_description;
            existingUser.service_location_to = updatedUser.service_location_to;
            existingUser.service_location_from = updatedUser.service_location_from;
            existingUser.service_value = updatedUser.service_value;
            existingUser.service_status = updatedUser.service_status;
            

            db.Entry(existingUser).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
