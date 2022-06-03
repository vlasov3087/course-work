using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public class ClientAbilityProtocol : IClientAbilityProtocol
    {
        IDataViewPermision DBconnection;

        public ClientAbilityProtocol()
        {
            DBconnection = new DatabaseContext();
        }

        public void Dispose()
        {
            DBconnection.Dispose();
        }

        public List<Employee> FindEmployeesWhere(Func<Employee, bool> comparer)
        {
            return DBconnection.FindEmployeesWhere(comparer);
        }

        public List<Product> FindProductsWhere(Func<Product, bool> comparer)
        {
            return DBconnection.FindProductsWhere(comparer);
        }
    }
}
