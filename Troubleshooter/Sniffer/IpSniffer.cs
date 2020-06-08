using System;
using System.Net;
using System.Net.Sockets;

namespace Troubleshooter.Sniffer
{
    internal class IpSniffer
    {
        private Socket _mainSocket;
        private byte[] _byteData = new byte[4096];

        internal void BeginCapturingPackages(string ipString, Action<IAsyncResult> onReceive)
        {
            _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            _mainSocket.Bind(new IPEndPoint(IPAddress.Parse(ipString), 0));

            _mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            byte[] byTrue = new byte[] { 1, 0, 0, 0 };
            byte[] byOut = new byte[] { 1, 0, 0, 0 };

            _mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);
            _mainSocket.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None, new AsyncCallback(onReceive), null);
        }
        internal void ContinueCapturingPackages(Action<IAsyncResult> onReceive)
        {
            _byteData = new byte[4096];
            _mainSocket.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None, new AsyncCallback(onReceive), null);
        }


        internal void StopCapturingPackages()
        {
            _mainSocket.Close();
        }
        
        public int Receive(IAsyncResult result)
        {
            return _mainSocket.EndReceive(result);
        }

        public byte[] ByteData => _byteData;
        internal void Close()
        {
            _mainSocket.Close();
        }
    }
}