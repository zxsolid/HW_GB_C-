using Network.Server.Services.Interfaces;

namespace Network.Server
{
    public class OurServer
    {
        private readonly IServerCommunication _serverCommunication;

        public OurServer(IServerCommunication serverCommunication)
        {
            _serverCommunication = serverCommunication;
        }

        public void Started()
        {
            _serverCommunication.Start();
        }
    }
}