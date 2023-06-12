using NetShare_Core.Entity;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


namespace NetShare_Win.Communicator
{
    public  class Requestor
    {   

        private static Requestor _instance;

        public static Requestor GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Requestor("127.0.0.1:545");
            }

            return _instance;
        }

        private Socket _pipeClient;

        private Encoding _encoding;
            

        private Requestor(string endPoint)
        {   
            _encoding = Encoding.UTF8;
            _pipeClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _pipeClient.Connect(IPEndPoint.Parse(endPoint));
        }

        public CommandResult SendAndReceive(CommandRequest request)
        {
            var rawRequest = JsonSerializer.Serialize(request);

            WriteAll(_pipeClient, _encoding, rawRequest);

            var rawResponse = ReadAll(_pipeClient, _encoding);

            return JsonSerializer.Deserialize<CommandResult>(rawResponse);
        }

        private static string ReadAll(Socket pipeClient, Encoding encoding)
        {

            byte[] buffer = new byte[4];

            pipeClient.Receive(buffer);

            int bufferSize = BitConverter.ToInt32(buffer, 0);

            buffer = new byte[bufferSize];

            pipeClient.Receive(buffer);

            return encoding.GetString(buffer);

        }

        private static void WriteAll(Socket pipeClient, Encoding encoding, string data)
        {
            byte[] buffer = encoding.GetBytes(data);
            byte[] bufferSize = BitConverter.GetBytes(buffer.Length);

            byte[] message = new byte[bufferSize.Length + buffer.Length];

            bufferSize.CopyTo(message, 0);

            buffer.CopyTo(message, bufferSize.Length);

            pipeClient.Send(message);

        }
    }
}
