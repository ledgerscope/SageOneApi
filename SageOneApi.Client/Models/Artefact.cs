using Newtonsoft.Json;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Artefact : PropertyValueWithPath
    {
        public List<Link> links { get; set; }
    }
}
