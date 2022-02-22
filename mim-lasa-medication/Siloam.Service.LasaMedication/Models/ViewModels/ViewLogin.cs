using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModels
{
	public class ViewLogin
	{
		public int Status { get; set; }
		public string Message{ get; set; }
		public int Code { get; set; }
		public int Result { get; set; }
		public string Name{ get; set; }
		public int UserId{ get; set; }
	}
}
