using SageOneApi.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Constants
{
    public static class ArtefactStatus
    {
        const string root = "/artefact_statuses/";

        public static PropertyValueWithPath Void => new PropertyValueWithPath()
        {
            path = root + "VOID",
            displayed_as = "Void",
            id = "VOID"
        };

        public static PropertyValueWithPath Paid => new PropertyValueWithPath()
        {
            path = root + "PAID",
            displayed_as = "Paid",
            id = "PAID"
        };

        public static PropertyValueWithPath Unpaid => new PropertyValueWithPath()
        {
            path = root + "UNPAID",
            displayed_as = "Unpaid",
            id = "UNPAID"
        };

        public static PropertyValueWithPath PartPaid => new PropertyValueWithPath()
        {
            path = root + "PART_PAID",
            displayed_as = "Part Paid",
            id = "PART_PAID"
        };
    }
}
