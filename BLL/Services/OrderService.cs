using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class OrderService
    {
        private static readonly IMapper _mapper;

        static OrderService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });

            _mapper = new Mapper(config);
        }
        public static void Create(OrderDTO u)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Order>(u);
            DataFactory.OrderData().Create(cnv);
        }
        public static OrderDTO Get(int id)
        {

            var data = DataFactory.OrderData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderDTO>(data);
        }
        public static List<OrderDTO> Get()
        {
            var data = DataFactory.OrderData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);

        }
        public static bool Update(int id, OrderDTO u)
        {

            var existingUser = DataFactory.OrderData().Get(id);
            if (existingUser == null)
            {
                return false;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(config);

            var updatedOrder = mapper.Map<Order>(u);

            return DataFactory.OrderData().Update(id, updatedOrder);
        }


        public static bool Delete(int id)
        {
            return DataFactory.OrderData().Delete(id);
        }

        public static List<OrderDTO> Sort(string sortBy, bool ascending)
        {
            var data = DataFactory.OrderData().Sort(sortBy, ascending);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }

        public static List<OrderDTO> Filter(string filterBy, string value)
        {
            var data = DataFactory.OrderData().Filter(filterBy, value);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }

        public static List<OrderDTO> GetPaged(int pageNumber, int pageSize)
        {
            var data = DataFactory.OrderData().GetPaged(pageNumber, pageSize);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }
    }
}
