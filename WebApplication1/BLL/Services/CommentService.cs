﻿using AutoMapper;
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
    public class CommentService
    {
        private static readonly IMapper _mapper;

        static CommentService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<Comment, CommentDTO>();
            });

            _mapper = new Mapper(config);
        }
        public static void Create(CommentDTO u)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Comment>(u);
            DataFactory.CommentData().Create(cnv);
        }
        public static CommentDTO Get(int id)
        {

            var data = DataFactory.CommentData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CommentDTO>(data);
        }
        public static List<CommentDTO> Get()
        {
            var data = DataFactory.CommentData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CommentDTO>>(data);

        }
        public static bool Update(int id, CommentDTO u)
        {

            var existingUser = DataFactory.CommentData().Get(id);
            if (existingUser == null)
            {
                return false;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(config);

            var updatedComment = mapper.Map<Comment>(u);

            return DataFactory.CommentData().Update(id, updatedComment);
        }



        public static bool Delete(int id)
        {
            return DataFactory.CommentData().Delete(id);
        }

    }
}
