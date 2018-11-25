using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CvsReader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Payment> payments = new List<Payment>();
            List<PaymentResult> test = new List<PaymentResult>();
            using (var reader = new StreamReader(@"C:\data\payments.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    payments.Add(new Payment(int.Parse(values[0]), decimal.Parse(values[1], CultureInfo.InvariantCulture), values[2]));

                }
            }

            var districts = payments.Select(c => c.kod_raj).Distinct().ToList();

            test = payments.
                GroupBy(x => x.str_name).
                Select(l => new PaymentResult
                {
                    Law = l.First().str_name.ToString(),
                    MimSumVipl = l.Min(c => c.sum_vipl),
                    MaxSumVipl = l.Max(c => c.sum_vipl),
                    AverageSumVipl = Math.Round(l.Average(c => c.sum_vipl), 2, MidpointRounding.AwayFromZero)
                }).ToList();

            ExcelHelper excel = new ExcelHelper(@"C:\Users\Искандер\Desktop\Форма для заполнения_мин_мах_ср размер выплат.xlsx", 1);
            //Console.WriteLine(excel.ReadCell(row: 2, column: 2));
            try
            {
                foreach (var item in test)
                {
                    int row = excel.FindRow(item);
                    if (row != -1)
                        excel.Write(item, row);
                }
                excel.SaveAs(@"ChelniReport");
            }
            finally
            {
                excel.Close();
            }
        }
    }
}
