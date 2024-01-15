namespace PosnetLibrary
{
    public class ItemOnFiscalReceipt
    {
        public ItemOnFiscalReceipt(string itemName, double grossAmount, double quantity, string vatSymbol, string? description = null )
        {
            ItemName = itemName;
            GrossAmount = grossAmount;
            Quantity = quantity;
            VatRate = vatSymbol;
            Description = description;
        }
        public string ItemName { get; set; }
        public double GrossAmount { get; set; }

        public double Quantity { get; set; }
        public string VatRate { get; set; }
        public string? Description { get; set; }
    }
}
