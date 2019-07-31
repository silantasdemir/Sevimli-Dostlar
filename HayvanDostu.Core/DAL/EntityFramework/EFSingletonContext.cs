using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.Core.DAL.EntityFramework
{
    public class EFSingletonContext<TContext>
         where TContext : DbContext, new()
    {
        private static TContext _instance;

        public static TContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TContext();
                }
                return _instance;
            }
        }


    }
}
