﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Utils
{
	public class ProgressUpdate
	{
        public ProgressUpdate(string message)
        {
            Message = message;
        }

        public ProgressUpdate(string message, int progress, int totalCount) : this(message)
        {
            Progress = progress;
            TotalCount = totalCount;
        }

		public string Message { get; }
		public int Progress { get; }
		public int TotalCount { get; }
	}
}