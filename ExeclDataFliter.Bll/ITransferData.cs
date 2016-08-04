using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeclDataFliter.Bll
{
    public interface ITransferData
    {
        Stream GetStream(DataTable table);


        DataTable GetData(Stream stream);
    }
}
