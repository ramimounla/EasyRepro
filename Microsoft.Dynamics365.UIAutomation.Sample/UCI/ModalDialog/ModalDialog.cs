using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
{
    [TestClass]
    public class ModalDialog : TestsBase
    {
        [TestMethod]
        public void UCITestDialogAccount()
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
                xrmApp.QuickCreate.SetValue("name", "A2");
                //xrmApp.Entity.SetValue("lastname", TestSettings.GetRandomString(5, 10));

                //xrmApp.Navigation.QuickCreate("account");
                //xrmApp.Entity.SetValue("name", "A1");
                //xrmApp.QuickCreate.SetValue("name", "A2");
                //xrmApp.ModalDialog.SetValue("name", "A3");
                //xrmApp.QuickCreate.Cancel();
                client.Browser.Driver.ExecuteScript("Xrm.Navigation.navigateTo({pageType:'entityrecord', entityName:'account', formType:2},{target: 2, position: 2, width: {value: 80, unit:'%'}})");
                
                //xrmApp.Entity.SetValue("name", "A1");
                xrmApp.ModalDialog.SetValue("name", "A3");
            }
        }
    }
}
