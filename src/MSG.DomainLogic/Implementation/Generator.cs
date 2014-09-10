using System;
using System.Collections.Generic;
using System.Text;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic.Implementation
{
    public class Generator : IGenerator
    {
        /// <summary>
        /// Get a string representing the job title of a boss.
        /// </summary>
        /// <returns></returns>
        private string GetBoss()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    return Managing() + Age() + Exec() + Title() + " of " + Department() + " ";
                default:
                    return Groupal() + "Chief " + DepartmentOrTopRole() + " Officer ";
            }

        }

        private string GetPerson(Plurality plurality)
        {
            return plurality == Plurality.Singular ? GetSingularPerson() : GetPluralPerson();
        }

        public List<string> GetSentences(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("count");
            }

            List<string> sentences = new List<string>();

            for (int i = 0; i < count; i++)
            {
                sentences.Add(GetSentence());
            }

            return sentences;
        }

        /// <summary>
        /// For a given random number, return a string representing the managing part of a job
        /// title. Called by GetBoss().
        /// </summary>
        /// <returns>An appropriate string.</returns>
        private string Managing()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 9);

            if (result > 2 && result < 9)
            {
                return string.Empty;
            }

            switch (result)
            {
                case 1:
                    return "Managing ";
                case 2:
                    return "Acting ";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string Age()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            return result == 1 ? "Senior " : string.Empty;
        }

        private string Exec()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 7);

            return result == 1 ? "Executive " : string.Empty;
        }

        private string Title()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    return string.Format("{0}Director", Vice());
                case 2:
                    return "Chief";
                case 3:
                    return string.Format("{0}Head", Co());
                case 4:
                    return string.Format("{0}President", Vice());
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string Department()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 15);

            switch (result)
            {
                case 1:
                    return "Human Resources";
                case 2:
                    return "Controlling";
                case 3:
                    return "Internal Audit";
                case 4:
                    return "Legal";
                case 5:
                    return "Operations";
                case 6:
                    return "Management Office";
                case 7:
                    return "Customer Relations";
                case 8:
                    return "Client Leadership";
                case 9:
                    return "Client Relationship";
                case 10:
                    return "Business Planning";
                case 11:
                    return "Business Operations";
                case 12:
                    return "IT Strategy";
                case 13:
                    return "IT Operations";
                case 14:
                    return "Marketing";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetPersonVerbHavingThingComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 67);

            switch (result)
            {
                case 1:
                    return BuildPluralVerb("manage ", plurality);
                case 2:
                    return BuildPluralVerb("target ", plurality);
                case 3:
                    return BuildPluralVerb("streamline ", plurality);
                case 4:
                    return BuildPluralVerb("improve ", plurality);
                case 5:
                    return BuildPluralVerb("optimise ", plurality);
                case 6:
                    return BuildPluralVerb("achieve ", plurality);
                case 7:
                    return BuildPluralVerb("secure ", plurality);
                case 8:
                    return BuildPluralVerb("address ", plurality);
                case 9:
                    return BuildPluralVerb("boost ", plurality);
                case 10:
                    return BuildPluralVerb("deploy ", plurality);
                case 11:
                    return BuildPluralVerb("innovate ", plurality);
                case 12:
                    return BuildPluralVerb("right-scale ", plurality);
                case 13:
                    return BuildPluralVerb("formulate ", plurality);
                case 14:
                    return BuildPluralVerb("transition ", plurality);
                case 15:
                    return BuildPluralVerb("leverage ", plurality);
                case 16:
                    return BuildPluralVerb("focus on ", plurality);
                case 17:
                    return BuildPluralVerb("synergise ", plurality);
                case 18:
                    return BuildPluralVerb("generate ", plurality);
                case 19:
                    return BuildPluralVerb("analyse ", plurality);
                case 20:
                    return BuildPluralVerb("integrate ", plurality);
                case 21:
                    return BuildPluralVerb("empower ", plurality);
                case 22:
                    return BuildPluralVerb("benchmark ", plurality);
                case 23:
                    return BuildPluralVerb("learn ", plurality);
                case 24:
                    return BuildPluralVerb("adapt ", plurality);
                case 25:
                    return BuildPluralVerb("enable ", plurality);
                case 26:
                    return BuildPluralVerb("strategise ", plurality);
                case 27:
                    return BuildPluralVerb("prioritise ", plurality);
                case 28:
                    return BuildPluralVerb("pre-prepare ", plurality);
                case 29:
                    return BuildPluralVerb("deliver ", plurality);
                case 30:
                    return BuildPluralVerb("champion ", plurality);
                case 31:
                    return BuildPluralVerb("embrace ", plurality);
                case 32:
                    return BuildPluralVerb("enhance ", plurality);
                case 33:
                    return BuildPluralVerb("engineer ", plurality);
                case 34:
                    return BuildPluralVerb("envision ", plurality);
                case 35:
                    return BuildPluralVerb("incentivise ", plurality);
                case 36:
                    return BuildPluralVerb("maximise ", plurality);
                case 37:
                    return BuildPluralVerb("visualise ", plurality);
                case 38:
                    return BuildPluralVerb("whiteboard ", plurality);
                case 39:
                    return BuildPluralVerb("institutionalise ", plurality);
                case 40:
                    return BuildPluralVerb("promote ", plurality);
                case 41:
                    return BuildPluralVerb("overdeliver ", plurality);
                case 42:
                    return BuildPluralVerb("right-size ", plurality);
                case 43:
                    return BuildPluralVerb("rebalance ", plurality);
                case 44:
                    return BuildPluralVerb("re-imagine ", plurality);
                case 45:
                    return BuildPluralVerb("influence ", plurality);
                case 46:
                    return BuildPluralVerb("facilitate ", plurality);
                case 47:
                    return BuildPluralVerb("drive ", plurality);
                case 48:
                    return BuildPluralVerb("structure ", plurality);
                case 49:
                    return BuildPluralVerb("standardise ", plurality);
                case 50:
                    return BuildPluralVerb("accelerate ", plurality);
                case 51:
                    return BuildPluralVerb("deepen ", plurality);
                case 52:
                    return BuildPluralVerb("strengthen ", plurality);
                case 53:
                    return BuildPluralVerb("broaden ", plurality);
                case 54:
                    return BuildPluralVerb("enforce ", plurality);
                case 55:
                    return BuildPluralVerb("establish ", plurality);
                case 56:
                    return BuildPluralVerb("foster ", plurality);
                case 57:
                    return BuildPluralVerb("build ", plurality);
                case 58:
                    return BuildPluralVerb("differentiate ", plurality);
                case 59:
                    return BuildPluralVerb("take a bite out of ", plurality);
                case 60:
                    return BuildPluralVerb("table ", plurality);
                case 61:
                    return BuildPluralVerb("flesh out ", plurality);
                case 62:
                    return BuildPluralVerb("reach out to ", plurality);
                case 63:
                    return BuildPluralVerb("jump-start ", plurality);
                case 64:
                    return BuildPluralVerb("telegraph ", plurality);
                case 65:
                    return BuildPluralVerb("justify ", plurality);
                case 66:
                    return BuildPluralVerb("display ", plurality);
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetSentence()
        {
            return GetArticulatedProposition();
        }

        private string GetArticulatedProposition()
        {
            // Mark the start of a sentence.
            DomainFactory.RandomNumber.GetRand(0, 0);

            int result = DomainFactory.RandomNumber.GetRand(1, 29);

            if (result > 0 && result < 18)
            {
                return ApplySentenceCase(GetProposition().Trim());
            }

            switch (result)
            {
                case 18:
                    return ApplySentenceCase(GetProposition().Trim() + "; this is why " + GetProposition());
                case 19:
                    return ApplySentenceCase(GetProposition().Trim() + "; nevertheless " + GetProposition());
                case 20:
                    return ApplySentenceCase(GetProposition().Trim() + "; whereas " + GetProposition());
                case 21:
                    return ApplySentenceCase("our gut feeling is that " + GetProposition());
                case 22:
                case 23:
                case 24:
                case 25:
                    return ApplySentenceCase(GetProposition().Trim() + ", while " + GetProposition());
                case 26:
                    return ApplySentenceCase(GetProposition().Trim() + ". At the same time, " + GetProposition());
                case 27:
                    return ApplySentenceCase(GetProposition().Trim() + ". As a result " + GetProposition());
                case 28:
                    return ApplySentenceCase(GetProposition().Trim() + ", whilst " + GetProposition());
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string ApplySentenceCase(string input)
        {
            return input.Substring(0, 1).ToUpper() + input.Substring(1) + ".";
        }

        private string GetProposition()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 101);

            if (result > 0 && result < 6)
            {
                return (GetFaukon() + GetEventualAdverb() + GetPersonVerbAndEnding(Plurality.Plural) + GetEventualPostfixedAdverb()).Trim();
            }

            if (result > 5 && result < 51)
            {
                Plurality plurality = GetRandomPlurality();
                return ("the " + GetPerson(plurality) + GetEventualAdverb() + GetPersonVerbAndEnding(plurality) +
                       GetEventualPostfixedAdverb()).Trim();
            }

            if (result > 50 && result < 93)
            {
                Plurality plurality = GetRandomPlurality();
                return (GetRandomArticle(plurality, GetThing(plurality)) + GetEventualAdverb()
                       + GetThingVerbAndEnding(plurality) + GetEventualPostfixedAdverb()).Trim();
            }

            if (result > 92 && result < 98)
            {
                return (GetThingAtom(Plurality.Singular) + "and " + GetThingAtom(Plurality.Singular)
                    + GetEventualAdverb() + GetThingVerbAndEnding(Plurality.Plural)   
                       + GetEventualPostfixedAdverb()).Trim();
            }

            if (result > 97 && result < 101)
            {
                return (GetThingAtom(Plurality.Singular).Trim() + ", " + GetThingAtom(Plurality.Singular)
                       + "and " + GetThingAtom(Plurality.Singular) + GetEventualAdverb() +
                       GetThingVerbAndEnding(Plurality.Plural) + GetEventualPostfixedAdverb()).Trim();
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThingVerbAndEnding(Plurality plurality)
        {
            Plurality innerPlurality = GetRandomPlurality();
            int result = DomainFactory.RandomNumber.GetRand(1, 102);

            if (result > 0 && result < 56)
            {
                return GetThingVerbHavingThingComplement(plurality) +
                       GetRandomArticle(innerPlurality, GetThing(innerPlurality));
            }

            if (result > 56 && result < 101)
            {
                return GetThingVerbHavingPersonComplement(plurality) + "the " + GetPerson(innerPlurality);
            }

            return BuildPluralVerb("add", plurality) +
                (plurality == Plurality.Singular ? "value " : " value ");
        }

        private string GetThingVerbHavingPersonComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 13);
            string item;

            switch (result)
            {
                case 1:
                    item = "motivate ";
                    break;
                case 2:
                    item = "target ";
                    break;
                case 3:
                    item = "enable ";
                    break;
                case 4:
                    item = "drive ";
                    break;
                case 5:
                    item = "synergise ";
                    break;
                case 6:
                    item = "empower ";
                    break;
                case 7:
                    item = "prioritise ";
                    break;
                case 8:
                    item = "incentivise ";
                    break;
                case 9:
                    item = "inspire ";
                    break;
                case 10:
                    item = "transfer ";
                    break;
                case 11:
                    item = "promote ";
                    break;
                case 12:
                    item = "influence ";
                    break;
                case 13:
                    item = "strengthen ";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            return BuildPluralVerb(item, plurality);
        }

        private string GetThingVerbHavingThingComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 30);
            string item;

            switch (result)
            {
                case 1:
                    item = "streamline ";
                    break;
                case 2:
                    item = "interact with ";
                    break;
                case 3:
                    item = "boost ";
                    break;
                case 4:
                    item = "generate ";
                    break;
                case 5:
                    item = "impact ";
                    break;
                case 6:
                    item = "enhance ";
                    break;
                case 7:
                    item = "leverage ";
                    break;
                case 8:
                    item = "synergise ";
                    break;
                case 9:
                    item = "generate ";
                    break;
                case 10:
                    item = "empower ";
                    break;
                case 11:
                    item = "enable ";
                    break;
                case 12:
                    item = "prioritise ";
                    break;
                case 13:
                    item = "transfer ";
                    break;
                case 14:
                    item = "drive ";
                    break;
                case 15:
                    item = "result in ";
                    break;
                case 16:
                    item = "promote ";
                    break;
                case 17:
                    item = "influence ";
                    break;
                case 18:
                    item = "facilitate ";
                    break;
                case 19:
                    item = "aggregate ";
                    break;
                case 20:
                    item = "architect ";
                    break;
                case 21:
                    item = "cultivate ";
                    break;
                case 22:
                    item = "engage ";
                    break;
                case 23:
                    item = "structure ";
                    break;
                case 24:
                    item = "standardise ";
                    break;
                case 25:
                    item = "accelerate ";
                    break;
                case 26:
                    item = "deepen ";
                    break;
                case 27:
                    item = "strengthen ";
                    break;
                case 28:
                    item = "enforce ";
                    break;
                case 29:
                    item = "foster ";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            return BuildPluralVerb(item, plurality);
        }

        private bool IsVowel(string input)
        {
            return "aeiou".Contains(input);
        }

        private string BuildPluralVerb(string verb, Plurality plurality)
        {
            if (plurality == Plurality.Plural)
            {
                return verb;
            }

            // There is a situation where we end up with verbs like "interact with" passed 
            // in here. See BuildPluralVerbInteractThing() for example.
            // In this case we need to pluralise the first word, not the second.
            // This also handles 3 word phrases like "streamline the process". See
            // FixMissingWord() for an example.
            // Seems now 4 letter phrases and higher are required (see GetPersonVerbAndComplement())
            verb = verb.Trim();
            string last = verb.Substring(verb.Length - 1, 1);
            int lastSpaceIndex = verb.LastIndexOf(' ');
            for (int i = verb.Length - 1; i > 0; i--)
            {
                if (verb[i] == ' ')
                {
                    last = verb[i - 1].ToString();
                    lastSpaceIndex = i;
                }
            }

            switch (last)
            {
                case "o":
                case "s":
                case "z":
                    return PluraliseVerb(verb, lastSpaceIndex, "es ");

                case "h":
                    string secondLast = lastSpaceIndex > 0
                        ? verb.Substring(lastSpaceIndex - 2, 1)
                        : verb.Substring(verb.Length - 2, 1);

                    if (secondLast == "c" || secondLast == "s")
                    {
                        return PluraliseVerb(verb, lastSpaceIndex, "es ");
                    }

                    return PluraliseVerb(verb, lastSpaceIndex, "s ");

                case "y":
                    if (IsVowel(verb.Substring(verb.Length - 2, 1)))
                    {
                        // If the second-last char is a vowel then append 's'.
                        // This covers "ploy" to "ploys".
                        return PluraliseVerb(verb, lastSpaceIndex, "s ");
                    }

                    // Remove the 'y' and append "ies".
                    // This covers "identify" to "identifies".
                    return verb.Substring(0, verb.Length - 1) + "ies ";

                default:
                    // If there was more than one word in the passed string then append "s" to the first word.
                    return PluraliseVerb(verb, lastSpaceIndex, "s ");
            }
        }

        private string PluraliseVerb(string verb, int lastSpaceIndex, string suffix)
        {
            return lastSpaceIndex > 0
                ? verb.Substring(0, lastSpaceIndex) + suffix + verb.Substring(lastSpaceIndex + 1) + " "
                : verb + suffix;
        }

        private string GetEventualPostfixedAdverb()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 156);

            switch (result)
            {
                case 1:
                    return "going forward";
                case 2:
                    return "within the industry";
                case 3:
                    return "across the board";
                case 4:
                    return "in this space";
                case 5:
                    return "from the get-go";
                case 6:
                    return "at the end of the day";
                case 7:
                    return "throughout the organisation";
                case 8:
                    return "as part of the plan";
                case 9:
                    return "by thinking outside the box";
                case 10:
                    Plurality plurality = GetRandomPlurality();
                    return "using " + GetRandomArticle(plurality, GetThing(plurality)).TrimEnd();
                case 11:
                    plurality = GetRandomPlurality();
                    return "by leveraging " + GetRandomArticle(plurality, GetThing(plurality));
                case 12:
                    plurality = GetRandomPlurality();
                    return "taking advantage of " + GetRandomArticle(plurality, GetThing(plurality));
                case 13:
                    return "within the " + GetMatrix();
                case 14:
                    return "across the " + GetEventualPlural(GetMatrix(), Plurality.Plural);
                case 15:
                    return "across and beyond the " + GetEventualPlural(GetMatrix(), Plurality.Plural);
                case 16:
                    return "resulting in " + GetGrowth();
                case 17:
                    return "reaped from our " + GetGrowth();
                case 18:
                    return "as a consequence of " + GetGrowth();
                case 19:
                    plurality = GetRandomPlurality();
                    return "because " + GetRandomArticle(plurality, GetThing(plurality))
                           + BuildPluralVerb("produce ", plurality) + GetGrowth();
                case 20:
                    return "ahead of schedule";
                case 21:
                    return "relative to our peers";
                case 22:
                    return "on a transitional basis";
                case 23:
                    return "by expanding boundaries";
                case 24:
                    return "by nurturing talent";
                case 25:
                    return "as a Tier 1 company";
                case 26:
                    return "up-front";
                case 27:
                    return "on-the-fly";
                case 28:
                    return "across our portfolio";
                case 29:
                    return "50/50";
                case 30:
                    return "up, down and across the " + GetMatrix();
                case 31:
                    return "in the marketplace";
                case 32:
                    return "by thinking and acting beyond boundaries";
                case 33:
                    return "at the individual, team and organizational level";
                default:
                    return string.Empty;
            }
        }

        private string GetPersonVerbAndEnding(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 96);

            if (result > 0 && result < 11)
            {
                return GetPersonVerbAndComplement(plurality);
            }

            if (result > 10 && result < 16)
            {
                return GetPersonVerbHavingBadThingComplement(plurality) + GetRandomArticle(Plurality.Plural, GetBadThings());
            }

            if (result > 15 && result < 96)
            {
                return GetPersonVerbHavingThingComplement(plurality) + GetRandomArticle(plurality, GetThing(plurality));
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThing(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 111);

            if (result > 0 && result < 10)
            {
                return string.Format("{0}, {1}, {2}", GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            if (result > 9 && result < 15)
            {
                return string.Format("{0} and {1} {2}", GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            if (result > 14 && result < 71)
            {
                return string.Format("{0} {1}", GetThingAdjective(), GetThingAtom(plurality));
            }

            if (result > 70 && result < 73)
            {
                return string.Format("{0} and/or {1} {2}", GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            if (result > 72 && result < 75)
            {
                return GetGrowth();
            }

            if (result > 74 && result < 81)
            {
                return string.Format("{0}, {1} and {2} {3}", GetThingAdjective(), GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            if (result > 80 && result < 85)
            {
                return string.Format("{0}, {1}, {2} and {3} {4}", GetThingAdjective(), GetThingAdjective(), GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            return GetThingAtom(plurality);
        }

        private string GetGrowth()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 9);
            string superlative;
            string improvement;

            switch (result)
            {
                case 1:
                    superlative = "organic";
                    break;
                case 2:
                    superlative = "double-digit";
                    break;
                case 3:
                    superlative = "upper single-digit";
                    break;
                case 4:
                    superlative = "breakout";
                    break;
                case 5:
                    superlative = "unprecedented";
                    break;
                case 6:
                    superlative = "unparallelled";
                    break;
                case 7:
                    superlative = "proven";
                    break;
                case 8:
                    superlative = "measured";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    improvement = "growth";
                    break;
                case 2:
                    improvement = "improvement";
                    break;
                case 3:
                    improvement = "throughput increase";
                    break;
                case 4:
                    improvement = "efficiency gain";
                    break;
                case 5:
                    improvement = "yield enhancement";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            return string.Format("{0} {1} ", superlative, improvement);
        }

        private string GetThingAdjective()
        {
            // LGA banned word list: http://news.bbc.co.uk/2/hi/7949077.stm
            int result = DomainFactory.RandomNumber.GetRand(1, 251);

            switch (result)
            {
                case 1:
                    return "efficient";
                case 2:
                    return "strategic";
                case 3:
                    return "constructive";
                case 4:
                    return "proactive";
                case 5:
                    return "strong";
                case 6:
                    return "key";
                case 7:
                    return "global";
                case 8:
                    return "corporate";
                case 9:
                    return "cost-effective";
                case 10:
                    return "focused";
                case 11:
                    return "top-line";
                case 12:
                    return "credible";
                case 13:
                    return "agile";
                case 14:
                    return "holistic";
                case 15:
                    return "new";
                case 16:
                    return "adaptive";
                case 17:
                    return "optimal";
                case 18:
                    return "unique";
                case 19:
                    return "core";
                case 20:
                    return "compliant";
                case 21:
                    return "goal-oriented";
                case 22:
                    return "non-linear";
                case 23:
                    return "problem-solving";
                case 24:
                    return "prioritising";
                case 25:
                    return "cultural";
                case 26:
                    return "future-oriented";
                case 27:
                    return "potential";
                case 28:
                    return "versatile";
                case 29:
                    return "leading";
                case 30:
                    return "dynamic";
                case 31:
                    return "progressive";
                case 32:
                    return "non-deterministic";
                case 33:
                    return "informed";
                case 34:
                    return "leveraged";
                case 35:
                    return "challenging";
                case 36:
                    return "intelligent";
                case 37:
                    return "controlled";
                case 38:
                    return "educated";
                case 39:
                    return "non-standard";
                case 40:
                    return "underlying";
                case 41:
                    return "centralised";
                case 42:
                    return "decentralised";
                case 43:
                    return "reliable";
                case 44:
                    return "consistent";
                case 45:
                    return "competent";
                case 46:
                    return "prospective";
                case 47:
                    return "collateral";
                case 48:
                    return "functional";
                case 49:
                    return "tolerably expensive";
                case 50:
                    return "organic";
                case 51:
                    return "forward-looking";
                case 52:
                    return "next-level";
                case 53:
                    return "executive";
                case 54:
                    return "seamless";
                case 55:
                    return "spectral";
                case 56:
                    return "balanced";
                case 57:
                    return "effective";
                case 58:
                    return "integrated";
                case 59:
                    return "systematised";
                case 60:
                    return "parallel";
                case 61:
                    return "responsive";
                case 62:
                    return "synchronised";
                case 63:
                    return "compatible";
                case 64:
                    return "carefully thought-out";
                case 65:
                    return "cascading";
                case 66:
                    return "high-level";
                case 67:
                    return "siloed";
                case 68:
                    return "operational";
                case 69:
                    return "future-ready";
                case 70:
                    return "flexible";
                case 71:
                    return "movable";
                case 72:
                    return "right";
                case 73:
                    return "productive";
                case 74:
                    return "evolutionary";
                case 75:
                    return "overarching";
                case 76:
                    return "documented";
                case 77:
                    return "awesome";
                case 78:
                    return "coordinated";
                case 79:
                    return "aligned";
                case 80:
                    return "enhanced";
                case 81:
                    return "replacement";
                case 82:
                    return "industry-standard";
                case 83:
                    return "accepted";
                case 84:
                    return "agreed-upon";
                case 85:
                    return "target";
                case 86:
                    return "customer-centric";
                case 87:
                    return "wide-spectrum";
                case 88:
                    return "well-communicated";
                case 89:
                    return "cutting-edge";
                case 90:
                    return "best-in-class";
                case 91:
                    return "state-of-the-art";
                case 92:
                    return "verifiable";
                case 93:
                    return "solid";
                case 94:
                    return "inspiring";
                case 95:
                    return "growing";
                case 96:
                    return "market-altering";
                case 97:
                    return "vertical";
                case 98:
                    return "emerging";
                case 99:
                    return "differentiating";
                case 100:
                    return "integrative";
                case 101:
                    return "cross-functional";
                case 102:
                    return "measurable";
                case 103:
                    return "well-planned";
                case 104:
                    return "accessible";
                case 105:
                    return "actionable";
                case 106:
                    return "accurate";
                case 107:
                    return "insightful";
                case 108:
                    return "relevant";
                case 109:
                    return "long-term";
                case 110:
                    return "top";
                case 111:
                    return "tactical";
                case 112:
                    return "best-of-breed";
                case 113:
                    return "robust";
                case 114:
                    return "targeted";
                case 115:
                    return "personalised";
                case 116:
                    return "interactive";
                case 117:
                    return "streamlined";
                case 118:
                    return "transparent";
                case 119:
                    return "traceable";
                case 120:
                    return "far-reaching";
                case 121:
                    return "powerful";
                case 122:
                    return "improved";
                case 123:
                    return "executive-level";
                case 124:
                    return "goal-based";
                case 125:
                    return "top-level";
                case 126:
                    return "value-added";
                case 127:
                    return "value-adding";
                case 128:
                    return "streamlining";
                case 129:
                    return "time-honored";
                case 130:
                    return "idiosyncratic";
                case 131:
                    return "sustainable";
                case 132:
                    return "in-depth";
                case 133:
                    return "immersive";
                case 134:
                    return "cross-industry";
                case 135:
                    return "time-phased";
                case 136:
                    return "day-to-day";
                case 137:
                    return "present-day";
                case 138:
                    return "medium-to-long-term";
                case 139:
                    return "profit-maximising";
                case 140:
                    return "generic";
                case 141:
                    return "granular";
                case 142:
                    return "market-driven";
                case 143:
                    return "value-driven";
                case 144:
                    return "well-defined";
                case 145:
                    return "outward-looking";
                case 146:
                    return "scalable";
                case 147:
                    return "strategy-focused";
                case 148:
                    return "promising";
                case 149:
                    return "collaborative";
                case 150:
                    return "scenario-based";
                case 151:
                    return "principle-based";
                case 152:
                    return "vision-setting";
                case 153:
                    return "client-oriented";
                case 154:
                    return "long-established";
                case 155:
                    return "established";
                case 156:
                    return "organisational";
                case 157:
                    return "visionary";
                case 158:
                    return "trusted";
                case 159:
                    return "full-scale";
                case 160:
                    return "firm-wide";
                case 161:
                    return "fast-growth";
                case 162:
                    return "performance-based";
                case 163:
                    return "high-performing";
                case 164:
                    return "top-down";
                case 165:
                    return "cross-enterprise";
                case 166:
                    return "outsourced";
                case 167:
                    return "situational";
                case 168:
                    return "bottom-up";
                case 169:
                    return "multidisciplinary";
                case 170:
                    return "one-to-one";
                case 171:
                    return "goal-directed";
                case 172:
                    return "intra-organisational";
                case 173:
                    return "high-performing";
                case 174:
                    return "multi-source";
                case 175:
                    return "360-degree";
                case 176:
                    return "motivational";
                case 177:
                    return "differentiated";
                case 178:
                    return "solutions-based";
                case 179:
                    return "compelling";
                case 180:
                    return "structural";
                case 181:
                    return "go-to-market";
                case 182:
                    return "on-message";
                case 183:
                    return "adequate";
                case 184:
                    return "value-enhancing";
                case 185:
                    return "mission-critical";
                case 186:
                    return "business enabling";
                case 187:
                    return "transitional";
                case 188:
                    return "future";
                case 189:
                    return "game-changing";
                case 190:
                    return "enterprise-wide";
                case 191:
                    return "rock-solid";
                case 192:
                    return "bullet-proof";
                case 193:
                    return "superior";
                case 194:
                    return "genuine";
                case 195:
                    return "alert";
                case 196:
                    return "nimble";
                case 197:
                    return "phased";
                case 198:
                    return "selective";
                case 199:
                    return "macroscopic";
                case 200:
                    return "low-risk high-yield";
                case 201:
                    return "interconnected";
                case 202:
                    return "high-margin";
                case 203:
                    return "resilient";
                case 204:
                    return "high-definition";
                case 205:
                    return "well-crafted";
                case 206:
                    return "fine-grained";
                case 207:
                    return "context-aware";
                case 208:
                    return "multi-tasked";
                case 209:
                    return "feedback-based";
                case 210:
                    return "analytics-based";
                case 211:
                    return "fact-based";
                case 212:
                    return "usage-based";
                case 213:
                    return "multi-channel";
                case 214:
                    return "omni-channel";
                case 215:
                    return "pre-approved";
                case 216:
                    return "specific";
                case 217:
                    return "heart-of-the-business";
                case 218:
                    return "responsible";
                case 219:
                    return "socially conscious";
                case 220:
                    return "results-centric";
                case 221:
                    return "business-led";
                case 222:
                    return "well-positioned";
                case 223:
                    return "end-to-end";
                case 224:
                    return "high-quality";
                case 225:
                    return "siloed";
                case 226:
                    return "modular";
                case 227:
                    return "service-oriented";
                case 228:
                    return "competitive";
                case 229:
                    return "scale-as-you-grow";
                case 230:
                    return "outside-in";
                case 231:
                    return "hyper-hybrid";
                case 232:
                    return "long-running";
                case 233:
                    return "large-scale";
                case 234:
                    return "wide-ranging";
                case 235:
                    return "active";
                case 236:
                    return "stellar";
                case 237:
                    return "dramatic";
                case 238:
                    return "aggressive";
                case 239:
                    return "innovative";
                case 240:
                    return "high-powered";
                case 241:
                    return "above-average";
                case 242:
                    return "result-driven";
                case 243:
                    return "innovation-driven";
                case 244:
                    return "customised";
                case 245:
                    return "outstanding";
                case 246:
                    return "non-mainstream";
                case 247:
                    return "customer-facing";
                case 248:
                    return "consumer-facing";
                case 249:
                    return "unified";
                case 250:
                    return "cooperative";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetBadThings()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 22);

            switch (result)
            {
                case 1:
                    return "issues ";
                case 2:
                    return "intricacies ";
                case 3:
                    return "organisational diseconomies ";
                case 4:
                    return "black swans ";
                case 5:
                    return "gaps ";
                case 6:
                    return "inefficiencies ";
                case 7:
                    return "overlaps ";
                case 8:
                    return "known unknowns ";
                case 9:
                    return "unknown unknowns ";
                case 10:
                    return "soft cycle issues ";
                case 11:
                    return "obstacles ";
                case 12:
                    return "surprises ";
                case 13:
                    return "weaknesses ";
                case 14:
                    return "threats ";
                case 15:
                    return "barriers to success ";
                case 16:
                    return "barriers ";
                case 17:
                    return "shortcomings ";
                case 18:
                    return "problems ";
                case 19:
                    return "uncertainties ";
                case 20:
                    return "unfavorable developments ";
                case 21:
                    return "consumer/agent disconnects ";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private Plurality GetRandomPlurality()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            return result == 1 ? Plurality.Singular : Plurality.Plural;
        }

        private string GetRandomArticle(Plurality plurality, string item)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 16);

            if (result > 0 && result < 3)
            {
                return "the " + item;
            }

            if (result > 2 && result < 7)
            {
                return "our " + item;
            }

            return GetIndefiniteArticle(plurality, item);
        }

        private string GetIndefiniteArticle(Plurality plurality, string to)
        {
            if (plurality == Plurality.Plural)
            {
                return to;
            }

            return StartsWithVowel(to) ? "an " + to : "a " + to;
        }

        private bool StartsWithVowel(string source)
        {
            return "aeiou".Contains(source.Substring(0, 1));
        }

        private string GetPersonVerbHavingBadThingComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);
            StringBuilder output = new StringBuilder();

            switch (result)
            {
                case 1:
                    output.Append(BuildPluralVerb("address", plurality));
                    break;
                case 2:
                    output.Append(BuildPluralVerb("identify", plurality));
                    break;
                case 3:
                    output.Append(BuildPluralVerb("avoid", plurality));
                    break;
                case 4:
                    output.Append(BuildPluralVerb("mitigate", plurality));
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            if (plurality == Plurality.Plural)
            {
                output.Append(" ");
            }

            return output.ToString();
        }

        private string GetPersonVerbAndComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 63);

            switch (result)
            {
                case 1:
                    return BuildPluralVerb("streamline the process ", plurality);
                case 2:
                    return BuildPluralVerb("address the overarching issues ", plurality);
                case 3:
                    return BuildPluralVerb("benchmark the portfolio ", plurality);
                case 4:
                    return BuildPluralVerb("manage the cycle ", plurality);
                case 5:
                    return BuildPluralVerb("figure out where we come from, where we are going to ", plurality);
                case 6:
                    return BuildPluralVerb("maximise the value ", plurality);
                case 7:
                    return BuildPluralVerb("execute the strategy ", plurality);
                case 8:
                    return BuildPluralVerb("think outside the box ", plurality);
                case 9:
                    return BuildPluralVerb("think differently ", plurality);
                case 10:
                    return BuildPluralVerb("think across the full value chain ", plurality);
                case 11:
                    return BuildPluralVerb("loop back ", plurality);
                case 12:
                    return BuildPluralVerb("conversate ", plurality);
                case 13:
                    return BuildPluralVerb("go forward together ", plurality);
                case 14:
                    return BuildPluralVerb("achieve efficiencies ", plurality);
                case 15:
                    return BuildPluralVerb("deliver ", plurality);
                case 16:
                    return BuildPluralVerb("stay in the mix ", plurality);
                case 17:
                    return BuildPluralVerb("stay in the zone ", plurality);
                case 18:
                    return BuildPluralVerb("evolve ", plurality);
                case 19:
                    return BuildPluralVerb("exceed expectations ", plurality);
                case 20:
                    return BuildPluralVerb("develop the plan ", plurality);
                case 21:
                    return BuildPluralVerb("develop the blue print for execution ", plurality);
                case 22:
                    return BuildPluralVerb("grow and diversify ", plurality);
                case 23:
                    return BuildPluralVerb("fuel changes ", plurality);
                case 24:
                    return BuildPluralVerb("nurture talent ", plurality);
                case 25:
                    return BuildPluralVerb("cultivate talent ", plurality);
                case 26:
                    return BuildPluralVerb("make it possible ", plurality);
                case 27:
                    return BuildPluralVerb("manage the portfolio ", plurality);
                case 28:
                    return BuildPluralVerb("align resources ", plurality);
                case 29:
                    return BuildPluralVerb("drive the business forward ", plurality);
                case 30:
                    return BuildPluralVerb("make things happen ", plurality);
                case 31:
                    return BuildPluralVerb("stay ahead ", plurality);
                case 32:
                    return BuildPluralVerb("outperform peers ", plurality);
                case 33:
                    return BuildPluralVerb("surge ahead ", plurality);
                case 34:
                    return BuildPluralVerb("manage the downside ", plurality);
                case 35:
                    return BuildPluralVerb("stay in the wings ", plurality);
                case 36:
                    return BuildPluralVerb("come to a landing ", plurality);
                case 37:
                    return BuildPluralVerb("shoot it over ", plurality);
                case 38:
                    return BuildPluralVerb("move the needle ", plurality);
                case 39:
                    return BuildPluralVerb("connect the dots ", plurality);
                case 40:
                    return BuildPluralVerb("connect the dots to the end game ", plurality);
                case 41:
                    return BuildPluralVerb("reset the benchmark ", plurality);
                case 42:
                    return BuildPluralVerb("take it offline ", plurality);
                case 43:
                    return BuildPluralVerb("peel the onion ", plurality);
                case 44:
                    return BuildPluralVerb("drill down ", plurality);
                case 45:
                    return BuildPluralVerb("get from here to here ", plurality);
                case 46:
                    return BuildPluralVerb("do things differently ", plurality);
                case 47:
                    return BuildPluralVerb("stretch the status quo ", plurality);
                case 48:
                    return BuildPluralVerb("challenge the status quo ", plurality);
                case 49:
                    return BuildPluralVerb("challenge established ideas ", plurality);
                case 50:
                    return BuildPluralVerb("increase customer satisfaction ", plurality);
                case 51:
                    return BuildPluralVerb("enable customer interaction ", plurality);
                case 52:
                    return BuildPluralVerb("manage the balance ", plurality);
                case 53:
                    return BuildPluralVerb("turn every stone ", plurality);
                case 54:
                    return BuildPluralVerb("drive revenue ", plurality);
                case 55:
                    return BuildPluralVerb("rise to the challenge ", plurality);
                case 56:
                    return BuildPluralVerb("keep it on the radar ", plurality);
                case 57:
                    return BuildPluralVerb("stay on trend ", plurality);
                case 58:
                    return BuildPluralVerb("hunt the business down ", plurality);
                case 59:
                    return BuildPluralVerb("push the envelope to the tilt ", plurality);
                case 60:
                    return BuildPluralVerb("execute on priorities ", plurality);
                case 61:
                    return BuildPluralVerb("telegraph the pass ", plurality);
                case 62:
                    return BuildPluralVerb("catch the high ball ", plurality);
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetEventualAdverb()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 93);

            switch (result)
            {
                case 1:
                    return "interactively ";
                case 2:
                    return "credibly ";
                case 3:
                    return "quickly ";
                case 4:
                    return "proactively ";
                case 5:
                    return "200% ";
                case 6:
                    return "24/7 ";
                case 7:
                    return "globally ";
                case 8:
                    return "culturally ";
                case 9:
                    return "technically ";
                case 10:
                    return "strategically ";
                case 11:
                    return "swiftly ";
                case 12:
                    return "cautiously ";
                case 13:
                    return "expediently ";
                case 14:
                    return "organically ";
                case 15:
                    return "carefully ";
                case 16:
                    return "significantly ";
                case 17:
                    return "conservatively ";
                case 18:
                    return "adequately ";
                case 19:
                    return "genuinely ";
                case 20:
                    return "efficiently ";
                case 21:
                    return "seamlessly ";
                case 22:
                    return "consistently ";
                case 23:
                    return "diligently ";
                default:
                    return string.Empty;
            }
        }

        private string GetFaukon()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 10);

            switch (result)
            {
                case 1:
                    return "we need to ";
                case 2:
                    return "we've got to ";
                case 3:
                    return "the reporting unit should ";
                case 4:
                    return "controlling should ";
                case 5:
                    return "we must activate the " + GetMatrix() + " to ";
                case 6:
                    return "pursuing this route will enable us to ";
                case 7:
                    return "we will go the extra mile to ";
                case 8:
                    return "we are working hard to ";
                case 9:
                    return "we continue to work tirelessly and diligently to ";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetMatrix()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 13);
            switch (result)
            {
                case 1:
                case 2:
                    return "organisation";
                case 3:
                case 4:
                case 5:
                case 6:
                    return "silo";
                case 7:
                case 8:
                case 9:
                case 10:
                    return "matrix";
                case 11:
                    return "cube";
                case 12:
                    return "sphere";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetPluralPerson()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 12);
            switch (result)
            {
                case 1:
                    return "key people ";
                case 2:
                    return "human resources ";
                case 3:
                    return "customers ";
                case 4:
                    return "clients ";
                case 5:
                    return "resources ";
                case 6:
                    return "team players ";
                case 7:
                    return "enablers ";
                case 8:
                    return "stakeholders ";
                case 9:
                    return "standard-setters ";
                case 10:
                    return "partners ";
                case 11:
                    return "business leaders ";
                case 12:
                    return string.Empty;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetSingularPerson()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 18);
            switch (result)
            {
                case 1:
                    return "steering committee ";
                case 2:
                    return "group ";
                case 3:
                    return "project manager ";
                case 4:
                    //return GetThingAtom(Plurality.Singular);
                    return GetThingAtom(GetRandomPlurality());
                case 5:
                    return "community ";
                case 6:
                    return "sales manager ";
                case 7:
                    return "enabler ";
                case 8:
                    return "powerful champion ";
                case 9:
                    return "thought leader ";
                case 10:
                    return "gatekeeper ";
                case 11:
                    return "resource ";
                case 12:
                    return "senior support staff ";
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    return GetBoss();
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetThingAtom(Plurality plurality)
        {
            if (plurality == Plurality.Singular)
            {
                return GetSingularAtom(DomainFactory.RandomNumber.GetRand(1, 469));
            }

            return GetPluralAtom(DomainFactory.RandomNumber.GetRand(1, 205));
        }

        private string GetSingularAtom(int rand)
        {
            switch (rand)
            {
                case 1:
                    return GetTimelessEvent();
                case 2:
                    return "team building ";
                case 3:
                    return "focus ";
                case 4:
                    return "strategy ";
                case 5:
                    return "planning granularity ";
                case 6:
                    return "core business ";
                case 7:
                    return "implementation ";
                case 8:
                    return "intelligence ";
                case 9:
                    return "governance ";
                case 10:
                    return "ROE ";
                case 11:
                    return "EBITDA ";
                case 12:
                    return "enterprise content management ";
                case 13:
                    return "excellence ";
                case 14:
                    return "trust ";
                case 15:
                    return "respect ";
                case 16:
                    return "openness ";
                case 17:
                    return "transparency ";
                case 18:
                    return "Quality Research ";
                case 19:
                    return "decision making ";
                case 20:
                    return "risk management ";
                case 21:
                    return "enterprise risk management ";
                case 22:
                    return "leverage ";
                case 23:
                    return "diversification ";
                case 24:
                    return "successful execution ";
                case 25:
                    return "effective execution ";
                case 26:
                    return "selectivity ";
                case 27:
                    return "optionality ";
                case 28:
                    return "expertise ";
                case 29:
                    return "awareness ";
                case 30:
                    return "broader thinking ";
                case 31:
                    return "client focus ";
                case 32:
                    return "thought leadership ";
                case 33:
                    return "quest for quality ";
                case 34:
                    return "360-degree thinking ";
                case 35:
                    return "drill-down ";
                case 36:
                    return "impetus ";
                case 37:
                    return "fairness ";
                case 38:
                    return "intellect ";
                case 39:
                    return "emotional impact ";
                case 40:
                    return "emotional intelligence ";
                case 41:
                    return "adaptability ";
                case 42:
                    return "stress management ";
                case 43:
                    return "self-awareness ";
                case 44:
                    return "strategic thinking ";
                case 45:
                    return "cross fertilization ";
                case 46:
                    return "cross-breeding ";
                case 47:
                    return "customer experience ";
                case 48:
                    return "centerpiece ";
                case 49:
                    return "SWOT analysis ";
                case 50:
                    return "responsibility ";
                case 51:
                    return "accountability ";
                case 52:
                    return "ROI ";
                case 53:
                    return "line of business ";
                case 54:
                    return "serviceability ";
                case 55:
                    return "responsiveness ";
                case 56:
                    return "simplicity ";
                case 57:
                    return "portfolio shaping ";
                case 58:
                    return "knowledge sharing ";
                case 59:
                    return "continuity ";
                case 60:
                    return "visual thinking ";
                case 61:
                    return "interoperability ";
                case 62:
                    return "compliance ";
                case 63:
                    return "teamwork ";
                case 64:
                    return "self-efficacy ";
                case 65:
                    return "decision-making ";
                case 66:
                    return "line-of-sight ";
                case 67:
                    return "scoping ";
                case 68:
                    return "line-up ";
                case 69:
                    return "predictability ";
                case 70:
                    return "recognition ";
                case 71:
                    return "investor confidence ";
                case 72:
                    return "competitive advantage ";
                case 73:
                    return "uniformity ";
                case 74:
                    return "connectivity ";
                case 75:
                    return "big picture ";
                case 76:
                    return "big-picture thinking ";
                case 77:
                    return "quality ";
                case 78:
                    return "upside focus ";
                case 79:
                    return "sustainability ";
                case 80:
                    return "resiliency ";
                case 81:
                    return "social sphere ";
                case 82:
                    return "intuitiveness ";
                case 83:
                    return "effectiveness ";
                case 84:
                    return "competitiveness ";
                case 85:
                    return "resourcefulness ";
                case 86:
                    return "informationalization ";
                case 87:
                    return "role building ";
                case 88:
                    return "talent retention ";
                case 89:
                    return "innovativeness ";
                case 90:
                    return "Economic Value Creation ";
                case 91:
                    return "intellectual capital ";
                case 92:
                    return "high quality ";
                case 93:
                    return "full range of products ";
                case 94:
                    return "technical strength ";
                case 95:
                    return "quality assurance ";
                case 96:
                    return "specification quality ";
                case 97:
                    return "market environment ";
                case 98:
                    return "client perspective ";
                default:
                    return GetInner();
            }
        }

        private string GetInner()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 192);

            switch (result)
            {
                case 1:
                    return "mission ";
                case 2:
                    return "vision ";
                case 3:
                    return "guideline ";
                case 4:
                    return "roadmap ";
                case 5:
                    return "timeline ";
                case 6:
                    return GetMatrix();
                case 7:
                    return "win-win solution ";
                case 8:
                    return "baseline starting point ";
                case 9:
                    return "sign-off ";
                case 10:
                    return "escalation ";
                case 11:
                    return "trigger event ";
                case 12:
                    return "system ";
                case 13:
                    return "Management Information System ";
                case 14:
                    return "Quality Management System ";
                case 15:
                    return "planning ";
                case 16:
                    return "target ";
                case 17:
                    return "calibration ";
                case 18:
                    return "Control Information System ";
                case 19:
                    return "process ";
                case 20:
                    return "talent ";
                case 21:
                    return "execution ";
                case 22:
                    return "leadership ";
                case 23:
                    return "performance ";
                case 24:
                    return "solution provider ";
                case 25:
                    return "value ";
                case 26:
                    return "value creation ";
                case 27:
                    return "feedback ";
                case 28:
                    return "document ";
                case 29:
                    return "bottom line ";
                case 30:
                    return "momentum ";
                case 31:
                    return "opportunity ";
                case 32:
                    return "credibility ";
                case 33:
                    return "issue ";
                case 34:
                    return "core meeting ";
                case 35:
                    return "platform ";
                case 36:
                    return "niche ";
                case 37:
                    return "content ";
                case 38:
                    return "communication ";
                case 39:
                    return "goal ";
                case 40:
                    return "skill ";
                case 41:
                    return "alternative ";
                case 42:
                    return "culture ";
                case 43:
                    return "requirement ";
                case 44:
                    return "potential ";
                case 45:
                    return "challenge ";
                case 46:
                    return "empowerment ";
                case 47:
                    return "benchmarking ";
                case 48:
                    return "framework ";
                case 49:
                    return "benchmark ";
                case 50:
                    return "implication ";
                case 51:
                    return "integration ";
                case 52:
                    return "enabler ";
                case 53:
                    return "control ";
                case 54:
                    return "trend ";
                case 55:
                    return "business case ";
                case 56:
                    return "architecture ";
                case 57:
                    return "action plan ";
                case 58:
                    return "project ";
                case 59:
                    return "review cycle ";
                case 60:
                    return "strategy formulation ";
                case 61:
                    return "decision ";
                case 62:
                    return "enhanced data capture ";
                case 63:
                    return "energy ";
                case 64:
                    return "plan ";
                case 65:
                    return "initiative ";
                case 66:
                    return "priority ";
                case 67:
                    return "synergy ";
                case 68:
                    return "incentive ";
                case 69:
                    return "dialogue ";
                case 70:
                    return "concept ";
                case 71:
                    return "time-phase ";
                case 72:
                    return "projection ";
                case 73:
                    return "blended approach ";
                case 74:
                    return "low hanging fruit ";
                case 75:
                    return "forward planning ";
                case 76:
                    return "pre-plan ";
                case 77:
                    return "pipeline ";
                case 78:
                    return "bandwidth ";
                case 79:
                    return "workshop ";
                case 80:
                    return "paradigm ";
                case 81:
                    return "paradigm shift ";
                case 82:
                    return "strategic staircase ";
                case 83:
                    return "cornerstone ";
                case 84:
                    return "executive talent ";
                case 85:
                    return "evolution ";
                case 86:
                    return "workflow ";
                case 87:
                    return "message ";
                case 88:
                    return "risk/return profile ";
                case 89:
                    return "efficient frontier ";
                case 90:
                    return "pillar ";
                case 91:
                    return "internal client ";
                case 92:
                    return "consistency ";
                case 93:
                    return "on-boarding process ";
                case 94:
                    return "dotted line ";
                case 95:
                    return "action item ";
                case 96:
                    return "cost efficiency ";
                case 97:
                    return "channel ";
                case 98:
                    return "convergence ";
                case 99:
                    return "infrastructure ";
                case 100:
                    return "metric ";
                case 101:
                    return "technology ";
                case 102:
                    return "relationship ";
                case 103:
                    return "partnership ";
                case 104:
                    return "supply-chain ";
                case 105:
                    return "portal ";
                case 106:
                    return "solution ";
                case 107:
                    return "business line ";
                case 108:
                    return "white paper ";
                case 109:
                    return "scalability ";
                case 110:
                    return "innovation ";
                case 111:
                    return "Strategic Management System ";
                case 112:
                    return "Balanced Scorecard ";
                case 113:
                    return "differentiator ";
                case 114:
                    return "case study ";
                case 115:
                    return "idiosyncrasy ";
                case 116:
                    return "benefit ";
                case 117:
                    return "say/do ratio ";
                case 118:
                    return "segmentation ";
                case 119:
                    return "image ";
                case 120:
                    return "realignment ";
                case 121:
                    return "business model ";
                case 122:
                    return "business philosophy ";
                case 123:
                    return "branding ";
                case 124:
                    return "methodology ";
                case 125:
                    return "profile ";
                case 126:
                    return "measure ";
                case 127:
                    return "measurement ";
                case 128:
                    return "philosophy ";
                case 129:
                    return "branding strategy ";
                case 130:
                    return "efficiency ";
                case 131:
                    return "industry ";
                case 132:
                    return "commitment ";
                case 133:
                    return "perspective ";
                case 134:
                    return "risk appetite ";
                case 135:
                    return "best practice ";
                case 136:
                    return "brand identity ";
                case 137:
                    return "customer centricity ";
                case 138:
                    return "shareholder value ";
                case 139:
                    return "attitude ";
                case 140:
                    return "mindset ";
                case 141:
                    return "flexibility ";
                case 142:
                    return "granularity ";
                case 143:
                    return "engagement ";
                case 144:
                    return "pyramid ";
                case 145:
                    return "market ";
                case 146:
                    return "diversity ";
                case 147:
                    return "interdependency ";
                case 148:
                    return "scaling ";
                case 149:
                    return "asset ";
                case 150:
                    return "flow charting ";
                case 151:
                    return "value proposition ";
                case 152:
                    return "performance culture ";
                case 153:
                    return "change ";
                case 154:
                    return "reward ";
                case 155:
                    return "learning ";
                case 156:
                    return "next step ";
                case 157:
                    return "delivery framework ";
                case 158:
                    return "structure ";
                case 159:
                    return "support structure ";
                case 160:
                    return "standardization ";
                case 161:
                    return "objective ";
                case 162:
                    return "footprint ";
                case 163:
                    return "transformation process ";
                case 164:
                    return "policy ";
                case 165:
                    return "sales target ";
                case 166:
                    return "ecosystem ";
                case 167:
                    return "landscape ";
                case 168:
                    return "atmosphere ";
                case 169:
                    return "environment ";
                case 170:
                    return "core competency ";
                case 171:
                    return "market practice ";
                case 172:
                    return "operating strategy ";
                case 173:
                    return "insight ";
                case 174:
                    return "accomplishment ";
                case 175:
                    return "correlation ";
                case 176:
                    return "touchpoint ";
                case 177:
                    return "knowledge transfer ";
                case 178:
                    return "correlation ";
                case 179:
                    return "capability ";
                case 180:
                    return "gamification ";
                case 181:
                    return "smooth transition ";
                case 182:
                    return "leadership strategy ";
                case 183:
                    return "collaboration ";
                case 184:
                    return "success factor ";
                case 185:
                    return "lever ";
                case 186:
                    return "breakthrough ";
                case 187:
                    return "open-door policy ";
                case 188:
                    return "recalibration ";
                case 189:
                    return "wow factor ";
                case 190:
                    return "onboarding solution ";
                case 191:
                    return "brand pyramid ";
                default:
                    return string.Empty;
            }
        }

        private string GetTimelessEvent()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    return "kick-off ";
                case 2:
                    return "roll-out ";
                case 3:
                    return "client-event ";
                case 4:
                    return "quarter results ";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetPluralAtom(int rand)
        {
            switch (rand)
            {
                case 1:
                    return "key target markets ";
                case 2:
                    return "style guidelines ";
                case 3:
                    return "key performance indicators ";
                case 4:
                    return "market conditions ";
                case 5:
                    return "market forces ";
                case 6:
                    return "market opportunities ";
                case 7:
                    return "tactics ";
                case 8:
                    return "organizing principles ";
                case 9:
                    return "interpersonal skills ";
                case 10:
                    return "roles and responsibilities ";
                case 11:
                    return "cost savings ";
                case 12:
                    return "lessons learned ";
                case 13:
                    return "client needs ";
                case 14:
                    return "requests / solutions ";
                case 15:
                    return "mobile strategies ";
                case 16:
                    return "expectations and allocations ";
                default:
                    return GetEventualPlural(GetInner(), Plurality.Plural);
            }
        }

        private string GetEventualPlural(string inner, Plurality plurality)
        {
            inner = inner.Trim();
            if (inner.Length < 1 || plurality == Plurality.Singular)
            {
                return inner;
            }

            if (inner == "matrix")
            {
                return "matrices";
            }

            if (inner == "analysis")
            {
                return "analyses";
            }

            char last = inner[inner.Length - 1];

            switch (last)
            {
                case 's':
                case 'x':
                case 'z':
                case 'h':
                    return inner + "es ";
                case 'y':
                    return inner.Substring(0, inner.Length - 1) + "ies ";
                default:
                    return inner + "s ";
            }
        }

        private string Vice()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 41);

            if (result > 0 && result < 11)
            {
                return "Vice ";
            }

            return result == 11 ? "Corporate Vice " : string.Empty;
        }

        private string Co()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 6);

            return result == 1 ? "Co-" : string.Empty;
        }

        private string Groupal()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 21);
            switch (result)
            {
                case 1:
                    return "Group ";
                case 2:
                    return "Global ";
                default:
                    return string.Empty;
            }
        }

        private string DepartmentOrTopRole()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 18);

            switch (result)
            {
                case 15:
                    return "Visionary";
                case 16:
                    return "Digital";
                case 17:
                    return "Technical";
                default:
                    return Department();
            }
        }
    }
}
