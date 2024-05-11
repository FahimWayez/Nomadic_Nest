using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {
        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Post, int, bool> PostData()
        {
            return new PostRepo();
        }

        public static IRepo<Service, int, bool> ServiceData()
        {
            return new ServiceRepo();
        }

        public static IRepo<Comment, int, bool> CommentData()
        {
            return new CommentRepo();
        }

        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }
    }
}
