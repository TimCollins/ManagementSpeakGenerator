﻿using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class BuildPluralVerbTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 13, 28, 1, 3, 4, 93, 3, 2, 9, 458, 4, 9, 3 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void BuildPluralVerbManages()
        {
            _defaults.Insert(6, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively manages a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbTargets()
        {
            _defaults.Insert(6, 2); 
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively targets a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbStreamlines()
        {
            _defaults.Insert(6, 3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively streamlines a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbImproves()
        {
            _defaults.Insert(6, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively improves a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbEstablishes()
        {
            _defaults.Insert(6, 55);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively establishes a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbTelegraphs()
        {
            _defaults.Insert(6, 64);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively telegraphs a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbJustifies()
        {
            _defaults.Insert(6, 65);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively justifies a strategic, cost-effective, roadmap across the board.", output);
        }

        [Test]
        public void BuildPluralVerbDisplays()
        {
            _defaults.Insert(6, 66);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The project manager proactively displays a strategic, cost-effective, roadmap across the board.", output);
        }

        // Tests for GetThingVerbHavingPersonComplement
        [Test]
        public void BuildPluralVerbMotivates()
        {
            _defaults.ReplaceAt(1, 52);            
            _defaults.ReplaceAt(5, 6);
            _defaults.ReplaceAt(9, 2);
            _defaults.ReplaceAt(10, 66);
            _defaults.ReplaceAt(11, 1);
            _defaults.Add(4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The proactive, key, focus technically motivates the customers in this space.", output);
        }

        [Test]
        public void BuildPluralVerbInspires()
        {
            _defaults.ReplaceAt(1, 52);
            _defaults.ReplaceAt(5, 6);
            _defaults.ReplaceAt(9, 2);
            _defaults.ReplaceAt(10, 66);
            _defaults.ReplaceAt(11, 9);
            _defaults.Add(4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The proactive, key, focus technically inspires the customers in this space.", output);
        }

        [Test]
        public void BuildPluralVerbTransfer()
        {
            _defaults.ReplaceAt(1, 52);
            _defaults.ReplaceAt(5, 6);
            _defaults.ReplaceAt(9, 2);
            _defaults.ReplaceAt(10, 66);
            _defaults.ReplaceAt(11, 10);
            _defaults.Add(4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The proactive, key, focus technically transfers the customers in this space.", output);
        }

        [Test]
        public void BuildPluralVerbStrengthen()
        {
            _defaults.ReplaceAt(1, 52);
            _defaults.ReplaceAt(5, 6);
            _defaults.ReplaceAt(9, 2);
            _defaults.ReplaceAt(10, 66);
            _defaults.ReplaceAt(11, 13);
            _defaults.Add(4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The proactive, key, focus technically strengthens the customers in this space.", output);
        }
    }
}
