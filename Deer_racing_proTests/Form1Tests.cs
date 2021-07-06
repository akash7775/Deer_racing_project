using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deer_racing_pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deer_racing_pro.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            functionlLogic logic = new functionlLogic();
            if (logic.moveDeer() < 50)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void Form2Test()
        {
            functionlLogic logic = new functionlLogic();
            if (logic.stpTimer() ==980)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }


    }
}