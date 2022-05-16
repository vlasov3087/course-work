using DatabaseEntities;
using System;
using System.Collections.Generic;


namespace TCPConnectionAPI_C_sharp_
{
    public class ExpertAbilityProtocol : IExpertAbilityProtocol
    {
        public IExpertMethod expertMethod { get; set; }

        public IDataModifyPermission DBconnection;

        public bool Rate(Employee entity, Expert expert, float rate)
        {
            expertMethod.Rate(ref entity, expert, rate);
            return DBconnection.UpdateEmployee(entity);
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

        public ExpertAbilityProtocol()
        {
            DBconnection = new DatabaseContext();
        }

    }
}
