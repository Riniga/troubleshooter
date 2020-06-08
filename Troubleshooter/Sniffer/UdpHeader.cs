using System;
using System.IO;
using System.Net;

namespace Troubleshooter.Sniffer
{
    public class UdpHeader
    {
        private readonly ushort _sourcePort;
        private readonly ushort _destinationPort;
        private readonly ushort _length;
        private readonly short  _checksum;
        private readonly byte[] _udpPacketData = new byte[4096];

        public UdpHeader(byte [] byBuffer, int nReceived)
        {
            var memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            var binaryReader = new BinaryReader(memoryStream);
            _sourcePort      = ReadSixteenBitsAsSourcePort(binaryReader);
            _destinationPort = ReadSixteenBitsAsDestinationPort(binaryReader);
            _length          = ReadSixteenBitsAsUdpPackageLength(binaryReader);
            _checksum        = ReadSixteenBitsAsChecksum(binaryReader);            
            CopyDataIntoBuffer(byBuffer, nReceived);
        }

        private void CopyDataIntoBuffer(byte[] byBuffer, int nReceived)
        {
            Array.Copy(byBuffer,8, _udpPacketData,0,nReceived - 8);
        }

        private static short ReadSixteenBitsAsChecksum(BinaryReader binaryReader)
        {
            return IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        private static ushort ReadSixteenBitsAsUdpPackageLength(BinaryReader binaryReader)
        {
            return (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        private static ushort ReadSixteenBitsAsDestinationPort(BinaryReader binaryReader)
        {
            return (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        private static ushort ReadSixteenBitsAsSourcePort(BinaryReader binaryReader)
        {
            return (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        public string SourcePort => _sourcePort.ToString();
        public string DestinationPort => _destinationPort.ToString();
        public string Length => _length.ToString ();
        public string Checksum => $"0x{_checksum:x2}";
        public byte[] Data => _udpPacketData;
    }
}