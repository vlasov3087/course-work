using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IUserModifyAccess : IUserViewAccess   
    {
        AnswerFromServer RegisterNewAdmin(Admin admin);
        AnswerFromServer RegisterNewClient(Client client);
        AnswerFromServer RegisterNewExpert(Expert expert);
        AnswerFromServer BanClientWith(string login);
        AnswerFromServer BanExpertWith(string login);
        AnswerFromServer UnbanExpertWith(string login);
        AnswerFromServer UnbanClientWith(string login);
        AnswerFromServer DeleteExpertWith(string login);
        AnswerFromServer DeleteClientWith(string login);
        AnswerFromServer ModifyClient(Client client);
        AnswerFromServer ModifyExpert(Expert expert);
    }
}
