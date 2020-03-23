using System;
using System.Collections.Generic;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public class IntegrationMerchantDetails
    {
        public int MerchantDetailsId { get; set; }
        public string MerchantAccountName { get; set; }
        public string MerchantCategoryCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CountryISONumber { get; set; }
        public string ContactPhone { get; set; }
        public string ChannelUrl { get; set; }
        public string Status { get; set; }
    }
}
