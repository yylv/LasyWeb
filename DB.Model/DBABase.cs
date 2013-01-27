using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;

namespace DB.Model
{
    public class DBABase
    {
        object thisLock = new object();
        private static LasyDBContext dBContext;
        protected LasyDBContext DBContext 
        {
            get 
            {
                if (DBABase.dBContext == null)
                {
                    lock (thisLock)
                    {
                        if (DBABase.dBContext == null)
                        {
                            DBABase.dBContext = new LasyDBContext();
                        }
                    }
                }
                return DBABase.dBContext;
            }
        }
    }
}
