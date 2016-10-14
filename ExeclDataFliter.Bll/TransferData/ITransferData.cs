using System.Data;
using System.IO;

namespace ExeclDataFliter.Bll
{
    public interface ITransferData
    {
        Stream GetStream(DataTable table);


        DataTable GetData(Stream stream);
    }
}
