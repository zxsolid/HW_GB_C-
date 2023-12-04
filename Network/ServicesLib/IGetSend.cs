using Network.Shared;
using Network.Shared.Dtos;

namespace ServicesLib
{
    public interface IGetSend
    {
        Task<ServiceResponse<byte[]>> FormingMessageForSend(Message message);
        Task<Message> FormingMessageForGet(byte[] sendMessage);
    }
}