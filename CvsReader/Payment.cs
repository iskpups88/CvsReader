using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvsReader
{
    class Payment
    {
        public int kod_raj { get; set; }
        public decimal sum_vipl { get; set; }
        public string str_name { get; set; }

        public Payment(int kod_raj, decimal sum_vipl, string srt_name)
        {
            this.kod_raj = kod_raj;
            this.sum_vipl = sum_vipl;
            this.str_name = srt_name;
        }
    }
}
