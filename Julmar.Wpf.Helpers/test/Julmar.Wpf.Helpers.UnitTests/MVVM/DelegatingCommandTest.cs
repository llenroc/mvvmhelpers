﻿using JulMar.Windows.Mvvm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace JulMar.Wpf.Helpers.UnitTests
{
    /// <summary>
    ///This is a test class for DelegatingCommandTest and is intended
    ///to contain all DelegatingCommandTest Unit Tests
    ///</summary>
    [TestClass]
    public class DelegatingCommandTest
    {
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Test a single registration
        ///</summary>
        [TestMethod]
        public void ActionWithNoParamTest()
        {
            ICommand command = new DelegatingCommand(OnAction);

            Assert.AreEqual(true, command.CanExecute(null), "CanExecute did not return true");
            command.Execute(null);
            Assert.AreEqual(1, calledAction, "Command did not invoked OnAction");
        }

        /// <summary>
        /// Test a single registration
        ///</summary>
        [TestMethod]
        public void ActionWithParamTest()
        {
            ICommand command = new DelegatingCommand(OnAction2);

            Assert.AreEqual(true, command.CanExecute(5), "CanExecute did not return true");
            command.Execute(5);
            Assert.AreEqual(5, calledAction, "Command did not invoked OnAction2");
        }

        /// <summary>
        /// Test CanExecute logic
        ///</summary>
        [TestMethod]
        public void CanExecuteTest()
        {
            ICommand command = new DelegatingCommand(OnAction, () => false);
            Assert.AreEqual(false, command.CanExecute(null), "CanExecute did not return false");
        }

        /// <summary>
        /// Test CanExecute logic
        ///</summary>
        [TestMethod]
        public void CanExecuteTestWithParam()
        {
            ICommand command = new DelegatingCommand(OnAction2, (o) => !((bool)o));
            Assert.AreEqual(false, command.CanExecute(true), "CanExecute did not return false");
        }

        private int calledAction;
        void OnAction()
        {
            calledAction = 1;
        }

        void OnAction2(object parameter)
        {
            calledAction = (int) parameter;
        }
    }
}