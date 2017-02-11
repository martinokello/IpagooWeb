using Ipagoo.Library.Domain.Models;
using Ipagoo.Library.Services.Concretes;
using Ipagoo.Library.Services.Interfaces;
using Ipagoo.Library.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ipagoo.Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController() { }
        public HomeController(IRepository<Book> bookRepository, IRepository<Loan> bookLoanRepository, IRepository<Domain.Models.Library> libraryRepository,
                IRepository<LoanComment> loanCommentRepository, IRepository<User> userRepository)
        {
            _unitOfWork = new UnitOfWork(bookRepository, bookLoanRepository, libraryRepository, loanCommentRepository, userRepository);            
        }
        public ActionResult Index() {

            var model = _unitOfWork.BookRepository.GetAll();
            return View(model);
        }
        [HttpPost]
       
        public ActionResult SearchBooks(Book bookQuery)
        {
            var booksResult = (_unitOfWork.BookRepository as BookRepository).SearchBy(bookQuery);
            //Could send json but for quickness sending Index Vies
            //return Json(booksResult, JsonRequestBehavior.AllowGet);
            return View("Index", booksResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}