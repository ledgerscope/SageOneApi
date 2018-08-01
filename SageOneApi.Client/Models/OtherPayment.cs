﻿using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class OtherPayment : SageOneAccountingEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public PropertyValueWithPath payment_method { get; set; }
        public Contact contact { get; set; }
        public BankAccount bank_account { get; set; }
        public string tax_address_region { get; set; }
        public DateTime date { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public string reference { get; set; }
        public List<PaymentLine> payment_lines { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
        public TaxRate withholding_tax_rate { get; set; }
        public decimal? withholding_tax_amount { get; set; }
    }
}
