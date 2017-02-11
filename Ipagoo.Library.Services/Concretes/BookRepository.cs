using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ipagoo.Library.Services.Interfaces;
using Ipagoo.Library.Domain.Models;
using System.Data.Entity;
using Ipagoo.Library.DataAccess;
using Ipagoo.Library.Services.IMarkers;

namespace Ipagoo.Library.Services.Concretes
{
    public class BookRepository : IRepository<Book>,IBookMarker
    {
         public IpagooDbContext Context
         { 

            get
            {
                return _context;
            }

            set
            {
                _context = value;
            }
        }


        DataAccess.IpagooDbContext _context;

        public IEnumerable<Book> GetAll()
        {
            var result = _context.Books.ToArray();
            if (result.Any())
            {
                return result.ToList();
            }
            else return new List<Book>();
        }

        public Book GetById(int Id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == Id);
        }

        public bool Save(Book objToSave)
        {
            try
            {
                _context.Books.Add(objToSave);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book objToUpdate)
        {
            try
            {
                var obj = _context.Books.SingleOrDefault(p => p.Id == objToUpdate.Id);

                if(obj != null)
                {
                    obj.Isbn = objToUpdate.Isbn;
                    obj.Title = objToUpdate.Title;
                    obj.Author = objToUpdate.Author;
                    obj.Description = objToUpdate.Description;
                    obj.Genre = objToUpdate.Genre;
                    obj.IsOnLoan = objToUpdate.IsOnLoan;
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public IEnumerable<Book> SearchBy(Book bookQuery)
        {
            var result = _context.Books.Where(p => p.Isbn == bookQuery.Isbn || p.Title == bookQuery.Title || p.Author == bookQuery.Author || p.Genre == bookQuery.Genre);
            if (result.Any())
            {
                return result.ToList();
            }
            else return new List<Book>();
        }


    }
}
