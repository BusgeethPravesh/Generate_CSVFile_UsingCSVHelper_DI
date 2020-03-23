using System;
using System.Collections.Generic;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public class ApplicationService : IApplicationService
    {
        private IQueryPending _queryPending;
        private IFileService _fileService;

        public ApplicationService(IQueryPending queryPending, IFileService fileService)
        {
            _queryPending = queryPending ?? throw new ArgumentNullException(nameof(queryPending));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }
        public void GenerateExtract()
        {
            try
            {
                _fileService.CsvExtract();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
