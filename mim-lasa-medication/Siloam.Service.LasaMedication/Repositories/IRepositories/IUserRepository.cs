using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories.IRepositories
{
	public interface IUserRepository
	{
		IEnumerable<ViewLogin> GetData_user_Login(ParamLogin paramLogin);
    }
}
