using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    internal class ExcelUtils
    {
        public static List<ExcelData>ReadExcelData(string excelFilePath)
        {
            List<ExcelData> excelDataList = new();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using(var stream=File.Open(excelFilePath,FileMode.Open,FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["GS"];
                    foreach(DataRow row in dataTable.Rows)
                    {
                        ExcelData excelData = new()
                        {
                            SearchText = row["searchtext"].ToString(),
                        };
                        excelDataList.Add(excelData);
                    }
                }
            }
            return excelDataList;
        }
    }
}
