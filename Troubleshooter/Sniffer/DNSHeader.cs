using System.IO;
using System.Net;

namespace Troubleshooter.Sniffer
{
    public class DnsHeader
    {
        private readonly ushort _identification;
        private readonly ushort _flags;
        private readonly ushort _totalQuestions;
        private readonly ushort _totalAnswers;
        private readonly ushort _totalAuthorities;
        private readonly ushort _totalAdditionals;

        public DnsHeader(byte []byBuffer, int nReceived)
        {
            var memoryStream = new MemoryStream(byBuffer, 0, nReceived);
            var binaryReader = new BinaryReader(memoryStream);    
   
            _identification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            _flags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            _totalQuestions = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            _totalAnswers = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            _totalAuthorities = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            _totalAdditionals = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
        }

        public string Identification => $"0x{_identification:x2}";
        public string Flags => $"0x{_flags:x2}";
        public string TotalQuestions => _totalQuestions.ToString();
        public string TotalAnswers => _totalAnswers.ToString();
        public string TotalAuthorityies => _totalAuthorities.ToString();
        public string TotalAdditionals => _totalAdditionals.ToString();
    }
}
