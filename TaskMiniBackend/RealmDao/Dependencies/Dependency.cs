using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmDao.Interfaces;
using RealmDao.Impls;

namespace RealmDao.Dependencies
{
    public class Dependency
    {
        public IDao Inject()
        {
            return new RealmDao.Impls.RealmDao();
        }
    }
}
