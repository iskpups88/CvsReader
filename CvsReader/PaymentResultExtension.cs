using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvsReader
{
    static class PaymentResultExtension
    {
        public static string[] ToArrayPaymentResult(this PaymentResult result)
        {
            string[] arr = new string[] { result.MimSumVipl.ToString(), result.MaxSumVipl.ToString(), result.AverageSumVipl.ToString() };
            return arr;
        }
    }
}
