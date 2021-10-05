using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
namespace IOStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Stream stream = null;
            Byte[] buffer = null;
            //FileInfo 
            //if(!File.Exists(@"D:\Database\\testUTF8.txt"))
            //using (stream = new FileStream(@"D:\Database\testUTF8.txt", FileMode.Create, FileAccess.Write, FileShare.None)) 
            //{
            //    buffer = Encoding.GetEncoding(1251).GetBytes("Привіт, світ!");
            //    stream.Write(buffer, 0, buffer.Length);
            //    //stream.Flush();
            //}
            //using (stream = new FileStream(@"D:\Database\testUTF8.txt", FileMode.Open, FileAccess.Read, FileShare.None))
            //{

            //    buffer = new byte[stream.Length];
            //    stream.Read(buffer, 0, buffer.Length);
            //    Console.WriteLine(Encoding.GetEncoding(1251).GetString(buffer, 0, buffer.Length));
            //    //stream.Flush();
            //}


            //using (stream=new FileStream(@"D:\Database\testUTF8.txt", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    using (StreamReader reader=new StreamReader(stream))
            //    {
            //        Console.WriteLine(reader.ReadToEnd());
            //    }
            //}

            //using (stream = new FileStream(@"D:\Database\test.txt", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    StreamReader reader = new StreamReader(stream,Encoding.GetEncoding(1251) );

            //        //Console.WriteLine(reader.ReadToEnd());
            //        while(reader.Peek()>-1)
            //    {
            //        Console.Write((char)reader.Read());
            //    }
            //    Console.WriteLine();
            //    if(stream.CanSeek)
            //    {
            //        stream.Seek(0, SeekOrigin.Begin);
            //        buffer = new byte[stream.Length];
            //        stream.Read(buffer, 0, buffer.Length);
            //        Console.WriteLine(Encoding.GetEncoding(1251).GetString(buffer, 0, buffer.Length));
            //    }

            //}
            //int[] ar = { 1, 2, 3, 5, 7, 11, 13, 17 };
            //if(!File.Exists(@"D:\database\test.bin"))
            //using (stream=new FileStream(@"D:\database\test.bin", FileMode.Create, FileAccess.Write) )
            //{
            //    //buffer = new byte[sizeof(int)];
            //    foreach (int item in ar)
            //    {
            //        buffer = BitConverter.GetBytes(item);
            //        stream.Write(buffer, 0, buffer.Length);
            //    }
            //}

            //using (stream = new FileStream(@"D:\database\test.bin", FileMode.Open, FileAccess.Read))
            //{
            //    using (BinaryReader breader=new BinaryReader(stream))
            //    {
            //        //while(breader.PeekChar()>-1)
            //        while(breader.BaseStream.Position!=breader.BaseStream.Length)
            //        {
            //            Console.Write($"{breader.ReadInt32()}, ");
            //        }
            //        Console.WriteLine();
            //    }



            //    //    buffer = new byte[sizeof(int)];
            //    //while(stream.Length!=stream.Position)
            //    //{
            //    //    stream.Read(buffer, 0, sizeof(int));
            //    //    Console.WriteLine(BitConverter.ToInt32(buffer, 0));
            //    //}


            //}
            //stream.Dispose();

            //DataManager dataManager = new DataManager { Path = "books.bin" };
            //List<Book> books = new List<Book>() {
            //    new Book {Id=25, Author="A1", Name="N1", Genre=Genre.Progr, Price=150.50m, Available=true  },
            //    new Book {Id=26, Author="A2", Name="N2", Genre=Genre.CyberSecur, Price=250.50m, Available=false  }
            //};
            //dataManager.SaveData(books);
            //books = dataManager.LoadData() as List<Book>;
            //foreach (Book item in books)
            //{
            //    Console.WriteLine(item);
            //}

            //DirectoryInfo directory = new DirectoryInfo(@"D:\database");
            //DirectoryInfo directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
            //if(directory.Exists)
            //{
            //    SubDirList(directory);
            //}
            //XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            //xmlReaderSettings.IgnoreProcessingInstructions = true;
            //xmlReaderSettings.IgnoreComments = true;
            //xmlReaderSettings.IgnoreWhitespace = true;
            //using (XmlReader reader=XmlReader.Create(@"..\..\books.xml",xmlReaderSettings))
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"{reader.NodeType,-15}{reader.Name,-15}{reader.LocalName,-15}{reader.NamespaceURI,15}{reader.Value}");
            //    }
            //}

            IDataManager dataManager = new XmlDataManager { DataPath = @"..\..\books.xml", Namespace="www.bookshop.ua", XsdPath=@"..\..\books.xsd" };
            try
            {
                dataManager.ValidationData();
                BookCollection books = dataManager.LoadData();
                books.Add(new Book { Id = 4551, Name = "SQL", Author = "C Date", Genre = Genre.Progr, Available = false, Price = 510.99m });

                foreach (Book item in books)
                {
                    Console.WriteLine(item);
                }
                dataManager.SaveData(books);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public static void SubDirList(DirectoryInfo directory)
        {
            Console.WriteLine($"{directory.FullName}\t{directory.Name}");
            try
            {
                foreach (DirectoryInfo item in directory.GetDirectories())
                {
                    SubDirList(item);
                }
            }
            catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
