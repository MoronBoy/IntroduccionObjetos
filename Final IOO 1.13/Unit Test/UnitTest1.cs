using System;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Enemy testEnemy = EnemyFactory.GetEnemy(EnemyFactory.EnemyType.SwordEnemyHorizontal, 100, 100);

            Assert.IsTrue(testEnemy.EnemyWeapon is Rifle);
        }
    }
}
