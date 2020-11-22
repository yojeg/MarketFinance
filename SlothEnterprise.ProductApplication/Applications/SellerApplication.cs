using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Applications
{
    public interface ISellerApplication
    {
        /// <summary>
        /// Product : Selective invoice discount, business loan, etc.
        /// </summary>
        IProduct Product { get; set; }

        /// <summary>
        /// Seller company data
        /// </summary>
        ISellerCompanyData CompanyData { get; set; }
    }

    public class SellerApplication : ISellerApplication
    {
        /// <summary>
        /// Product : Selective invoice discount, business loan, etc.
        /// </summary>
        public IProduct Product { get; set; }

        /// <summary>
        /// Seller company data
        /// </summary>
        public ISellerCompanyData CompanyData { get; set; }
    }
}