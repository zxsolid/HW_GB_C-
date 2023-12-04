using Network.Client.Services.Interfaces;

namespace Network.Client
{
    public class OurClient
    {
        private readonly IClientCommunication _clientCommunication;

        public OurClient(IClientCommunication clientCommunication)
        {
            _clientCommunication = clientCommunication;
        }

        public void Start()
        {
            HandleCommunication();
        }

        private void HandleCommunication()
        {
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input == null || string.IsNullOrEmpty(input))
                    continue;

                if (input.ToLower().Equals("exit"))
                {
                    _clientCommunication.Close();
                    break;
                }

                var parts = input.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("Клиент: Неверный формат ввода. Попробуйте снова.");
                    continue;
                }

                if (_clientCommunication.SendMessageAsync(parts).Result)
                {
                    if (!_clientCommunication.GetMessage().Result)
                    {
                        Console.WriteLine("Клиент: Ошибка обработки сообщения или сервер остановлен.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Клиент: Ошибка отправки сообщения");
                }
            }

            _clientCommunication.Close();
            Console.WriteLine("Клиент: Работа клиента завершена.");
        }
    }
}