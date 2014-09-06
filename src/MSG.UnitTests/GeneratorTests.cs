using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GeneratorTests
    {
        [Test]
        public void VerifyBlankManaging()
        {
            MoqUtil.SetupRandMock(1, 7, 2, 2, 3, 2, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Marketing ", boss);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            MoqUtil.SetupRandMock(1, 1, 2, 2, 3, 2, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Head of Marketing ", boss);
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head of Operations ", boss);
        }

        [Test]
        public void VerifyDirectorTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 1, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Director of Legal ", boss);
        }

        [Test]
        public void VerifyChiefTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Customer Relations ", boss);
        }

        [Test]
        public void VerifyHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Legal ", boss);
        }

        [Test]
        public void VerifyCoHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 1, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Co-Head of Operations ", boss);
        }

        [Test]
        public void VerifyPresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 17, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("President of Customer Relations ", boss);
        }

        [Test]
        public void VerifyVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Vice President of Marketing ", boss);
        }

        [Test]
        public void VerifyCorporateVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 11, 13);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Corporate Vice President of IT Operations ", boss);
        }

        [Test]
        public void VerifySeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Customer Relations ", boss);
        }

        [Test]
        public void VerifyNoSeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Marketing ", boss);
        }

        [Test]
        public void VerifySeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 1, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Executive Chief of Customer Relations ", boss);
        }

        [Test]
        public void VerifyNoSeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Legal ", boss);
        }

        [Test]
        public void VerifyDepartment()
        {
            MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 9);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head of Client Relationship ", boss);
        }

        [Test]
        public void VerifySpacingInActingSeniorExecutiveHead()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 2, 12);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);
        }

        [Test]
        public void VerifySpacingInManagingDirector()
        {
            MoqUtil.SetupRandMock(1, 1, 2, 2, 1, 12, 10);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Director of Business Planning ", boss);
        }

        [Test]
        public void VerifyBoss()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 12, 12);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.IsNotNull(boss);
            Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);
        }

        [Test]
        public void VerifyBossAlt()
        {
            MoqUtil.SetupRandMock(2, 1, 17);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.IsNotNull(boss);
            Assert.AreEqual("Group Chief Technical Officer ", boss);
        }

        [Test]
        public void VerifyChiefSpacing()
        {
            MoqUtil.SetupRandMock(2, 3, 14, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.IsNotNull(boss);
            Assert.AreEqual("Chief Operations Officer ", boss);
        }

        [Test]
        public void VerifyGroupChiefSpacing()
        {
            MoqUtil.SetupRandMock(2, 1, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.IsNotNull(boss);
            Assert.AreEqual("Group Chief Digital Officer ", boss);
        }

        [Test]
        public void VerifyGlobalChiefSpacing()
        {
            MoqUtil.SetupRandMock(2, 2, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.IsNotNull(boss);
            Assert.AreEqual("Global Chief Digital Officer ", boss);
        }

        [Test]
        public void FixExtraSpace()
        {
            List<int> defaults = new List<int> { 14, 51, 1, 2, 1, 3, 277, 11, 11, 21, 2, 82, 2, 7, 10, 1, 8, 3, 2, 250, 8, 4 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("An efficient, constructive, trigger event seamlessly targets the enablers using our constructive, strategic, baseline starting point.", output);
        }

        [Test]
        public void FixPluralSpace()
        {
            List<int> defaults = new List<int> { 16, 95, 173, 7, 159, 5, 6, 2, 29, 2, 3, 9, 2, 105, 5, 4, 7 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Win-win solution and timeline 24/7 interact with our cost-effective, strategic, timelines throughout the organisation.", output);
        }

        [Test]
        public void EnsureDeEscalationSpacing()
        {
            List<int> defaults = new List<int> { 23, 34, 2, 6, 4, 32, 2, 4, 8, 4, 10, 11, 1, 7, 1, 8, 1, 16, 2, 1, 9, 6, 4, 3, 2, 1 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The team players proactively target corporate, proactive, roles and responsibilities going forward, while the powerful champion interactively targets our cost-effective, key, strategy within the industry.", output);
        }

        [Test]
        public void FixSpaceAtEnd()
        {
            List<int> defaults = new List<int> { 6, 26, 1, 2, 13, 95, 2, 4, 1, 4, 8, 203, 1, 2, 10, 2, 4, 6, 9, 50, 11, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The group expediently targets an efficient, proactive, intelligence going forward.", output);
        }

        [Test]
        public void FixMissingWord()
        {
            List<int> defaults = new List<int> { 5, 43, 1, 15, 4, 16, 8, 1, 9, 3, 1, 1, 1, 1 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The Chief Human Resources Officer technically streamlines the process going forward.", output);
        }

        [Test]
        public void SpacingAgain()
        {
            List<int> defaults = new List<int> { 26, 40, 1, 1, 21, 61, 1, 2, 3, 2, 9, 280, 11, 3, 9, 60, 1, 7, 1, 5, 7, 8, 1, 5, 2, 90, 2, 1, 7 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The steering committee seamlessly manages a constructive, strategic, governance by leveraging the parallel, efficient, tactics. At the same time, we will go the extra mile to culturally figure out where we come from, where we are going to within the industry.", output);
        }

        [Test]
        public void LoopBackGoingForward()
        {
            List<int> defaults = new List<int> { 17, 5, 1, 8, 1, 11, 1, 1, 1, 1 };

            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("We need to culturally loop back going forward.", output);
        }

        [Test]
        public void CapitalLetterAtStartGetPerson()
        {
            // Change the 14 to hit other branches of GetProposition() and make sure they
            // are all capitalised.
            List<int> defaults = new List<int> { 5, 14, 1, 15, 3, 11, 4, 5, 22, 54, 2, 2, 1, 5, 4, 4, 3, 6 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The Chief Operations Officer consistently targets our efficient, strong, strategy across the board.", output);
        }

        [Test]
        public void CapitalLetterAtStartGetFaukon()
        {
            List<int> defaults = new List<int> { 5, 4, 1, 3, 11, 4, 5, 22, 2 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("We need to quickly mitigate gaps within the industry.", output);
        }

        [Test]
        public void CapitalLetterAtStartGetRandomArticle()
        {
            List<int> defaults = new List<int> { 5, 66, 1, 5, 3, 7, 4, 5, 22, 18, 2, 2, 1, 5, 4, 8, 2, 9, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Our constructive, global, strategy consistently interacts with the strong, proactive, organizing principles by thinking outside the box.", output);
        }

        [Test]
        public void CapitalLetterAtStartGetThingAtomAnd()
        {
            // Note the duplicated "strategic" in the output.
            List<int> defaults = new List<int> { 5, 97, 1, 4, 3, 7, 4, 5, 3, 9, 2, 2, 1, 5, 4, 8, 2, 15, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Quarter results and focus globally boost our strategic, strategic, key target markets in this space.", output);
        }

        [Test]
        public void CapitalLetterAtStartGetThingAtom()
        {
            List<int> defaults = new List<int> { 5, 100, 1, 4, 3, 7, 4, 5, 3, 9, 2, 2, 1, 5, 4, 8, 2, 9, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Quarter results, focus and implementation proactively generate our strategic, efficient, market forces as part of the plan.", output);
        }

        [Test]
        public void IncorrectPluralTest()
        {
            List<int> defaults = new List<int> { 13, 28, 1, 3, 4, 93, 2, 3, 2, 9, 458, 4, 9, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The project manager proactively targets a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void AnotherPluralTest()
        {
            List<int> defaults = new List<int> { 26, 36, 2, 1, 13, 27, 1, 1, 5, 4, 6, 404, 7, 8, 7, 1, 1, 7, 10, 1, 5, 1, 14, 6, 2, 14, 1, 7, 6, 1, 184, 4, 13, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The key people expediently manage strong, proactive, market opportunities throughout the organisation. At the same time, the key people interactively think across the full value chain going forward.", output);
        }

        [Test]
        public void TwoSpacingErrors()
        {
            List<int> defaults = new List<int> { 17, 8, 2, 8, 6, 11, 3, 5, 12, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The stakeholders 24/7 avoid gaps as part of the plan.", output);
        }

        [Test]
        public void SpacingErrorsEnablers()
        {
            List<int> defaults = new List<int> { 25, 6, 9, 7, 4, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The enablers proactively figure out where we come from, where we are going to in this space, while we've got to interactively benchmark the portfolio in this space.", output);
        }

        [Test]
        public void IncorrectBossCapitalisation()
        {
            List<int> defaults = new List<int> { 22, 46, 2, 5, 12, 61, 27, 7, 166, 231, 55, 137, 10, 1, 47, 1, 6, 13, 70, 5, 3, 197, 206, 180, 46, 4, 1 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The resources cautiously prioritise outsourced, hyper-hybrid, customer centricities going forward, while the sales manager expediently optimises our phased, fine-grained, empowerment going forward.", output);
        }

        [Test]
        public void IncorrectBossCapitalisation2()
        {
            List<int> defaults = new List<int> { 27, 13, 2, 8, 13, 65, 25, 9, 223, 149, 187, 9, 11, 8, 12, 2, 11, 2, 1, 3, 9 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The stakeholders expediently enable end-to-end, collaborative, sign-offs as part of the plan. As a result the business leaders credibly benchmark the portfolio by thinking outside the box.", output);
        }

        [Test]
        public void IncorrectPluralSurprise()
        {
            List<int> defaults = new List<int> { 14, 17, 1, 16, 4, 1, 12, 3, 2, 14, 1, 12, 11, 4 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The Group Chief Internal Audit Officer credibly addresses surprises in this space.", output);
        }

        [Test]
        public void SpacingErrorPrioritise()
        {
            List<int> defaults = new List<int> { 13, 61, 2, 1, 168, 86, 143, 104, 12, 20, 1, 69, 7, 12, 9 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Bottom-up, customer-centric, supply-chains efficiently prioritise the senior support staff by thinking outside the box.", output);
        }

        [Test]
        public void SpacingErrorAvoids()
        {
            List<int> defaults = new List<int> { 25, 10, 1, 12, 16, 11, 3, 1, 5, 7, 61, 5, 90, 16, 16, 1, 101, 4, 1, 2, 3, 4, 5, 6, 7, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The senior support staff significantly avoids our issues throughout the organisation, while expectations and allocations interactively streamline our constructive, proactive, market forces throughout the organisation.", output);
        }

        [Test]
        public void SpaceBeforeFullStop()
        {
            List<int> defaults = new List<int> { 2, 57, 2, 13, 135, 239, 183, 60, 8, 9, 2, 3, 7, 25, 191, 143, 179, 4, 49 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Time-phased and innovative strategy formulations technically leverage our rock-solid capabilities.", output);
        }

        [Test]
        public void SpacingErrorMeasurementShorter()
        {
            List<int> defaults = new List<int> { 10, 75, 1, 89, 117, 162, 5, 46, 1, 16, 17, 104, 285, 37, 8, 89 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Our footprint influences a content.", output);
        }

        [Test]
        public void FullStopSpaceBefore()
        {
            //1,93,306,129,232,117,70,2,84,10,4,138
            //"Branding strategy and say/do ratio transfer the clients ."
        }

        [Test]
        public void NewPluralProblem()
        {
            //17,31,1,2,21,10,31,143,
            // The group seamlessly stay aheads.
        }
    }
}
