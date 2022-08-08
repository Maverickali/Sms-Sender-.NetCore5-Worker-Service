using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Sms.DAL;
using Sms.SendSms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Sms
{
    public class Program
    {
        private static IConfiguration _iconfiguration;
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void Main(string[] args)
        {
            //GetAppSettingsFile();
            //Console.WriteLine("Hello World!");
            //var smsDAL = new SmsDal(_iconfiguration);
            //var lstSmsList = smsDAL.GetAllSms();
            //var s = new Sms.SendSms.SendSms();
            //foreach (var item in lstSmsList)
            //{
            //    s.Send(item.smstext, item.phone, item.RecordId);
            //}
            //lstSmsList.ForEach(item =>
            //{
            //    Console.WriteLine($"RecordId: {item.RecordId}" +
            //        $" Phone: {item.phone}" +
            //        $" Sms text: {item.smstext}" +
            //        $" Last Update date: {item.lupd_datetime}");
            //});
        }

        private static void updateSmsStatus(int RecordId)
        {
            var smsDAL = new SmsDal(_iconfiguration);
            smsDAL.UpdateSms(RecordId);
        }


    }
}
