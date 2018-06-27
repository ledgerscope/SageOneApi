namespace SageOneApi.Client.Models
{
    public class PropertyValue
    {
        public string id { get; set; }
        public string displayed_as { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PropertyValue pv)
            {
                return pv.id == id && pv.displayed_as == displayed_as;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (id ?? string.Empty).GetHashCode();
        }
    }
}
