namespace SlothEnterprise.ProductApplication.Products
{
    public class SelectiveInvoiceDiscount : IProduct
    {
        /// <summary>
        ///     Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        ///     Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = AdvanceRate.Default;

        /// <summary>
        ///     Selective invoice discount identifier
        /// </summary>
        public int Id { get; set; }
    }
}