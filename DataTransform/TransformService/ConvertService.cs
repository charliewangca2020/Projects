using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformService
{
    public class ConvertService
    {
        public void Convert(String inputFileType, List<String> rows, String outputFileName)
        {
            var srcAccount = getSourceAccountObject(inputFileType);
            srcAccount.OutputCSVFileName = outputFileName;
            srcAccount.TransformData(rows);
        }

        /// <summary>
        /// Get the SourceAccount instance by the inputFileType
        /// </summary>
        /// <param name="inputFileType"></param>
        /// <returns></returns>
        private SourceAccount getSourceAccountObject(String inputFileType)
        {
            //In real project, we can use Reflection to get the instance
            switch (inputFileType)
            {
                case "SourceAccount1":
                    return new SourceAccount1();
                case "SourceAccount2":
                    return new SourceAccount2();
                default:
                    return null;
            }
        }
    }
}
