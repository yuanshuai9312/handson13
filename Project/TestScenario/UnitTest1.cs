using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagementDriver;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Diagnostics;
using System.Collections.Generic;
using EmployeeManagement;

namespace TestScenario
{
    [TestClass]
    public class AdjustDriver
    {
        AppDriver _app;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new AppDriver();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _app.Release();
        }

        [TestMethod]
        public void TestAdd()
        {
            var addForm = _app.MainForm.ButtonAdd_EmulateClick();
            addForm.TextBoxName.EmulateChangeText("ishikawa-tatsuya");
            addForm.TextBoxAddress.EmulateChangeText("Japan");
            addForm.RadioButtonMan.EmulateCheck();
            addForm.ButtonEntry.EmulateClick();
            Assert.AreEqual("ishikawa-tatsuya(男) Japan", _app.MainForm.ListBoxEmployee_GetItemText(0));
        }

        [TestMethod]
        public void TestError()
        {
            var addForm = _app.MainForm.ButtonAdd_EmulateClick();
            addForm.TextBoxName.EmulateChangeText("ishikawa-tatsuya");
            addForm.TextBoxAddress.EmulateChangeText("Japan");
            Assert.AreEqual("性別を入力してください。", addForm.ButtonEntry_EmulateClickAndGetMessage());
            addForm.Close();
        }

        [TestMethod]
        public void TestAddShortcut()
        {
            List<EmployeeData> data = new List<EmployeeData>();
            for (int i = 0; i < 10000; i++)
            {
                data.Add(new EmployeeData()
                {
                    Name = "Name" + i.ToString(),
                    Address = "Osaka-" + i.ToString(),
                    IsMan = i % 2 == 0
                });
            }
            _app.MainForm.AddEmployeeData(data.ToArray());
        }
    }
}
