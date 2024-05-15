using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(config);
            var cnv = mapper.Map<Post>(u);
            DataFactory.PostData().Create(cnv);
        }
        public static PostDTO Get(int id)
        {

            var data = DataFactory.PostData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<PostDTO>(data);
        }
        public static List<PostDTO> Get()
        {
            var data = DataFactory.PostData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PostDTO>>(data);

        }

        public static PostCommentDTO GetPostComment(int id)
        {
            var data = DataFactory.PostData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostCommentDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<PostCommentDTO>(data);
        }
        public static bool Update(int id, PostDTO u)
        {

            var existingUser = DataFactory.PostData().Get(id);
            if (existingUser == null)
            {
                return false;
            }

            var config = new MapperConfiguration(cfg =>
            {
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

        public static List<PostDTO> Sort(string sortBy, bool ascending)
        {
            var data = DataFactory.PostData().Sort(sortBy, ascending);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PostDTO>>(data);
        }

        public static List<PostDTO> Filter(string filterBy, string value)
        {
            var data = DataFactory.PostData().Filter(filterBy, value);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PostDTO>>(data);
        }

        public static List<PostDTO> GetPaged(int pageNumber, int pageSize)
        {
            var data = DataFactory.PostData().GetPaged(pageNumber, pageSize);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PostDTO>>(data);
        }

    }
}
