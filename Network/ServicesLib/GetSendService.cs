using Network.Shared.Dtos;
using Network.Shared;
using System.Text.Json;
using System.Text;

namespace ServicesLib
{
    public class GetSendService : IGetSend
    {
        public async Task<ServiceResponse<byte[]>> FormingMessageForSend(Message message)
        {
            var response = new ServiceResponse<byte[]>
            {
                Data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message))
            };

            return await Task.FromResult(response);
        }

        public async Task<Message> FormingMessageForGet(byte[] sendMessage)
        {
            if (sendMessage is null)
                return null;

            return await Task.FromResult(JsonSerializer.Deserialize<Message>(Encoding.UTF8.GetString(sendMessage)));
        }
    }
}