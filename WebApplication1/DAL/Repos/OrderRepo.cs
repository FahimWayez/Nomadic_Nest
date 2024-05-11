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
    public class OrderRepo: Repo, IRepo<Order, int, bool>
    {
        public void Create(Order obj)
        {
            db.orders.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.orders.Remove(exobj);
            return db.SaveChanges() > 0;
            //throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return db.orders.Find(id);
            //throw new NotImplementedException();
        }

        public List<Order> Get()
        {
            return db.orders.ToList();
            //throw new NotImplementedException();
        }

        public bool Update(int id, Order updatedUser)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }

            db.Entry(existingUser).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
