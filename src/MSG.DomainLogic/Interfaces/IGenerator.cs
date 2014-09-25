using System.Collections.Generic;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        List<Sentence> GetSentences(int count);
    }
}
