﻿using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public List<Service> Search(string term)
        {
            return db.services.Where(u => u.service_location_from.Contains(term) || u.service_title.Contains(term)).ToList();
        }

        public List<Service> Sort(string sortBy, bool ascending)
        {
            IQueryable<Service> query = db.services;

            switch (sortBy.ToLower())
            {
                case "service_value":
                    query = ascending ? query.OrderBy(c => c.service_value) : query.OrderByDescending(c => c.service_value);
                    break;
                default:
                    throw new ArgumentException("Invalid sort field");
            }

            return query.ToList();
        }

        public List<Service> Filter(string filterBy, string value)
        {
            IQueryable<Service> query = db.services;

            switch (filterBy.ToLower())
            {
                case "service_status":
                    query = query.Where(c => c.service_status.Contains(value));
                    break;
                case "service_location_from":
                    query = query.Where(c => c.service_location_from.Contains(value));
                    break;
                default:
                    throw new ArgumentException("Invalid filter field");
            }

            return query.ToList();
        }

        public List<Service> GetPaged(int pageNumber, int pageSize)
        {
            return db.services
                     .OrderBy(c => c.service_id)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
        }

        public bool Vote(int id, bool upvote)
        {
            var service = Get(id);
            if (service == null)
            {
                return false;
            }

            if (upvote)
            {
                service.Votes++;
            }
            else
            {
                service.Votes--;
            }

            db.Entry(service).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }


    }
}
