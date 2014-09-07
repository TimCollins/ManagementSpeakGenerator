using System.Collections.Generic;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        string GetPerson(Plurality plurality);
        List<string> GetSentences(int count);
    }
}
