using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class JournalCode : SageOneAccountingEntity
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("code")]
        public string Code { get; set; }
		[JsonPropertyName("journal_code_type")]
        public PropertyValueWithPath JournalCodeType { get; set; }
		[JsonPropertyName("control_name")]
        public string ControlName { get; set; }
		[JsonPropertyName("reserved")]
        public bool Reserved { get; set; }
    }
}
