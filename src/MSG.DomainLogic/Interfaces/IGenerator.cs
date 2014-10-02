using System.Collections.Generic;
using MSG.DomainLogic.Entities;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        List<Sentence> GetSentences(int count);
    }
}
