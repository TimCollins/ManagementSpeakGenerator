using System.Collections.Generic;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        string GetBoss();
        string GetPerson();
        List<string> GetSentences(int count);

        string Managing();

        string Title();

        string Age();

        string Exec() ;

        string Department();
    }
}
