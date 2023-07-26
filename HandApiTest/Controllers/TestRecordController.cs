using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HandApiTest.Models;
using HandApiTest.Utilities;

namespace HandApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestRecordController : ControllerBase
    {
        [HttpPost]
        public async Task<ApiResponse> PostAsync(ApiRequest apiRequest) 
        {   
            TestRecord testRecord = apiRequest.TestRecord;
            
            if (testRecord == null) 
            {
                throw new ArgumentNullException(nameof(testRecord)); 
            }

            ApiResponse resp = new();
            
            try
            {
                LaboratoryReport laboratoryReport = ReportMapper.MapTestRecordToLaboratoryReport(testRecord);
                string fileName = TxtFileGenerator.GenerateTxtFile(laboratoryReport.ToCommaDelimitedString(), laboratoryReport.StaticSection.ReportingLabCode);

                resp = new ApiResponse
                {
                    Status = "Accepted",
                    HttpRespCode = "202",
                    Message = "Message ccepted",
                    NhstrackId = fileName
                };
            }
            catch (System.Exception)
            {
                throw;
            }

            return await Task.FromResult(resp);
        }
    }

    public class ApiRequest
    {
        public TestRecord TestRecord { get; set; }
    }

    public class ApiResponse
    {
        public string Status { get; set; }
        public string HttpRespCode { get; set; }
        public string Message { get; set; }
        public string NhstrackId { get; set; }
    }

}

