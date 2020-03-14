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

                xrmApp.Navigation.OpenSubArea("Sales", "Contacts");

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("firstname", TestSettings.GetRandomString(5, 10));
                xrmApp.Entity.SetValue("lastname", TestSettings.GetRandomString(5, 10));

                client.Browser.Driver.ExecuteScript("Xrm.Navigation.navigateTo({pageType:'entityrecord', entityName:'account', formType:2},{target: 2, position: 2, width: {value: 80, unit:'%'}})");
                //xrmApp.QuickCreate.SetValue("name", TestSettings.GetRandomString(5, 10));
                xrmApp.ModalDialog.SetValue("name", TestSettings.GetRandomString(5, 10));

            }
        }
    }
}
