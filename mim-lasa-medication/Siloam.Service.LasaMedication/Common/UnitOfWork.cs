using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siloam.Service.LasaMedication.Repositories;

namespace Siloam.Service.LasaMedication.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        //mendaftarkan dan mapping class repository yang digunakan
        internal DatabaseContext Context;
        private LasaRepository Lasa_Repository;
        private UserRepository User_Repository;

        public UnitOfWork(DatabaseContext _context)
        {
            Context = _context;
        }

        //add new data

       public LasaRepository UnitOfWork_TR_lasa()
       {
            if (Lasa_Repository == null)
            {
                Lasa_Repository = new LasaRepository(Context);
            }
            return Lasa_Repository;
       }

        public UserRepository UnitOfWork_MS_user()
        {
            if (User_Repository == null)
            {
                User_Repository = new UserRepository(Context);
            }
            return User_Repository;
        }


        public bool Disposing;
        private void DisposingProperties()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected virtual void Disposed(bool _disposing)
        {
            if (!Disposing)
            {
                if (_disposing)
                {
                    DisposingProperties();
                }
            }

            Disposing = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
    }
}
