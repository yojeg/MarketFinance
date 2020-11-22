using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        private const int InvalidResult = -1;

        private readonly IBusinessLoansService _businessLoansService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly ISelectInvoiceService _selectInvoiceService;

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        /// <summary>
        ///     Submit a select invoice discount application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public int SubmitApplicationFor(ISellerApplication<SelectiveInvoiceDiscount> application)
        {
            return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), application.Product.InvoiceAmount, application.Product.AdvancePercentage);
        }

        /// <summary>
        ///     Submit a confidential invoice discount application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public int SubmitApplicationFor(ISellerApplication<ConfidentialInvoiceDiscount> application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, application.Product.TotalLedgerNetworth, application.Product.AdvancePercentage, application.Product.VatRate);

            return result.Success ? result.ApplicationId ?? InvalidResult : InvalidResult;
        }

        /// <summary>
        ///     Submit a business loan application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public int SubmitApplicationFor(ISellerApplication<BusinessLoan> application)
        {
            var result = _businessLoansService.SubmitApplicationFor(new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            }, new LoansRequest
            {
                InterestRatePerAnnum = application.Product.InterestRatePerAnnum,
                LoanAmount = application.Product.LoanAmount
            });

            return result.Success ? result.ApplicationId ?? InvalidResult : InvalidResult;
        }
    }
}