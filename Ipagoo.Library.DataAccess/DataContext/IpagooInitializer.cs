using Ipagoo.Library.Domain.Models;
using System.Data.Entity;

namespace Ipagoo.Library.DataAccess
{
    public class IpagooInitializer : DropCreateDatabaseAlways<IpagooDbContext>
    {
        protected override void Seed(IpagooDbContext context)
        {

            var library = new Domain.Models.Library();

            var book = new Book
            {
                Isbn = "29834949040540505",
                Title = "Ipagoo Mvc App development",
                Author = "Martin Alex Okello",
                IsOnLoan = false,
                Genre = "Computer Science",
                Description ="The Medallion Aka Delivers",
                Library = library
            };

            var book2 = new Book
            {
                Isbn = "298349490405398505",
                Title = "The Giants Of Brazil",
                Author = "Abdi Pele",
                IsOnLoan = true,
                Genre = "Sport",
                Description = "The Medallion Aka Caught out of time",
                Library = library
            };

            var book3 = new Book
            {
                Isbn = "465786790405398505",
                Title = "The Mystery Of Medallion",
                Author = "Robert Ludlum",
                IsOnLoan = false,
                Genre = "Espionage",
                Description = "The Medallion Aka DeliversIs Winning - has won",
                Library = library
            };

            context.Libraries.Add(library);

            context.Books.Add(book);
            context.Books.Add(book2);
            context.Books.Add(book3);

            context.SaveChanges();
        }
    }
}