namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscount : IProduct
    {
        /// <summary>
        ///     Total ledger networth
        /// </summary>
        public decimal TotalLedgerNetworth { get; set; }

        /// <summary>
        ///     Advance percentage
        /// </summary>
        public decimal AdvancePercentage { get; set; }

        /// <summary>
        ///     Vat rate value
        /// </summary>
        public decimal VatRate { get; set; } = Products.VatRate.UkVatRate;

        /// <summary>
        ///     Confidential invoice discount identifier
        /// </summary>
        public int Id { get; set; }
    }
}