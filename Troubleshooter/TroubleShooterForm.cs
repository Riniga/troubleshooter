using DnsClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Troubleshooter.Sniffer;
using Whois;

namespace Troubleshooter
{
    public partial class TroubleShooterForm : Form
    {
        private bool bContinueCapturing = false;            //A flag to check if packets are to be captured or not
        private IpSniffer ipSniffer = new IpSniffer();
        private delegate void AddTreeNode(TreeNode node);
        public TroubleShooterForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbInterfaces.Text == "")
            {
                MessageBox.Show("Select an Interface to capture the packets.", "Troubleshooter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (!bContinueCapturing)
                {
                    btnStart.Text = "&Stop";
                    bContinueCapturing = true;
                    treeView.Nodes.Clear();
                    var ipString = ((ComboboxItem)cmbInterfaces.SelectedItem).Value;

                    ipSniffer.BeginCapturingPackages(ipString, OnReceive);
                }
                else
                {
                    btnStart.Text = "&Start";
                    bContinueCapturing = false;
                    ipSniffer.StopCapturingPackages();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message);
            }
        }
        private void SnifferForm_Load(object sender, EventArgs e)
        {
            Logger.Instance.SetLoggerListBox(logListBox);
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics.Where(nic => nic.OperationalStatus == OperationalStatus.Up))
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();

                foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {

                        Logger.Instance.Log(adapter.Name + ": ip=" + ip.Address.ToString());

                        cmbInterfaces.Items.Add(new ComboboxItem() { Text = adapter.Name + "(" + ip.Address + ")", Value = ip.Address.ToString() });
                    }
                }
            }

            var types = Enum.GetValues(typeof(QueryType)).OfType<QueryType>().OrderBy(item => item.ToString()).ToList();
            types.Remove(QueryType.ANY);
            types.Insert(0, QueryType.ANY);

            foreach (var item in types)
            {
                queryTypeComboBox.Items.Add(item);
            }

            queryTypeComboBox.SelectedIndex = 0;
            if (cmbInterfaces.Items.Count > 0) cmbInterfaces.SelectedIndex = 0;

            if (File.Exists("pinglist.json"))
            {
                var json = File.ReadAllText("pinglist.json");
                var items = JsonConvert.DeserializeObject<List<string>>(json);
                foreach (var item in items)
                {
                    pingListListBox.Items.Add(item);
                }
            }
        }
        private void SnifferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bContinueCapturing) ipSniffer.Close();
        }
        private void treeView_DoubleClick(object sender, EventArgs e)
        {
            var selectedNode = treeView.SelectedNode.Text;

            if (selectedNode.Contains("Source:")) IpTextBox.Text = selectedNode.Replace("Source: ", "");
            if (selectedNode.Contains("Destination:")) IpTextBox.Text = selectedNode.Replace("Destination: ", "");
            if (selectedNode.Contains("Source Port:")) PortTextBox.Text = selectedNode.Replace("Source Port: ", "");
            if (selectedNode.Contains("Destination Port:")) PortTextBox.Text = selectedNode.Replace("Destination Port: ", "");
        }
        private void pingButton_Click(object sender, EventArgs e)
        {
            pingButton.Enabled = false;
            var result = PingHost(pingIpTextBox.Text);
            pingListBox.Items.Insert(0, result);
            pingButton.Enabled = true;
        }
        private void dnsLookupButton_Click(object sender, EventArgs e)
        {

            var client = new LookupClient();
            client.UseCache = true;
            client.EnableAuditTrail = true;
            var result = client.Query(dnsLookupNameTextBox.Text, (QueryType)queryTypeComboBox.SelectedItem);
            dnsLookupResultTextBox.Text = result.AuditTrail;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string row in pingListListBox.Items)
            {
                var fromto = row.Split('>');
                PingFromTo(fromto[0].Trim(), fromto[1].Trim());
            }
        }
        private void addPingButton_Click(object sender, EventArgs e)
        {
            pingListListBox.Items.Add($"{fromComputerTextBox.Text} > {toComputerTextBox.Text}");
            SavePingList();
        }
        private void pingListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pingListListBox.SelectedIndex >= 0)
                removePingButton.Enabled = true;
        }
        private void removePingButton_Click(object sender, EventArgs e)
        {
            pingListListBox.Items.RemoveAt(pingListListBox.SelectedIndex);
            removePingButton.Enabled = false;
            SavePingList();
        }
        private void whoIsLookUpButton_Click(object sender, EventArgs e)
        {
            var lookup = new WhoisLookup();
            var result = lookup.Lookup(whoisLookUpTextBox.Text);
            whoIsResultTextBox.Text = result.Content;
        }

        private void OnReceive(IAsyncResult result)
        {
            try
            {
                var received = ipSniffer.Receive(result);
                ParseData(ipSniffer.ByteData, received);
                if (bContinueCapturing)
                {
                    ipSniffer.ContinueCapturingPackages(OnReceive);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message);
            }
        }
        private void ParseData(byte[] byteData, int nReceived)
        {
            var rootNode = new TreeNode();
            var node = new TreeNode();

            var ipHeader = new IpHeader(byteData, nReceived);
            var ipNode = MakeIPTreeNode(ipHeader);
            rootNode.Nodes.Add(ipNode);

            uint destinationPort = 0;
            uint sourcePort = 0;


            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    var tcpHeader = new TcpHeader(ipHeader.Data, ipHeader.MessageLength);
                    destinationPort = uint.Parse(tcpHeader.DestinationPort);
                    sourcePort = uint.Parse(tcpHeader.DestinationPort);

                    node = MakeTCPTreeNode(tcpHeader);
                    break;
                case Protocol.UDP:
                    var udpHeader = new UdpHeader(ipHeader.Data, (int)ipHeader.MessageLength);
                    destinationPort = uint.Parse(udpHeader.DestinationPort);
                    sourcePort = uint.Parse(udpHeader.DestinationPort);
                    node = MakeUDPTreeNode(udpHeader);
                    break;
                case Protocol.Unknown:
                    break;
            }

            rootNode.Nodes.Add(node);
            rootNode.Text = ipHeader.SourceAddress + "->" + ipHeader.DestinationAddress;

            if (IsInFilter(ipHeader.SourceAddress.ToString(), ipHeader.DestinationAddress.ToString(), sourcePort, destinationPort, ipHeader.ProtocolType))
                treeView.Invoke(new AddTreeNode(OnAddTreeNode), new object[] { rootNode });
        }
        private bool IsInFilter(string sourceIp, string destinationIp, uint sourcePort, uint destinationPort, Protocol protocolType)
        {
            if (!string.IsNullOrEmpty(IpTextBox.Text))
                if (sourceIp != IpTextBox.Text && destinationIp != IpTextBox.Text) return false;
            if (!string.IsNullOrEmpty(PortTextBox.Text))
                if (sourcePort != uint.Parse(PortTextBox.Text) && destinationPort != uint.Parse(PortTextBox.Text)) return false;
            if (ProtocolComboBox.SelectedIndex >= 1)
            {
                logListBox.Items.Add("prot: " + ProtocolComboBox.SelectedItem.ToString());
                if (string.Compare(protocolType.ToString(), ProtocolComboBox.SelectedItem.ToString(), StringComparison.Ordinal) != 0) return false;

            }

            return true;

        }
        private TreeNode MakeIPTreeNode(IpHeader ipHeader)
        {
            TreeNode ipNode = new TreeNode();

            ipNode.Text = "IP";
            ipNode.Nodes.Add("Ver: " + ipHeader.Version);
            ipNode.Nodes.Add("Total Length: " + ipHeader.TotalLength);
            ipNode.Nodes.Add("Time to live: " + ipHeader.Ttl);
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    ipNode.Nodes.Add("Protocol: " + "TCP");
                    break;
                case Protocol.UDP:
                    ipNode.Nodes.Add("Protocol: " + "UDP");
                    break;
                case Protocol.Unknown:
                    ipNode.Nodes.Add("Protocol: " + "Unknown");
                    break;
            }
            ipNode.Nodes.Add("Source: " + ipHeader.SourceAddress.ToString());
            ipNode.Nodes.Add("Destination: " + ipHeader.DestinationAddress.ToString());

            return ipNode;
        }
        private TreeNode MakeTCPTreeNode(TcpHeader tcpHeader)
        {
            TreeNode tcpNode = new TreeNode();

            tcpNode.Text = "TCP";

            tcpNode.Nodes.Add("Source Port: " + tcpHeader.SourcePort);
            tcpNode.Nodes.Add("Destination Port: " + tcpHeader.DestinationPort);
            tcpNode.Nodes.Add("Sequence Number: " + tcpHeader.SequenceNumber);

            if (tcpHeader.AcknowledgementNumber != "")
                tcpNode.Nodes.Add("Acknowledgement Number: " + tcpHeader.AcknowledgementNumber);

            tcpNode.Nodes.Add("Header Length: " + tcpHeader.HeaderLength);
            tcpNode.Nodes.Add("Flags: " + tcpHeader.Flags);
            tcpNode.Nodes.Add("Window Size: " + tcpHeader.WindowSize);
            tcpNode.Nodes.Add("Checksum: " + tcpHeader.Checksum);

            if (tcpHeader.UrgentPointer != "")
                tcpNode.Nodes.Add("Urgent Pointer: " + tcpHeader.UrgentPointer);

            return tcpNode;
        }
        private TreeNode MakeUDPTreeNode(UdpHeader udpHeader)
        {
            TreeNode udpNode = new TreeNode();

            udpNode.Text = "UDP";
            udpNode.Nodes.Add("Source Port: " + udpHeader.SourcePort);
            udpNode.Nodes.Add("Destination Port: " + udpHeader.DestinationPort);
            udpNode.Nodes.Add("Length: " + udpHeader.Length);
            udpNode.Nodes.Add("Checksum: " + udpHeader.Checksum);

            return udpNode;
        }
        private TreeNode MakeDNSTreeNode(byte[] byteData, int nLength)
        {
            DnsHeader dnsHeader = new DnsHeader(byteData, nLength);
            TreeNode dnsNode = new TreeNode();

            dnsNode.Text = "DNS";
            dnsNode.Nodes.Add("Identification: " + dnsHeader.Identification);
            dnsNode.Nodes.Add("Flags: " + dnsHeader.Flags);
            dnsNode.Nodes.Add("Questions: " + dnsHeader.TotalQuestions);
            dnsNode.Nodes.Add("Answer RRs: " + dnsHeader.TotalAnswers);
            dnsNode.Nodes.Add("Authority RRs: " + dnsHeader.TotalAuthorityies);
            dnsNode.Nodes.Add("Additional RRs: " + dnsHeader.TotalAdditionals);

            return dnsNode;
        }
        private void OnAddTreeNode(TreeNode node)
        {
            treeView.Nodes.Insert(0, node);
        }
        private void SavePingList()
        {
            var json = JsonConvert.SerializeObject(pingListListBox.Items);
            File.WriteAllText("pinglist.json", json);
        }
        private string PingHost(string nameOrAddress)
        {
            Ping pinger = null;
            PingReply reply = null;
            try
            {
                pinger = new Ping();
                reply = pinger.Send(nameOrAddress);
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            if (reply != null)
            {
                if (reply.Status == IPStatus.Success)
                    return "Reply from " + nameOrAddress + ": bytes = " + reply.Buffer.Length + " time < " + reply.RoundtripTime + "ms Ttl = " + reply.Options.Ttl;
                else
                    return "Reply from " + nameOrAddress + " time out!";
            }

            return "Pinging " + nameOrAddress + " failed!";
        }
        private void PingFromTo(string from, string to)
        {
            var ps = PowerShell.Create();
            var block = ScriptBlock.Create("{ }");

            ps.AddCommand("Invoke-Command");
            ps.AddParameter("ComputerName", from);
            ps.AddParameter("ScriptBlock", ScriptBlock.Create(@"param(${computername}, ${count}) Test-Connection -ComputerName ${computername} -Count ${count}")); ps.AddParameter("ArgumentList", new object[] { to, 1 });

            var result = ps.Invoke();
            if (result.Count == 0)
                listBox2.Items.Add($"Request from {from} gave NO reply from {to}!");
            else
                foreach (var psObject in result)
                {
                    psObject.ToString().Split(',');
                    foreach (var prop in psObject.Properties)
                    {
                        logListBox.Items.Add($"Property {prop.Name} = {prop.Value}");
                    }

                    listBox2.Items.Add(
                        $"Request from  {psObject.Properties["PSComputerName"].Value} gave reply from {to}({psObject.Properties["IPV4Address"].Value}) in time:{psObject.Properties["ResponseTime"].Value}ms  ");
                }
        }
    }
}

