using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo2<Token, string, Token>
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            return db.tokens.ToList();
            //throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return db.tokens.FirstOrDefault(t => t.TokenKey.Equals(id));
        }

        public Token Insert(Token obj)
        {
            db.tokens.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.TokenKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return token;
            return null;
        }
    }
}
