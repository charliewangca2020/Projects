using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformService
{
    public class TargetData
    {
        public class ColumnIndex
        {
            public const int AccountCode = 0;
            public const int Name = 1;
            public const int Type = 2;
            public const int OpenDate = 3;
            public const int Currency = 4;
        };

        public List<String[]> Rows { get; private set; }
        public String[]  ColumnHeaders { get; private set; }
        public int[] OptionColumns { get; private set; }

        public const string DATEFORMAT = "yyyy-MM-dd";

        public const String CsvDelimit = ",";

        public TargetData()
        {
            Rows = new List<string[]>();
            ColumnHeaders = new String[]
            {
                "AccountCode",
                "Name",
                "Type",
                "Open Date",
                "Currency"
            };

            OptionColumns = new int[]{ ColumnIndex.OpenDate };
        }

        public void AddRow(String[] row)
        {
            //Check valid
            for (int i = 0; i < row.Length; i++)
            {
                if(string.IsNullOrEmpty(row[i]))
                {
                    if(!OptionColumns.Contains(i))
                    {
                        throw new ArgumentNullException(ColumnHeaders[i]);
                    }
                }
            }

            Rows.Add(row);
        }

        public String ConvertRowToCsc(String[] row)
        {
            return row.Aggregate((item, next) => item + CsvDelimit + next);
        }

        public String GetHeaderString()
        {
            return ColumnHeaders.Aggregate((item, next) => item + CsvDelimit + next);
        }

        public static String[] NewRow()
        {
            return new String[ColumnIndex.Currency + 1];
        }

    }
}
