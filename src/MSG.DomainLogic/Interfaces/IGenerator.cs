using System.Collections.Generic;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        List<string> GetSentences(int count);
    }
}
