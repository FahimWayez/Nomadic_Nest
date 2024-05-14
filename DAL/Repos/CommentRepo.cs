using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, int, bool>
    {
        public void Create(Comment obj)
        {
            db.comments.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.comments.Remove(exobj);
            return db.SaveChanges() > 0;
            //throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            return db.comments.Find(id);
            //throw new NotImplementedException();
        }

        public List<Comment> Get()
        {
            return db.comments.ToList();
            //throw new NotImplementedException();
        }

        public bool Update(int id, Comment updatedUser)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.comment = updatedUser.comment;


            db.Entry(existingUser).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public List<Comment> Search(string term)
        {
            return db.comments.Where(c => c.comment.Contains(term)).ToList();
        }

        public List<Comment> Sort(string sortBy, bool ascending)
        {
            IQueryable<Comment> query = db.comments;

            switch (sortBy.ToLower())
            {
                case "comment_created":
                    query = ascending ? query.OrderBy(c => c.comment_created) : query.OrderByDescending(c => c.comment_created);
                    break;
                case "comment_id":
                    query = ascending ? query.OrderBy(c => c.comment_Id) : query.OrderByDescending(c => c.comment_Id);
                    break;
                case "comment":
                    query = ascending ? query.OrderBy(c => c.comment) : query.OrderByDescending(c => c.comment);
                    break;
                default:
                    throw new ArgumentException("Invalid sort field");
            }

            return query.ToList();
        }
    }
}
