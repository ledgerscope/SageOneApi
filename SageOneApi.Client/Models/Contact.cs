using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Contact : SageOneAccountingEntity
    {
        public List<Link> links { get; set; }
        public List<PropertyValueWithPath> contact_types { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public LedgerAccount default_sales_ledger_account { get; set; }
        public TaxRate default_sales_tax_rate { get; set; }
        public string tax_number { get; set; }
        public string notes { get; set; }
        public string locale { get; set; }
        public MainAddress main_address { get; set; }
        public DeliveryAddress delivery_address { get; set; }
        public Contact main_contact_person { get; set; }
        public BankAccountDetails bank_account_details { get; set; }
        public string credit_limit { get; set; }
        public string credit_days { get; set; }
        public string credit_terms_and_conditions { get; set; }
        public PropertyValueWithPath product_sales_price_type { get; set; }
        public string source_guid { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public string aux_reference { get; set; }
        public string registered_number { get; set; }
        public bool deletable { get; set; }
        public TaxTreatment tax_treatment { get; set; }
    }
}
