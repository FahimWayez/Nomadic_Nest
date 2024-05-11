using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService
    {
        private static readonly IMapper _mapper;

        static ServiceService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceDTO, Service>();
                cfg.CreateMap<Service, ServiceDTO>();
            });

            _mapper = new Mapper(config);
        }
        public static void Create(ServiceDTO u)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ServiceDTO, Service>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Service>(u);
            DataFactory.ServiceData().Create(cnv);
        }
        public static ServiceDTO Get(int id)
        {

            var data = DataFactory.ServiceData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ServiceDTO>(data);
        }
        public static List<ServiceDTO> Get()
        {
            var data = DataFactory.ServiceData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<ServiceDTO>>(data);

        }
        public static bool Update(int id, ServiceDTO u)
        {

            var existingUser = DataFactory.ServiceData().Get(id);
            if (existingUser == null)
            {
                return false;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ServiceDTO, Service>();
            });
            var mapper = new Mapper(config);

            var updatedService = mapper.Map<Service>(u);

            return DataFactory.ServiceData().Update(id, updatedService);
        }



        public static bool Delete(int id)
        {
            return DataFactory.ServiceData().Delete(id);
        }
    }
}
