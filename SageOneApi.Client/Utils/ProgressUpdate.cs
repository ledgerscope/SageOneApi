using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Utils
{
	public class ProgressUpdate
	{
		public string Message { get; set; }
		public int Progress { get; set; }
		public int TotalCount { get; set; }
	}
}
