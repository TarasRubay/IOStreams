using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOStreams
{
   public interface IDataManager
    {
        string DataPath { get; set; }
        BookCollection LoadData();
        void SaveData(BookCollection books);

        void ValidationData();
    }
}
