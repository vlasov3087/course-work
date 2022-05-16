using DatabaseEntities;
using System;
using System.Collections.Generic;
namespace TCPConnectionAPI_C_sharp_
{
    public interface IDataViewPermision : IDisposable
    {
        List<Employee> FindEmployeesWhere(Func<Employee, bool> comparer);
        List<Product> FindProductsWhere(Func<Product, bool> comparer);
    }
}
