using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataModifyAccess : IDataViewAccess   
    {
        AnswerFromServer CreateEmployee(Employee obj);
        AnswerFromServer ModifyEmployee(Employee obj);
        AnswerFromServer DeleteEmployee(int id);

        AnswerFromServer CreateProduct(Product obj);
        AnswerFromServer ModifyProduct(Product obj);
        AnswerFromServer DeleteProduct(int id);
    }
}
