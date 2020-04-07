using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformService
{
    public class SourceAccount1 : SourceAccount
    {
        public SourceAccount1()
        {
        }

        public override void DoTransform(string[] row, String[] newRow)
        {
            newRow[TargetData.ColumnIndex.AccountCode] = row[0].Substring(row[0].IndexOf('|') + 1);
            newRow[TargetData.ColumnIndex.Name] = row[1];
            newRow[TargetData.ColumnIndex.Type] = GetAccountTypeString(Convert.ToInt32(row[2]));
            newRow[TargetData.ColumnIndex.OpenDate] = DateTime.ParseExact(row[3], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                                                          .ToString(TargetData.DATEFORMAT);
            newRow[TargetData.ColumnIndex.Currency] = GetCurrencyString(row[4]);

        }

        public String GetAccountTypeString(int accountTypeCode)
        {
            switch (accountTypeCode)
            {
                case 1:
                    return "Trading";
                case 2:
                    return "RRSP";
                case 3:
                    return "RESP";
                case 4:
                    return "Fund";
                default:
                    return "Trading";
            }
        }

        public String GetCurrencyString(String cur)
        {
            Dictionary<String, String> curDict = new Dictionary<string, string>()
                {
                    {"CD", "CAD" },
                    {"US", "USD" }
                };

            return curDict[cur];
        }
    }
}
