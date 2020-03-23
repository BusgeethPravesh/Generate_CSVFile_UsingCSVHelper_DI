using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public class QueryPending : IQueryPending
    {
        private IOptions<ConnectionStrings> _connectionString;
        private IOptions<IOSettings> _ioSettings;

        public QueryPending(IOptions<ConnectionStrings> connectionString, IOptions<IOSettings> ioSettings)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _ioSettings = ioSettings ?? throw new ArgumentNullException(nameof(ioSettings));
        }

        public List<IntegrationMerchantDetails> QueryDciMerchantDetails()
        {
            var result = new List<IntegrationMerchantDetails>();
            var query = $@"
                        SELECT [MerchantDetailsId]
                              ,[MerchantAccountName]
                              ,[MerchantCategoryCode]
                              ,[CompanyName]
                              ,[CompanyPostalCode]
                              ,[CountryISONumber]
                              ,[ContactPhone]
                              ,[ChannelUrl]
                              ,[Status]
                          FROM [CSV].[dbo].[IntegrationMerchantDetails]
                          where Status = 'Pending'";

            using (var connection = new SqlConnection(_connectionString.Value.IntegrationDBConnectionString))
            {
                try
                {
                    var queryResult = connection.Query<IntegrationMerchantDetails>(query);
                    if (queryResult.Any())
                    {
                        result.AddRange(queryResult);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }
    }
}
