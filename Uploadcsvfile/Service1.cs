using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MySql.Data.MySqlClient;
using System.Configuration;
using CsvHelper;
using System.Globalization;
using Uploadcsvfile.Model;
using Uploadcsvfile.Map;

namespace Uploadcsvfile
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        private readonly SalesRecordContext salesRecordContext;
        public Service1()
        {
            InitializeComponent();
            salesRecordContext = new SalesRecordContext();
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Service is started at " + DateTime.Now);
            ServiceUploadethod();
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 9000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            Console.WriteLine("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            ServiceUploadethod();
        }

        public void ServiceUploadethod()
        {
            try
            {
                salesRecordContext.SalesRecord.AddRange(ReadCSVFile(AppDomain.CurrentDomain.BaseDirectory + "10000 Sales Records.csv"));
                salesRecordContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace + " Error in ServiceUploadMethod");
            }
        }

        public List<SalesRecord> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<SalesRecordMap>();
                    var records = csv.GetRecords<SalesRecord>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        internal void onDebug()
        {
            salesRecordContext.SalesRecord.AddRange(ReadCSVFile(AppDomain.CurrentDomain.BaseDirectory + "10000 Sales Records.csv"));
            salesRecordContext.SaveChanges();
        }
    }
}
