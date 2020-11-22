using System;

namespace SlothEnterprise.ProductApplication.Applications
{
    public interface ISellerCompanyData
    {
        /// <summary>
        /// Company name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Company number //todo: explain?
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Company director's name
        /// </summary>
        string DirectorName { get; set; }

        /// <summary>
        /// Date a company was founded
        /// </summary>
        DateTime Founded { get; set; }
    }
}