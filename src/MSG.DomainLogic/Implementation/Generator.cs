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
                case 2:
                    return Groupal() + "Chief " + DepartmentOrTopRole() + " Officer ";
                default:
                    return string.Empty;
            }
            
        }

        public string GetPerson()
        {
            // 1 == singular, 2 == plural
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            return result == 1
                ? GetSingularPerson()
                : GetPluralPerson();
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
                    return "manage ";
                case 2:
                    return "target ";
                case 3:
                    return "streamline ";
                case 4:
                    return "improve ";
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
                    return GetProposition();
                case 18:
                    return GetProposition() + "; this is why " + GetProposition();
                case 19:
                    return GetProposition() + "; nevertheless " + GetProposition();
                case 20:
                    return GetProposition() + "; whereas " + GetProposition();
                case 21:
                    return "our gut feeling is that " + GetProposition();
                case 22:
                case 23:
                case 24:
                case 25:
                    return GetProposition() + ", while " + GetProposition();
                case 26:
                    return GetProposition() + ". At the same time, " + GetProposition();
                case 27:
                    return GetProposition() + ". As a result " + GetProposition();
                case 28:
                    return GetProposition() + ", whilst " + GetProposition();

                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }
        }

        private string GetProposition()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 101);

            // Switching to if statements instead of enormous case statements.
            if (result > 0 && result < 6)
            {
                return GetFaukon() + GetEventualAdverb() + GetPersonVerbAndEnding() + GetEventualPostfixedAdverb();
            }

            if (result > 5 && result < 51)
            {
                return "the " + GetPerson() + GetEventualAdverb() + GetPersonVerbAndEnding() +
                       GetEventualPostfixedAdverb();
            }

            return string.Empty;

            //   when 1 .. 5    => -- "We need to..."
            //      return
            //      Faukon & ' ' &
            //      Eventual_Adverb &
            //      Person_Verb_And_Ending (Plural) & -- Trick to get the infinitive
            //      Eventual_Postfixed_Adverb;
            //      -- infinitive written same as present plural
            //   when 6 .. 50    => -- ** PERSON...
            //      return
            //        "the " & Person (Sp1) & ' ' &
            //        Eventual_Adverb &
            //        Person_Verb_And_Ending (Sp1) &
            //        Eventual_Postfixed_Adverb;
            //   when 51 .. 92   => -- ** THING...
            //      return
            //      Add_Random_Article (Sp1, Thing (Sp1)) & ' ' &
            //      Eventual_Adverb &
            //      Thing_Verb_And_Ending (Sp1) &
            //      Eventual_Postfixed_Adverb;
            //   when 93..97     => -- ** thing and thing ...
            //      return -- nb: no article, no adjective
            //      Thing_Atom (Singular) & " and " &
            //      Thing_Atom (Singular) & ' ' &
            //      Eventual_Adverb &
            //      Thing_Verb_And_Ending (Plural) &
            //      Eventual_Postfixed_Adverb;
            //   when 98..100    => -- ** thing, thing and thing ...
            //      return -- nb: no article, no adjective
            //      Thing_Atom (Singular) & ", " &
            //      Thing_Atom (Singular) & " and " &
            //      Thing_Atom (Singular) & ' ' &
            //      Eventual_Adverb &
            //      Thing_Verb_And_Ending (Plural) &
            //      Eventual_Postfixed_Adverb;
            //end case;
        }

        private string GetEventualPostfixedAdverb()
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 156);
            int result = DomainFactory.RandomNumber.GetRand(1, 4);

            switch (result)
            {
                case 1:
                    return "going forward";
                case 2:
                    return "within the industry";
                case 3:
                    return "across the board";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

             //when 4 => return " in this space";
             //when 5 => return " from the get-go";
             //when 6 => return " at the end of the day";
             //when 7 => return " throughout the organization";
             //when 8 => return " as part of the plan";
             //when 9 => return " by thinking outside of the box";
             //when 10 => return " using " & Add_Random_Article (P, Thing (P));
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

        private string GetPersonVerbAndEnding()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 96);

            Plurality plurality = GetRandomPlurality();

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
                return string.Format("{0}, {1}, {2}", GetThingAdjective(), GetThingAdjective(), GetThingAtom(plurality));
            }

            throw new RandomNumberException(result + " is an invalid value.");
        }

        private string GetThingAdjective()
        {
            // LGA banned word list: http://news.bbc.co.uk/2/hi/7949077.stm
            //int result = DomainFactory.RandomNumber.GetRand(1, 251);
            int result = DomainFactory.RandomNumber.GetRand(1, 4);

            // The implementation of this list starts on line 191 of the original source. 
            // There's a lot so I'm not copying them in here in one lump.
            switch (result)
            {
                case 1:
                    return "efficient ";
                case 2:
                    return "strategic";
                case 3:
                    return "constructive";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }            
        }

        // Thing() is implemented on 840.

        private string GetBadThings()
        {
            //int result = DomainFactory.RandomNumber.GetRand(1, 22);
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            switch (result)
            {
                case 1:
                    return "issues";
                case 2:
                    return "intricacies";
                default:
                    throw new RandomNumberException(result + " is an invalid value.");
            }

      //            case R21 is
      //   when 1  => return "issues";
      //   when 2  => return "intricacies";
      //   when 3  => return "organizational diseconomies";
      //   when 4  => return "black swans";
      //   when 5  => return "gaps";
      //   when 6  => return "inefficiencies";
      //   when 7  => return "overlaps";
      //   when 8  => return "known unknowns";
      //   when 9  => return "unknown unknowns";
      //   when 10 => return "soft cycle issues";
      //   when 11 => return "obstacles";
      //   when 12 => return "surprises";
      //   when 13 => return "weaknesses"; -- The W in SWOT
      //   when 14 => return "threats";    -- The T in SWOT
      //   when 15 => return "barriers to success";
      //   when 16 => return "barriers";
      //   when 17 => return "shortcomings";
      //   when 18 => return "problems";
      //   when 19 => return "uncertainties";
      //   when 20 => return "unfavorable developments";
      //   when 21 => return "consumer/agent disconnects";
      //end case;
        }

        private Plurality GetRandomPlurality()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            return result == 1 ? Plurality.Singular : Plurality.Plural;
        }

        private string GetPersonHavingThingComplement(Plurality plurality)
        {
            return string.Empty;
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

            // TODO: Add Build_Plural_Verb call like the original code here.
            switch (result)
            {
                case 1:
                    return "address";
                case 2:
                    return "identify";
                case 3:
                    return "avoid";
                case 4:
                    return "mitigate";
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
                    return "key people";
                case 2:
                    return "human resources";
                case 3:
                    return "customers";
                case 4:
                    return "clients";
                case 5:
                    return "resources";
                case 6:
                    return "team players";
                case 7:
                    return "enablers";
                case 8:
                    return "stakeholders";
                case 9:
                    return "standard-setters";
                case 10:
                    return "partners";
                case 11:
                    return "business leaders";
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
                    return "steering committee";
                case 2:
                    return "group";
                case 3:
                    return "project manager";
                case 4:
                    // TODO: Establish if this should be a random choice between singular and plural
                    // or whether it should do as here and follow the parent method.
                    return GetThingAtom(Plurality.Singular);
                case 5:
                    return "community";
                case 6:
                    return "sales manager";
                case 7:
                    return "enabler";
                case 8:
                    return "powerful champion";
                case 9:
                    return "thought leader ";
                case 10:
                    return "gatekeeper";
                case 11:
                    return "resource";
                case 12:
                    return "senior support staff";
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
                    return "focus";
                // ...etc
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
                    return "mission";
                case 2:
                    return "vision";
                case 3:
                    return "guideline";
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
                    return "kick-off";
                case 2:
                    return "roll-out";
                case 3:
                    return "client-event";
                case 4:
                    return "quarter results";
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
