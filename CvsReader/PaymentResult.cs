using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CvsReader
{
    class PaymentResult
    {
        public string Law { get; set; }
        public decimal MimSumVipl { get; set; }
        public decimal MaxSumVipl { get; set; }
        public decimal AverageSumVipl { get; set; }
        public int District { get; set; }
    }
}
