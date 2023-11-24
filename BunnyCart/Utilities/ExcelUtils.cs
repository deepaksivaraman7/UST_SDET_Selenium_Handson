using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Utilities
{
    internal class ExcelUtils
    {
        public static List<CreateAccount> ReadExcelData(string excelFilePath,string sheetName)
        {
            List<CreateAccount> excelDataList = new();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read,FileShare.ReadWrite))
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
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            CreateAccount excelData = new()
                            {
                                FirstName = GetValueOrDefault(row, "firstname"),
                                LastName = GetValueOrDefault(row, "lastname"),
                                Email = GetValueOrDefault(row, "email"),
                                Password = GetValueOrDefault(row, "pwd"),
                                ConfirmPassword = GetValueOrDefault(row, "conpwd"),
                                MobileNumber = GetValueOrDefault(row, "mbno")

                        };
                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine(sheetName + " not found in the excel file.");
                    }
                }
            }
            return excelDataList;
        }
        static string GetValueOrDefault(DataRow row,string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
