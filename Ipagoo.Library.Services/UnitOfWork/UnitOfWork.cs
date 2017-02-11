using Ipagoo.Library;
using Ipagoo.Library.Domain.Models;
using Ipagoo.Library.Services.Interfaces;
using System;

namespace Ipagoo.Library.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccess.IpagooDbContext _dbContext;

        private IRepository<Book> _bookRepository;
        private IRepository<Loan> _bookLoanRepository;
        private IRepository<Domain.Models.Library> _libraryRepository;
        private IRepository<User> _userRepository;
        private IRepository<LoanComment> _loanCommentRepository;
        
        public UnitOfWork(IRepository<Book> bookRepository, IRepository<Loan> bookLoanRepository, IRepository<Domain.Models.Library> libraryRepository,
                IRepository<LoanComment> loanCommentRepository, IRepository<User> userRepository)
        {
            _dbContext = new DataAccess.IpagooDbContext();
            bookRepository.Context = _dbContext;
            libraryRepository.Context = _dbContext;
            loanCommentRepository.Context = _dbContext;
            bookLoanRepository.Context = _dbContext;
            userRepository.Context = _dbContext;

            this._bookRepository = bookRepository;
            this._bookLoanRepository = bookLoanRepository;
            this._libraryRepository = libraryRepository;
            this._loanCommentRepository = loanCommentRepository;
            this._userRepository = userRepository;
        }


        public IRepository<Book> BookRepository
        {
            get
            {
                return _bookRepository;
            }
        }
        public IRepository<Loan> LoanRepository
        {
            get
            {
                return _bookLoanRepository;
            }
        }
        public IRepository<Domain.Models.Library> LibraryRepository
        {
            get
            {
                return _libraryRepository;
            }
        }
        public IRepository<User> UserRepository
        {
            get
            {
                return _userRepository;
            }
        }
        public IRepository<LoanComment> LoanCommentkRepository
        {
            get
            {
                return _loanCommentRepository;
            }
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
