using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ContactPayment
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public Transaction transaction { get; set; }
        public TransactionType transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public PaymentMethod payment_method { get; set; }
        public Contact contact { get; set; }
        public BankAccount bank_account { get; set; }
        public string date { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public Currency currency { get; set; }
        public string exchange_rate { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public string base_currency_total_amount { get; set; }
        public string base_currency_currency_charge { get; set; }
        public string reference { get; set; }
        public List<AllocatedArtefact> allocated_artefacts { get; set; }
        public object tax_rate { get; set; }
        public object payment_on_account { get; set; }
    }

    public class PaymentMethod
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
    }

    public class BankAccount
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
    }

    public class Link2
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string type { get; set; }
    }

    public class Artefact
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public List<Link2> links { get; set; }
    }

    public class AllocatedArtefact
    {
        public string id { get; set; }
        public Artefact artefact { get; set; }
        public string amount { get; set; }
        public string discount { get; set; }
    }
}
