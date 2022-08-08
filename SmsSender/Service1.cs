using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmsSender
{
    public partial class Service1 : ServiceBase
    {
        Thread _Threader;
        private static IConfiguration _iconfiguration;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _Threader = new Thread(new ThreadStart(DoWork));
            _Threader.Start();
        }

        protected override void OnStop()
        {
            _Threader.Abort();
        }

        public void DoWork()
        {
            while (true)
            {
                try
                {
                    var smsDAL = new SmsDal(_iconfiguration);
                    var lstSmsList = smsDAL.GetAllSms();
                    var s = new SendSms();
                    foreach (var item in lstSmsList)
                    {
                        s.Send(item.smstext, "256700459182", item.RecordId);
                    }

                }
                catch (Exception ex)
                {
                    //Console.WriteLine("EXCEPTION: " + ex.Message);
                }
                Thread.Sleep(new TimeSpan(0, 0, 3));
            }
        }
    }
}
