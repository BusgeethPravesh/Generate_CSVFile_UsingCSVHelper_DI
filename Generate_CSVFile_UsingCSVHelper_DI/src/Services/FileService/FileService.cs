using CsvHelper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public class FileService : IFileService
    {
        private IOptions<ConnectionStrings> _connectionString;
        private IOptions<IOSettings> _ioSettings;
        private IQueryPending _queryPending;
        public FileService(IOptions<ConnectionStrings> connectionString, IQueryPending queryPending, IOptions<IOSettings> ioSettings)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _queryPending = queryPending ?? throw new ArgumentNullException(nameof(queryPending));
            _ioSettings = ioSettings ?? throw new ArgumentNullException(nameof(ioSettings));
        }
        public IEnumerable<IntegrationMerchantDetails> CsvExtract()
        {

            var timestamp = DateTime.Now;
            var fileDate = timestamp.Date.ToString("yyyyMMdd");
            var filename = $"Pending-Extract-{fileDate}.csv";
            var filePath = Path.Combine(_ioSettings.Value.ProcessedCsvFilePath, filename);

            var generateExtract = _queryPending.QueryDciMerchantDetails();

            //generating csv 
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))

            {
                csv.WriteRecords(generateExtract);
                if (generateExtract.Count == 0)
                {
                    Console.WriteLine("No records found!");
                }
            }

            return generateExtract;

        }
    }
}
