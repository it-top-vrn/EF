using System;
using System.Collections.Generic;
using System.Linq;
using EF.Model;

namespace EF.Lib.CRUD
{
    public class AuthorsCrud : ICrud<Author>, IDisposable
    {
        private readonly BookStore _db;

        public AuthorsCrud()
        {
            _db = BookStore.Init();
        }
        
        public void Add(Author obj)
        {
            _db.TableAuthors.Add(obj);
            _db.SaveChanges();
        }

        public void Update(Author obj)
        {
            _db.TableAuthors.Update(obj);
            _db.SaveChanges();
        }

        public void Delete(Author obj) { }

        public List<Author> ReadAll()
        {
            return _db.TableAuthors.ToList();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}