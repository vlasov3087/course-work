using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public abstract class AbstractClientAbilityProtocol
    {
        abstract public List<Employee> FindEmployeesWhere(Func<Employee, bool> comparer);
        abstract public List<Product> FindProductsWhere(Func<Product, bool> comparer);
    }
}
