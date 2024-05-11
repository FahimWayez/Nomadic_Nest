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
    internal class CommentRepo : Repo , IRepo<Comment, int , bool>
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
    }
}
