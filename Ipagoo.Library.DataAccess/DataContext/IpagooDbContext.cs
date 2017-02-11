using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ipagoo.Library.Domain.Models;


namespace Ipagoo.Library.DataAccess
{
    public class IpagooDbContext: System.Data.Entity.DbContext
    {
        public IpagooDbContext()
        {
            Database.SetInitializer(new IpagooInitializer());
        }
        public DbSet<Domain.Models.Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<LoanComment> LoanComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanComment>()
             .HasRequired(p => p.Book)
             .WithMany()
             .HasForeignKey(p => p.BookId)
             .WillCascadeOnDelete(false);



            modelBuilder.Entity<LoanComment>()
             .HasRequired(p => p.Loan)
             .WithMany()
             .HasForeignKey(p => p.LoanId)
             .WillCascadeOnDelete(false);
        }

    }
}

