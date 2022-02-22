using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModels
{
	public class ResponseLasa
	{
		public int Status { get; set; }
		public string Message { get; set; }
		public int Code { get; set; }
		public Int64 SalesItemId { get; set; }
	}
}
