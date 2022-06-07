using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public class ClientAbilityProtocol : AbstractClientAbilityProtocol
    {
        IDataViewPermision DBconnection;

        public ClientAbilityProtocol()
        {
            DBconnection = new DatabaseContext();
        }

        public override List<Employee> FindEmployeesWhere(Func<Employee, bool> comparer)
        {
            return DBconnection.FindEmployeesWhere(comparer);
        }

        public override List<Product> FindProductsWhere(Func<Product, bool> comparer)
        {
            return DBconnection.FindProductsWhere(comparer);
        }
    }
}
