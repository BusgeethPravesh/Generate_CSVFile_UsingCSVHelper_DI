using System;
using System.Collections.Generic;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public interface IQueryPending
    {
        List<IntegrationMerchantDetails> QueryDciMerchantDetails();
    }
}
