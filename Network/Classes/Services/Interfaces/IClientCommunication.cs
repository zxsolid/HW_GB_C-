namespace Network.Client.Services.Interfaces
{
    public interface IClientCommunication
    {
        Task<bool> SendMessageAsync(string[] parts);
        Task<bool> GetMessage();
        void Close();
    }
}