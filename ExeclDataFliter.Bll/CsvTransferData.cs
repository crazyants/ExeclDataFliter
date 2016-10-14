using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using System.Text;

namespace ExeclDataFliter.Bll
{
    public class CsvTransferData : ITransferData
    {
        private Encoding _encode;

        public CsvTransferData()
        {
            this._encode = Encoding.GetEncoding("GB2312");
        }

        public Stream GetStream(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            if (table != null && table.Columns.Count > 0 && table.Rows.Count > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        if (item[i] != null)
                        {
                            sb.Append("\"").Append(item[i].ToString().Replace("\"", "\"\"")).Append("\"");
                        }
                    }
                    sb.Append("\n");
                }
            }
            MemoryStream stream = new MemoryStream(_encode.GetBytes(sb.ToString()));
            return stream;
        }

        public DataTable GetData(Stream stream)
        {
            using (stream)
            {
                using (StreamReader input = new StreamReader(stream, _encode))
                {
                    using (CsvReader csv = new CsvReader(input, false))
                    {
                        DataTable dt = new DataTable();
                        int columnCount = csv.FieldCount;
                        int index = 0;
                        while (csv.ReadNextRecord())
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (index == 0)
                                {
                                    dt.Columns.Add(csv[i]);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(csv[i]))
                                    {
                                        dr[i] = csv[i];
                                    }
                                }
                            }

                            if (index > 0)
                            {
                                dt.Rows.Add(dr);
                            }
                            index++;
                        }
                        return dt;
                    }
                }
            }
        }
    }
}
