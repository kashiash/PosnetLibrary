namespace PosnetLibrary
{
    public class FiscalReceipt
    {
        public double GrossAmount => FiscalReceiptItems.Sum(i => i.GrossAmount);

        public List<ItemOnFiscalReceipt> FiscalReceiptItems { get; set; }

        public FiscalReceipt()
        {
            FiscalReceiptItems = new List<ItemOnFiscalReceipt>();
        }
        public string BuyerNIP { get; set; }
        public string TransactionNumber { get; set; }
        public string Notes { get; set; }
    }
}
