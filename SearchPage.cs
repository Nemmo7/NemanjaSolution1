using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NemanjaTest1
{
    public class SearchPage
    {
        
        public static void FindText(string SearchParam)
        {
           // for (int second = 0; ; second++)
           // {
            //    if (second >= 60) Assert.Fail("timeout");
             //   try
             //   {
            //        if (IsElementPresent(By.Id(IDSelector))) break;
            //    }
            //    catch (Exception)
             //   { }
            //    Thread.Sleep(1000);
          //  }

          //  public static bool IsElementPresent(By by)
           // {
           //     try
           //     {
           //         Driver.Instance.FindElement(by);
            //        return true;
           //     }
            //    catch (NoSuchElementException)
            //    {
            //        return false;
            //    }
           // }

            var FindText = Driver.Instance.FindElement(By.Name("q"));
            FindText.SendKeys(SearchParam);
            Thread.Sleep(1000);

            Actions builder = new Actions(Driver.Instance);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);
        }
    }
}
