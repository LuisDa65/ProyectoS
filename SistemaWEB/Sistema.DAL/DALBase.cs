using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public abstract class DALBase
    {
        protected private readonly string connectionString;

        public DALBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
