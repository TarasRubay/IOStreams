using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace IOStreams
{
    class XmlDataManager : IDataManager
    {
        public string DataPath { get; set; } = "";
        public string Namespace { get; set; } = "";

        public string XsdPath { get; set; } = "";
        public BookCollection LoadData()
        {
            BookCollection books = new BookCollection();
            Book book;
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreProcessingInstructions = true;
            xmlReaderSettings.IgnoreComments = true;
            xmlReaderSettings.IgnoreWhitespace = true;

            using (XmlReader reader = XmlReader.Create(DataPath, xmlReaderSettings))
            {
                reader.MoveToContent();
                while (reader.Read() && reader.NodeType == XmlNodeType.Element && reader.Name == "Book")
                {
                    book = new Book();
                    book.Available = bool.Parse(reader["Available"]);
                    reader.Read();// read Id
                    book.Id = reader.ReadElementContentAsInt("Id", Namespace);
                    book.Name = reader.ReadElementContentAsString("Name", Namespace);
                    book.Author = reader.ReadElementContentAsString("Author", Namespace);
                    book.Price = reader.ReadElementContentAsDecimal("Price", Namespace);
                    //book.Available = reader.ReadElementContentAsBoolean("Available", "");
                    book.Genre = (Genre)Enum.Parse(typeof(Genre), reader.ReadElementContentAsString("Genre", Namespace));
                    //Console.WriteLine($"{reader.NodeType,-15}{reader.Name,-15}{reader.Value}");
                    books.Add(book);
                }
            }

            return books;
        }

        public void SaveData(BookCollection books)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer=XmlWriter.Create(DataPath,xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Books", Namespace);
                foreach (Book item in books)
                {
                    writer.WriteStartElement("Book", Namespace);
                    //writer.WriteAttributeString("Available", item.Available.ToString());
                    writer.WriteStartAttribute("Available");
                    writer.WriteValue(item.Available);
                    writer.WriteEndAttribute();

                    writer.WriteStartElement("Id", Namespace);
                    writer.WriteValue(item.Id);
                    writer.WriteEndElement();


                    //writer.WriteStartElement("Name", Namespace);
                    // writer.WriteValue(item.Name);
                    // writer.WriteEndElement(); 
                    writer.WriteElementString("Name", Namespace, item.Name);

                    writer.WriteElementString("Author", Namespace, item.Author);

                    writer.WriteStartElement("Price", Namespace);
                    writer.WriteValue(item.Price);
                    writer.WriteEndElement();

                    writer.WriteElementString("Genre", Namespace, item.Genre.ToString());


                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void ValidationData()
        {
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreProcessingInstructions = true;
            xmlReaderSettings.IgnoreComments = true;
            xmlReaderSettings.IgnoreWhitespace = true;
            xmlReaderSettings.ValidationType = ValidationType.Schema;//xsd
            xmlReaderSettings.Schemas.Add(Namespace, XsdPath);
            xmlReaderSettings.ValidationEventHandler += XmlReaderSettings_ValidationEventHandler;


            using (XmlReader reader = XmlReader.Create(DataPath, xmlReaderSettings))
            {
                while (reader.Read()) { };
            }
        }

        private void XmlReaderSettings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            throw e.Exception;
        }
    }
}
