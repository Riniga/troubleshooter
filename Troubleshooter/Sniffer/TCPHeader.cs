using System;
using System.IO;
using System.Net;

namespace Troubleshooter.Sniffer
{
    public class TcpHeader
    {
        private readonly ushort _sourcePort;
        private readonly ushort _destinationPort;
        private readonly uint   _sequenceNumber=555;
        private readonly uint   _acknowledgementNumber=555;
        private readonly ushort _dataOffsetAndFlags=555;
        private readonly ushort _window=555;
        private readonly short  _checksum=555;
        private readonly ushort _urgentPointer;
        private readonly byte   _headerLength;
        private readonly ushort _messageLength;
        private readonly byte[] _tcpData = new byte[4096];
       
        public TcpHeader(byte [] byBuffer, int nReceived)
        {
            try
            {
                var memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                var binaryReader = new BinaryReader(memoryStream);
           
                _sourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());
                _destinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16 ());
                _sequenceNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
                _acknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
                _dataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _window = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _checksum = (short)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _urgentPointer = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _headerLength = (byte)(_dataOffsetAndFlags >> 12);
                _headerLength *= 4;
                _messageLength = (ushort)(nReceived - _headerLength);
                //Array.Copy(byBuffer, _headerLength, _tcpData, 0, nReceived - _headerLength);
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message);
            }
        }

        public string SourcePort => _sourcePort.ToString();

        public string DestinationPort => _destinationPort.ToString ();

        public string SequenceNumber => _sequenceNumber.ToString();

        public string AcknowledgementNumber
        {
            get
            {
                if ((_dataOffsetAndFlags & 0x10) != 0)
                {
                    return _acknowledgementNumber.ToString();
                }
                return "";
            }
        }

        public string HeaderLength => _headerLength.ToString();

        public string WindowSize => _window.ToString();

        public string UrgentPointer
        {
            get
            {
                if ((_dataOffsetAndFlags & 0x20) != 0)
                {
                    return _urgentPointer.ToString();
                }
                return "";
            }
        }

        public string Flags
        {
            get
            {
                var nFlags = _dataOffsetAndFlags & 0x3F;
                var strFlags = $"0x{nFlags:x2} (";

                if ((nFlags & 0x01) != 0)
                {
                    strFlags += "FIN, ";
                }
                if ((nFlags & 0x02) != 0)
                {
                    strFlags += "SYN, ";
                }
                if ((nFlags & 0x04) != 0)
                {
                    strFlags += "RST, ";
                }
                if ((nFlags & 0x08) != 0)
                {
                    strFlags += "PSH, ";
                }
                if ((nFlags & 0x10) != 0)
                {
                    strFlags += "ACK, ";
                }
                if ((nFlags & 0x20) != 0)
                {
                    strFlags += "URG";
                }
                strFlags += ")";

                if (strFlags.Contains("()"))
                {
                    strFlags = strFlags.Remove(strFlags.Length - 3);
                }
                else if (strFlags.Contains(", )"))
                {
                    strFlags = strFlags.Remove(strFlags.Length - 3, 2);
                }

                return strFlags;
            }
        }

        public string Checksum => string.Format("0x{0:x2}", _checksum);
        public byte[] Data => _tcpData;
        public ushort MessageLength => _messageLength;
    }
}