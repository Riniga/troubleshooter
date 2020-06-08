using System;
using System.IO;
using System.Net;

namespace Troubleshooter.Sniffer
{
    public class IpHeader
    {
        private readonly byte _versionAndHeaderLength;
        private readonly byte _differentiatedServices;
        private readonly ushort _totalLength;         
        private readonly ushort _identification;      
        private readonly ushort _flagsAndOffset;      
        private readonly byte _ttl;                   
        private readonly byte _protocol;              
        private readonly short _checksum;              
        private readonly uint _sourceIpAddress;       
        private readonly uint _destinationIpAddress;  
        private readonly byte _headerLength;          
        private readonly byte[] _ipData = new byte[4096];

        public IpHeader(byte[] byBuffer, int nReceived)
        {
            try
            {
                var memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                var binaryReader = new BinaryReader(memoryStream);

                _versionAndHeaderLength = binaryReader.ReadByte();
                _differentiatedServices = binaryReader.ReadByte();
                _totalLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _identification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _flagsAndOffset = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _ttl = binaryReader.ReadByte();
                _protocol = binaryReader.ReadByte();
                _checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                _sourceIpAddress = (uint)(binaryReader.ReadInt32());
                _destinationIpAddress = (uint)(binaryReader.ReadInt32());
                _headerLength = _versionAndHeaderLength;
                _headerLength <<= 4;
                _headerLength >>= 4;
                _headerLength *= 4;

                Array.Copy(byBuffer,
                           _headerLength,  //start copying from the end of the header
                           _ipData, 0,
                           _totalLength - _headerLength);
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message);
            }
        }

        public string Version
        {
            get
            {
                if ((_versionAndHeaderLength >> 4) == 4)
                {
                    return "IP v4";
                }
                if ((_versionAndHeaderLength >> 4) == 6)
                {
                    return "IP v6";
                }
                return "Unknown";
            }
        }

        public string HeaderLength => _headerLength.ToString();
        public ushort MessageLength => (ushort)(_totalLength - _headerLength);
        public string DifferentiatedServices => $"0x{_differentiatedServices:x2} ({_differentiatedServices})";
        public string Flags
        {
            get
            {
                int nFlags = _flagsAndOffset >> 13;
                if (nFlags == 2)
                {
                    return "Don't fragment";
                }
                if (nFlags == 1)
                {
                    return "More fragments to come";
                }
                return nFlags.ToString();
            }
        }
        public string FragmentationOffset
        {
            get
            {
                var nOffset = _flagsAndOffset << 3;
                nOffset >>= 3;
                return nOffset.ToString();
            }
        }
        public string Ttl => _ttl.ToString();
        public Protocol ProtocolType
        {
            get
            {
                if (_protocol == 6)
                {
                    return Protocol.TCP;
                }
                if (_protocol == 17)
                {
                    return Protocol.UDP;
                }
                return Protocol.Unknown;
            }
        }
        public string Checksum => $"0x{_checksum:x2}";
        public IPAddress SourceAddress => new IPAddress(_sourceIpAddress);
        public IPAddress DestinationAddress => new IPAddress(_destinationIpAddress);
        public string TotalLength => _totalLength.ToString();
        public string Identification => _identification.ToString();
        public byte[] Data => _ipData;
    }
}
