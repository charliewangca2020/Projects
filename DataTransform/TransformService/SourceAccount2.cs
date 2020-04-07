using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformService
{
    public class SourceAccount2 : SourceAccount
    {
        public override void DoTransform(string[] row, String[] newRow)
        {
            newRow[TargetData.ColumnIndex.Name] = row[1];
            newRow[TargetData.ColumnIndex.Type] = row[2];
            newRow[TargetData.ColumnIndex.Currency] = GetCurrencyString(row[4]);
            
        }

        public String GetCurrencyString(String cur)
        {
            Dictionary<String, String> curDict = new Dictionary<string, string>()
                {
                    {"C", "CAD" },
                    {"U", "USD" }
                };

            return curDict[cur];
        }
    }
}
