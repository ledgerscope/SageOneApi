using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class PropertyValueWithPath : PropertyValue
    {
        [JsonProperty("$path")]
        public string path { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PropertyValueWithPath pv)
            {
                return pv.path == path && base.Equals(pv);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (path ?? string.Empty).GetHashCode();
        }
    }
}
