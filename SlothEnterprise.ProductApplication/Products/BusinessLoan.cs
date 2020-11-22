namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoan : IProduct
    {
        /// <summary>
        ///     Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        ///     Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }

        /// <summary>
        ///     Business loan identifier
        /// </summary>
        public int Id { get; set; }
    }
}