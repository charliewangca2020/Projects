using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransformService;

namespace TestTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> lines = new List<string>();
            lines.Add("Identifier,Name,Type,Opened,Currency");
            lines.Add("123|AbcCode,My Account,2,01-01-2018,CD");

            ConvertService service = new ConvertService();
            String strPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Test1.csv");
            service.Convert("SourceAccount1", lines, strPath);
        }
    }
}
