using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UowDesignPattern.EntityLayer.Concrete
{
    public partial class Customer2
    {

        public int Customer2ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Bank2> Bank2s { get; set; }
    }
}
