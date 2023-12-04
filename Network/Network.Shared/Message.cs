using System.Text.Json;

namespace Network.Shared
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public UserEntity NickNameFrom { get; set; }
        public UserEntity NickNameTo { get; set; }

        public Message(string text, UserEntity nickNameFrom, UserEntity nickNameTo)
        {
            Text = text;
            DateTime = DateTime.Now;
            NickNameFrom = nickNameFrom;
            NickNameTo = nickNameTo;
        }


    }
}