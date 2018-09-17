using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;

namespace GameofLifeDojo
{
    [TestFixture]
    class GivenA2x2Grid
    {
        class WhenSeedingWithOneCell
        {
            LifeGrid lifeGrid = new LifeGrid(2, 2);
            private bool[,] _result;

            [SetUp]
            public void WhenGeneratingNextGeneration()
            {
                lifeGrid.Seed(0, 0);
                _result = lifeGrid.Generate();
            }

            [Test]
            public void ThenTheResultGridIsAsExpected()
            {
                Assert.IsFalse(_result[0,0]);
                Assert.IsFalse(_result[0, 1]);
                Assert.IsFalse(_result[1, 0]);
                Assert.IsFalse(_result[1, 1]);
            }
        }

        class WhenSeedingWithTwoCells
        {
            LifeGrid lifeGrid = new LifeGrid(2, 2);
            private bool[,] _result;

            [SetUp]
            public void WhenGeneratingNextGeneration()
            {
                lifeGrid.Seed(0, 0);
                lifeGrid.Seed(0, 1);
                _result = lifeGrid.Generate();
            }

            [Test]
            public void ThenTheResultGridIsAsExpected()
            {
                Assert.IsFalse(_result[0, 0]);
                Assert.IsFalse(_result[0, 1]);
                Assert.IsFalse(_result[1, 0]);
                Assert.IsFalse(_result[1, 1]);
            }
        }

        class WhenSeedingWithThreeCells
        {
            LifeGrid lifeGrid = new LifeGrid(2, 2);
            private bool[,] _result;

            [SetUp]
            public void WhenGeneratingNextGeneration()
            {
                lifeGrid.Seed(0, 0);
                lifeGrid.Seed(0, 1);
                lifeGrid.Seed(1,0);
                _result = lifeGrid.Generate();
            }

            [Test]
            public void ThenTheResultGridIsAsExpected()
            {
                Assert.IsTrue(_result[0, 0]);
                Assert.IsTrue(_result[0, 1]);
                Assert.IsTrue(_result[1, 0]);
                Assert.IsTrue(_result[1, 1]);
            }
        }

        class WhenSeedingWithFourCells
        {
            LifeGrid lifeGrid = new LifeGrid(2, 2);
            private bool[,] _result;

            [SetUp]
            public void WhenGeneratingNextGeneration()
            {
                lifeGrid.Seed(0, 0);
                lifeGrid.Seed(0, 1);
                lifeGrid.Seed(1, 0);
                lifeGrid.Seed(1, 1);
                _result = lifeGrid.Generate();
            }

            [Test]
            public void ThenTheResultGridIsAsExpected()
            {
                Assert.IsTrue(_result[0, 0]);
                Assert.IsTrue(_result[0, 1]);
                Assert.IsTrue(_result[1, 0]);
                Assert.IsTrue(_result[1, 1]);
            }
        }
    }

}