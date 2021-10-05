using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOStreams
{

    public enum Genre {Progr, Design, CyberSecur }
 public  class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public Genre Genre { get; set; }

        public override string ToString() => $"{Id,-5}{Genre,-15}{Name,-25}{Author,-15}{Price,15}{Available,8}";

}
}
