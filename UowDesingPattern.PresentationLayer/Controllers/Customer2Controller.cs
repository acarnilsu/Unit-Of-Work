using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UowDesignPattern.DataAccessLayer.Concrete;
using UowDesignPattern.DataAccessLayer.UnitOfWork.Abstract;
using UowDesignPattern.EntityLayer.Concrete;
using UowDesignPattern.PresentationLayer.Models;

namespace UowDesignPattern.PresentationLayer.Controllers
{
    public class Customer2Controller : Controller
    {
        private readonly Context _context;
        private readonly IUowDal _uowDal;

        public Customer2Controller(Context context, IUowDal uowDal)
        {
            _context = context;
            _uowDal = uowDal;
        }

        public IActionResult Index()
        {
            var values=_context.Customer2s.ToList();
            foreach (var item in values)
            {
                item.Count=_context.Bank2s.Where(x=>x.Customer2ID==item.Customer2ID).Count();   
            }
            return View(values);
        }


        public IActionResult Detail(int id)
        {
            var values=_context.Bank2s.Where(x=>x.Customer2ID==id).Include(x=>x.Customer2).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMoney(string Iban)
        {
            TempData["iban"]=Iban;
            return View();
        }

        [HttpPost]
        public IActionResult SendMoney(ProcessVM2 p)
        {
            p.SenderID = _context.Bank2s.Where(x => x.AccountNumber == TempData["iban"].ToString()).Select(x => x.Customer2ID).FirstOrDefault();

            var Sender = _context.Bank2s.Where(x => x.AccountNumber == TempData["iban"].ToString()).FirstOrDefault();
            
            var Receiver = _context.Bank2s.Where(x => x.AccountNumber == p.iban.ToString()).FirstOrDefault();



            Sender.Balance -= p.Amount;

            Receiver.Balance += p.Amount;


            AccountTransaction TSender = new();
            AccountTransaction TReceiver = new();

     

            TSender.Customer2ID = p.SenderID;
            TSender.Amount = p.Amount.ToString();

            TSender.ReciverName = _context.Customer2s.Where(x => x.Customer2ID == 
            (_context.Bank2s.Where(x => x.AccountNumber == p.iban.ToString()).Select(x => x.Customer2ID).First()))
                .Select(x => x.Name).First(); 

            TSender.ReciverIban = p.iban;
            TSender.SendIban = TempData["iban"].ToString();
            TSender.SendName = _context.Customer2s.Where(x => x.Customer2ID == p.SenderID).Select(x => x.Name).First();

            TReceiver.Customer2ID = _context.Bank2s.Where(x => x.AccountNumber == p.iban.ToString()).Select(x => x.Customer2ID).First();
            TReceiver.Amount = TSender.Amount;
            TReceiver.ReciverName = TSender.ReciverName;
            TReceiver.ReciverIban = p.iban;
            TReceiver.SendIban = TSender.SendIban;
            TReceiver.SendName = TSender.SendName;


            _context.Entry(TSender).State = EntityState.Added;
            _context.Entry(TReceiver).State = EntityState.Added;

            _uowDal.Save();

            return RedirectToAction("Index");
        }


        public IActionResult Transaction(int id, string iban)
        {

            var result = _context.accountTransactions.Where(x => x.Customer2ID == id && x.SendIban == iban).ToList();


            return View(result);
        }

    }
}
