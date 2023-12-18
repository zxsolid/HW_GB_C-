using Network.Shared;
using System.Net.Sockets;
using System.Net;
using Network.Client.Services.Interfaces;
using ServicesLib;

namespace Network.Client.Services.Classes
{
    public class ClientCommunication : IClientCommunication
    {
        private readonly UdpClient _udpClient;
        private readonly IGetSend _getSendService;
        private IPEndPoint _iPEndPoint;
        private readonly IPrintMessage _printMessage;

        public ClientCommunication(UdpClient udpClient, IGetSend getSendService, IPrintMessage printMessage)
        {
            _udpClient = udpClient;
            _getSendService = getSendService;
            _printMessage = printMessage;
            _iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        }

        public async Task<bool> SendMessageAsync(string[] parts)
        {
            Message message = new Message(parts[0], new UserEntity(parts[1]), new UserEntity(parts[2]));

            var sendMessage = await _getSendService.FormingMessageForSend(message);

            if (sendMessage is null)
                return await Task.FromResult(false);


            await _udpClient.SendAsync(sendMessage.Data, sendMessage.Data.Length, _iPEndPoint);

            return await Task.FromResult(true);
        }

        public async Task<bool> GetMessage()
        {
            try
            {
                var receiveResult = await _udpClient.ReceiveAsync();
                byte[] buffer = receiveResult.Buffer;

                Message? getMessage = await _getSendService.FormingMessageForGet(buffer);

                if (getMessage is null)
                {
                    Console.WriteLine("Клиент: Ошибка обработки сообщения.");
                    return await Task.FromResult(false);
                }

                _printMessage.Print(getMessage);

                if (getMessage.Text.Equals("Сервер остановлен"))
                    return await Task.FromResult(false);

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        public void Close()
        {
            _udpClient.Close();
        }
    }
}