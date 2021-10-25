using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA2;
using FlaUI.UIA3;
using System.IO;
using FlaUI.Core.AutomationElements;

namespace UnitTests
{
    [TestClass]
    public class UITest
    {

        private string _appPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + "\\bin\\Debug\\Calculator.exe";


        #region Plus
        [TestMethod]
        public void TestPlusButton()
        {
            string expected = "3";
            var app = FlaUI.Core.Application.Launch(_appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
                Console.WriteLine(window.Title);
                window.FindFirstDescendant(cf.ByAutomationId("TbA")).AsTextBox().Enter("1");
                window.FindFirstDescendant(cf.ByAutomationId("TbB")).AsTextBox().Enter("2");
                window.FindFirstDescendant(cf.ByAutomationId("BtnPlus")).AsButton().Click();
                var actual = window.FindFirstDescendant(cf.ByAutomationId("LbResult")).AsLabel().Text;
                app.Close();
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

        #region Minus
        [TestMethod]
        public void TestMinusButton()
        {
            string expected = "1";
            var app = FlaUI.Core.Application.Launch(_appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
                Console.WriteLine(window.Title);
                window.FindFirstDescendant(cf.ByAutomationId("TbA")).AsTextBox().Enter("2");
                window.FindFirstDescendant(cf.ByAutomationId("TbB")).AsTextBox().Enter("1");
                window.FindFirstDescendant(cf.ByAutomationId("BtnMinus")).AsButton().Click();
                var actual = window.FindFirstDescendant(cf.ByAutomationId("LbResult")).AsLabel().Text;
                app.Close();
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

        #region Multiply
        [TestMethod]
        public void TestMultiplyButton()
        {
            string expected = "9";
            var app = FlaUI.Core.Application.Launch(_appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
                Console.WriteLine(window.Title);
                window.FindFirstDescendant(cf.ByAutomationId("TbA")).AsTextBox().Enter("3");
                window.FindFirstDescendant(cf.ByAutomationId("TbB")).AsTextBox().Enter("3");
                window.FindFirstDescendant(cf.ByAutomationId("BtnMultiply")).AsButton().Click();
                var actual = window.FindFirstDescendant(cf.ByAutomationId("LbResult")).AsLabel().Text;
                app.Close();
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

        #region Subdivision
        [TestMethod]
        public void TestSubButton()
        {
            string expected = "3";
            var app = FlaUI.Core.Application.Launch(_appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
                Console.WriteLine(window.Title);
                window.FindFirstDescendant(cf.ByAutomationId("TbA")).AsTextBox().Enter("9");
                window.FindFirstDescendant(cf.ByAutomationId("TbB")).AsTextBox().Enter("3");
                window.FindFirstDescendant(cf.ByAutomationId("BtnSub")).AsButton().Click();
                var actual = window.FindFirstDescendant(cf.ByAutomationId("LbResult")).AsLabel().Text;
                app.Close();
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

        #region Exceptions

        [TestMethod]
        public void TestSubException()
        {
            string expected = "Попытка деления на нуль.";
            var app = FlaUI.Core.Application.Launch(_appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
                Console.WriteLine(window.Title);
                window.FindFirstDescendant(cf.ByAutomationId("TbA")).AsTextBox().Enter("9");
                window.FindFirstDescendant(cf.ByAutomationId("TbB")).AsTextBox().Enter("0");
                window.FindFirstDescendant(cf.ByAutomationId("BtnSub")).AsButton().Click();
                var actual = window.FindFirstDescendant(cf.ByAutomationId("LbInfo")).AsLabel().Text;
                app.Close();
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion

    }
}
