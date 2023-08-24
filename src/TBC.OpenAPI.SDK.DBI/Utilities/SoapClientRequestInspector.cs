using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TBC.OpenAPI.SDK.DBI.Models;

namespace TBC.OpenAPI.SDK.DBI.Utilities
{
    internal sealed class SoapClientRequestInspector : IClientMessageInspector
    {
        private readonly SecurityCredentials _securityCredentials;

        public SoapClientRequestInspector(SecurityCredentials securityCredentials)
        {
            _securityCredentials = securityCredentials;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(int.MaxValue);
            request = buffer.CreateMessage();

            request.Headers.RemoveAt(0);
            request.Headers.Add(new SecurityConfig(_securityCredentials));

            return null;
        }
    }
}