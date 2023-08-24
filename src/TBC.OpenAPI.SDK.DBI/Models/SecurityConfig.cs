using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;

namespace TBC.OpenAPI.SDK.DBI.Models
{
    public class SecurityConfig : MessageHeader
    {
        private readonly string _username;
        private readonly string _password;
        private readonly string _nonce;

        public SecurityConfig(string username, string password, string nonce)
        {
            _username = username;
            _password = password;
            _nonce = nonce;
        }

        public SecurityConfig(SecurityCredentials securityCredentials)
        {
            _username = securityCredentials.Username;
            _password = securityCredentials.Password;
            _nonce = securityCredentials.Nonce;
        }

        [XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public class UsernameToken
        {
            public string Username { get; set; }

            public string Password { get; set; }

            public string Nonce { get; set; }
        }

        public override string Name { get; } = "Security";

        public override string Namespace { get; } = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            var serializer = new XmlSerializer(typeof(UsernameToken));
            serializer.Serialize(writer,
                new UsernameToken
                {
                    Username = _username,
                    Password = _password,
                    Nonce = _nonce
                });
        }
    }
}
