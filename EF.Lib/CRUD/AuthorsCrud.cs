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

        private void Exec(Author obj, Action<Author> exec)
        {
            exec.Invoke(obj);
            _db.SaveChanges();
        }
        
        public void Add(Author obj)
        {
            Exec(obj, author => _db.TableAuthors.Add(author));
        }

        public void Update(Author obj)
        {
            Exec(obj, author => _db.TableAuthors.Update(author));
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