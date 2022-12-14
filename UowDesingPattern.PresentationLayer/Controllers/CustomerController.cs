using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UowDesignPattern.BusinessLayer.Abstract;
using UowDesignPattern.DataAccessLayer.Concrete;
using UowDesignPattern.EntityLayer.Concrete;
using UowDesignPattern.PresentationLayer.Models;

namespace UowDesignPattern.PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        private readonly Context context;

        public CustomerController(ICustomerService customerService, Context context)
        {
            _customerService = customerService;
            this.context = context;
        }

        [HttpGet]
        public IActionResult SendMoney()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMoney(ProcessViewModel p)
        {

            decimal senderCurrentBalance = context.Customers.Where(x => x.CustomerID == p.SenderID).Select(y => y.Balance).FirstOrDefault();

            decimal receiverCurrentBalance = context.Customers.Where(x => x.CustomerID == p.ReceiverID).Select(y => y.Balance).FirstOrDefault();

            p.SenderNewBalance = senderCurrentBalance - p.Amount;
            p.ReceiverNewBalance = receiverCurrentBalance + p.Amount;

            // Customer t = new Customer();

            var value1 = new Customer()
            {
                CustomerID = p.SenderID,
                Balance = p.SenderNewBalance
            };

            var value2 = new Customer()
            {
                CustomerID = p.ReceiverID,
                Balance = p.ReceiverNewBalance
            };

            //  _customerService.TUpdate(t);

            return View();
        }
    }
}
