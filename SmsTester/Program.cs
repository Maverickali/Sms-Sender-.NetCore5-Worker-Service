using Microsoft.Extensions.Configuration;
using Sms.DAL;
using Sms.SendSms;
using System;

namespace SmsTester
{
    public class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            Console.WriteLine("======>>>>>>>>> In ");
            var smsDAL = new SmsDal(_iconfiguration);
            var lstSmsList = smsDAL.GetAllSms();
            var s = new SendSms();
            foreach (var item in lstSmsList)
            {
                s.Send(item.smstext, "256700459182", item.RecordId);
            }
            Console.WriteLine("======>>>>>>>>> Out ");
        }
    }
}
