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
    public class PostService
    {
        private static readonly IMapper _mapper;

        static PostService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<Post, PostDTO>();
            });

            _mapper = new Mapper(config);
        }
        public static void Create(PostDTO u)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Post>(u);
            DataFactory.PostData().Create(cnv);
        }
        public static PostDTO Get(int id)
        {

            var data = DataFactory.PostData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<PostDTO>(data);
        }
        public static List<PostDTO> Get()
        {
            var data = DataFactory.PostData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PostDTO>>(data);

        }
        public static bool Update(int id, PostDTO u)
        {

            var existingUser = DataFactory.PostData().Get(id);
            if (existingUser == null)
            {
                return false;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(config);

            var updatedPost = mapper.Map<Post>(u);

            return DataFactory.PostData().Update(id, updatedPost);
        }



        public static bool Delete(int id)
        {
            return DataFactory.PostData().Delete(id);
        }

    }
}