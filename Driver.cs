using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NemanjaTest1
{
    internal class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance = new ChromeDriver();
            
            Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));

            Instance.Manage().Window.Maximize();
        }

        public static void Initialize(int n)
        {
            
            if (n == 1)
            {
                Instance = new FirefoxDriver();
                Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
                Instance.Manage().Window.Maximize();

                var downloadDirectory = @"C:\Files";
                FirefoxOptions options = new FirefoxOptions();

                options.SetPreference("download.default_directory", downloadDirectory);
                options.SetPreference("download.prompt_for_download", false);
                options.SetPreference("disable-popup-blocking", "true");
            }
            else if(n == 2)
            {
                var downloadDirectory = @"C:\Files";
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("download.default_directory", downloadDirectory);
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("disable-popup-blocking", "true");
                options.AddUserProfilePreference("plugins.plugins_disabled", new[] {
                "Adobe Flash Player",
                "Chrome PDF Viewer"
                                                                                   });

                Instance = new ChromeDriver(@"C:\Drivers\", options);
                Instance.Manage().Window.Maximize();
               
            }
        }

        public static void Close()
        {
           Instance.Close();
        }

    }
}