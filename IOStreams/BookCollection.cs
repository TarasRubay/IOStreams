using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOStreams
{
  public  class BookCollection : IEnumerable<Book>
    {
        public List<Book> Books { get; private set; } = new List<Book>();

        public IEnumerator<Book> GetEnumerator()
        {
            return Books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Book book)
        {
            Books.Add(book);
        }

        public void Remove(Book book)
        {
            Books.Remove(book);
        }
    }
}
