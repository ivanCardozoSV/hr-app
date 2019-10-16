using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace HrApp.API.Queries
{
    public class GetProcessesQuery : HttpCommand
    {
        private readonly string endpoint;

        public GetProcessesQuery()
        {
            this.endpoint = api + "Process";
        }

        public override HttpResponseMessage Execute()
        {
            var reciever = HttpReceiver.GetReceiver().SetToken(Application.Current.Properties[Constants.ValidatedUserToken].ToString());
            return reciever.Get(endpoint);
        }
    }
}
