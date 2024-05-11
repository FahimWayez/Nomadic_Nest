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
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Order>(u);
            DataFactory.OrderData().Create(cnv);
        }
        public static OrderDTO Get(int id)
        {

            var data = DataFactory.OrderData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderDTO>(data);
        }
        public static List<OrderDTO> Get()
        {
            var data = DataFactory.OrderData().Get();
            var config = new MapperConfiguration(cfg => {
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

            var config = new MapperConfiguration(cfg => {
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
    }
}
