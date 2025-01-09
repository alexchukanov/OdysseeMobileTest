using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connector;
using Newtonsoft.Json.Linq;

namespace OdysseeMobileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyListApiBefore = MobileConnector.GetCompanyList();
            Console.WriteLine($"before update - {companyListApiBefore.Count}");

            var companyList = MobileConnector.LoadCompanyCsv();
            Console.WriteLine($"load list - {companyList.Count()}");

            foreach (Company company in companyList)
            {
                string companyId = MobileConnector.CheckCompany(company.code);

                if (companyId != null)
                {
                    company.id = companyId;
                    MobileConnector.UpdateCompany(company);
                    Console.WriteLine($"{company.name} - updated");
                }
                else
                {
                    company.id = Guid.NewGuid().ToString();
                    MobileConnector.AddCompany(company);
                    Console.WriteLine($"{company.name} - added");
                }
            }

            var companyListApiAfter = MobileConnector.GetCompanyList();
            Console.WriteLine($"after update - {companyListApiAfter.Count}");
            
            Console.ReadLine();
        }
    }
}
