using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IRepo<Post, int, bool>
    {
        public void Create(Post obj)
        {
            db.posts.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.posts.Remove(exobj);
            return db.SaveChanges() > 0;
            //throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            return db.posts.Find(id);
            //throw new NotImplementedException();
        }

        public List<Post> Get()
        {
            return db.posts.ToList();
            //throw new NotImplementedException();
        }

        public bool Update(int id, Post updatedUser)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.post_title = updatedUser.post_title;
            existingUser.post_description = updatedUser.post_description;
            existingUser.post_location = updatedUser.post_location;

            db.Entry(existingUser).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public List<Post> Search(string term)
        {
            return db.posts.Where(u => u.post_description.Contains(term)).ToList();
        }

        public List<Post> Sort(string sortBy, bool ascending)
        {
            IQueryable<Post> query = db.posts;

            switch (sortBy.ToLower())
            {
                case "post_created":
                    query = ascending ? query.OrderBy(c => c.post_created) : query.OrderByDescending(c => c.post_created);
                    break;
                default:
                    throw new ArgumentException("Invalid sort field");
            }

            return query.ToList();
        }

        public List<Post> Filter(string filterBy, string value)
        {
            IQueryable<Post> query = db.posts;

            switch (filterBy.ToLower())
            {
                case "post_created":
                    if (DateTime.TryParse(value, out DateTime postCreated))
                    {
                        query = query.Where(c => DbFunctions.TruncateTime(c.post_created) == postCreated.Date);
                    }
                    break;
                case "post_location":
                    query = query.Where(c => c.post_location.Contains(value));
                    break;
                default:
                    throw new ArgumentException("Invalid filter field");
            }

            return query.ToList();
        }

        public List<Post> GetPaged(int pageNumber, int pageSize)
        {
            return db.posts
                     .OrderBy(c => c.post_id)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
        }
    }
}
