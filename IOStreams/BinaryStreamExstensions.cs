using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IOStreams
{
public  static  class BinaryStreamExtensions
    {
        public static void Write(this BinaryWriter writer, Book book)
        {
            writer.Write(book.Id);
            writer.Write(book.Name);
            writer.Write(book.Author);
            writer.Write(book.Price);
            writer.Write(book.Genre.ToString());
            writer.Write(book.Available);
        }

        public static Book ReadBook(this BinaryReader reader)
        {
            Book book = new Book();
            book.Id = reader.ReadInt32();
            book.Name = reader.ReadString();
            book.Author = reader.ReadString();
            book.Price = reader.ReadDecimal();
            book.Genre =(Genre)Enum.Parse(typeof(Genre), reader.ReadString());
            book.Available = reader.ReadBoolean();
            return book;
        }
    }
}
