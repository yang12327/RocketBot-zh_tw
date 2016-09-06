using System.Drawing;
namespace PokemonGo.RocketAPI.Window
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.authTypeLabel = new System.Windows.Forms.Label();
            this.authTypeCb = new System.Windows.Forms.ComboBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.latLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UserLoginBox = new System.Windows.Forms.TextBox();
            this.UserPasswordBox = new System.Windows.Forms.TextBox();
            this.latitudeText = new System.Windows.Forms.TextBox();
            this.longitudeText = new System.Windows.Forms.TextBox();
            this.razzmodeCb = new System.Windows.Forms.ComboBox();
            this.transferTypeCb = new System.Windows.Forms.ComboBox();
            this.evolveAllChk = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.SetStart = new System.Windows.Forms.Button();
            this.AdressBox = new System.Windows.Forms.TextBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.useIncubatorsCb = new System.Windows.Forms.ComboBox();
            this.useIncubatorsText = new System.Windows.Forms.Label();
            this.CatchPokemonBox = new System.Windows.Forms.CheckBox();
            this.TravelSpeedText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UseLastGPS = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.CatchDelay = new System.Windows.Forms.NumericUpDown();
            this.SupplyCheck = new System.Windows.Forms.NumericUpDown();
            this.SupplyDelay = new System.Windows.Forms.NumericUpDown();
            this.LimitCatch = new System.Windows.Forms.NumericUpDown();
            this.ReLoginDelay = new System.Windows.Forms.NumericUpDown();
            this.LimitSupply = new System.Windows.Forms.NumericUpDown();
            this.CatchDistance = new System.Windows.Forms.NumericUpDown();
            this.WalkRange = new System.Windows.Forms.NumericUpDown();
            this.WalkDelay = new System.Windows.Forms.NumericUpDown();
            this.TravelSpeedBox = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.SupplyDistance = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBoxOR = new System.Windows.Forms.CheckBox();
            this.checkBoxMoreCP = new System.Windows.Forms.CheckBox();
            this.checkBoxMoreIV = new System.Windows.Forms.CheckBox();
            this.transferThresText = new System.Windows.Forms.NumericUpDown();
            this.razzSettingText = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMoreCP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMoreIV = new System.Windows.Forms.NumericUpDown();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.numericUpDownGreat = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDownUltra = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDownMaster = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.tabLocation = new System.Windows.Forms.TabPage();
            this.DeleteLocation = new System.Windows.Forms.Button();
            this.AddLocation = new System.Windows.Forms.Button();
            this.tabPokemon = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clbEvolve = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllEvolve = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbCatch = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllCatch = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbTransfer = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllTransfer = new System.Windows.Forms.CheckBox();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeviceModelIdentifierTb = new System.Windows.Forms.TextBox();
            this.deviceTypeCb = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.RandomIDBtn = new System.Windows.Forms.Button();
            this.deviceIdlb = new System.Windows.Forms.Label();
            this.DeviceIdTb = new System.Windows.Forms.TextBox();
            this.FirmwareFingerprintTb = new System.Windows.Forms.TextBox();
            this.BoardName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.AndroidBoardNameTb = new System.Windows.Forms.TextBox();
            this.FirmwareTypeTb = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.AndroidBootloaderTb = new System.Windows.Forms.TextBox();
            this.FirmwareTagsTb = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DeviceBrandTb = new System.Windows.Forms.TextBox();
            this.FirmwareBrandTb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.DeviceModelTb = new System.Windows.Forms.TextBox();
            this.HardwareModelTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.HardwareManufacturerTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DeviceModelBootTb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.RandomDeviceBtn = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CatchDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitCatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReLoginDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitSupply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatchDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WalkRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WalkDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelSpeedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyDistance)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transferThresText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.razzSettingText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreIV)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUltra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaster)).BeginInit();
            this.tabLocation.SuspendLayout();
            this.tabPokemon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // authTypeLabel
            // 
            this.authTypeLabel.AutoSize = true;
            this.authTypeLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authTypeLabel.Location = new System.Drawing.Point(6, 22);
            this.authTypeLabel.Name = "authTypeLabel";
            this.authTypeLabel.Size = new System.Drawing.Size(68, 16);
            this.authTypeLabel.TabIndex = 0;
            this.authTypeLabel.Text = "登入類型：";
            // 
            // authTypeCb
            // 
            this.authTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authTypeCb.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authTypeCb.FormattingEnabled = true;
            this.authTypeCb.Items.AddRange(new object[] {
            "Google",
            "PTC"});
            this.authTypeCb.Location = new System.Drawing.Point(82, 18);
            this.authTypeCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authTypeCb.Name = "authTypeCb";
            this.authTypeCb.Size = new System.Drawing.Size(175, 23);
            this.authTypeCb.TabIndex = 1;
            this.authTypeCb.SelectedIndexChanged += new System.EventHandler(this.authTypeCb_SelectedIndexChanged);
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.Location = new System.Drawing.Point(6, 54);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(68, 16);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "登入帳號：";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(6, 84);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(68, 16);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "登入密碼：";
            this.toolTip1.SetToolTip(this.PasswordLabel, "密碼經過128位元加密\r\n只有你的電腦能解密\r\n換電腦請重新輸入密碼即可");
            // 
            // latLabel
            // 
            this.latLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.latLabel.AutoSize = true;
            this.latLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latLabel.Location = new System.Drawing.Point(3, 10);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(68, 16);
            this.latLabel.TabIndex = 4;
            this.latLabel.Text = "預設座標：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "使用莓果：";
            this.toolTip1.SetToolTip(this.label1, "機率請自行換算\r\n50%填入0.5\r\n40%填入0.4\r\n以此類推");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "傳送方式：";
            this.toolTip1.SetToolTip(this.label2, "傳送：把神奇寶貝變成糖果");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "CP以下傳送：";
            // 
            // UserLoginBox
            // 
            this.UserLoginBox.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLoginBox.Location = new System.Drawing.Point(82, 50);
            this.UserLoginBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserLoginBox.Name = "UserLoginBox";
            this.UserLoginBox.Size = new System.Drawing.Size(175, 24);
            this.UserLoginBox.TabIndex = 11;
            this.UserLoginBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserLoginBox.TextChanged += new System.EventHandler(this.UserLoginBox_TextChanged);
            // 
            // UserPasswordBox
            // 
            this.UserPasswordBox.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPasswordBox.Location = new System.Drawing.Point(82, 84);
            this.UserPasswordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserPasswordBox.Name = "UserPasswordBox";
            this.UserPasswordBox.Size = new System.Drawing.Size(175, 22);
            this.UserPasswordBox.TabIndex = 12;
            this.UserPasswordBox.Text = "（未變更）";
            this.UserPasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserPasswordBox.TextChanged += new System.EventHandler(this.UserPasswordBox_TextChanged);
            this.UserPasswordBox.Enter += new System.EventHandler(this.UserPasswordBox_Enter);
            this.UserPasswordBox.Leave += new System.EventHandler(this.UserPasswordBox_Leave);
            // 
            // latitudeText
            // 
            this.latitudeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.latitudeText.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitudeText.Location = new System.Drawing.Point(78, 4);
            this.latitudeText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.latitudeText.Name = "latitudeText";
            this.latitudeText.ReadOnly = true;
            this.latitudeText.Size = new System.Drawing.Size(409, 27);
            this.latitudeText.TabIndex = 13;
            this.latitudeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // longitudeText
            // 
            this.longitudeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeText.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitudeText.Location = new System.Drawing.Point(493, 4);
            this.longitudeText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.longitudeText.Name = "longitudeText";
            this.longitudeText.ReadOnly = true;
            this.longitudeText.Size = new System.Drawing.Size(409, 27);
            this.longitudeText.TabIndex = 14;
            this.longitudeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // razzmodeCb
            // 
            this.razzmodeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.razzmodeCb.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.razzmodeCb.FormattingEnabled = true;
            this.razzmodeCb.Items.AddRange(new object[] {
            "捕捉機率低於",
            "CP高於"});
            this.razzmodeCb.Location = new System.Drawing.Point(82, 135);
            this.razzmodeCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.razzmodeCb.Name = "razzmodeCb";
            this.razzmodeCb.Size = new System.Drawing.Size(106, 24);
            this.razzmodeCb.TabIndex = 15;
            this.razzmodeCb.SelectedIndexChanged += new System.EventHandler(this.razzmodeCb_SelectedIndexChanged);
            // 
            // transferTypeCb
            // 
            this.transferTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transferTypeCb.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferTypeCb.FormattingEnabled = true;
            this.transferTypeCb.Items.AddRange(new object[] {
            "不傳送",
            "保留高於CP…",
            "保留高於IV…",
            "只保留最強",
            "保留最高CP值",
            "保留最高IV值",
            "保留最高CP和IV值",
            "全部傳送"});
            this.transferTypeCb.Location = new System.Drawing.Point(81, 198);
            this.transferTypeCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transferTypeCb.Name = "transferTypeCb";
            this.transferTypeCb.Size = new System.Drawing.Size(175, 24);
            this.transferTypeCb.TabIndex = 17;
            this.transferTypeCb.SelectedIndexChanged += new System.EventHandler(this.transferTypeCb_SelectedIndexChanged);
            // 
            // evolveAllChk
            // 
            this.evolveAllChk.AutoSize = true;
            this.evolveAllChk.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evolveAllChk.Location = new System.Drawing.Point(134, 22);
            this.evolveAllChk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.evolveAllChk.Name = "evolveAllChk";
            this.evolveAllChk.Size = new System.Drawing.Size(123, 20);
            this.evolveAllChk.TabIndex = 19;
            this.evolveAllChk.Text = "自動進化神奇寶貝";
            this.evolveAllChk.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.saveBtn.ForeColor = System.Drawing.Color.Blue;
            this.saveBtn.Location = new System.Drawing.Point(4, 1);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(1116, 47);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "儲存所有設定";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.BackColor = System.Drawing.SystemColors.Info;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 39);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 10;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1113, 390);
            this.gMapControl1.TabIndex = 8;
            this.gMapControl1.Zoom = 10D;
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseClick);
            // 
            // SetStart
            // 
            this.SetStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetStart.Enabled = false;
            this.SetStart.Location = new System.Drawing.Point(841, 395);
            this.SetStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SetStart.Name = "SetStart";
            this.SetStart.Size = new System.Drawing.Size(85, 30);
            this.SetStart.TabIndex = 25;
            this.SetStart.Text = "設為起點";
            this.toolTip1.SetToolTip(this.SetStart, "把地圖中的藍點設為起點");
            this.SetStart.UseVisualStyleBackColor = true;
            this.SetStart.Click += new System.EventHandler(this.FindAdressButton_Click);
            // 
            // AdressBox
            // 
            this.AdressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdressBox.ForeColor = System.Drawing.Color.Gray;
            this.AdressBox.Location = new System.Drawing.Point(6, 402);
            this.AdressBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AdressBox.Multiline = true;
            this.AdressBox.Name = "AdressBox";
            this.AdressBox.Size = new System.Drawing.Size(829, 23);
            this.AdressBox.TabIndex = 25;
            this.AdressBox.Text = "輸入一個地址或一個地點";
            this.AdressBox.Enter += new System.EventHandler(this.AdressBox_Enter);
            this.AdressBox.Leave += new System.EventHandler(this.AdressBox_Leave);
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.BackColor = System.Drawing.SystemColors.Info;
            this.trackBar.LargeChange = 3;
            this.trackBar.Location = new System.Drawing.Point(1063, 46);
            this.trackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBar.Maximum = 20;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(45, 120);
            this.trackBar.TabIndex = 25;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 15;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // useIncubatorsCb
            // 
            this.useIncubatorsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.useIncubatorsCb.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useIncubatorsCb.FormattingEnabled = true;
            this.useIncubatorsCb.Items.AddRange(new object[] {
            "不孵蛋",
            "只使用無限孵蛋器",
            "使用所有孵蛋器"});
            this.useIncubatorsCb.Location = new System.Drawing.Point(82, 167);
            this.useIncubatorsCb.Name = "useIncubatorsCb";
            this.useIncubatorsCb.Size = new System.Drawing.Size(175, 24);
            this.useIncubatorsCb.TabIndex = 26;
            // 
            // useIncubatorsText
            // 
            this.useIncubatorsText.AutoSize = true;
            this.useIncubatorsText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useIncubatorsText.Location = new System.Drawing.Point(6, 170);
            this.useIncubatorsText.Name = "useIncubatorsText";
            this.useIncubatorsText.Size = new System.Drawing.Size(68, 16);
            this.useIncubatorsText.TabIndex = 27;
            this.useIncubatorsText.Text = "自動孵蛋：";
            // 
            // CatchPokemonBox
            // 
            this.CatchPokemonBox.AutoSize = true;
            this.CatchPokemonBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatchPokemonBox.Location = new System.Drawing.Point(6, 23);
            this.CatchPokemonBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CatchPokemonBox.Name = "CatchPokemonBox";
            this.CatchPokemonBox.Size = new System.Drawing.Size(123, 20);
            this.CatchPokemonBox.TabIndex = 26;
            this.CatchPokemonBox.Text = "自動蒐集神奇寶貝";
            this.CatchPokemonBox.UseVisualStyleBackColor = true;
            // 
            // TravelSpeedText
            // 
            this.TravelSpeedText.AutoSize = true;
            this.TravelSpeedText.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravelSpeedText.Location = new System.Drawing.Point(6, 26);
            this.TravelSpeedText.Name = "TravelSpeedText";
            this.TravelSpeedText.Size = new System.Drawing.Size(68, 16);
            this.TravelSpeedText.TabIndex = 23;
            this.TravelSpeedText.Text = "移動速度：";
            this.toolTip1.SetToolTip(this.TravelSpeedText, "走路的速度，時速公里");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "補給延遲：";
            this.toolTip1.SetToolTip(this.label5, "A補給站領完之後延遲幾秒才領B補給站");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "移動延遲：";
            this.toolTip1.SetToolTip(this.label6, "過幾秒傳送一次GPS訊號\r\n建議不要低於1秒（灌水）\r\n然後也不要太久（飛人）\r\n請自行調整一個自己覺得合理的時間");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "抓寵延遲：";
            this.toolTip1.SetToolTip(this.label3, "抓完A神奇寶貝之後延遲幾秒才抓B神奇寶貝");
            // 
            // UseLastGPS
            // 
            this.UseLastGPS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UseLastGPS.AutoSize = true;
            this.UseLastGPS.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseLastGPS.Location = new System.Drawing.Point(908, 8);
            this.UseLastGPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UseLastGPS.Name = "UseLastGPS";
            this.UseLastGPS.Size = new System.Drawing.Size(205, 20);
            this.UseLastGPS.TabIndex = 26;
            this.UseLastGPS.Text = "使用機器人最後的位置當預設座標";
            this.toolTip1.SetToolTip(this.UseLastGPS, "每移動一次，就更新一次預設座標");
            this.UseLastGPS.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1124, 457);
            this.panel2.TabIndex = 27;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAccount);
            this.tabControl.Controls.Add(this.tabLocation);
            this.tabControl.Controls.Add(this.tabPokemon);
            this.tabControl.Controls.Add(this.tabItems);
            this.tabControl.Controls.Add(this.tabDevice);
            this.tabControl.Controls.Add(this.tabProfile);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1124, 457);
            this.tabControl.TabIndex = 26;
            // 
            // tabAccount
            // 
            this.tabAccount.BackColor = System.Drawing.SystemColors.Control;
            this.tabAccount.Controls.Add(this.flowLayoutPanel1);
            this.tabAccount.Location = new System.Drawing.Point(4, 24);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Size = new System.Drawing.Size(1116, 429);
            this.tabAccount.TabIndex = 4;
            this.tabAccount.Text = "基本設定";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Controls.Add(this.groupBox6);
            this.flowLayoutPanel1.Controls.Add(this.groupBox8);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1116, 429);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.authTypeLabel);
            this.groupBox5.Controls.Add(this.authTypeCb);
            this.groupBox5.Controls.Add(this.PasswordLabel);
            this.groupBox5.Controls.Add(this.UserLoginBox);
            this.groupBox5.Controls.Add(this.UserLabel);
            this.groupBox5.Controls.Add(this.UserPasswordBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 117);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "登入帳號";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.CatchDelay);
            this.groupBox7.Controls.Add(this.SupplyCheck);
            this.groupBox7.Controls.Add(this.SupplyDelay);
            this.groupBox7.Controls.Add(this.LimitCatch);
            this.groupBox7.Controls.Add(this.ReLoginDelay);
            this.groupBox7.Controls.Add(this.LimitSupply);
            this.groupBox7.Controls.Add(this.CatchDistance);
            this.groupBox7.Controls.Add(this.WalkRange);
            this.groupBox7.Controls.Add(this.WalkDelay);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.TravelSpeedBox);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.TravelSpeedText);
            this.groupBox7.Controls.Add(this.SupplyDistance);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Location = new System.Drawing.Point(277, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(268, 354);
            this.groupBox7.TabIndex = 25;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "動作設定";
            // 
            // CatchDelay
            // 
            this.CatchDelay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatchDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CatchDelay.Location = new System.Drawing.Point(80, 108);
            this.CatchDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CatchDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CatchDelay.Name = "CatchDelay";
            this.CatchDelay.Size = new System.Drawing.Size(177, 24);
            this.CatchDelay.TabIndex = 33;
            this.CatchDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CatchDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SupplyCheck
            // 
            this.SupplyCheck.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyCheck.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SupplyCheck.Location = new System.Drawing.Point(80, 168);
            this.SupplyCheck.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SupplyCheck.Name = "SupplyCheck";
            this.SupplyCheck.Size = new System.Drawing.Size(177, 24);
            this.SupplyCheck.TabIndex = 31;
            this.SupplyCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SupplyCheck.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SupplyDelay
            // 
            this.SupplyDelay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SupplyDelay.Location = new System.Drawing.Point(80, 198);
            this.SupplyDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SupplyDelay.Name = "SupplyDelay";
            this.SupplyDelay.Size = new System.Drawing.Size(177, 24);
            this.SupplyDelay.TabIndex = 30;
            this.SupplyDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SupplyDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LimitCatch
            // 
            this.LimitCatch.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimitCatch.Location = new System.Drawing.Point(80, 318);
            this.LimitCatch.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.LimitCatch.Name = "LimitCatch";
            this.LimitCatch.Size = new System.Drawing.Size(177, 24);
            this.LimitCatch.TabIndex = 29;
            this.LimitCatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LimitCatch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ReLoginDelay
            // 
            this.ReLoginDelay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReLoginDelay.Location = new System.Drawing.Point(80, 228);
            this.ReLoginDelay.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ReLoginDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ReLoginDelay.Name = "ReLoginDelay";
            this.ReLoginDelay.Size = new System.Drawing.Size(177, 24);
            this.ReLoginDelay.TabIndex = 29;
            this.ReLoginDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReLoginDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LimitSupply
            // 
            this.LimitSupply.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimitSupply.Location = new System.Drawing.Point(80, 288);
            this.LimitSupply.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.LimitSupply.Name = "LimitSupply";
            this.LimitSupply.Size = new System.Drawing.Size(177, 24);
            this.LimitSupply.TabIndex = 29;
            this.LimitSupply.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LimitSupply.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CatchDistance
            // 
            this.CatchDistance.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatchDistance.Location = new System.Drawing.Point(80, 78);
            this.CatchDistance.Name = "CatchDistance";
            this.CatchDistance.Size = new System.Drawing.Size(177, 24);
            this.CatchDistance.TabIndex = 28;
            this.CatchDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CatchDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WalkRange
            // 
            this.WalkRange.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalkRange.Location = new System.Drawing.Point(80, 258);
            this.WalkRange.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.WalkRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WalkRange.Name = "WalkRange";
            this.WalkRange.Size = new System.Drawing.Size(177, 24);
            this.WalkRange.TabIndex = 29;
            this.WalkRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WalkRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WalkDelay
            // 
            this.WalkDelay.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalkDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.WalkDelay.Location = new System.Drawing.Point(80, 48);
            this.WalkDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WalkDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WalkDelay.Name = "WalkDelay";
            this.WalkDelay.Size = new System.Drawing.Size(177, 24);
            this.WalkDelay.TabIndex = 27;
            this.WalkDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WalkDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TravelSpeedBox
            // 
            this.TravelSpeedBox.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravelSpeedBox.Location = new System.Drawing.Point(80, 18);
            this.TravelSpeedBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TravelSpeedBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TravelSpeedBox.Name = "TravelSpeedBox";
            this.TravelSpeedBox.Size = new System.Drawing.Size(177, 24);
            this.TravelSpeedBox.TabIndex = 26;
            this.TravelSpeedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TravelSpeedBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 16);
            this.label24.TabIndex = 9;
            this.label24.Text = "抓寵距離：";
            this.toolTip1.SetToolTip(this.label24, "與神奇寶貝的距離小於幾公尺才捕抓");
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 142);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 16);
            this.label23.TabIndex = 9;
            this.label23.Text = "補給距離：";
            this.toolTip1.SetToolTip(this.label23, "補給站的距離小於幾公尺才補給\r\n40公尺是正常遊戲最大的範圍");
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 172);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 16);
            this.label19.TabIndex = 9;
            this.label19.Text = "檢查延遲：";
            this.toolTip1.SetToolTip(this.label19, "多久檢查一次補給站的距離");
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(6, 232);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 16);
            this.label25.TabIndex = 9;
            this.label25.Text = "重新登入：";
            this.toolTip1.SetToolTip(this.label25, "運行幾分鐘後自動重新登入\r\n（上限30分鐘）");
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(7, 322);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 16);
            this.label31.TabIndex = 9;
            this.label31.Text = "抓寵上限：";
            this.toolTip1.SetToolTip(this.label31, "抓寵數量達到上限即停止（每小時幾次）\r\n0為不啟用此功能（抓不停）");
            // 
            // SupplyDistance
            // 
            this.SupplyDistance.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyDistance.Location = new System.Drawing.Point(80, 138);
            this.SupplyDistance.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.SupplyDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SupplyDistance.Name = "SupplyDistance";
            this.SupplyDistance.Size = new System.Drawing.Size(177, 24);
            this.SupplyDistance.TabIndex = 32;
            this.SupplyDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SupplyDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(7, 292);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(68, 16);
            this.label30.TabIndex = 9;
            this.label30.Text = "補給上限：";
            this.toolTip1.SetToolTip(this.label30, "補給數量達到上限即停止（每小時幾次）\r\n0為不啟用此功能（翻不停）");
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(7, 262);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(92, 16);
            this.label29.TabIndex = 9;
            this.label29.Text = "最大行走範圍：";
            this.toolTip1.SetToolTip(this.label29, "預設路徑最大的規劃範圍（半徑幾公尺）\r\n前提要使用預設路徑才有效");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBoxOR);
            this.groupBox6.Controls.Add(this.checkBoxMoreCP);
            this.groupBox6.Controls.Add(this.checkBoxMoreIV);
            this.groupBox6.Controls.Add(this.transferThresText);
            this.groupBox6.Controls.Add(this.razzSettingText);
            this.groupBox6.Controls.Add(this.numericUpDownMoreCP);
            this.groupBox6.Controls.Add(this.numericUpDownMoreIV);
            this.groupBox6.Controls.Add(this.evolveAllChk);
            this.groupBox6.Controls.Add(this.useIncubatorsCb);
            this.groupBox6.Controls.Add(this.CatchPokemonBox);
            this.groupBox6.Controls.Add(this.useIncubatorsText);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.razzmodeCb);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.transferTypeCb);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Location = new System.Drawing.Point(551, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(272, 265);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "神奇寶貝設定";
            // 
            // checkBoxOR
            // 
            this.checkBoxOR.AutoSize = true;
            this.checkBoxOR.Location = new System.Drawing.Point(6, 107);
            this.checkBoxOR.Name = "checkBoxOR";
            this.checkBoxOR.Size = new System.Drawing.Size(182, 19);
            this.checkBoxOR.TabIndex = 28;
            this.checkBoxOR.Text = "只要達到其中一個條件就抓";
            this.checkBoxOR.UseVisualStyleBackColor = true;
            this.checkBoxOR.Visible = false;
            // 
            // checkBoxMoreCP
            // 
            this.checkBoxMoreCP.AutoSize = true;
            this.checkBoxMoreCP.Location = new System.Drawing.Point(6, 81);
            this.checkBoxMoreCP.Name = "checkBoxMoreCP";
            this.checkBoxMoreCP.Size = new System.Drawing.Size(106, 19);
            this.checkBoxMoreCP.TabIndex = 28;
            this.checkBoxMoreCP.Text = "只抓CP高於：";
            this.checkBoxMoreCP.UseVisualStyleBackColor = true;
            this.checkBoxMoreCP.CheckedChanged += new System.EventHandler(this.checkBoxMoreOR);
            // 
            // checkBoxMoreIV
            // 
            this.checkBoxMoreIV.AutoSize = true;
            this.checkBoxMoreIV.Location = new System.Drawing.Point(6, 51);
            this.checkBoxMoreIV.Name = "checkBoxMoreIV";
            this.checkBoxMoreIV.Size = new System.Drawing.Size(101, 19);
            this.checkBoxMoreIV.TabIndex = 28;
            this.checkBoxMoreIV.Text = "只抓IV高於：";
            this.checkBoxMoreIV.UseVisualStyleBackColor = true;
            this.checkBoxMoreIV.CheckedChanged += new System.EventHandler(this.checkBoxMoreOR);
            // 
            // transferThresText
            // 
            this.transferThresText.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferThresText.Location = new System.Drawing.Point(82, 228);
            this.transferThresText.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.transferThresText.Name = "transferThresText";
            this.transferThresText.Size = new System.Drawing.Size(174, 24);
            this.transferThresText.TabIndex = 29;
            this.transferThresText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.transferThresText.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // razzSettingText
            // 
            this.razzSettingText.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.razzSettingText.Location = new System.Drawing.Point(194, 135);
            this.razzSettingText.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.razzSettingText.Name = "razzSettingText";
            this.razzSettingText.Size = new System.Drawing.Size(63, 24);
            this.razzSettingText.TabIndex = 29;
            this.razzSettingText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.razzSettingText.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownMoreCP
            // 
            this.numericUpDownMoreCP.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMoreCP.Location = new System.Drawing.Point(113, 78);
            this.numericUpDownMoreCP.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownMoreCP.Name = "numericUpDownMoreCP";
            this.numericUpDownMoreCP.Size = new System.Drawing.Size(144, 24);
            this.numericUpDownMoreCP.TabIndex = 29;
            this.numericUpDownMoreCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMoreCP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownMoreIV
            // 
            this.numericUpDownMoreIV.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMoreIV.Location = new System.Drawing.Point(113, 50);
            this.numericUpDownMoreIV.Name = "numericUpDownMoreIV";
            this.numericUpDownMoreIV.Size = new System.Drawing.Size(144, 24);
            this.numericUpDownMoreIV.TabIndex = 29;
            this.numericUpDownMoreIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMoreIV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.numericUpDownGreat);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.numericUpDownUltra);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.numericUpDownMaster);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Location = new System.Drawing.Point(829, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(268, 121);
            this.groupBox8.TabIndex = 30;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "寶貝球設定";
            // 
            // numericUpDownGreat
            // 
            this.numericUpDownGreat.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGreat.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownGreat.Location = new System.Drawing.Point(148, 22);
            this.numericUpDownGreat.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownGreat.Name = "numericUpDownGreat";
            this.numericUpDownGreat.Size = new System.Drawing.Size(114, 24);
            this.numericUpDownGreat.TabIndex = 31;
            this.numericUpDownGreat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownGreat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(131, 16);
            this.label26.TabIndex = 9;
            this.label26.Text = "CP高於多少使用超級球";
            // 
            // numericUpDownUltra
            // 
            this.numericUpDownUltra.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownUltra.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownUltra.Location = new System.Drawing.Point(148, 52);
            this.numericUpDownUltra.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownUltra.Name = "numericUpDownUltra";
            this.numericUpDownUltra.Size = new System.Drawing.Size(114, 24);
            this.numericUpDownUltra.TabIndex = 30;
            this.numericUpDownUltra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownUltra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(11, 86);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(131, 16);
            this.label27.TabIndex = 9;
            this.label27.Text = "CP高於多少使用頂級球";
            // 
            // numericUpDownMaster
            // 
            this.numericUpDownMaster.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMaster.Location = new System.Drawing.Point(148, 82);
            this.numericUpDownMaster.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownMaster.Name = "numericUpDownMaster";
            this.numericUpDownMaster.Size = new System.Drawing.Size(114, 24);
            this.numericUpDownMaster.TabIndex = 29;
            this.numericUpDownMaster.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMaster.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(11, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(131, 16);
            this.label28.TabIndex = 9;
            this.label28.Text = "CP高於多少使用高級球";
            // 
            // tabLocation
            // 
            this.tabLocation.BackColor = System.Drawing.SystemColors.Control;
            this.tabLocation.Controls.Add(this.tableLayoutPanel1);
            this.tabLocation.Controls.Add(this.trackBar);
            this.tabLocation.Controls.Add(this.AdressBox);
            this.tabLocation.Controls.Add(this.DeleteLocation);
            this.tabLocation.Controls.Add(this.AddLocation);
            this.tabLocation.Controls.Add(this.SetStart);
            this.tabLocation.Controls.Add(this.gMapControl1);
            this.tabLocation.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLocation.Location = new System.Drawing.Point(4, 24);
            this.tabLocation.Name = "tabLocation";
            this.tabLocation.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocation.Size = new System.Drawing.Size(1116, 429);
            this.tabLocation.TabIndex = 0;
            this.tabLocation.Text = "預設座標";
            // 
            // DeleteLocation
            // 
            this.DeleteLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteLocation.Enabled = false;
            this.DeleteLocation.Location = new System.Drawing.Point(1023, 395);
            this.DeleteLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteLocation.Name = "DeleteLocation";
            this.DeleteLocation.Size = new System.Drawing.Size(85, 30);
            this.DeleteLocation.TabIndex = 25;
            this.DeleteLocation.Text = "刪除路標";
            this.toolTip1.SetToolTip(this.DeleteLocation, "刪除路線的最後一個點");
            this.DeleteLocation.UseVisualStyleBackColor = true;
            this.DeleteLocation.Click += new System.EventHandler(this.DeleteLocation_Click);
            // 
            // AddLocation
            // 
            this.AddLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddLocation.Enabled = false;
            this.AddLocation.Location = new System.Drawing.Point(932, 395);
            this.AddLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddLocation.Name = "AddLocation";
            this.AddLocation.Size = new System.Drawing.Size(85, 30);
            this.AddLocation.TabIndex = 25;
            this.AddLocation.Text = "新建路標";
            this.toolTip1.SetToolTip(this.AddLocation, "把地圖中的藍點設為下一個前往的位置");
            this.AddLocation.UseVisualStyleBackColor = true;
            this.AddLocation.Click += new System.EventHandler(this.AddLocation_Click);
            // 
            // tabPokemon
            // 
            this.tabPokemon.BackColor = System.Drawing.SystemColors.Control;
            this.tabPokemon.Controls.Add(this.tableLayoutPanel2);
            this.tabPokemon.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPokemon.Location = new System.Drawing.Point(4, 24);
            this.tabPokemon.Name = "tabPokemon";
            this.tabPokemon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPokemon.Size = new System.Drawing.Size(1116, 429);
            this.tabPokemon.TabIndex = 1;
            this.tabPokemon.Text = "神奇寶貝";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.clbEvolve);
            this.groupBox3.Controls.Add(this.cbSelectAllEvolve);
            this.groupBox3.Location = new System.Drawing.Point(741, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 417);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "不進化的神奇寶貝";
            // 
            // clbEvolve
            // 
            this.clbEvolve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbEvolve.CheckOnClick = true;
            this.clbEvolve.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbEvolve.FormattingEnabled = true;
            this.clbEvolve.Location = new System.Drawing.Point(0, 41);
            this.clbEvolve.Name = "clbEvolve";
            this.clbEvolve.Size = new System.Drawing.Size(366, 364);
            this.clbEvolve.TabIndex = 0;
            // 
            // cbSelectAllEvolve
            // 
            this.cbSelectAllEvolve.AutoSize = true;
            this.cbSelectAllEvolve.Location = new System.Drawing.Point(6, 22);
            this.cbSelectAllEvolve.Name = "cbSelectAllEvolve";
            this.cbSelectAllEvolve.Size = new System.Drawing.Size(51, 20);
            this.cbSelectAllEvolve.TabIndex = 1;
            this.cbSelectAllEvolve.Text = "全選";
            this.cbSelectAllEvolve.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.clbCatch);
            this.groupBox2.Controls.Add(this.cbSelectAllCatch);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 417);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "不蒐集的神奇寶貝";
            // 
            // clbCatch
            // 
            this.clbCatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCatch.CheckOnClick = true;
            this.clbCatch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbCatch.FormattingEnabled = true;
            this.clbCatch.Location = new System.Drawing.Point(0, 41);
            this.clbCatch.Name = "clbCatch";
            this.clbCatch.Size = new System.Drawing.Size(363, 364);
            this.clbCatch.TabIndex = 0;
            // 
            // cbSelectAllCatch
            // 
            this.cbSelectAllCatch.AutoSize = true;
            this.cbSelectAllCatch.Location = new System.Drawing.Point(6, 22);
            this.cbSelectAllCatch.Name = "cbSelectAllCatch";
            this.cbSelectAllCatch.Size = new System.Drawing.Size(51, 20);
            this.cbSelectAllCatch.TabIndex = 1;
            this.cbSelectAllCatch.Text = "全選";
            this.cbSelectAllCatch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.clbTransfer);
            this.groupBox1.Controls.Add(this.cbSelectAllTransfer);
            this.groupBox1.Location = new System.Drawing.Point(372, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 417);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "不傳送的神奇寶貝";
            // 
            // clbTransfer
            // 
            this.clbTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbTransfer.CheckOnClick = true;
            this.clbTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTransfer.FormattingEnabled = true;
            this.clbTransfer.Location = new System.Drawing.Point(0, 41);
            this.clbTransfer.Name = "clbTransfer";
            this.clbTransfer.Size = new System.Drawing.Size(363, 364);
            this.clbTransfer.TabIndex = 0;
            // 
            // cbSelectAllTransfer
            // 
            this.cbSelectAllTransfer.AutoSize = true;
            this.cbSelectAllTransfer.Location = new System.Drawing.Point(6, 22);
            this.cbSelectAllTransfer.Name = "cbSelectAllTransfer";
            this.cbSelectAllTransfer.Size = new System.Drawing.Size(51, 20);
            this.cbSelectAllTransfer.TabIndex = 1;
            this.cbSelectAllTransfer.Text = "全選";
            this.cbSelectAllTransfer.UseVisualStyleBackColor = true;
            // 
            // tabItems
            // 
            this.tabItems.BackColor = System.Drawing.SystemColors.Control;
            this.tabItems.Controls.Add(this.flpItems);
            this.tabItems.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabItems.Location = new System.Drawing.Point(4, 24);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(1116, 429);
            this.tabItems.TabIndex = 2;
            this.tabItems.Text = "保留物品";
            // 
            // flpItems
            // 
            this.flpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpItems.Location = new System.Drawing.Point(3, 3);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(1110, 423);
            this.flpItems.TabIndex = 0;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.splitContainer2);
            this.tabDevice.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDevice.Location = new System.Drawing.Point(4, 24);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(1116, 429);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "模擬裝置";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1116, 429);
            this.splitContainer2.SplitterDistance = 927;
            this.splitContainer2.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.DeviceModelIdentifierTb);
            this.panel3.Controls.Add(this.deviceTypeCb);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.RandomIDBtn);
            this.panel3.Controls.Add(this.deviceIdlb);
            this.panel3.Controls.Add(this.DeviceIdTb);
            this.panel3.Controls.Add(this.FirmwareFingerprintTb);
            this.panel3.Controls.Add(this.BoardName);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.AndroidBoardNameTb);
            this.panel3.Controls.Add(this.FirmwareTypeTb);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.AndroidBootloaderTb);
            this.panel3.Controls.Add(this.FirmwareTagsTb);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.DeviceBrandTb);
            this.panel3.Controls.Add(this.FirmwareBrandTb);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.DeviceModelTb);
            this.panel3.Controls.Add(this.HardwareModelTb);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.HardwareManufacturerTb);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.DeviceModelBootTb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(927, 429);
            this.panel3.TabIndex = 73;
            // 
            // DeviceModelIdentifierTb
            // 
            this.DeviceModelIdentifierTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceModelIdentifierTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceModelIdentifierTb.Location = new System.Drawing.Point(183, 188);
            this.DeviceModelIdentifierTb.Name = "DeviceModelIdentifierTb";
            this.DeviceModelIdentifierTb.Size = new System.Drawing.Size(728, 24);
            this.DeviceModelIdentifierTb.TabIndex = 53;
            // 
            // deviceTypeCb
            // 
            this.deviceTypeCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceTypeCb.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceTypeCb.FormattingEnabled = true;
            this.deviceTypeCb.Items.AddRange(new object[] {
            "Apple",
            "Android"});
            this.deviceTypeCb.Location = new System.Drawing.Point(183, 12);
            this.deviceTypeCb.Name = "deviceTypeCb";
            this.deviceTypeCb.Size = new System.Drawing.Size(728, 25);
            this.deviceTypeCb.TabIndex = 37;
            this.deviceTypeCb.SelectionChangeCommitted += new System.EventHandler(this.deviceTypeCb_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 36;
            this.label18.Text = "裝置類型：";
            // 
            // RandomIDBtn
            // 
            this.RandomIDBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomIDBtn.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomIDBtn.Location = new System.Drawing.Point(824, 42);
            this.RandomIDBtn.Name = "RandomIDBtn";
            this.RandomIDBtn.Size = new System.Drawing.Size(87, 25);
            this.RandomIDBtn.TabIndex = 65;
            this.RandomIDBtn.Text = "產生新的ID";
            this.RandomIDBtn.UseVisualStyleBackColor = true;
            this.RandomIDBtn.Click += new System.EventHandler(this.RandomIDBtn_Click);
            // 
            // deviceIdlb
            // 
            this.deviceIdlb.AutoSize = true;
            this.deviceIdlb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceIdlb.Location = new System.Drawing.Point(16, 45);
            this.deviceIdlb.Name = "deviceIdlb";
            this.deviceIdlb.Size = new System.Drawing.Size(69, 17);
            this.deviceIdlb.TabIndex = 45;
            this.deviceIdlb.Text = "Device ID";
            // 
            // DeviceIdTb
            // 
            this.DeviceIdTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceIdTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceIdTb.Location = new System.Drawing.Point(183, 41);
            this.DeviceIdTb.Name = "DeviceIdTb";
            this.DeviceIdTb.Size = new System.Drawing.Size(635, 24);
            this.DeviceIdTb.TabIndex = 38;
            // 
            // FirmwareFingerprintTb
            // 
            this.FirmwareFingerprintTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareFingerprintTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirmwareFingerprintTb.Location = new System.Drawing.Point(183, 392);
            this.FirmwareFingerprintTb.Name = "FirmwareFingerprintTb";
            this.FirmwareFingerprintTb.Size = new System.Drawing.Size(728, 24);
            this.FirmwareFingerprintTb.TabIndex = 62;
            // 
            // BoardName
            // 
            this.BoardName.AutoSize = true;
            this.BoardName.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardName.Location = new System.Drawing.Point(16, 74);
            this.BoardName.Name = "BoardName";
            this.BoardName.Size = new System.Drawing.Size(135, 17);
            this.BoardName.TabIndex = 39;
            this.BoardName.Text = "Android Board Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 17);
            this.label14.TabIndex = 49;
            this.label14.Text = "Firmware Fingerprint";
            // 
            // AndroidBoardNameTb
            // 
            this.AndroidBoardNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AndroidBoardNameTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AndroidBoardNameTb.Location = new System.Drawing.Point(183, 71);
            this.AndroidBoardNameTb.Name = "AndroidBoardNameTb";
            this.AndroidBoardNameTb.Size = new System.Drawing.Size(728, 24);
            this.AndroidBoardNameTb.TabIndex = 61;
            // 
            // FirmwareTypeTb
            // 
            this.FirmwareTypeTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareTypeTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirmwareTypeTb.Location = new System.Drawing.Point(183, 363);
            this.FirmwareTypeTb.Name = "FirmwareTypeTb";
            this.FirmwareTypeTb.Size = new System.Drawing.Size(728, 24);
            this.FirmwareTypeTb.TabIndex = 58;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(16, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 17);
            this.label17.TabIndex = 40;
            this.label17.Text = "Android Boot loader";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 51;
            this.label13.Text = "Firmware Type";
            // 
            // AndroidBootloaderTb
            // 
            this.AndroidBootloaderTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AndroidBootloaderTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AndroidBootloaderTb.Location = new System.Drawing.Point(183, 100);
            this.AndroidBootloaderTb.Name = "AndroidBootloaderTb";
            this.AndroidBootloaderTb.Size = new System.Drawing.Size(728, 24);
            this.AndroidBootloaderTb.TabIndex = 59;
            // 
            // FirmwareTagsTb
            // 
            this.FirmwareTagsTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareTagsTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirmwareTagsTb.Location = new System.Drawing.Point(183, 334);
            this.FirmwareTagsTb.Name = "FirmwareTagsTb";
            this.FirmwareTagsTb.Size = new System.Drawing.Size(728, 24);
            this.FirmwareTagsTb.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "Device Brand";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 17);
            this.label12.TabIndex = 50;
            this.label12.Text = "Firmware Tags";
            // 
            // DeviceBrandTb
            // 
            this.DeviceBrandTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceBrandTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceBrandTb.Location = new System.Drawing.Point(183, 129);
            this.DeviceBrandTb.Name = "DeviceBrandTb";
            this.DeviceBrandTb.Size = new System.Drawing.Size(728, 24);
            this.DeviceBrandTb.TabIndex = 57;
            // 
            // FirmwareBrandTb
            // 
            this.FirmwareBrandTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareBrandTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirmwareBrandTb.Location = new System.Drawing.Point(183, 305);
            this.FirmwareBrandTb.Name = "FirmwareBrandTb";
            this.FirmwareBrandTb.Size = new System.Drawing.Size(728, 24);
            this.FirmwareBrandTb.TabIndex = 52;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 17);
            this.label15.TabIndex = 42;
            this.label15.Text = "Device Model";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Firmware Brand";
            // 
            // DeviceModelTb
            // 
            this.DeviceModelTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceModelTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceModelTb.Location = new System.Drawing.Point(183, 158);
            this.DeviceModelTb.Name = "DeviceModelTb";
            this.DeviceModelTb.Size = new System.Drawing.Size(728, 24);
            this.DeviceModelTb.TabIndex = 55;
            // 
            // HardwareModelTb
            // 
            this.HardwareModelTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardwareModelTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardwareModelTb.Location = new System.Drawing.Point(183, 275);
            this.HardwareModelTb.Name = "HardwareModelTb";
            this.HardwareModelTb.Size = new System.Drawing.Size(728, 24);
            this.HardwareModelTb.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "Device Model Identifier";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.TabIndex = 46;
            this.label10.Text = "Hardware Model";
            // 
            // HardwareManufacturerTb
            // 
            this.HardwareManufacturerTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardwareManufacturerTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardwareManufacturerTb.Location = new System.Drawing.Point(183, 246);
            this.HardwareManufacturerTb.Name = "HardwareManufacturerTb";
            this.HardwareManufacturerTb.Size = new System.Drawing.Size(728, 24);
            this.HardwareManufacturerTb.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Device Model Boot";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Hardware Manu facturer";
            // 
            // DeviceModelBootTb
            // 
            this.DeviceModelBootTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceModelBootTb.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceModelBootTb.Location = new System.Drawing.Point(183, 217);
            this.DeviceModelBootTb.Name = "DeviceModelBootTb";
            this.DeviceModelBootTb.Size = new System.Drawing.Size(728, 24);
            this.DeviceModelBootTb.TabIndex = 63;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.RandomDeviceBtn);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 429);
            this.panel1.TabIndex = 73;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(3, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 34);
            this.label20.TabIndex = 67;
            this.label20.Text = "注意：";
            // 
            // RandomDeviceBtn
            // 
            this.RandomDeviceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomDeviceBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RandomDeviceBtn.Location = new System.Drawing.Point(9, 363);
            this.RandomDeviceBtn.Name = "RandomDeviceBtn";
            this.RandomDeviceBtn.Size = new System.Drawing.Size(157, 50);
            this.RandomDeviceBtn.TabIndex = 64;
            this.RandomDeviceBtn.Text = "隨機產生一個裝置";
            this.RandomDeviceBtn.UseVisualStyleBackColor = true;
            this.RandomDeviceBtn.Click += new System.EventHandler(this.RandomDeviceBtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(5, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 60);
            this.label21.TabIndex = 66;
            this.label21.Text = "為了您的帳號安全，\r\n請不要經常更改您的\r\n模擬裝置資訊。";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(5, 110);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(151, 68);
            this.label22.TabIndex = 69;
            this.label22.Text = "當然您也可以將模擬裝置\r\n改成和您手機一模一樣，\r\n這樣官方就會認為您使用\r\n您的手機登入";
            // 
            // tabProfile
            // 
            this.tabProfile.BackColor = System.Drawing.SystemColors.Control;
            this.tabProfile.Controls.Add(this.tableLayoutPanel3);
            this.tabProfile.Controls.Add(this.groupBox4);
            this.tabProfile.Location = new System.Drawing.Point(4, 24);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(1116, 429);
            this.tabProfile.TabIndex = 3;
            this.tabProfile.Text = "設定檔";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.checkedListBox1);
            this.groupBox4.Location = new System.Drawing.Point(6, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1107, 354);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            this.groupBox4.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "全選";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "帳號密碼（因為經過加密，在不同電腦上會密碼錯誤）",
            "預設座標",
            "莓果設定",
            "移動速度",
            "孵蛋設定",
            "傳送設定",
            "自動蒐集神奇寶貝設定",
            "自動進化神奇寶貝",
            "不蒐集的神奇寶貝",
            "不傳送的神奇寶貝",
            "不進化的神奇寶貝",
            "背包物品數量設定",
            "虛擬裝置設定"});
            this.checkedListBox1.Location = new System.Drawing.Point(9, 47);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(1092, 292);
            this.checkedListBox1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(739, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(365, 51);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = "原始設定檔";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(371, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(362, 51);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "匯入設定檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(362, 51);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "匯出設定檔";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveBtn);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(1124, 513);
            this.splitContainer1.SplitterDistance = 457;
            this.splitContainer1.TabIndex = 30;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Controls.Add(this.latLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.latitudeText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.longitudeText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.UseLastGPS, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 36);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1110, 423);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(9, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 169);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "在此只提供Android作法\n1.　首先在手機安裝APP：\nhttp://Bit.ly/GetDID\n2.　打開APP，長按內容可以複製\n3.　將複製下來的內容在" +
    "這裡貼上即可\n";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1107, 57);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 513);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(874, 497);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PokémonGO Rocket 設定";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabAccount.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CatchDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitCatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReLoginDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitSupply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatchDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WalkRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WalkDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelSpeedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyDistance)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transferThresText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.razzSettingText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreIV)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUltra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaster)).EndInit();
            this.tabLocation.ResumeLayout(false);
            this.tabLocation.PerformLayout();
            this.tabPokemon.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabItems.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabProfile.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label authTypeLabel;
        private System.Windows.Forms.ComboBox authTypeCb;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label latLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UserLoginBox;
        private System.Windows.Forms.TextBox UserPasswordBox;
        private System.Windows.Forms.TextBox latitudeText;
        private System.Windows.Forms.TextBox longitudeText;
        private System.Windows.Forms.ComboBox transferTypeCb;
        private System.Windows.Forms.CheckBox evolveAllChk;
        private System.Windows.Forms.Button saveBtn;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label TravelSpeedText;
        private System.Windows.Forms.TextBox AdressBox;
        private System.Windows.Forms.Button SetStart;
        private System.Windows.Forms.CheckBox CatchPokemonBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLocation;
        private System.Windows.Forms.TabPage tabPokemon;
        private System.Windows.Forms.CheckedListBox clbTransfer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbCatch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbEvolve;
        private System.Windows.Forms.CheckBox cbSelectAllEvolve;
        private System.Windows.Forms.CheckBox cbSelectAllCatch;
        private System.Windows.Forms.CheckBox cbSelectAllTransfer;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.Button RandomIDBtn;
        private System.Windows.Forms.ComboBox deviceTypeCb;
        private System.Windows.Forms.Button RandomDeviceBtn;
        private System.Windows.Forms.TextBox FirmwareFingerprintTb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox FirmwareTypeTb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox FirmwareTagsTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox FirmwareBrandTb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox HardwareModelTb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox HardwareManufacturerTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DeviceModelBootTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DeviceModelIdentifierTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DeviceModelTb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox DeviceBrandTb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox AndroidBootloaderTb;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox AndroidBoardNameTb;
        private System.Windows.Forms.Label BoardName;
        private System.Windows.Forms.TextBox DeviceIdTb;
        private System.Windows.Forms.Label deviceIdlb;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.Label useIncubatorsText;
        private System.Windows.Forms.ComboBox useIncubatorsCb;
        public System.Windows.Forms.ComboBox razzmodeCb;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox UseLastGPS;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DeleteLocation;
        private System.Windows.Forms.Button AddLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown CatchDelay;
        private System.Windows.Forms.NumericUpDown SupplyCheck;
        private System.Windows.Forms.NumericUpDown SupplyDelay;
        private System.Windows.Forms.NumericUpDown ReLoginDelay;
        private System.Windows.Forms.NumericUpDown CatchDistance;
        private System.Windows.Forms.NumericUpDown WalkDelay;
        private System.Windows.Forms.NumericUpDown TravelSpeedBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown SupplyDistance;
        private System.Windows.Forms.CheckBox checkBoxOR;
        private System.Windows.Forms.CheckBox checkBoxMoreCP;
        private System.Windows.Forms.CheckBox checkBoxMoreIV;
        private System.Windows.Forms.NumericUpDown numericUpDownMoreCP;
        private System.Windows.Forms.NumericUpDown numericUpDownMoreIV;
        private System.Windows.Forms.NumericUpDown transferThresText;
        private System.Windows.Forms.NumericUpDown razzSettingText;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown numericUpDownGreat;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDownUltra;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDownMaster;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown LimitCatch;
        private System.Windows.Forms.NumericUpDown LimitSupply;
        private System.Windows.Forms.NumericUpDown WalkRange;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
