using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModels
{
	public class ViewLasa
	{
		public Int64 SalesItemId { get; set; }
		public string Name { get; set; }
		public int LasaId { get; set; }
		public bool IsLasa { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
