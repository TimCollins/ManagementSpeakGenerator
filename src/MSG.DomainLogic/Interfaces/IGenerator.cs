﻿using System.Collections.Generic;

namespace MSG.DomainLogic.Interfaces
{
    public interface IGenerator
    {
        string GetBoss();
        string GetPerson();
        List<string> GetSentences(int count);

        /// <summary>
        /// For a given random number, return a string representing the managing part of a job
        /// title.
        /// </summary>
        /// <returns>An appropriate string.</returns>
        string Managing();

        string Title();

        string Age();

        string Exec() ;

        string Department();
    }
}
