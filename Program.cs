using Microsoft.Win32.SafeHandles;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleImpersonation;
using System;
using System.Security.Principal;

namespace SimpleImpersonationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user = WindowsIdentity.GetCurrent().Name;
            Console.WriteLine($"Current user (non-impersonated): {user}");

            UserCredentials credentials = new UserCredentials(<domain>, <username>, <password>);
            SafeAccessTokenHandle userHandle = credentials.LogonUser(LogonType.Interactive);
            WindowsIdentity.RunImpersonated(userHandle, () =>
            {
                var user1 = WindowsIdentity.GetCurrent().Name;
                Console.WriteLine($"Current user (impersonated): {user1}");

                ChromeOptions options = new ChromeOptions();
                options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                IWebDriver driver = new ChromeDriver(options);

            });


        }
    }
}
