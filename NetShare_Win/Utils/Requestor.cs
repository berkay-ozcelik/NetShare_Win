using NetShare_Core.Entity;
using System.IO.Pipes;
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
                _instance = new Requestor("NetShare");
            }

            return _instance;
        }

        private NamedPipeClientStream _pipeClient;

        private Encoding _encoding;
            

        private Requestor(string pipeName)
        {   
            _encoding = Encoding.UTF8;
            _pipeClient = new NamedPipeClientStream(pipeName);
            _pipeClient.Connect();
        }

        public CommandResult SendAndReceive(CommandRequest request)
        {
            var rawRequest = JsonSerializer.Serialize(request);

            WriteAll(_pipeClient, _encoding, rawRequest);

            var rawResponse = ReadAll(_pipeClient, _encoding);

            return JsonSerializer.Deserialize<CommandResult>(rawResponse);
        }

        private static string ReadAll(NamedPipeClientStream pipeServer, Encoding encoding)
        {

            byte[] buffer = new byte[4];

            pipeServer.Read(buffer, 0, buffer.Length);

            int bufferSize = BitConverter.ToInt32(buffer, 0);

            buffer = new byte[bufferSize];

            pipeServer.Read(buffer, 0, buffer.Length);

            return encoding.GetString(buffer);

        }

        private static void WriteAll(NamedPipeClientStream pipeServer, Encoding encoding, string data)
        {
            byte[] buffer = encoding.GetBytes(data);
            byte[] bufferSize = BitConverter.GetBytes(buffer.Length);

            byte[] message = new byte[bufferSize.Length + buffer.Length];

            bufferSize.CopyTo(message, 0);

            buffer.CopyTo(message, bufferSize.Length);


            pipeServer.Write(message, 0, message.Length);

            pipeServer.Flush();
        }
    }
}
