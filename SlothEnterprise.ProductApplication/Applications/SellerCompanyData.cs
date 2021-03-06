﻿using System;

namespace SlothEnterprise.ProductApplication.Applications
{
    public class SellerCompanyData : ISellerCompanyData
    {
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company number //todo: explain?
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Company director's name
        /// </summary>
        public string DirectorName { get; set; }

        /// <summary>
        /// Date a company was founded
        /// </summary>
        public DateTime Founded { get; set; }
    }
}