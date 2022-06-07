using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public class AdminAbilityProtocol : AbstractAdminAbilityProto
    {
        protected IMainDBPermission dbContext =
            new DatabaseContext();

        public override bool BanClientsWhere(Func<Client, bool> comparer)
        {
            var buf = dbContext.FindClientsWhere(comparer);
            if (buf.Count == 0) return false;
            else
            {
                foreach (var item in buf)
                {
                    item.UserStatus = Status.Banned;
                    dbContext.UpdateClient(item);
                }
                return true;
            }
        }

        public override bool BanExpertsWhere(Func<Expert, bool> comparer)
        {
            var buf = dbContext.FindExpertsWhere(comparer);
            if (buf.Count == 0) return false;
            else
            {
                foreach (var item in buf)
                {
                    item.UserStatus = Status.Banned;
                    dbContext.UpdateExpert(item);
                }
                return true;
            }
        }

        public override bool CreateEmployee(Employee obj)
        {
            dbContext.CreateEmployee(obj);
            if (obj.Id > 0) return true;
            else return false;
        }

        public override bool DeleteClientsWhere(Func<Client, bool> comparer)
        {
            return dbContext.DeleteClientsWhere(comparer);
        }

        public override bool DeleteEmployeesWhere(Func<Employee, bool> sampler)
        {
            return dbContext.DeleteEmployee(sampler);
        }

        public override bool DeleteExpertsWhere(Func<Expert, bool> comparer)
        {
            return dbContext.DeleteExpertsWhere(comparer);
        }

        public override List<Admin> FindAdminsWhere(Func<Admin, bool> comparer)
        {
            return dbContext.FindAdminsWhere(comparer);
        }

        public override List<Client> FindClientsWhere(Func<Client, bool> comparer)
        {
            return dbContext.FindClientsWhere(comparer);
        }

        public override List<Expert> FindExpertsWhere(Func<Expert, bool> comparer)
        {
            return dbContext.FindExpertsWhere(comparer);
        }

        public override List<Employee> FindEmployeesWhere(Func<Employee, bool> comparer)
        {
            return dbContext.FindEmployeesWhere(comparer);
        }

        public override bool ModifyEmployee(Employee newVesrion)
        {
            return dbContext.UpdateEmployee(newVesrion);
        }

        public override bool UnbanClientsWhere(Func<Client, bool> comparer)
        {
            var buf = dbContext.FindClientsWhere(comparer);
            if (buf == null) return false;
            else
            {
                foreach (var item in buf)
                {
                    if (item.UserStatus == Status.Banned)
                    {
                        item.UserStatus = Status.NotBanned;
                    }
                }
                return true;
            }
        }

        public override bool UnbanExpertsWhere(Func<Expert, bool> comparer)
        {
            var buf = dbContext.FindExpertsWhere(comparer);
            if (buf == null) return false;
            else
            {
                foreach (var item in buf)
                {
                    if (item.UserStatus == Status.Banned)
                    {
                        item.UserStatus = Status.NotBanned;
                    }
                }
                return true;
            }
        }

        public override string CreateReport()
        {
            return ReportCreator.CreateReportAboutCarriers();
        }

        public override bool ModifyExpert(Expert newVersion)
        {
            return dbContext.UpdateExpert(newVersion);
        }

        public override bool ModifyClient(Client newVersion)
        {
            return dbContext.UpdateClient(newVersion);
        }

        public override int RegisterNewClient(Client obj)
        {
            return dbContext.CreateClient(obj);
        }

        public override int RegisterNewAdmin(Admin obj)
        {
            return dbContext.CreateAdmin(obj);
        }

        public override int RegisterNewExpert(Expert obj)
        {
            return dbContext.CreateExpert(obj);
        }

        public override bool CreateProduct(Product obj)
        {
            return dbContext.CreateProduct(obj) > 0;
        }

        public override bool ModifyProduct(Product newVesrion)
        {
            return dbContext.UpdateProduct(newVesrion);
        }

        public override bool DeleteProductsWhere(Func<Product, bool> sampler)
        {
            return dbContext.DeleteProduct(sampler);
        }

        public override List<Product> FindProductsWhere(Func<Product, bool> comparer)
        {
            return dbContext.FindProductsWhere(comparer);
        }
    }
}
