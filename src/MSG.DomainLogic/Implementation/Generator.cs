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

        public string Managing()
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

        public string Age()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 5);

            return result == 1 ? "Senior " : string.Empty;
        }

        public string Exec()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 7);

            return result == 1 ? "Executive " : string.Empty;
        }

        public string Title()
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

        public string Department()
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
