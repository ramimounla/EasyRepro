using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI.Broken
{
    [TestClass]
    public class BrokenTest : TestsBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password);

                xrmApp.Navigation.OpenApp(UCIAppName.Sales);

                xrmApp.Navigation.OpenSubArea("Sales", "Accounts");

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("name", "A1");
                xrmApp.Navigation.QuickCreate("account");
                xrmApp.QuickCreate.SetValue("name", "A2"); // << Will fail due to attribute not clickable
            }
        }
    }
}
