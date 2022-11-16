using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UowDesignPattern.EntityLayer.Concrete
{
    public class AccountTransaction
    {
        public int Id { get; set; }

        public int Customer2ID { get; set; }

        public Customer2 Customer2 { get; set; }

        public string ReciverIban { get; set; }

        public string ReciverName { get; set; }

        public string SendName { get; set; }

        public string SendIban { get; set; }

        public string Amount { get; set; }

    }
}
