using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

namespace Microsoft.Dynamics365.UIAutomation.Api.UCI
{
    public class ModalDialog : Element
    {
        private readonly WebClient _client;

        public ModalDialog(WebClient client) : base()
        {
            _client = client;
        }

        /// <summary>
        /// Sets the value of a field in the quick create form
        /// </summary>
        /// <param name="field">Schema name of the field</param>
        /// <param name="value">Value of the field</param>
        public void SetValue(string field, string value)
        {
            _client.SetValue(field, value);
        }
    }
}
