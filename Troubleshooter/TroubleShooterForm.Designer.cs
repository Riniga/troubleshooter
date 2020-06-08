namespace Troubleshooter
{
    partial class TroubleShooterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView = new System.Windows.Forms.TreeView();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.InterfacesLabel = new System.Windows.Forms.Label();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.ProtocolLabel = new System.Windows.Forms.Label();
            this.ProtocolComboBox = new System.Windows.Forms.ComboBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ipSnifferTabPage = new System.Windows.Forms.TabPage();
            this.pingTabPage = new System.Windows.Forms.TabPage();
            this.pingListBox = new System.Windows.Forms.ListBox();
            this.pingIpLabel = new System.Windows.Forms.Label();
            this.pingButton = new System.Windows.Forms.Button();
            this.pingIpTextBox = new System.Windows.Forms.TextBox();
            this.pingKingTabPage = new System.Windows.Forms.TabPage();
            this.removePingButton = new System.Windows.Forms.Button();
            this.addPingButton = new System.Windows.Forms.Button();
            this.pingListListBox = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toComputerTextBox = new System.Windows.Forms.TextBox();
            this.fromComputerTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dnsTabPage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.queryTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dnsLookupResultTextBox = new System.Windows.Forms.TextBox();
            this.dnsNameLabel = new System.Windows.Forms.Label();
            this.dnsLookupButton = new System.Windows.Forms.Button();
            this.dnsLookupNameTextBox = new System.Windows.Forms.TextBox();
            this.whoIsTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.whoIsResultTextBox = new System.Windows.Forms.TextBox();
            this.lookUpLabel = new System.Windows.Forms.Label();
            this.whoIsLookUpButton = new System.Windows.Forms.Button();
            this.whoisLookUpTextBox = new System.Windows.Forms.TextBox();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.TabControl.SuspendLayout();
            this.ipSnifferTabPage.SuspendLayout();
            this.pingTabPage.SuspendLayout();
            this.pingKingTabPage.SuspendLayout();
            this.dnsTabPage.SuspendLayout();
            this.whoIsTabPage.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(17, 86);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(416, 630);
            this.treeView.TabIndex = 0;
            this.treeView.DoubleClick += new System.EventHandler(this.treeView_DoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(342, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 33);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(17, 19);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(416, 21);
            this.cmbInterfaces.TabIndex = 2;
            // 
            // InterfacesLabel
            // 
            this.InterfacesLabel.AutoSize = true;
            this.InterfacesLabel.Location = new System.Drawing.Point(14, 3);
            this.InterfacesLabel.Name = "InterfacesLabel";
            this.InterfacesLabel.Size = new System.Drawing.Size(94, 13);
            this.InterfacesLabel.TabIndex = 3;
            this.InterfacesLabel.Text = "From/to interface: ";
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(17, 59);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(131, 20);
            this.IpTextBox.TabIndex = 4;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(14, 43);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(57, 13);
            this.IpLabel.TabIndex = 5;
            this.IpLabel.Text = "From/to IP";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(212, 43);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 7;
            this.PortLabel.Text = "Port";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(214, 59);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(68, 20);
            this.PortTextBox.TabIndex = 6;
            // 
            // ProtocolLabel
            // 
            this.ProtocolLabel.AutoSize = true;
            this.ProtocolLabel.Location = new System.Drawing.Point(154, 43);
            this.ProtocolLabel.Name = "ProtocolLabel";
            this.ProtocolLabel.Size = new System.Drawing.Size(52, 13);
            this.ProtocolLabel.TabIndex = 9;
            this.ProtocolLabel.Text = "Protocol: ";
            // 
            // ProtocolComboBox
            // 
            this.ProtocolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProtocolComboBox.FormattingEnabled = true;
            this.ProtocolComboBox.Items.AddRange(new object[] {
            "All",
            "TCP",
            "UDP"});
            this.ProtocolComboBox.Location = new System.Drawing.Point(154, 59);
            this.ProtocolComboBox.Name = "ProtocolComboBox";
            this.ProtocolComboBox.Size = new System.Drawing.Size(54, 21);
            this.ProtocolComboBox.TabIndex = 8;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.ipSnifferTabPage);
            this.TabControl.Controls.Add(this.pingTabPage);
            this.TabControl.Controls.Add(this.pingKingTabPage);
            this.TabControl.Controls.Add(this.dnsTabPage);
            this.TabControl.Controls.Add(this.whoIsTabPage);
            this.TabControl.Controls.Add(this.logTabPage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(463, 759);
            this.TabControl.TabIndex = 11;
            // 
            // ipSnifferTabPage
            // 
            this.ipSnifferTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.ipSnifferTabPage.Controls.Add(this.treeView);
            this.ipSnifferTabPage.Controls.Add(this.ProtocolLabel);
            this.ipSnifferTabPage.Controls.Add(this.btnStart);
            this.ipSnifferTabPage.Controls.Add(this.ProtocolComboBox);
            this.ipSnifferTabPage.Controls.Add(this.cmbInterfaces);
            this.ipSnifferTabPage.Controls.Add(this.PortLabel);
            this.ipSnifferTabPage.Controls.Add(this.InterfacesLabel);
            this.ipSnifferTabPage.Controls.Add(this.PortTextBox);
            this.ipSnifferTabPage.Controls.Add(this.IpTextBox);
            this.ipSnifferTabPage.Controls.Add(this.IpLabel);
            this.ipSnifferTabPage.Location = new System.Drawing.Point(4, 22);
            this.ipSnifferTabPage.Name = "ipSnifferTabPage";
            this.ipSnifferTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ipSnifferTabPage.Size = new System.Drawing.Size(455, 733);
            this.ipSnifferTabPage.TabIndex = 0;
            this.ipSnifferTabPage.Text = "IP Sniffer";
            // 
            // pingTabPage
            // 
            this.pingTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.pingTabPage.Controls.Add(this.pingListBox);
            this.pingTabPage.Controls.Add(this.pingIpLabel);
            this.pingTabPage.Controls.Add(this.pingButton);
            this.pingTabPage.Controls.Add(this.pingIpTextBox);
            this.pingTabPage.Location = new System.Drawing.Point(4, 22);
            this.pingTabPage.Name = "pingTabPage";
            this.pingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pingTabPage.Size = new System.Drawing.Size(455, 733);
            this.pingTabPage.TabIndex = 2;
            this.pingTabPage.Text = "Ping";
            // 
            // pingListBox
            // 
            this.pingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pingListBox.FormattingEnabled = true;
            this.pingListBox.Location = new System.Drawing.Point(17, 44);
            this.pingListBox.Name = "pingListBox";
            this.pingListBox.Size = new System.Drawing.Size(856, 667);
            this.pingListBox.TabIndex = 8;
            // 
            // pingIpLabel
            // 
            this.pingIpLabel.AutoSize = true;
            this.pingIpLabel.Location = new System.Drawing.Point(14, 2);
            this.pingIpLabel.Name = "pingIpLabel";
            this.pingIpLabel.Size = new System.Drawing.Size(16, 13);
            this.pingIpLabel.TabIndex = 7;
            this.pingIpLabel.Text = "Ip";
            // 
            // pingButton
            // 
            this.pingButton.Location = new System.Drawing.Point(165, 5);
            this.pingButton.Name = "pingButton";
            this.pingButton.Size = new System.Drawing.Size(91, 33);
            this.pingButton.TabIndex = 5;
            this.pingButton.Text = "&Ping";
            this.pingButton.UseVisualStyleBackColor = true;
            this.pingButton.Click += new System.EventHandler(this.pingButton_Click);
            // 
            // pingIpTextBox
            // 
            this.pingIpTextBox.Location = new System.Drawing.Point(17, 18);
            this.pingIpTextBox.Name = "pingIpTextBox";
            this.pingIpTextBox.Size = new System.Drawing.Size(131, 20);
            this.pingIpTextBox.TabIndex = 6;
            // 
            // pingKingTabPage
            // 
            this.pingKingTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.pingKingTabPage.Controls.Add(this.removePingButton);
            this.pingKingTabPage.Controls.Add(this.addPingButton);
            this.pingKingTabPage.Controls.Add(this.pingListListBox);
            this.pingKingTabPage.Controls.Add(this.listBox2);
            this.pingKingTabPage.Controls.Add(this.button1);
            this.pingKingTabPage.Controls.Add(this.label2);
            this.pingKingTabPage.Controls.Add(this.toComputerTextBox);
            this.pingKingTabPage.Controls.Add(this.fromComputerTextBox);
            this.pingKingTabPage.Controls.Add(this.label3);
            this.pingKingTabPage.Location = new System.Drawing.Point(4, 22);
            this.pingKingTabPage.Name = "pingKingTabPage";
            this.pingKingTabPage.Size = new System.Drawing.Size(455, 733);
            this.pingKingTabPage.TabIndex = 4;
            this.pingKingTabPage.Text = "Ping King";
            // 
            // removePingButton
            // 
            this.removePingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removePingButton.Enabled = false;
            this.removePingButton.Location = new System.Drawing.Point(11, 691);
            this.removePingButton.Name = "removePingButton";
            this.removePingButton.Size = new System.Drawing.Size(91, 33);
            this.removePingButton.TabIndex = 16;
            this.removePingButton.Text = "&Remove";
            this.removePingButton.UseVisualStyleBackColor = true;
            this.removePingButton.Click += new System.EventHandler(this.removePingButton_Click);
            // 
            // addPingButton
            // 
            this.addPingButton.Location = new System.Drawing.Point(159, 18);
            this.addPingButton.Name = "addPingButton";
            this.addPingButton.Size = new System.Drawing.Size(91, 33);
            this.addPingButton.TabIndex = 15;
            this.addPingButton.Text = "&Add";
            this.addPingButton.UseVisualStyleBackColor = true;
            this.addPingButton.Click += new System.EventHandler(this.addPingButton_Click);
            // 
            // pingListListBox
            // 
            this.pingListListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pingListListBox.FormattingEnabled = true;
            this.pingListListBox.Location = new System.Drawing.Point(11, 58);
            this.pingListListBox.Name = "pingListListBox";
            this.pingListListBox.Size = new System.Drawing.Size(239, 628);
            this.pingListListBox.TabIndex = 14;
            this.pingListListBox.SelectedIndexChanged += new System.EventHandler(this.pingListListBox_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(256, 18);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(619, 706);
            this.listBox2.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(159, 691);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Ping All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "To";
            // 
            // toComputerTextBox
            // 
            this.toComputerTextBox.Location = new System.Drawing.Point(85, 31);
            this.toComputerTextBox.Name = "toComputerTextBox";
            this.toComputerTextBox.Size = new System.Drawing.Size(68, 20);
            this.toComputerTextBox.TabIndex = 11;
            this.toComputerTextBox.Text = "sesto088";
            // 
            // fromComputerTextBox
            // 
            this.fromComputerTextBox.Location = new System.Drawing.Point(6, 31);
            this.fromComputerTextBox.Name = "fromComputerTextBox";
            this.fromComputerTextBox.Size = new System.Drawing.Size(68, 20);
            this.fromComputerTextBox.TabIndex = 9;
            this.fromComputerTextBox.Text = "sesto039";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "From";
            // 
            // dnsTabPage
            // 
            this.dnsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.dnsTabPage.Controls.Add(this.label5);
            this.dnsTabPage.Controls.Add(this.queryTypeComboBox);
            this.dnsTabPage.Controls.Add(this.dnsLookupResultTextBox);
            this.dnsTabPage.Controls.Add(this.dnsNameLabel);
            this.dnsTabPage.Controls.Add(this.dnsLookupButton);
            this.dnsTabPage.Controls.Add(this.dnsLookupNameTextBox);
            this.dnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.dnsTabPage.Name = "dnsTabPage";
            this.dnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dnsTabPage.Size = new System.Drawing.Size(455, 733);
            this.dnsTabPage.TabIndex = 3;
            this.dnsTabPage.Text = "DNS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Type";
            // 
            // queryTypeComboBox
            // 
            this.queryTypeComboBox.FormattingEnabled = true;
            this.queryTypeComboBox.Location = new System.Drawing.Point(154, 20);
            this.queryTypeComboBox.Name = "queryTypeComboBox";
            this.queryTypeComboBox.Size = new System.Drawing.Size(106, 21);
            this.queryTypeComboBox.TabIndex = 14;
            // 
            // dnsLookupResultTextBox
            // 
            this.dnsLookupResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dnsLookupResultTextBox.Location = new System.Drawing.Point(17, 65);
            this.dnsLookupResultTextBox.Multiline = true;
            this.dnsLookupResultTextBox.Name = "dnsLookupResultTextBox";
            this.dnsLookupResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dnsLookupResultTextBox.Size = new System.Drawing.Size(423, 652);
            this.dnsLookupResultTextBox.TabIndex = 13;
            this.dnsLookupResultTextBox.WordWrap = false;
            // 
            // dnsNameLabel
            // 
            this.dnsNameLabel.AutoSize = true;
            this.dnsNameLabel.Location = new System.Drawing.Point(14, 5);
            this.dnsNameLabel.Name = "dnsNameLabel";
            this.dnsNameLabel.Size = new System.Drawing.Size(55, 13);
            this.dnsNameLabel.TabIndex = 11;
            this.dnsNameLabel.Text = "Dns name";
            // 
            // dnsLookupButton
            // 
            this.dnsLookupButton.Location = new System.Drawing.Point(266, 8);
            this.dnsLookupButton.Name = "dnsLookupButton";
            this.dnsLookupButton.Size = new System.Drawing.Size(91, 33);
            this.dnsLookupButton.TabIndex = 9;
            this.dnsLookupButton.Text = "&DNS Lookup";
            this.dnsLookupButton.UseVisualStyleBackColor = true;
            this.dnsLookupButton.Click += new System.EventHandler(this.dnsLookupButton_Click);
            // 
            // dnsLookupNameTextBox
            // 
            this.dnsLookupNameTextBox.Location = new System.Drawing.Point(17, 21);
            this.dnsLookupNameTextBox.Name = "dnsLookupNameTextBox";
            this.dnsLookupNameTextBox.Size = new System.Drawing.Size(131, 20);
            this.dnsLookupNameTextBox.TabIndex = 10;
            this.dnsLookupNameTextBox.Text = "skanska.se";
            // 
            // whoIsTabPage
            // 
            this.whoIsTabPage.Controls.Add(this.label4);
            this.whoIsTabPage.Controls.Add(this.label1);
            this.whoIsTabPage.Controls.Add(this.whoIsResultTextBox);
            this.whoIsTabPage.Controls.Add(this.lookUpLabel);
            this.whoIsTabPage.Controls.Add(this.whoIsLookUpButton);
            this.whoIsTabPage.Controls.Add(this.whoisLookUpTextBox);
            this.whoIsTabPage.Location = new System.Drawing.Point(4, 22);
            this.whoIsTabPage.Name = "whoIsTabPage";
            this.whoIsTabPage.Size = new System.Drawing.Size(455, 733);
            this.whoIsTabPage.TabIndex = 5;
            this.whoIsTabPage.Text = "Who is";
            this.whoIsTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Unable to run Whois for an IP address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Who is is over port 43 (blocked by Skanska), run this command outside Skanet";
            // 
            // whoIsResultTextBox
            // 
            this.whoIsResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whoIsResultTextBox.Location = new System.Drawing.Point(17, 52);
            this.whoIsResultTextBox.Multiline = true;
            this.whoIsResultTextBox.Name = "whoIsResultTextBox";
            this.whoIsResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.whoIsResultTextBox.Size = new System.Drawing.Size(423, 670);
            this.whoIsResultTextBox.TabIndex = 18;
            this.whoIsResultTextBox.WordWrap = false;
            // 
            // lookUpLabel
            // 
            this.lookUpLabel.AutoSize = true;
            this.lookUpLabel.Location = new System.Drawing.Point(14, 10);
            this.lookUpLabel.Name = "lookUpLabel";
            this.lookUpLabel.Size = new System.Drawing.Size(55, 13);
            this.lookUpLabel.TabIndex = 17;
            this.lookUpLabel.Text = "Dns name";
            // 
            // whoIsLookUpButton
            // 
            this.whoIsLookUpButton.Location = new System.Drawing.Point(154, 13);
            this.whoIsLookUpButton.Name = "whoIsLookUpButton";
            this.whoIsLookUpButton.Size = new System.Drawing.Size(91, 33);
            this.whoIsLookUpButton.TabIndex = 15;
            this.whoIsLookUpButton.Text = "&Who is Lookup";
            this.whoIsLookUpButton.UseVisualStyleBackColor = true;
            this.whoIsLookUpButton.Click += new System.EventHandler(this.whoIsLookUpButton_Click);
            // 
            // whoisLookUpTextBox
            // 
            this.whoisLookUpTextBox.Location = new System.Drawing.Point(17, 26);
            this.whoisLookUpTextBox.Name = "whoisLookUpTextBox";
            this.whoisLookUpTextBox.Size = new System.Drawing.Size(131, 20);
            this.whoisLookUpTextBox.TabIndex = 16;
            this.whoisLookUpTextBox.Text = "skanska.se";
            // 
            // logTabPage
            // 
            this.logTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.logTabPage.Controls.Add(this.logListBox);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(455, 733);
            this.logTabPage.TabIndex = 1;
            this.logTabPage.Text = "Log";
            // 
            // logListBox
            // 
            this.logListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(6, 13);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(443, 706);
            this.logListBox.TabIndex = 11;
            // 
            // TroubleShooterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 783);
            this.Controls.Add(this.TabControl);
            this.Name = "TroubleShooterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Troubleshooter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnifferForm_FormClosing);
            this.Load += new System.EventHandler(this.SnifferForm_Load);
            this.TabControl.ResumeLayout(false);
            this.ipSnifferTabPage.ResumeLayout(false);
            this.ipSnifferTabPage.PerformLayout();
            this.pingTabPage.ResumeLayout(false);
            this.pingTabPage.PerformLayout();
            this.pingKingTabPage.ResumeLayout(false);
            this.pingKingTabPage.PerformLayout();
            this.dnsTabPage.ResumeLayout(false);
            this.dnsTabPage.PerformLayout();
            this.whoIsTabPage.ResumeLayout(false);
            this.whoIsTabPage.PerformLayout();
            this.logTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.Label InterfacesLabel;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label ProtocolLabel;
        private System.Windows.Forms.ComboBox ProtocolComboBox;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage ipSnifferTabPage;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.TabPage pingTabPage;
        private System.Windows.Forms.Label pingIpLabel;
        private System.Windows.Forms.Button pingButton;
        private System.Windows.Forms.TextBox pingIpTextBox;
        private System.Windows.Forms.ListBox pingListBox;
        private System.Windows.Forms.TabPage dnsTabPage;
        private System.Windows.Forms.Label dnsNameLabel;
        private System.Windows.Forms.Button dnsLookupButton;
        private System.Windows.Forms.TextBox dnsLookupNameTextBox;
        private System.Windows.Forms.TextBox dnsLookupResultTextBox;
        private System.Windows.Forms.ComboBox queryTypeComboBox;
        private System.Windows.Forms.TabPage pingKingTabPage;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toComputerTextBox;
        private System.Windows.Forms.TextBox fromComputerTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addPingButton;
        private System.Windows.Forms.ListBox pingListListBox;
        private System.Windows.Forms.Button removePingButton;
        private System.Windows.Forms.TabPage whoIsTabPage;
        private System.Windows.Forms.TextBox whoIsResultTextBox;
        private System.Windows.Forms.Label lookUpLabel;
        private System.Windows.Forms.Button whoIsLookUpButton;
        private System.Windows.Forms.TextBox whoisLookUpTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

