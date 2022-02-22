using Siloam.Service.LasaMedication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Common
{
    public interface IUnitOfWork : IDisposable
    {
        //mendaftarkan class repository yang digunakan
        LasaRepository UnitOfWork_TR_lasa();
        UserRepository UnitOfWork_MS_user();
    }
}
