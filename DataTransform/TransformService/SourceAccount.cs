using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformService
{
    public abstract class SourceAccount
    {
        public bool HasHeader { get; protected set; }
        public char[] ColumnDelimiter { get; private set; }
        public String OutputCSVFileName { get; set; }

        protected TargetData _targetData;

        public SourceAccount()
        {
            HasHeader = false;
            ColumnDelimiter = new char[]{','};
            _targetData = new TargetData();
        }

        public void TransformData(List<String> lines)
        {
            PreTransform(lines);

            int firstLine = HasHeader ? 1 : 0;
            for (int i = firstLine; i < lines.Count; i++)
            {
                var row = lines[i].Split(ColumnDelimiter);
                try
                {
                    var newRow = TargetData.NewRow();
                    DoTransform(row, newRow);
                    _targetData.AddRow(newRow);

                }
                catch (Exception ex)
                {
                    //log out error message etc...
                }
            }

            PostTransform(lines);

            ExportCSV();
        }

        public virtual void DoTransform(String[] row, String[] newRow)
        {
        }

        public virtual void PreTransform(List<String> lines)
        {
        }

        public virtual void PostTransform(List<String> lines)
        {
        }

        public virtual void ExportCSV()
        {
            //Export CSV file here
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(OutputCSVFileName))
            {
                //export header
                sw.WriteLine(_targetData.GetHeaderString());
                
                foreach (var row in _targetData.Rows)
                {
                    sw.WriteLine(_targetData.ConvertRowToCsc(row));
                }
            }
        }

        public virtual void ExportCSVRow(String[] row)
        {
            //export row to csv file
        }
    }
}
