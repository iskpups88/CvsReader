using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvsReader
{
    class ExcelHelper
    {
        string _path { get; set; }
        Application _excel = new Application();
        Workbook _wb;
        Worksheet _ws;

        public ExcelHelper(string path, int sheetNum)
        {
            _path = path;
            _wb = _excel.Workbooks.Open(path);
            _ws = _wb.Worksheets[sheetNum];
        }

        public string ReadCell(int row, int column)
        {
            if (_ws.Cells[row, column].Value2 != null)
            {
                return _ws.Cells[row, column].Value2;
            }
            else
            {
                return "";
            }
        }

        public int FindRow(PaymentResult result)
        {
            string currentStr = "";
            for (int i = 12; i < 47; i++)
            {
                currentStr = ReadCell(i, 1).Trim();
                if (result.Law.Trim() == currentStr)
                    return i;
            }

            return -1;
        }

        public void Write(PaymentResult result, int row)
        {
            //Проверка на закон
            Range range = (Range)_ws.Range[_ws.Cells[row, 2], _ws.Cells[row, 4]];
            range.Value2 = PaymentResultExtension.ToArrayPaymentResult(result);
        }

        public void Save()
        {
            _wb.Save();
        }

        public void SaveAs(string path)
        {
            _wb.SaveAs(path);
        }

        public void Close()
        {
            _wb.Close();
        }

    }
}
