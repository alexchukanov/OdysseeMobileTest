using Csv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector
{
    public class MobileConnector
    {
        private static string baseUrl = "https://developers.odysseemobile.com/api/";
        private static string csvFileName = "Odyssee DataSet.csv";

        private static string domain = "SAMPLEAPI";
        private static string user = "test@sampleapi.com";
        private static string password = "8f0690jjlkjIHZLKjZJlkZ";
               

        public static IEnumerable<Company> LoadCompanyCsv()
        {
            List<Company> companyList = new List<Company>();

            var csv1 = File.ReadAllText(csvFileName);
            foreach (var line in CsvReader.ReadFromText(csv1))
            {
                Company company = new Company();

                company.id = "00000000-0000-0000-0000-000000000000";
                company.sales_territory_id = "110d205f-a041-4606-ad5c-3ee3e48c64a3";
                company.sales_organization_id = "0ea11d61-4e52-4eee-a945-bd8c26b52b45";
                company.marketing_segment_id = "00000000-0000-0000-0000-000000000000";
                company.parent_id = "00000000-0000-0000-0000-000000000000";
                company.db_country_id = "f3f3bef8-397c-442b-b9ab-2d2e1eb91987";
                company.feelist_id = "00000000-0000-0000-0000-000000000000";
                company.company_type_id = "00000000-0000-0000-0000-000000000000";
                company.db_language_id = "5ee7147f-63b2-4171-813c-60422af2e19c";
                company.article_price_label_id = "00000000-0000-0000-0000-000000000000";
                company.db_payment_method_id = "a0186e8f-96f0-4db2-953c-5a192ed7ce29";
                company.db_country_code = "BE";

                company.name = line["name"];
                company.is_client = line["is_client"].ConvertInvariant<bool>();
                company.is_supplier = line["is_supplier"].ConvertInvariant<bool>();
                company.code = line["code"].ToStringInvariant();
                company.is_working_address = line["is_working_address"].ConvertInvariant<bool>();
                company.city = line["city"].ToStringInvariant();
                company.street = line["street"].ToStringInvariant();
                company.street_number = line["street_number"].ToStringInvariant();
                company.zip = line["zip"].ToStringInvariant();
                company.phone = line["phone"].ToStringInvariant() + $"; {line["mobile"].ToStringInvariant()}";
                company.email = line["email"].ToStringInvariant();
                company.vat_reg_code = line["vat_reg_code"].ToStringInvariant();

                companyList.Add(company);
            }

            return companyList;
        }

        public static JArray GetCompanyList()
        {
            var client = new RestClient(baseUrl);
            client.Authenticator = new OdysseeAuthenticator(domain, user, password);
            var request = new RestRequest("/Company", Method.GET);
                       
           var response = client.Execute(request); // use async ver

            JArray list = JsonConvert.DeserializeObject<JObject>(response.Content)["value"] as JArray;

            return list;
        }

        public static string CheckCompany(string code)
        {
            string id = null;

            var client = new RestClient(baseUrl);
            client.Authenticator = new OdysseeAuthenticator(domain, user, password);
            var request = new RestRequest($"/Company?$filter=code+eq+'{code}'", Method.GET);

            var response = client.Execute(request);

            JArray list = JsonConvert.DeserializeObject<JObject>(response.Content)["value"] as JArray;

            if(list.Count() > 0)
            {
                id = list[0]["id"].ToStringInvariant();
            }

            return id;
        }

        public static void AddCompany(Company company)
        {
            var client = new RestClient(baseUrl);
            client.Authenticator = new OdysseeAuthenticator(domain, user, password);
            var request = new RestRequest("/Company", Method.POST, DataFormat.Json);
            request.AddBody(company);

            var response = client.Execute(request);
        }

        public static void UpdateCompany(Company company)
        {
            var client = new RestClient(baseUrl);
            client.Authenticator = new OdysseeAuthenticator(domain, user, password);
            var request = new RestRequest($"/Company({company.id})", Method.PUT, DataFormat.Json);
            request.AddBody(company);

            var response = client.Execute(request);            
        }
    }
}
