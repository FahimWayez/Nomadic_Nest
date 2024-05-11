﻿using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth<bool>, IUser<User, string, string>
    {
        public bool Authenticate(string unsername, string password)
        {
            var data = db.users.FirstOrDefault(u => u.user_name.Equals(unsername) && u.user_password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public string ChangePassword(int id, string exPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Create(User obj)
        {
            db.users.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.users.Remove(exobj);
            return db.SaveChanges() > 0;
            //throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return db.users.Find(id);
            //throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return db.users.ToList();
            //throw new NotImplementedException();
        }

        public bool Update(int id, User updatedUser)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.user_name = updatedUser.user_name;
            existingUser.user_state_name = updatedUser.user_state_name;
            existingUser.user_country = updatedUser.user_country;
            //existingUser.user_password = updatedUser.user_password;
            existingUser.user_phone_number = updatedUser.user_phone_number;
            existingUser.user_city = updatedUser.user_city;
            existingUser.user_email= updatedUser.user_email;
            existingUser.user_gender= updatedUser.user_gender;
            existingUser.role= updatedUser.role;

            db.Entry(existingUser).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }



        //public string ChangePassword(int id, string exPassword, string newPassword)
        //{
        //    //var existingUser = Get(id);
        //    //if (existingUser == null)
        //    //{
        //    //    return false;
        //    //}

        //    //existingUser.user_password = newPassword.user_password;

        //    //db.Entry(existingUser).State = EntityState.Modified;
        //    //return db.SaveChanges() > 0;
        //}
    }
}
