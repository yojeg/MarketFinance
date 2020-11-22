using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Applications
{
    public interface ISellerApplication<TProduct> where TProduct: IProduct
    {
        /// <summary>
        ///     Product : Selective invoice discount, business loan, etc.
        /// </summary>
        TProduct Product { get; set; }

        /// <summary>
        ///     Seller company data
        /// </summary>
        ISellerCompanyData CompanyData { get; set; }
    }
}