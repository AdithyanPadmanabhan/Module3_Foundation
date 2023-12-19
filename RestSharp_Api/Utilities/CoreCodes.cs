using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonPlaceHolder.Utilities
{
    public class CoreCodes
    {


        protected RestClient client;
        protected ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        protected ExtentTest? test;



        [OneTimeSetUp]

        public void OneTimeSetup()
        {

            //added reports

            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currentDirectory + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            //added logs
            extent.AttachReporter(sparkReporter);
            string filePath = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");


        }
        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }
    }
}
