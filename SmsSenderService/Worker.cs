using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Sms.DAL;
//using Sms.SendSms;
using Sms.DAL;
using Sms.SendSms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmsSenderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private static IConfiguration _iconfiguration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _iconfiguration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
               {
                _logger.LogInformation("SmsSender running at: {time}", DateTimeOffset.Now);

                Console.WriteLine("======>>>>>>>>> In ");
                var smsDAL = new SmsDal(_iconfiguration);
                var lstSmsList = smsDAL.GetAllSms();

                Console.WriteLine("======>>>>>>>>> Pending Sms {0}", lstSmsList.Count);
                var s = new SendSms();
                foreach (var item in lstSmsList)
                {
                    s.Send(item.smstext, item.phone, item.RecordId);
                }
                Console.WriteLine("======>>>>>>>>> Out ");
                
                await Task.Delay(80000, stoppingToken);
            }
        }
    }
}
