using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IOStreams
{
 public   class BinaryDataManager: IDataManager
    {
        public string DataPath { get; set; }

        public void SaveData(BookCollection coll)
        {
            using (Stream stream=new FileStream(DataPath,FileMode.Create, FileAccess.Write))
            using (BinaryWriter binary =new BinaryWriter(stream))
                foreach (Book item in coll)
                {
                    binary.Write(item);
                }
        }

        public BookCollection LoadData()
        {
            BookCollection coll = new BookCollection();
         
            using (Stream stream = new FileStream(DataPath, FileMode.Open, FileAccess.Read))
            using (BinaryReader binary = new BinaryReader(stream))
            {
                while(binary.BaseStream.Position!=binary.BaseStream.Length)
                {
                    coll.Add(binary.ReadBook());
                }
            }
                return coll;

                
        }

        void IDataManager.ValidationData()
        {
            throw new NotImplementedException();
        }
    }
}
