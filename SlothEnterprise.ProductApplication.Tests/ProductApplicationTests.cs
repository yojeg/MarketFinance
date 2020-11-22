using Moq;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private readonly Mock<ISelectInvoiceService> _selectInvoiceServiceMock;
        private Mock<IBusinessLoansService> _businessLoansServiceMock;
        private Mock<IConfidentialInvoiceService> _confidentialInvoiceServiceMock;

        public ProductApplicationTests()
        {
            _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            _businessLoansServiceMock = new Mock<IBusinessLoansService>();
            _confidentialInvoiceServiceMock = new Mock<IConfidentialInvoiceService>();
        }

        [Fact]
        public void ProductApplicationService_ShouldSubmitApplication_ToSelectInvoiceService()
        {
            var productApplicationService = new ProductApplicationService(_selectInvoiceServiceMock.Object, null, null);

            productApplicationService.SubmitApplicationFor(new SellerApplication()
            {
                Product = new SelectiveInvoiceDiscount(),
                CompanyData = new SellerCompanyData()
                {
                }
            });

            _selectInvoiceServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }
    }
}