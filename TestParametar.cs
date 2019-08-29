using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{


    public  class TestParametar
    {
        public string browser { get; set; }

        public string url { get; set; }

        public TestParametar()
        {
            SearchListPage.WriteInto("Start of Test parameter");

            string configFilePath = @"C://TestConfiguration//config.xml";

            if (!File.Exists(configFilePath))
                throw new FileNotFoundException("Specified test configuration file does not exist.");


            //Load configuration xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);
            string browsersValue = doc.DocumentElement.SelectSingleNode("//testconfiguration//browser").InnerText;

            string urlValue = doc.DocumentElement.SelectSingleNode("//testconfiguration//url").InnerText;


            if (string.IsNullOrWhiteSpace(browsersValue))
            {
                throw new ArgumentNullException("Test parameters from configuration XML file are not valid. Please check configuration xml file");
            }
            else
            {
                this.browser = browsersValue;
                this.url = urlValue;

            }

            SearchListPage.WriteInto("End of Test parameter");

        }

        
    }

    
}