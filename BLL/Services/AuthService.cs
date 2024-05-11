using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;
using AutoMapper;
using BLL.DTOs;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass) {
            var res = DataFactory.AuthData().Authenticate(uname,pass);

            if (res) {
                var token = new Token();
                token.UserId = uname;
                token.TokenCreate = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                var ret = DataFactory.TokenData().Insert(token);
                if (ret != null) {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });

                    var mapper = new Mapper(cfg);

                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;
        }

        public static bool isTokenValid(string tokenKey) 
        {
            var extokenkey = DataFactory.TokenData().Get(tokenKey);

            if (extokenkey != null && extokenkey.TokenDestroy == null) { 
                return true;
            }
            return false;
        
        }

        public static bool Logout(string tokenKey) 
        {
            var extokenkey = DataFactory.TokenData().Get(tokenKey);

            extokenkey.TokenDestroy = DateTime.Now;
            if (DataFactory.TokenData().Update(extokenkey) != null)
            {
                return true;
            }
            return false;        
        } 

        
    }
    
}
