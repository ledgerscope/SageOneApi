using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models.Core
{
    public abstract class SageOneCoreEntity
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool business_owner { get; set; }
    }
}
