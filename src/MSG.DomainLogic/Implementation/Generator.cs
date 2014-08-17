using System.Collections.Generic;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic.Implementation
{
    public class Generator : IGenerator
    {
        public string GetBoss()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            switch (result)
            {
                case 1:
                    return Managing() + Age() + Exec() + Title() + " of " + Department();
                default:
                    return Groupal() + "Chief " + DepartmentOrTopRole() + " Officer";
            }
            
        }

        /// <summary>
        /// For a given random number, return a string representing the managing part of a job
        /// title.
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
                default:
                    return string.Empty;
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
                    return string.Empty;
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
                    return string.Empty;
            }
        }

        public string GetPerson()
        {
            // 1 == singular, 2 == plural
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            return result == 1
                ? GetSingularPerson(DomainFactory.RandomNumber.GetRand(1, 18))
                : GetPluralPerson(DomainFactory.RandomNumber.GetRand(1, 12));
        }

        public string GetPersonVerbHavingThingComplement()
        {
            return string.Empty;
            //Boss => Person => Person_Verb_Having_Thing_Complement etc.

            //Sentence_Guaranteed_Amount calls Sentences calls Sentence calls Articulated_Propositions calls Proposition calls Thing_Verb_And_Ending calls Person
            //Sentence_Guaranteed_Amount calls Sentences calls Sentence calls Articulated_Propositions calls Proposition calls Person

            //Workshop calls Sentence_Guaranteed_Amount 500 times.
            //Short_Workshop calls Sentence_Guaranteed_Amount 5 times.

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
                default:
                    return string.Empty;
                    //when 18       => return Proposition & "; this is why " & Proposition;
                    //when 19       => return Proposition & "; nevertheless " & Proposition;
                    //when 20       => return Proposition & ", whereas " & Proposition;
                    //when 21       => return "our gut-feeling is that " & Proposition;
                    //when 22 .. 25 => return Proposition & ", while " & Proposition;
                    //when 26       => return Proposition & ". In the same time, " & Proposition;
                    //when 27       => return Proposition & ". As a result, " & Proposition;
                    //when 28       => return Proposition & ", whilst " & Proposition;
            }
        }

        private string GetProposition()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 101);

            switch (result)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return GetFaukon() + GetEventualAdverb() + GetPersonVerbAndEnding() + GetEventualPostfixedAdverb();
                default:
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
                default:
                    return string.Empty;
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
            // TODO: Put a random selector in for this:
            const Plurality plurality = Plurality.Plural;

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
                    return GetPersonVerbAndComplement(plurality);
                case 11:
                    return GetPersonVerbHavingBadThingComplement(plurality);

                default:
                    return string.Empty;
            }

              //   when  1 .. 10  =>
              //      return Person_Verb_And_Complement (P);
              //   when 11 .. 15  => -- Fight-the-Evil situation
              //      return
              //        Person_Verb_Having_Bad_Thing_Complement (P) &
              //        ' ' &
              //        Add_Random_Article (Plural, Bad_Things);
              //   when 16 .. 95 =>
              //      return
              //        Person_Verb_Having_Thing_Complement (P) &
              //        ' ' &
              //        Add_Random_Article (Compl_Sp, Thing (Compl_Sp));
              //end case;
        }

        private string GetPersonVerbHavingBadThingComplement(Plurality plurality)
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 93);

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
                    return string.Empty;
            }
        }

        private string GetPersonVerbAndComplement(Plurality plurality)
        {
            // Implements a function called Inner which I think is referenced in a few places.
            int result = DomainFactory.RandomNumber.GetRand(1, 61);

            switch (result)
            {
                case 1:
                    return "streamline the process ";
                case 2:
                    return "address the overarching issues ";
                default:
                    return string.Empty;
            }

            //when 3  => return "benchmark the portfolio";
            //when 4  => return "manage the cycle";     -- Fad of 2004
            //when 5  => return "figure out where we come from, where we are going to";
            //when 6  => return "maximize the value";
            //when 7  => return "execute the strategy"; -- Obsessive in 2006
            //when 8  => return "think out of the box";
            //when 9  => return "think differently";
            //when 10 => return "think across the full value chain";
            //   -- BBC office-speak phrases
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
                    return "`credibly ";
                default:
                    return string.Empty;
            }

              //case R92 is -- proportion: 3/4 empty adverb
              //   when 1 => return "interactively ";
              //   when 2 => return "credibly ";
              //   when 3 => return "quickly ";
              //   when 4 => return "proactively ";
              //   when 5 => return "200% ";
              //   when 6 => return "24/7 ";
              //      -- UW Presentation Nov 2010
              //   when 7 => return "globally ";
              //   when 8 => return "culturally ";
              //   when 9 => return "technically ";
              //   --
              //   when 10 => return "strategically ";
              //   when 11 => return "swiftly ";
              //   when 12 => return "cautiously ";
              //   when 13 => return "expediently ";
              //   when 14 => return "organically ";
              //   when 15 => return "carefully ";
              //   when 16 => return "significantly ";
              //   when 17 => return "conservatively ";
              //   when 18 => return "adequately ";
              //   when 19 => return "genuinely ";
              //   when 20 => return "efficiently ";
              //   when 21 => return "seamlessly ";
              //   when 22 => return "consistently ";
              //   when 23 => return "diligently ";
              //   when others => return "";
              //end case;
        }

        private string GetFaukon()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 10);

            switch (result)
            {
                case 1:
                    return "we need to ";
                default:
                    return string.Empty;
            }
            //case R9 is
            //   when 1 => return "we need to";
            //   when 2 => return "we've got to";
            //   when 3 => return "the reporting unit should";
            //   when 4 => return "controlling should";
            //   when 5 => return "we must activate the " & Matrix_Or_So & " to";
            //   when 6 => return "pursuing this route will enable us to";
            //   when 7 => return "we will go the extra mile to";
            //   when 8 => return "we are working hard to";
            //   when 9 => return "we continue to work tirelessly and diligently to";
            //end case;
        }

        private string GetPluralPerson(int result)
        {
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
                default:
                    return string.Empty;
            }
        }

        private string GetSingularPerson(int result)
        {
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
                    return "thought leader";
                case 10:
                    return "gatekeeper";
                case 11:
                    return "resource";
                case 12:
                    return "senior support staff";
                default:
                    return GetBoss();
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
                    return string.Empty;
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
