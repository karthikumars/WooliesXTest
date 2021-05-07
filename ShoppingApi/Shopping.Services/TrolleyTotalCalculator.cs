using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopping.Models;
using Shopping.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Services
{
    public class TrolleyTotalCalculator : ITrolleyTotalCalculator
    {
        private readonly ILogger<TrolleyTotalCalculator> _logger;
        private readonly WooliesXApiDetail _wooliesXApiDetail;

        public TrolleyTotalCalculator(ILogger<TrolleyTotalCalculator> logger, IOptions<WooliesXApiDetail> wooliesXApiDetailOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _wooliesXApiDetail = wooliesXApiDetailOptions?.Value ?? throw new ArgumentNullException(nameof(wooliesXApiDetailOptions));
        }

        public async Task<decimal> Calculate(CalculateTrolleyTotalRequest request)
        {
            using (var client = new HttpClient())
            {
                //1. Create wooliex trolley total request
                var requestUrl = string.Format("{0}/{1}?token={2}", _wooliesXApiDetail.BaseUrl.Trim('/'), _wooliesXApiDetail.TrolleyCalculatorMethodName, _wooliesXApiDetail.ApiToken);

                var requestString = JsonConvert.SerializeObject(request);
                var requestContent = new StringContent(requestString, System.Text.Encoding.UTF8, "application/json");

                //2. Post
                var response = await client.PostAsync(requestUrl, requestContent);
                response.EnsureSuccessStatusCode();

                //2. Read response
                var result = await response.Content.ReadAsStringAsync();
                var trolleyTotal = JsonConvert.DeserializeObject<decimal>(result);

                return trolleyTotal;
            }
        }
    }
}