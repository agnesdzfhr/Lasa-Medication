using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories.IRepositories
{
	public interface ILasaRepository
	{
      IEnumerable<ViewLasa> GetAllData_lasa();
      IEnumerable<ViewLasa> GetData_lasa_byID(Int64 SalesItemId);
    }
}
