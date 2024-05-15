using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    public class OrderRepo : Repo, IRepo<Order, int, bool>
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

        public List<Order> Search(string term)
        {
            throw new System.NotImplementedException();
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

        public List<Order> Sort(string sortBy, bool ascending)
        {
            IQueryable<Order> query = db.orders;

            switch (sortBy.ToLower())
            {
                case "order_created":
                    query = ascending ? query.OrderBy(c => c.order_created) : query.OrderByDescending(c => c.order_created);
                    break;
                case "order_id":
                    query = ascending ? query.OrderBy(c => c.order_Id) : query.OrderByDescending(c => c.order_Id);
                    break;
                default:
                    throw new ArgumentException("Invalid sort field");
            }

            return query.ToList();
        }

        public List<Order> Filter(string filterBy, string value)
        {
            IQueryable<Order> query = db.orders;

            switch (filterBy.ToLower())
            {
                case "order_created":
                    if (DateTime.TryParse(value, out DateTime orderCreated))
                    {
                        query = query.Where(c => DbFunctions.TruncateTime(c.order_created) == orderCreated.Date);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid filter field");
            }

            return query.ToList();
        }

        public List<Order> GetPaged(int pageNumber, int pageSize)
        {
            return db.orders
                     .OrderBy(c => c.order_Id)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
        }

        public bool Vote(int id, bool upvote)
        {
            throw new NotImplementedException();
        }
    }
}
