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

        public string GetPerson(Plurality plurality)
        {
            if (plurality == Plurality.Singular)
            {
                return GetSingularPerson(DomainFactory.RandomNumber.GetRand(1, 18));
            }

            return GetPluralPerson(DomainFactory.RandomNumber.GetRand(1, 12));
        }

        private string GetPluralPerson(int result)
        {
            switch (result)
            {
                case 1:
                    return "key people";
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
                default:
                    return GetBoss();
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
