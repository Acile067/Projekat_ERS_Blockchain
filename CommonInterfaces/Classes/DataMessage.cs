namespace CommonInterfaces
{
    public enum MsgType
        {
            BLOCK,
            CLIENT_DATA,
            MINER_LIST,
        }
    public class DataMessage
    {
        public MsgType Type { get; set; } = MsgType.CLIENT_DATA;
        public int UserId { get; set; }
        public string Data { get; set; }
        public DateTime DateTime { get; set; }
    }
}
