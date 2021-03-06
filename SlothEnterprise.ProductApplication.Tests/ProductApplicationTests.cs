﻿using System;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        public ProductApplicationTests()
        {
            _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            _businessLoansServiceMock = new Mock<IBusinessLoansService>();
            _confidentialInvoiceServiceMock = new Mock<IConfidentialInvoiceService>();
        }

        private readonly Mock<ISelectInvoiceService> _selectInvoiceServiceMock;
        private readonly Mock<IBusinessLoansService> _businessLoansServiceMock;
        private readonly Mock<IConfidentialInvoiceService> _confidentialInvoiceServiceMock;

        [Fact]
        public void ProductApplicationService_ShouldSubmitApplication_ForConfidentialInvoiceDiscountService()
        {
            _confidentialInvoiceServiceMock.Setup(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(() =>
            {
                var result = new Mock<IApplicationResult>();

                return result.Object;
            });

            var productApplicationService = new ProductApplicationService(null, _confidentialInvoiceServiceMock.Object, null);

            productApplicationService.SubmitApplicationFor(new SellerApplication<ConfidentialInvoiceDiscount>
            {
                Product = new ConfidentialInvoiceDiscount(),
                CompanyData = new SellerCompanyData()
            });

            _confidentialInvoiceServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void ProductApplicationService_ShouldSubmitApplication_ToBusinessLoanService()
        {
            _businessLoansServiceMock.Setup(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>())).Returns(() =>
            {
                var result = new Mock<IApplicationResult>();

                return result.Object;
            });

            var productApplicationService = new ProductApplicationService(null, null, _businessLoansServiceMock.Object);

            productApplicationService.SubmitApplicationFor(new SellerApplication<BusinessLoan>
            {
                Product = new BusinessLoan(),
                CompanyData = new SellerCompanyData()
            });

            _businessLoansServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>()), Times.Once);
        }

        [Fact]
        public void ProductApplicationService_ShouldReturnApplicationId_ForFailedResult_FromBusinessLoanService()
        {
            _businessLoansServiceMock.Setup(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>())).Returns(() =>
            {
                var serviceResult = new Mock<IApplicationResult>();
                serviceResult.Setup(x => x.ApplicationId).Returns(1);
                serviceResult.Setup(x => x.Success).Returns(false);

                return serviceResult.Object;
            });

            var productApplicationService = new ProductApplicationService(null, null, _businessLoansServiceMock.Object);

            var result = productApplicationService.SubmitApplicationFor(new SellerApplication<BusinessLoan>
            {
                Product = new BusinessLoan(),
                CompanyData = new SellerCompanyData()
            });

            Assert.Equal(-1, result);
        }

        [Fact]
        public void ProductApplicationService_ShouldReturnApplicationId_ForSuccessResult_FromBusinessLoanService()
        {
            _businessLoansServiceMock.Setup(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>())).Returns(() =>
            {
                var serviceResult = new Mock<IApplicationResult>();
                serviceResult.Setup(x => x.ApplicationId).Returns(1);
                serviceResult.Setup(x => x.Success).Returns(true);

                return serviceResult.Object;
            });

            var productApplicationService = new ProductApplicationService(null, null, _businessLoansServiceMock.Object);

            var result = productApplicationService.SubmitApplicationFor(new SellerApplication<BusinessLoan>
            {
                Product = new BusinessLoan(),
                CompanyData = new SellerCompanyData()
            });

            Assert.Equal(1, result);
        }

        [Fact]
        public void ProductApplicationService_ShouldSubmitApplication_ToSelectInvoiceService()
        {
            var productApplicationService = new ProductApplicationService(_selectInvoiceServiceMock.Object, null, null);

            productApplicationService.SubmitApplicationFor(new SellerApplication<SelectiveInvoiceDiscount>
            {
                Product = new SelectiveInvoiceDiscount(),
                CompanyData = new SellerCompanyData()
            });

            _selectInvoiceServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void ProductApplicationService_ShouldReturnServiceCallValue_ForSelectInvoiceService()
        {
            _selectInvoiceServiceMock.Setup(x => x.SubmitApplicationFor(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(1);

            var productApplicationService = new ProductApplicationService(_selectInvoiceServiceMock.Object, null, null);

            var result = productApplicationService.SubmitApplicationFor(new SellerApplication<SelectiveInvoiceDiscount>
            {
                Product = new SelectiveInvoiceDiscount(),
                CompanyData = new SellerCompanyData()
            });

            Assert.Equal(1, result);
        }
    }
}