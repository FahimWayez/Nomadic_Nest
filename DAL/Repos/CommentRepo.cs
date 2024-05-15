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
                default:
                    throw new ArgumentException("Invalid sort field");
            }

            return query.ToList();
        }

        public List<Comment> Filter(string filterBy, string value)
        {
            IQueryable<Comment> query = db.comments;

            switch (filterBy.ToLower())
            {
                case "postid":
                    if (int.TryParse(value, out int postId))
                    {
                        query = query.Where(c => c.PostId == postId);
                    }
                    break;
                case "comment_created":
                    if (DateTime.TryParse(value, out DateTime commentCreated))
                    {
                        query = query.Where(c => DbFunctions.TruncateTime(c.comment_created) == commentCreated.Date);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid filter field");
            }

            return query.ToList();
        }

        public List<Comment> GetPaged(int pageNumber, int pageSize)
        {
            return db.comments
                     .OrderBy(c => c.comment_Id)
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
