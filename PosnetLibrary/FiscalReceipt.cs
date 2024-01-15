using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosnetLibrary
{
    public class FiscalReceipt
    {
        public double GrossAmount => FiscalReceiptItems.Sum(i => i.GrossAmount);

        public  List<ItemOnFiscalReceipt> FiscalReceiptItems { get; set; }

        public FiscalReceipt()
        {
             FiscalReceiptItems = new List<ItemOnFiscalReceipt>();
        }

    }
}
