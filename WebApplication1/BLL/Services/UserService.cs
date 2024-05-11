using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private static readonly IMapper _mapper;

        static UserService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });

            _mapper = new Mapper(config);
        }
        public static void Create(UserDTO u)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<User>(u);
            DataFactory.UserData().Create(cnv);
        }
        public static UserDTO Get(int id)
        {

            var data = DataFactory.UserData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }
        public static List<UserDTO> Get()
        {
            // Get the data that needs to be mapped
            var userData = DataFactory.UserData().Get(); // Renamed variable to avoid conflict

            // Initialize the mapper configuration only once, ideally in the startup of your application.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            // Create the mapper instance using the configuration
            var mapper = config.CreateMapper();

            // Perform the mapping
            return mapper.Map<List<UserDTO>>(userData); // Use the renamed variable here

        }
        public static bool Update(int id,UserDTO u)
        {
            
            var existingUser = DataFactory.UserData().Get(id);
            if (existingUser == null)
            {
                return false; 
            }
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            
            var updatedUser = mapper.Map<User>(u);
            
            return DataFactory.UserData().Update(id,updatedUser);
        }



        public static bool Delete(int id)
        {
            return DataFactory.UserData().Delete(id);
        }


    }
}
