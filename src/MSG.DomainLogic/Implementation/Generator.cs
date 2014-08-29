using System.Collections.Generic;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic.Implementation
{
    public class Generator : IGenerator
    {
        /// <summary>
        /// Get a string representing the job title of a boss.
        /// </summary>
        /// <returns></returns>
        public string GetBoss()
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

        public string GetPerson(Plurality plurality)
        {
            return plurality == Plurality.Singular ? GetSingularPerson() : GetPluralPerson();
        }

        public List<string> GetSentences(int count)
        {
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

            switch (result)
            {
                case 1:
                    return "Managing ";
                case 2:
                    return "Acting ";
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    return string.Empty;
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
            //int result = DomainFactory.RandomNumber.GetRand(1, 64);
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

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
            int result = DomainFactory.RandomNumber.GetRand(1, 29);

            switch (result)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    return ApplySentenceCase(GetProposition());
                case 18:
                    return ApplySentenceCase(GetProposition() + "; this is why " + GetProposition());
                case 19:
                    return ApplySentenceCase(GetProposition() + "; nevertheless " + GetProposition());
                case 20:
                    return ApplySentenceCase(GetProposition() + "; whereas " + GetProposition());
                case 21:
                    return ApplySentenceCase("our gut feeling is that " + GetProposition());
                case 22:
                case 23:
                case 24:
                case 25:
                    return ApplySentenceCase(GetProposition() + ", while " + GetProposition());
                case 26:
                    return ApplySentenceCase(GetProposition() + ". At the same time, " + GetProposition());
                case 27:
                    return ApplySentenceCase(GetProposition() + ". As a result " + GetProposition());
                case 28:
                    return ApplySentenceCase(GetProposition() + ", whilst " + GetProposition());

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
                // TODO: See line 1303 - I think this plurality should be plural always.
                Plurality plurality = GetRandomPlurality();
                //return GetFaukon() + GetEventualAdverb() + GetPersonVerbAndEnding(plurality) + GetEventualPostfixedAdverb();
                return GetFaukon() + GetEventualAdverb() + GetPersonVerbAndEnding(Plurality.Plural) + GetEventualPostfixedAdverb();
            }

            if (result > 5 && result < 51)
            {
                Plurality plurality = GetRandomPlurality();
                return "The " + GetPerson(plurality) + GetEventualAdverb() + GetPersonVerbAndEnding(plurality) +
                       GetEventualPostfixedAdverb();
            }

            if (result > 50 && result < 93)
            {
                Plurality plurality = GetRandomPlurality();
                return GetRandomArticle(plurality, GetThing(plurality)) + GetEventualAdverb()
                       + GetThingVerbAndEnding(plurality) + GetEventualPostfixedAdverb();
            }

            if (result > 93 && result < 98)
            {
                return GetThingAtom(Plurality.Singular) + "and " + GetThingAtom(Plurality.Singular)
                       + GetEventualAdverb() + GetThingVerbAndEnding(Plurality.Plural)
                       + GetEventualPostfixedAdverb();
            }

            if (result > 98 && result < 101)
            {
                return GetThingAtom(Plurality.Singular).Trim() + ", " + GetThingAtom(Plurality.Singular)
                       + "and " + GetThingAtom(Plurality.Singular) + " " + GetEventualAdverb() +
                       GetThingVerbAndEnding(Plurality.Plural) + GetEventualPostfixedAdverb();
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThingVerbAndEnding(Plurality plurality)
        {
            Plurality innerPlurality = GetRandomPlurality();
            int result = DomainFactory.RandomNumber.GetRand(1, 102);

            if (result > 0 && result < 56)
            {
                return GetThingVerbHavingThingComplement(plurality) + " " +
                       GetRandomArticle(innerPlurality, GetThing(innerPlurality));
            }

            if (result > 56 && result < 101)
            {
                return GetThingVerbHavingPersonComplement(plurality) + " the " + GetPerson(innerPlurality);
            }

            return BuildPluralVerb("add", plurality) + " value";
        }

        private string GetThingVerbHavingPersonComplement(Plurality plurality)
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 13);
            int result = DomainFactory.RandomNumber.GetRand(1, 3);
            string item;

            switch (result)
            {
                case 1:
                    item = "motivate";
                    break;
                case 2:
                    item = "target";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            return BuildPluralVerb(item, plurality);

            //when 3 => return "enable";
            //when 4 => return "drive";
            //when 5 => return "synergize";
            //when 6 => return "empower";
            //when 7 => return "prioritize";
            //-- BBC office-speak phrases
            //when 8 => return "incentivise";
            //when 9 => return "inspire";
            //--
            //when 10 => return "transfer";
            //when 11 => return "promote";
            //when 12 => return "influence";
            //when 13 => return "strengthen";
        }

        private string GetThingVerbHavingThingComplement(Plurality plurality)
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 29);
            int result = DomainFactory.RandomNumber.GetRand(1, 3);
            string item;

            switch (result)
            {
                case 1:
                    item = "streamline";
                    break;
                case 2:
                    item = "interact with";
                    break;
                case 3:
                    item = "boost";
                    break;
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            return BuildPluralVerb(item, plurality);

            //when 4  => return "generate";
            //when 5  => return "impact";
            //when 6  => return "enhance";
            //when 7  => return "leverage";
            //when 8  => return "synergize";
            //when 9  => return "generate";
            //when 10 => return "empower";
            //when 11 => return "enable";
            //when 12 => return "prioritize";
            //when 13 => return "transfer";
            //when 14 => return "drive";
            //when 15 => return "result in";
            //when 16 => return "promote";
            //when 17 => return "influence";
            //when 18 => return "facilitate";
            //when 19 => return "aggregate";
            //when 20 => return "architect";
            //when 21 => return "cultivate";
            //when 22 => return "engage";
            //when 23 => return "structure";
            //when 24 => return "standardize";
            //when 25 => return "accelerate";
            //when 26 => return "deepen";
            //when 27 => return "strengthen";
            //when 28 => return "enforce";
            //when 29 => return "foster";
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

            // I think the original code is checking for spaces at the end of the input string.
            string last = verb.Substring(verb.Length - 1, 1);
            verb = verb.Trim();

            switch (last)
            {
                case "o":
                case "s":
                case "z":
                    return verb + "es";
                case "h":
                    string secondLast = verb.Substring(verb.Length - 2, 1);
                    if (secondLast == "c" || secondLast == "s")
                    {
                        return verb + "es";
                    }
                    return verb + "s";
                case "y":
                    if (IsVowel(verb.Substring(verb.Length - 2, 1)))
                    {
                        // If the second-last char is a vowel then append 's'.
                        // This covers "ploy" to "ploys".
                        return verb + "s";
                    }
                    else
                    {
                        // Remove the 'y' and append "ies".
                        // This covers "identify" to "identifies".
                        return verb.Substring(0, verb.Length - 1) + "ies";
                    }
                    // TODO: Review the original for what should be returned in the default
                    // case. It doesn't look right currently.
                    // This will not now be hit.
                    //return verb.Substring(0, verb.Length - 2) + "s";
                default:
                    return verb + "s";
            }
        }

        private string GetEventualPostfixedAdverb()
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 156);
            int result = DomainFactory.RandomNumber.GetRand(1, 11);

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

                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
            //when 11 => return " by leveraging " & Add_Random_Article (P, Thing (P));
            //when 12 => return " taking advantage of " & Add_Random_Article (P, Thing (P));
            //when 13 => return " within the " & Matrix_Or_So;
            //when 14 => return " across the " & Make_Eventual_Plural (Matrix_Or_So, Plural);
            //when 15 => return " across and beyond the " & Make_Eventual_Plural (Matrix_Or_So, Plural);
            //when 16 => return " resulting in " & Growth;
            //when 17 => return " reaped from our " & Growth;
            //when 18 => return " as a consequence of " & Growth;
            //when 19 => return " because " & Add_Random_Article (P, Thing (P))
            //                  & ' ' & Build_Plural_Verb ("produce", P) & ' ' & Growth;
            //when 20 => return " ahead of schedule";
            //when 21 => return ", relative to our peers";
            //when 22 => return " on a transitional basis";
            //when 23 => return " by expanding boundaries";
            //when 24 => return " by nurturing talent";
            //when 25 => return ", as a Tier 1 company";
            //when 26 => return " up-front";
            //when 27 => return " on-the-fly";
            //when 28 => return " across our portfolio";
            //when 29 => return " 50/50";
            //when 30 => return " up, down and across the " & Matrix_Or_So;
            //when 31 => return " in the marketplace";
            //when 32 => return " by thinking and acting beyond boundaries";
            //when 33 => return " at the individual, team and organizational level";
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
                return GetPersonVerbHavingBadThingComplement(plurality) + GetRandomArticle(plurality, GetBadThings());
            }

            if (result > 15 && result < 96)
            {
                return GetPersonVerbHavingThingComplement(plurality) + GetRandomArticle(plurality, GetThing(plurality));
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThing(Plurality plurality)
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 111);
            int result = DomainFactory.RandomNumber.GetRand(1, 10);

            if (result > 0 && result < 10)
            {
                return string.Format("{0}, {1}, {2} ", GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThingAdjective()
        {
            // LGA banned word list: http://news.bbc.co.uk/2/hi/7949077.stm
            //int result = DomainFactory.RandomNumber.GetRand(1, 251);
            int result = DomainFactory.RandomNumber.GetRand(1, 11);

            // The implementation of this list starts on line 191 of the original source. 
            // There's a lot so I'm not copying them in here in one lump.
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
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        // Thing() is implemented on 840.

        private string GetBadThings()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 22);

            switch (result)
            {
                case 1:
                    return "issues ";
                case 2:
                    return "intricacies";
                case 3:
                    return "organisational diseconomies";
                case 4:
                    return "black swans";
                case 5:
                    return "gaps ";
                case 6:
                    return "inefficiencies";
                case 7:
                    return "overlaps";
                case 8:
                    return "known unknowns";
                case 9:
                    return "unknown unknowns";
                case 10:
                    return "soft cycle issues";
                case 11:
                    return "obstacles";
                case 12:
                    return "surprises";
                case 13:
                    return "weaknesses";
                case 14:
                    return "threats";
                case 15:
                    return "barriers to success";
                case 16:
                    return "barriers";
                case 17:
                    return "shortcomings";
                case 18:
                    return "problems";
                case 19:
                    return "uncertainties";
                case 20:
                    return "unfavorable developments";
                case 21:
                    return "consumer/agent disconnects";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        public Plurality GetRandomPlurality()
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

            switch (result)
            {
                case 1:
                    return BuildPluralVerb("address", plurality);
                case 2:
                    return BuildPluralVerb("identify", plurality);
                case 3:
                    return BuildPluralVerb("avoid", plurality) + " ";
                case 4:
                    return BuildPluralVerb("mitigate", plurality);
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetPersonVerbAndComplement(Plurality plurality)
        {
            // Implements a function called Inner which I think is referenced in a few places.
            //int result = DomainFactory.RandomNumber.GetRand(1, 61);
            int result = DomainFactory.RandomNumber.GetRand(1, 11);

            switch (result)
            {
                case 1:
                    return "streamline the process ";
                case 2:
                    return "address the overarching issues ";
                case 3:
                    return "benchmark the portfolio ";
                case 4:
                    return "manage the cycle ";
                case 5:
                    return "figure out where we come from, where we are going to ";
                case 6:
                    return "maximise the value ";
                case 7:
                    return "execute the strategy ";
                case 8:
                    return "think outside the box ";
                case 9:
                    return "think differently ";
                case 10:
                    return "think across the full value chain ";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

            //when 11 => return "loop back";
            //when 12 => return "conversate";
            //when 13 => return "go forward together";
            //   --
            //when 14 => return "achieve efficiencies";
            //when 15 => return "deliver"; -- deliver, form without complement
            //                             -- GAC 2010
            //when 16 => return "stay in the mix";
            //when 17 => return "stay in the zone";
            //when 18 => return "evolve";
            //when 19 => return "exceed expectations";
            //when 20 => return "develop the plan";
            //when 21 => return "develop the blue print for execution";
            //when 22 => return "grow and diversify";
            //when 23 => return "fuel changes";
            //when 24 => return "nurture talent";
            //when 25 => return "cultivate talent";
            //when 26 => return "make it possible";
            //when 27 => return "manage the portfolio";
            //when 28 => return "align resources";
            //when 29 => return "drive the business forward";
            //when 30 => return "make things happen";
            //when 31 => return "stay ahead";
            //when 32 => return "outperform peers";
            //when 33 => return "surge ahead";
            //when 34 => return "manage the downside";
            //when 35 => return "stay in the wings";
            //when 36 => return "come to a landing";
            //when 37 => return "shoot it over";
            //when 38 => return "move the needle";
            //when 39 => return "connect the dots";
            //when 40 => return "connect the dots to the end game";
            //when 41 => return "reset the benchmark";
            //when 42 => return "take it offline";
            //when 43 => return "peel the onion";
            //when 44 => return "drill down";
            //when 45 => return "get from here to here";
            //when 46 => return "do things differently";
            //when 47 => return "stretch the status quo";
            //when 48 => return "challenge the status quo";
            //when 49 => return "challenge established ideas";
            //when 50 => return "increase customer satisfaction";
            //when 51 => return "enable customer interaction";
            //when 52 => return "manage the balance";
            //when 53 => return "turn every stone";
            //when 54 => return "drive revenue";
            //when 55 => return "rise to the challenge";
            //when 56 => return "keep it on the radar";
            //when 57 => return "stay on trend";
            //when 58 => return "hunt the business down";
            //when 59 => return "push the envelope to the tilt";
            //when 60 => return "execute on priorities";
        }

        private string GetEventualAdverb()
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 93);
            int result = DomainFactory.RandomNumber.GetRand(1, 24);

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
                    // TODO: Establish if this should be a random choice between singular and plural
                    // or whether it should do as here and follow the parent method.
                    return GetThingAtom(Plurality.Singular);
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
                    return "team building";
                case 3:
                    return "focus ";
                // ...etc
                default:
                    return GetInner().Trim();
            }
        }

        private string GetInner()
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 192);
            int result = DomainFactory.RandomNumber.GetRand(1, 12);

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
                    return "de-escalation "; // Note this doesn't exist in original.
                default:
                    return string.Empty;
            }

            //when 12 => return "system";
            //when 13 => return "Management Information System";
            //when 14 => return "Quality Management System";
            //when 15 => return "planning";
            //when 16 => return "target";
            //when 17 => return "calibration";
            //when 18 => return "Control Information System";
            //when 19 => return "process";
            //when 20 => return "talent";
            //when 21 => return "execution"; -- Winner 2006!
            //when 22 => return "leadership";
            //when 23 => return "performance";
            //when 24 => return "solution provider";
            //when 25 => return "value";
            //when 26 => return "value creation";
            //when 27 => return "feedback";
            //when 28 => return "document";
            //when 29 => return "bottom line";
            //when 30 => return "momentum";
            //when 31 => return "opportunity";
            //when 32 => return "credibility";
            //when 33 => return "issue";
            //when 34 => return "core meeting";
            //when 35 => return "platform";
            //when 36 => return "niche";
            //when 37 => return "content";
            //when 38 => return "communication";
            //when 39 => return "goal";
            //when 40 => return "skill";
            //when 41 => return "alternative";
            //when 42 => return "culture";
            //when 43 => return "requirement";
            //when 44 => return "potential";
            //when 45 => return "challenge";
            //when 46 => return "empowerment";
            //when 47 => return "benchmarking";
            //when 48 => return "framework";
            //when 49 => return "benchmark";
            //when 50 => return "implication";
            //when 51 => return "integration";
            //when 52 => return "enabler"; -- also person
            //when 53 => return "control";
            //when 54 => return "trend";
            //   -- the pyramid-cube 2004, added 2009:
            //when 55 => return "business case";
            //when 56 => return "architecture";
            //when 57 => return "action plan";
            //when 58 => return "project";
            //when 59 => return "review cycle";
            //when 11 => return "trigger event";
            //when 60 => return "strategy formulation";
            //when 61 => return "decision";
            //when 62 => return "enhanced data capture";
            //when 63 => return "energy";
            //when 64 => return "plan";
            //when 65 => return "initiative";
            //when 66 => return "priority";
            //when 67 => return "synergy";
            //when 68 => return "incentive";
            //when 69 => return "dialogue";
            //   -- Buzz Phrase Generator.xls (Kurt)
            //when 70 => return "concept";
            //when 71 => return "time-phase";
            //when 72 => return "projection";
            //   -- Merger buzz 2009:
            //when 73 => return "blended approach";
            //   -- BBC office-speak phrases
            //when 74 => return "low hanging fruit";
            //when 75 => return "forward planning";
            //when 76 => return "pre-plan"; -- also a verb
            //when 77 => return "pipeline";
            //when 78 => return "bandwidth";
            //when 79 => return "workshop";
            //when 80 => return "paradigm";
            //when 81 => return "paradigm shift";
            //when 82 => return "strategic staircase";
            //   --
            //when 83  => return "cornerstone";
            //when 84  => return "executive talent";
            //when 85  => return "evolution";
            //when 86  => return "workflow";
            //when 87  => return "message";
            //   -- GAC 2010
            //when 88  => return "risk/return profile";
            //when 89  => return "efficient frontier";
            //when 90  => return "pillar";
            //   -- Andy
            //when 91  => return "internal client";
            //when 92  => return "consistency";
            //   -- Ludovic
            //when 93  => return "on-boarding process";
            //   --
            //when 94  => return "dotted line";
            //when 95  => return "action item";
            //when 96  => return "cost efficiency";
            //when 97  => return "channel";
            //when 98  => return "convergence";
            //when 99  => return "infrastructure";
            //when 100 => return "metric";
            //when 101 => return "technology";
            //when 102 => return "relationship";
            //when 103 => return "partnership";
            //when 104 => return "supply-chain";
            //when 105 => return "portal";
            //when 106 => return "solution";
            //when 107 => return "business line";
            //when 108 => return "white paper";
            //when 109 => return "scalability";
            //when 110 => return "innovation";
            //when 111 => return "Strategic Management System";
            //when 112 => return "Balanced Scorecard";
            //when 113 => return "differentiator"; -- PDM
            //when 114 => return "case study";
            //when 115 => return "idiosyncrasy"; -- ED
            //when 116 => return "benefit";
            //when 117 => return "say/do ratio";
            //when 118 => return "segmentation";
            //when 119 => return "image";
            //when 120 => return "realignment";
            //when 121 => return "business model";
            //when 122 => return "business philosophy";
            //when 123 => return "branding";
            //when 124 => return "methodology";
            //when 125 => return "profile";
            //when 126 => return "measure";
            //when 127 => return "measurement";
            //when 128 => return "philosophy";
            //when 129 => return "branding strategy";
            //when 130 => return "efficiency";
            //when 131 => return "industry";
            //when 132 => return "commitment";
            //when 133 => return "perspective";
            //when 134 => return "risk appetite";
            //when 135 => return "best practice";
            //when 136 => return "brand identity";
            //when 137 => return "customer centricity"; -- Mili
            //when 138 => return "shareholder value"; -- Andrew
            //when 139 => return "attitude";
            //when 140 => return "mindset";
            //when 141 => return "flexibility";
            //when 142 => return "granularity";
            //when 143 => return "engagement";
            //when 144 => return "pyramid";
            //when 145 => return "market";
            //when 146 => return "diversity";
            //when 147 => return "interdependency";
            //when 148 => return "scaling";
            //when 149 => return "asset";
            //when 150 => return "flow charting";
            //when 151 => return "value proposition";
            //when 152 => return "performance culture";
            //when 153 => return "change";
            //when 154 => return "reward";
            //when 155 => return "learning";
            //when 156 => return "next step";
            //when 157 => return "delivery framework";
            //when 158 => return "structure";
            //when 159 => return "support structure";
            //when 160 => return "standardization";
            //when 161 => return "objective";
            //when 162 => return "footprint";
            //when 163 => return "transformation process";
            //when 164 => return "policy";
            //when 165 => return "sales target";
            //when 166 => return "ecosystem";
            //when 167 => return "landscape";
            //when 168 => return "atmosphere";
            //when 169 => return "environment";
            //when 170 => return "core competency";
            //when 171 => return "market practice";
            //when 172 => return "operating strategy";
            //when 173 => return "insight";
            //when 174 => return "accomplishment";
            //when 175 => return "correlation";
            //when 176 => return "touchpoint";
            //when 177 => return "knowledge transfer";
            //when 178 => return "correlation";
            //when 179 => return "capability";
            //when 180 => return "gamification";
            //when 181 => return "smooth transition";
            //when 182 => return "leadership strategy";
            //when 183 => return "collaboration";
            //when 184 => return "success factor";
            //when 185 => return "lever";
            //when 186 => return "breakthrough";
            //when 187 => return "open-door policy";
            //when 188 => return "recalibration";
            //when 189 => return "wow factor"; -- (obtained by bootstrapping)
            //when 190 => return "onboarding solution"; -- (obtained by bootstrapping)
            //when 191 => return "brand pyramid"; 
        }

        private string GetTimelessEvent()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    return "kick-off";
                case 2:
                    return "roll-out";
                case 3:
                    return "client-event";
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
                    return "key target markets";
                case 2:
                    return "style guidelines";
                default:
                    // TODO: As elsewhere, check if this should be random or derived from parent.
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
                    return inner + "es";
                case 'y':
                    return inner.Substring(0, inner.Length - 1) + "ies";
                default:
                    return inner + "s";
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
