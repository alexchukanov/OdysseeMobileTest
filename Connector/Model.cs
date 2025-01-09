using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector
{

    public class Company
    {
        public string id { get; set; }
        public bool is_client { get; set; }
        public bool is_supplier { get; set; }
        public bool archived { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public DateTime create_date { get; set; }
        public string sales_territory_id { get; set; }
        public object sales_territory_code { get; set; }
        public string marketing_segment_id { get; set; }
        public object marketing_segment_code { get; set; }
        public string sales_organization_id { get; set; }
        public object sales_organization_code { get; set; }
        public object company_sales_status_code { get; set; }
        public string vat_reg_code { get; set; }
        public bool is_working_address { get; set; }
        public string parent_id { get; set; }
        public object parent_company_code { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string url { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string db_country_id { get; set; }
        public string db_country_code { get; set; }
        public string feelist_id { get; set; }
        public object feelist_reference_back_office { get; set; }
        public string company_type_id { get; set; }
        public string company_type_name { get; set; }
        public string db_language_id { get; set; }
        public object db_language_code { get; set; }
        public string code { get; set; }
        public string article_price_label_id { get; set; }
        public string db_payment_method_id { get; set; }
        public object db_payment_method_reference_back_office { get; set; }
        public DateTime modified_dateutc { get; set; }
    }


   /*
    public class Company
    {
        public string Id { get; set; }
        public bool Is_client { get; set; }
        public bool Is_supplier { get; set; }
        public bool Archived { get; set; }        
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Create_date { get; set; }
        public string Sales_territory_id { get; set; }
        public object Sales_territory_code { get; set; }
        public string Marketing_segment_id { get; set; }
        public object Marketing_segment_code { get; set; }
        public string Sales_organization_id { get; set; }
        public object Sales_organization_code { get; set; }
        public object Company_sales_status_code { get; set; }
        public string Vat_reg_code { get; set; }
        public bool Is_working_address { get; set; }
        public string Parent_id { get; set; }
        public object Parent_company_code { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Street_number { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Db_country_id { get; set; }
        public string Db_country_code { get; set; }
        public string Feelist_id { get; set; }
        public object Feelist_reference_back_office { get; set; }
        public string Company_type_id { get; set; }
        public string Company_type_name { get; set; }
        public string Db_language_id { get; set; }
        public object Db_language_code { get; set; }
        public string Code { get; set; }
        public string Article_price_label_id { get; set; }
        public string Db_payment_method_id { get; set; }
        public object Db_payment_method_reference_back_office { get; set; }
        public DateTime Modified_dateutc { get; set; }
    }
    */    
}
