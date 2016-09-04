using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.Win32;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PokemonGo.RocketAPI.Window
{
    internal partial class SettingsForm : Form
    {
        private DeviceHelper _deviceHelper;
        private List<DeviceInfo> _deviceInfos;
        private readonly GMapOverlay _playerOverlay = new GMapOverlay("players");
        private readonly GMapOverlay _TempOverlay = new GMapOverlay("TempLocation");
        private GMarkerGoogle _playerMarker;
        List<PointLatLng> GPS_Location = new List<PointLatLng>();

        private List<ItemId> itemSettings = new List<ItemId> {
            ItemId.Item寶貝球,
            ItemId.Item莓果,
            ItemId.Item藥水,
            ItemId.Item復活石,
        };

        public SettingsForm()
        {
            InitializeComponent();
            AdressBox.KeyDown += AdressBox_KeyDown;
            cbSelectAllCatch.CheckedChanged += CbSelectAllCatch_CheckedChanged;
            cbSelectAllTransfer.CheckedChanged += CbSelectAllTransfer_CheckedChanged;
            cbSelectAllEvolve.CheckedChanged += CbSelectAllEvolve_CheckedChanged;

            foreach (PokemonId id in Enum.GetValues(typeof(PokemonId)))
            {
                if (id == PokemonId.Missingno) continue;
                clbCatch.Items.Add(id);
                clbTransfer.Items.Add(id);
                clbEvolve.Items.Add(id);
            }

            foreach (ItemId itemId in itemSettings)
            {
                ItemData item = new ItemData();
                item.ItemId = itemId;
                flpItems.Controls.Add(new ItemSetting(item));
            }

            gMapControl1.Overlays.Add(_playerOverlay);
            gMapControl1.Overlays.Add(_TempOverlay);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSetting();
            // Initialize map:
            //use google provider
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            //not use proxy
            GMapProvider.WebProxy = null;
            //center map on moscow
            var lat = latitudeText.Text;
            var longit = longitudeText.Text;
            lat.Replace(',', '.');
            longit.Replace(',', '.');
            gMapControl1.Position = new PointLatLng(double.Parse(lat.Replace(",", "."), CultureInfo.InvariantCulture),
                double.Parse(longit.Replace(",", "."), CultureInfo.InvariantCulture));

            //zoom min/max; default both = 2
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.CenterPen = new Pen(Color.Red, 2);
            gMapControl1.MinZoom = trackBar.Maximum = 1;
            gMapControl1.MaxZoom = trackBar.Maximum = 20;
            trackBar.Value = 15;

            //set zoom
            gMapControl1.Zoom = trackBar.Value;

            //disable map focus
            gMapControl1.DisableFocusOnMouseEnter = true;

            foreach (var pokemonIdSetting in Settings.Instance.ExcludedPokemonCatch)
            {
                for (var i = 0; i < clbCatch.Items.Count; i++)
                {
                    var pokemonId = (PokemonId)clbCatch.Items[i];
                    if (pokemonIdSetting == pokemonId)
                    {
                        clbCatch.SetItemChecked(i, true);
                    }
                }
            }

            foreach (var pokemonIdSetting in Settings.Instance.ExcludedPokemonTransfer)
            {
                for (var i = 0; i < clbTransfer.Items.Count; i++)
                {
                    var pokemonId = (PokemonId)clbTransfer.Items[i];
                    if (pokemonIdSetting == pokemonId)
                    {
                        clbTransfer.SetItemChecked(i, true);
                    }
                }
            }

            foreach (var pokemonIdSetting in Settings.Instance.ExcludedPokemonEvolve)
            {
                for (var i = 0; i < clbEvolve.Items.Count; i++)
                {
                    var pokemonId = (PokemonId)clbEvolve.Items[i];
                    if (pokemonIdSetting == pokemonId)
                    {
                        clbEvolve.SetItemChecked(i, true);
                    }
                }
            }

            var itemCounts = Settings.Instance.ItemCounts;
            foreach (ItemSetting itemSetting in flpItems.Controls)
            {
                foreach (var itemCount in itemCounts)
                {
                    if (itemSetting.ItemData.ItemId == itemCount.ItemId)
                    {
                        itemSetting.ItemData = itemCount;
                    }
                }
            }

            // Device settings
            _deviceHelper = new DeviceHelper();
            _deviceInfos = _deviceHelper.DeviceBucket;

            if (Settings.Instance.DeviceId == "8525f6d8251f71b7")   PopulateDevice();
            else
            {
                DeviceIdTb.Text = Settings.Instance.DeviceId;
                AndroidBoardNameTb.Text = Settings.Instance.AndroidBoardName;
                AndroidBootloaderTb.Text = Settings.Instance.AndroidBootloader;
                DeviceBrandTb.Text = Settings.Instance.DeviceBrand;
                DeviceModelTb.Text = Settings.Instance.DeviceModel;
                DeviceModelIdentifierTb.Text = Settings.Instance.DeviceModelIdentifier;
                DeviceModelBootTb.Text = Settings.Instance.DeviceModelBoot;
                HardwareManufacturerTb.Text = Settings.Instance.HardwareManufacturer;
                HardwareModelTb.Text = Settings.Instance.HardwareModel;
                FirmwareBrandTb.Text = Settings.Instance.FirmwareBrand;
                FirmwareTagsTb.Text = Settings.Instance.FirmwareTags;
                FirmwareTypeTb.Text = Settings.Instance.FirmwareType;
                FirmwareFingerprintTb.Text = Settings.Instance.FirmwareFingerprint;
                deviceTypeCb.SelectedIndex = Settings.Instance.DeviceBrand.ToLower() == "apple" ? 0 : 1;
            }
            UpdateRoute();
        }
        public void LoadSetting()
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket");
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
            authTypeCb.SelectedIndex = Convert.ToInt32(Reg.GetValue("LoginType", 0));
            UserLoginBox.Text = Convert.ToString(Reg.GetValue("LoginAccount", ""));
            UserPasswordBox.Text = "（未變更）";/*Convert.ToString(Reg.GetValue("LoginPassword", ""));*/
            GPS_Location = Settings.Instance.GPS_Location;
            latitudeText.Text = Convert.ToString(GPS_Location[0].Lat);
            longitudeText.Text = Convert.ToString(GPS_Location[0].Lng);
            UseLastGPS.Checked = Convert.ToBoolean(Reg.GetValue("EnableLastGPS", true));
            razzmodeCb.SelectedIndex = Convert.ToInt32(Reg.GetValue("RazzType", 0));
            TravelSpeedBox.Value = Convert.ToInt32(Reg.GetValue("Speed", 10));
            useIncubatorsCb.SelectedIndex = Convert.ToInt32(Reg.GetValue("Incubator", 2));
            transferTypeCb.SelectedIndex = Convert.ToInt32(Reg.GetValue("TransferType", 6));
            if (transferTypeCb.SelectedIndex == 1) Reg.SetValue("TransferCP", transferThresText.Value);
            else if (transferTypeCb.SelectedIndex == 2) Reg.SetValue("TransferIV", transferThresText.Value);
            else if (transferTypeCb.SelectedIndex != 7) Reg.SetValue("TransferCount", transferThresText.Value);
            CatchPokemonBox.Checked = Convert.ToBoolean(Reg.GetValue("EnableCatch", true));
            evolveAllChk.Checked = Convert.ToBoolean(Reg.GetValue("EnableEvolve", false));
            deviceTypeCb.SelectedIndex = Convert.ToInt32(Reg.GetValue("Device_Type", 0));
            DeviceIdTb.Text = Convert.ToString(Reg.GetValue("Device_ID", ""));
            AndroidBoardNameTb.Text = Convert.ToString(Reg.GetValue("Device_ABN", ""));
            AndroidBootloaderTb.Text = Convert.ToString(Reg.GetValue("Device_AB", ""));
            DeviceBrandTb.Text = Convert.ToString(Reg.GetValue("Device_DB", ""));
            DeviceModelTb.Text = Convert.ToString(Reg.GetValue("Device_DM", ""));
            DeviceModelIdentifierTb.Text = Convert.ToString(Reg.GetValue("Device_DMI", ""));
            DeviceModelBootTb.Text = Convert.ToString(Reg.GetValue("Device_DMB", ""));
            HardwareManufacturerTb.Text = Convert.ToString(Reg.GetValue("Device_HMf", ""));
            HardwareModelTb.Text = Convert.ToString(Reg.GetValue("Device_HM", ""));
            FirmwareBrandTb.Text = Convert.ToString(Reg.GetValue("Device_FB", ""));
            FirmwareTagsTb.Text = Convert.ToString(Reg.GetValue("Device_FTa", ""));
            FirmwareTypeTb.Text = Convert.ToString(Reg.GetValue("Device_FTy", ""));
            FirmwareFingerprintTb.Text = Convert.ToString(Reg.GetValue("Device_FF", ""));
            CatchDelay.Value = Settings.Instance.DelayCatch;
            SupplyDelay.Value = Settings.Instance.DelaySupply;
            WalkDelay.Value = Settings.Instance.DelayWalk;
            SupplyCheck.Value = Settings.Instance.DelayCheck;
            ReLoginDelay.Value = Settings.Instance.DelayReLogin;
            CatchDistance.Value = Settings.Instance.DistanceCatch;
            SupplyDistance.Value = Settings.Instance.DistanceSupply;
            numericUpDownMoreIV.Value = Settings.Instance.CatchMoreIV;
            numericUpDownMoreCP.Value = Settings.Instance.CatchMoreCP;
            checkBoxMoreIV.Checked = Settings.Instance.EnableCatchMoreIV;
            checkBoxMoreCP.Checked = Settings.Instance.EnableCatchMoreCP;
            checkBoxOR.Checked = Settings.Instance.EnableCatchOR;
            numericUpDownGreat.Value = Settings.Instance.CatchUseGreat;
            numericUpDownUltra.Value = Settings.Instance.CatchUseUltra;
            numericUpDownMaster.Value = Settings.Instance.CatchUseMaster;
            WalkRange.Value = Settings.Instance.WalkRange;
            LimitSupply.Value = Settings.Instance.LimitSupply;
            LimitCatch.Value = Settings.Instance.LimitCatch;
            Reg.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveSetting();
            if (DeviceIdTb.Text == "8525f6d8251f71b7")  PopulateDevice();
            MainForm.ResetMap();
            Close();
        }
        public void SaveSetting()
        {
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
            Reg.SetValue("LoginType", authTypeCb.SelectedIndex);
            Reg.SetValue("LoginAccount", UserLoginBox.Text);
            if (UserPasswordBox.PasswordChar == '*')
            {
                byte[] PasswordByte = System.Text.Encoding.UTF8.GetBytes(UserPasswordBox.Text);
                UserPasswordBox.Text = "（未變更）";
                UserPasswordBox.PasswordChar = Convert.ToChar(0);
                string ComputerName = Environment.MachineName;
                byte[] ComputerByte = System.Text.Encoding.UTF8.GetBytes(ComputerName);
                while(ComputerByte.Length < 16)
                {
                    ComputerName += ComputerName;
                    ComputerByte = System.Text.Encoding.UTF8.GetBytes(ComputerName);
                }
                string SafePassword = "";
                int j = PasswordByte.Length;
                if (j < 16) j = 16;
                for(int i = 0; i < j; i++)
                {
                    int[] Temp = { 0, 0, 0 };
                    if (i < PasswordByte.Length) Temp[1] = Convert.ToInt32(PasswordByte[i]);
                    if (i < 16) Temp[2] = Convert.ToInt32(ComputerByte[i]);
                    Temp[0] = Temp[1] + Temp[2];
                    SafePassword += Convert.ToString(Temp[0], 16).PadLeft(3, '0');
                }
                Reg.SetValue("LoginPassword", SafePassword);
            }
            Reg.SetValue("GPS_La", latitudeText.Text);
            Reg.SetValue("GPS_Lo", longitudeText.Text);
            Settings.Instance.GPS_Location = GPS_Location;
            Reg.SetValue("EnableLastGPS", UseLastGPS.Checked);
            Reg.SetValue("RazzType", razzmodeCb.SelectedIndex);
            if (razzmodeCb.SelectedIndex == 0) Reg.SetValue("RazzValue", (float)(razzSettingText.Value / 100));
            else if (razzmodeCb.SelectedIndex == 1) Reg.SetValue("RazzCP", razzSettingText.Value);
            Reg.SetValue("Speed", TravelSpeedBox.Value);
            Reg.SetValue("Incubator", useIncubatorsCb.SelectedIndex);
            Reg.SetValue("TransferType", transferTypeCb.SelectedIndex);
            if (transferTypeCb.SelectedIndex == 1) Reg.SetValue("TransferCP", transferThresText.Value);
            else if (transferTypeCb.SelectedIndex == 2) Reg.SetValue("TransferIV", transferThresText.Value);
            else if (transferTypeCb.SelectedIndex != 7) Reg.SetValue("TransferCount", transferThresText.Value);
            Reg.SetValue("EnableCatch", CatchPokemonBox.Checked);
            Reg.SetValue("EnableEvolve", evolveAllChk.Checked);
            Reg.SetValue("ExcludedCatch", string.Join(",", clbCatch.CheckedItems.Cast<PokemonId>()));
            Reg.SetValue("ExcludedTransfer", string.Join(",", clbTransfer.CheckedItems.Cast<PokemonId>()));
            Reg.SetValue("ExcludedEvolve", string.Join(",", clbEvolve.CheckedItems.Cast<PokemonId>()));
            Settings.Instance.ItemCounts = flpItems.Controls.Cast<ItemSetting>().Select(i => i.ItemData).ToList();
            Reg.SetValue("Device_Type", deviceTypeCb.SelectedIndex);
            Reg.SetValue("Device_ID", DeviceIdTb.Text);
            Reg.SetValue("Device_ABN", AndroidBoardNameTb.Text);
            Reg.SetValue("Device_AB", AndroidBootloaderTb.Text);
            Reg.SetValue("Device_DB", DeviceBrandTb.Text);
            Reg.SetValue("Device_DM", DeviceModelTb.Text);
            Reg.SetValue("Device_DMI", DeviceModelIdentifierTb.Text);
            Reg.SetValue("Device_DMB", DeviceModelBootTb.Text);
            Reg.SetValue("Device_HMf", HardwareManufacturerTb.Text);
            Reg.SetValue("Device_HM", HardwareModelTb.Text);
            Reg.SetValue("Device_FB", FirmwareBrandTb.Text);
            Reg.SetValue("Device_FTa", FirmwareTagsTb.Text);
            Reg.SetValue("Device_FTy", FirmwareTypeTb.Text);
            Reg.SetValue("Device_FF", FirmwareFingerprintTb.Text);
            Reg.SetValue("DelayCatch", CatchDelay.Value);
            Reg.SetValue("DelaySupply", SupplyDelay.Value);
            Reg.SetValue("DelayWalk", WalkDelay.Value);
            Reg.SetValue("DelayCheck", SupplyCheck.Value);
            Reg.SetValue("DelayReLogin", ReLoginDelay.Value);
            Reg.SetValue("DistanceSupply", SupplyDistance.Value);
            Reg.SetValue("DistanceCatch", CatchDistance.Value);
            Reg.SetValue("CatchMoreIV", numericUpDownMoreIV.Value);
            Reg.SetValue("CatchMoreCP", numericUpDownMoreCP.Value);
            Reg.SetValue("EnableCatchMoreIV", checkBoxMoreIV.Checked);
            Reg.SetValue("EnableCatchMoreCP", checkBoxMoreCP.Checked);
            Reg.SetValue("EnableCatchOR", checkBoxOR.Checked);
            Reg.SetValue("CatchUseGreat", numericUpDownGreat.Value);
            Reg.SetValue("CatchUseUltra", numericUpDownUltra.Value);
            Reg.SetValue("CatchUseMaster", numericUpDownMaster.Value);
            Settings.Instance.WalkRange = Convert.ToInt32(WalkRange.Value);
            Settings.Instance.LimitSupply = Convert.ToInt32(LimitSupply.Value);
            Settings.Instance.LimitCatch = Convert.ToInt32(LimitCatch.Value);
            Reg.Close();
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var localCoordinates = e.Location;
            gMapControl1.Position = gMapControl1.FromLocalToLatLng(localCoordinates.X, localCoordinates.Y);
            double X = Math.Round(gMapControl1.Position.Lat, 8);
            double Y = Math.Round(gMapControl1.Position.Lng, 8);
            _TempOverlay.Clear();
            _playerMarker = new GMarkerGoogle(new PointLatLng(X, Y), GMarkerGoogleType.blue);
            _TempOverlay.Markers.Add(_playerMarker);
            SetStart.Enabled = true;
            AddLocation.Enabled = true;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBar.Value;
        }

        private void transferTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            transferThresText.Visible = (transferTypeCb.SelectedIndex != 0) && (transferTypeCb.SelectedIndex != 7);
            label4.Visible = (transferTypeCb.SelectedIndex != 0) && (transferTypeCb.SelectedIndex != 7);
            if (transferTypeCb.SelectedIndex == 1)
            {
                label4.Text = "CP以下傳送：";
                transferThresText.Value = Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "TransferCP", "1000"));
                transferThresText.Maximum = 5000;
            }
            else if (transferTypeCb.SelectedIndex == 2)
            {
                label4.Text = "IV以下傳送：";
                transferThresText.Value = Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "TransferIV", "80"));
                transferThresText.Maximum = 100;
            }
            else if (transferTypeCb.SelectedIndex != 7)
            {
                label4.Text = "留最強幾隻：";
                transferThresText.Value = Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "TransferCount", "2"));
                transferThresText.Maximum = 1000;
            }
        }

        private void FindAdressButton_Click(object sender, EventArgs e)
        {
            GPS_Location.Clear();
            GPS_Location.Add(new PointLatLng(gMapControl1.Position.Lat,gMapControl1.Position.Lng));
            latitudeText.Text = Convert.ToString(GPS_Location[0].Lat);
            longitudeText.Text = Convert.ToString(GPS_Location[0].Lng);
            UpdateRoute();
        }

        private void AddLocation_Click(object sender, EventArgs e)
        {
            GPS_Location.Add(new PointLatLng(gMapControl1.Position.Lat,gMapControl1.Position.Lng));
            UpdateRoute();
        }

        private void DeleteLocation_Click(object sender, EventArgs e)
        {
            GPS_Location.RemoveAt(GPS_Location.Count - 1);
            UpdateRoute();
        }

        void UpdateRoute()
        {
            _TempOverlay.Clear();
            _playerOverlay.Clear();
            _playerMarker = new GMarkerGoogle(GPS_Location[0], GMarkerGoogleType.orange);
            _playerOverlay.Markers.Add(_playerMarker);
            if (GPS_Location.Count > 1)
                for (int i = 1; i < GPS_Location.Count; i++)
                {
                    _playerMarker = new GMarkerGoogle(GPS_Location[i], GMarkerGoogleType.orange_small);
                    _playerOverlay.Markers.Add(_playerMarker);
                }
            _playerOverlay.Routes.Clear();
            _playerOverlay.Routes.Add(new GMapRoute(GPS_Location, "Walking Path"));
            SetStart.Enabled = false;
            AddLocation.Enabled = false;
            DeleteLocation.Enabled = GPS_Location.Count > 1;
        }

        private void TravelSpeedBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void razzSettingText_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void AdressBox_Leave(object sender, EventArgs e)
        {
            if (AdressBox.Text.Length == 0)
            {
                AdressBox.Text = "輸入一個地址或一個地點";
                AdressBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void AdressBox_Enter(object sender, EventArgs e)
        {
            if (AdressBox.Text == "輸入一個地址或一個地點")
            {
                AdressBox.Text = "";
                AdressBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void CbSelectAllEvolve_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < clbEvolve.Items.Count; i++)
            {
                clbEvolve.SetItemChecked(i, cbSelectAllEvolve.Checked);
            }
        }

        private void CbSelectAllTransfer_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < clbTransfer.Items.Count; i++)
            {
                clbTransfer.SetItemChecked(i, cbSelectAllTransfer.Checked);
            }
        }

        private void CbSelectAllCatch_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCatch.Items.Count; i++)
            {
                clbCatch.SetItemChecked(i, cbSelectAllCatch.Checked);
            }
        }

        private void AdressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gMapControl1.SetPositionByKeywords(AdressBox.Text);
                gMapControl1.Zoom = 15;
            }
        }

        private void RandomDeviceBtn_Click(object sender, EventArgs e)
        {
            PopulateDevice();
        }

        private void deviceTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDevice(deviceTypeCb.SelectedIndex);
        }

        private void RandomIDBtn_Click(object sender, EventArgs e)
        {
            DeviceIdTb.Text = _deviceHelper.RandomString(16, "0123456789abcdef");
        }

        private void PopulateDevice(int tabIndex = -1)
        {
            deviceTypeCb.SelectedIndex = tabIndex == -1 ? _deviceHelper.GetRandomIndex(2) : tabIndex;
            var candidateDevices = deviceTypeCb.SelectedIndex == 0
                ? _deviceInfos.Where(d => d.DeviceBrand.ToLower() == "apple").ToList()
                : _deviceInfos.Where(d => d.DeviceBrand.ToLower() != "apple").ToList();
            var selectIndex = _deviceHelper.GetRandomIndex(candidateDevices.Count);

            DeviceIdTb.Text = candidateDevices[selectIndex].DeviceId == "8525f6d8251f71b7"
                ? _deviceHelper.RandomString(16, "0123456789abcdef")
                : candidateDevices[selectIndex].DeviceId;
            AndroidBoardNameTb.Text = candidateDevices[selectIndex].AndroidBoardName;
            AndroidBootloaderTb.Text = candidateDevices[selectIndex].AndroidBootloader;
            DeviceBrandTb.Text = candidateDevices[selectIndex].DeviceBrand;
            DeviceModelTb.Text = candidateDevices[selectIndex].DeviceModel;
            DeviceModelIdentifierTb.Text = candidateDevices[selectIndex].DeviceModelIdentifier;
            DeviceModelBootTb.Text = candidateDevices[selectIndex].DeviceModelBoot;
            HardwareManufacturerTb.Text = candidateDevices[selectIndex].HardwareManufacturer;
            HardwareModelTb.Text = candidateDevices[selectIndex].HardwareModel;
            FirmwareBrandTb.Text = candidateDevices[selectIndex].FirmwareBrand;
            FirmwareTagsTb.Text = candidateDevices[selectIndex].FirmwareTags;
            FirmwareTypeTb.Text = candidateDevices[selectIndex].FirmwareType;
            FirmwareFingerprintTb.Text = candidateDevices[selectIndex].FirmwareFingerprint;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.IndexOf("DeviceId:") >= 0)
            {
                for(int i = 0; i < 13; i++)
                {
                    string Search = "";
                    switch (i)
                    {
                        case 0:
                            Search = "DeviceId";
                            break;
                        case 1:
                            Search = "AndroidBoardName";
                            break;
                        case 2:
                            Search = "AndroidBootloader";
                            break;
                        case 3:
                            Search = "DeviceBrand";
                            break;
                        case 4:
                            Search = "DeviceModel";
                            break;
                        case 5:
                            Search = "DeviceModelIdentifier";
                            break;
                        case 6:
                            Search = "DeviceModelBoot";
                            break;
                        case 7:
                            Search = "HardwareManufacturer";
                            break;
                        case 8:
                            Search = "HardwareModel";
                            break;
                        case 9:
                            Search = "FirmwareBrand";
                            break;
                        case 10:
                            Search = "FirmwareTags";
                            break;
                        case 11:
                            Search = "FirmwareType";
                            break;
                        case 12:
                            Search = "FirmwareFingerprint";
                            break;
                    }
                    if (Search == "") break;
                    if (textBox1.Text.IndexOf(Search) >= 0)
                    {
                        string TempText = textBox1.Text.Substring(textBox1.Text.IndexOf(":", textBox1.Text.IndexOf(Search)) + 1);
                        while (TempText.Substring(0, 1) == " ")
                            TempText = TempText.Substring(1);
                        if (TempText.IndexOf(Environment.NewLine) >= 0) TempText = TempText.Substring(0, TempText.IndexOf(Environment.NewLine));
                        switch (i)
                        {
                            case 0:
                                DeviceIdTb.Text = TempText;
                                break;
                            case 1:
                                AndroidBoardNameTb.Text = TempText;
                                break;
                            case 2:
                                AndroidBootloaderTb.Text = TempText;
                                break;
                            case 3:
                                DeviceBrandTb.Text = TempText;
                                break;
                            case 4:
                                DeviceModelTb.Text = TempText;
                                break;
                            case 5:
                                DeviceModelIdentifierTb.Text = TempText;
                                break;
                            case 6:
                                DeviceModelBootTb.Text = TempText;
                                break;
                            case 7:
                                HardwareManufacturerTb.Text = TempText;
                                break;
                            case 8:
                                HardwareModelTb.Text = TempText;
                                break;
                            case 9:
                                FirmwareBrandTb.Text = TempText;
                                break;
                            case 10:
                                FirmwareTagsTb.Text = TempText;
                                break;
                            case 11:
                                FirmwareTypeTb.Text = TempText;
                                break;
                            case 12:
                                FirmwareFingerprintTb.Text = TempText;
                                break;
                        }
                        deviceTypeCb.SelectedItem = "Android";
                    }
                }
            }
        }

        private void UserLoginBox_TextChanged(object sender, EventArgs e)
        {
            UserPasswordBox.Text = "";
        }
        
        private void UserPasswordBox_Enter(object sender, EventArgs e)
        {
            if (UserPasswordBox.Text == "（未變更）")
            {
                UserPasswordBox.Text = "";
                UserPasswordBox.PasswordChar = '*';
            }
        }

        private void UserPasswordBox_Leave(object sender, EventArgs e)
        {
            if (UserPasswordBox.Text == "")
            {
                UserPasswordBox.Text = "（未變更）";
                UserPasswordBox.PasswordChar = Convert.ToChar(0);
            }
        }

        private void UserPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (UserPasswordBox.Text == "（未變更）") UserPasswordBox.PasswordChar = Convert.ToChar(0);
            else UserPasswordBox.PasswordChar = '*';
        }

        private void authTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLoginBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "匯出設定檔")
            {
                groupBox4.Text = "選擇要匯出成檔案的設定：";
                button1.Text = "將勾選的匯出成檔案";
                button2.Visible = false;
                button3.Text = "取消";
                groupBox4.Visible = true;
            }
            else if (button1.Text == "將勾選的匯出成檔案")
            {
                saveFileDialog1.Filter = "PokémonGO Rocket設定檔|*.Poké";
                saveFileDialog1.Title = "設定匯出路徑";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    string Write = "PokémonGO Rocket 設定檔";
                    for (int i = 0; i < 13; i++) if (checkedListBox1.GetItemChecked(i))
                        {
                            switch (i)
                            {
                                case 0 :
                                    Write += "\nLoginType:" + authTypeCb.SelectedIndex + "\nLoginAccount:" + UserLoginBox.Text + "\nLoginPassword:" + Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "LoginPassword", "");
                                    break;
                                case 1:
                                    Write += "\nGPS:" + Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "GPS", "24.161653,120.647146;") + "\nEnableLastGPS:" + UseLastGPS.Checked;
                                    break;
                                case 2:
                                    Write += "\nRazzType:" + razzmodeCb.SelectedIndex + "\nRazzValue:" + razzSettingText.Value;
                                    break;
                                case 3:
                                    Write += $"\nSpeed:{TravelSpeedBox.Value}\nDelayCatch:{CatchDelay.Value}\nDelayCheck:{SupplyCheck.Value}\nDelaySupply:{SupplyDelay.Value}\nDelayWalk:{WalkDelay.Value}\nDistanceCatch:{CatchDistance.Value}\nDistanceSupply:{SupplyDistance.Value}\nDelayReLogin:{ReLoginDelay.Value}";
                                    break;
                                case 4:
                                    Write += "\nIncubator:" + useIncubatorsCb.SelectedIndex;
                                    break;
                                case 5:
                                    Write += "\nTransferType:" + transferTypeCb.SelectedIndex + "\nTransferValue:" + transferThresText.Value;
                                    break;
                                case 6:
                                    Write += $"\nEnableCatch:{CatchPokemonBox.Checked}\nCatchMoreIV:{numericUpDownMoreIV.Value}\nCatchMoreCP:{numericUpDownMoreCP.Value}\nEnableCatchMoreIV:{checkBoxMoreIV.Checked}\nEnableCatchMoreCP:{checkBoxMoreCP.Checked}\nEnableCatchOR:{checkBoxOR.Checked}";
                                    Write += $"\nCatchUseGreat:{numericUpDownGreat.Value}\nCatchUseUltra:{numericUpDownUltra.Value}\nCatchUseMaster:{numericUpDownMaster.Value}";
                                    break;
                                case 7:
                                    Write += "\nEnableEvolve:" + evolveAllChk.Checked;
                                    break;
                                case 8:
                                    Write += "\nExcludedCatch:" + string.Join(",", clbCatch.CheckedItems.Cast<PokemonId>());
                                    break;
                                case 9:
                                    Write += "\nExcludedTransfer:" + string.Join(",", clbTransfer.CheckedItems.Cast<PokemonId>());
                                    break;
                                case 10:
                                    Write += "\nExcludedEvolve:" + string.Join(",", clbEvolve.CheckedItems.Cast<PokemonId>());
                                    break;
                                case 11:
                                    Write += "\nBackpack:" + Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "Backpack", "");
                                    break;
                                case 12:
                                    Write += "\nDevice_Type:" + deviceTypeCb.SelectedIndex +
                                            "\nDevice_ID:" + DeviceIdTb.Text +
                                            "\nDevice_ABN:" + AndroidBoardNameTb.Text +
                                            "\nDevice_AB:" + AndroidBootloaderTb.Text +
                                            "\nDevice_DB:" + DeviceBrandTb.Text +
                                            "\nDevice_DM:" + DeviceModelTb.Text +
                                            "\nDevice_DMI:" + DeviceModelIdentifierTb.Text +
                                            "\nDevice_DMB:" + DeviceModelBootTb.Text +
                                            "\nDevice_HMf:" + HardwareManufacturerTb.Text +
                                            "\nDevice_HM:" + HardwareModelTb.Text +
                                            "\nDevice_FB:" + FirmwareBrandTb.Text +
                                            "\nDevice_FTa:" + FirmwareTagsTb.Text +
                                            "\nDevice_FTy:" + FirmwareTypeTb.Text +
                                            "\nDevice_FF:" + FirmwareFingerprintTb.Text;
                                    break;
                            }
                        }
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, Write + "\nPokémonGO Rocket 結束");
                    OtherCancel();
                }
            }
            else if (button1.Text == "將勾選的還原預設值")
            {
                RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
                for (int i = 0; i < 13; i++) if (checkedListBox1.GetItemChecked(i))
                    {
                        try
                        {
                            switch (i)
                            {
                                case 0:
                                    Reg.DeleteValue("LoginAccount");
                                    Reg.DeleteValue("LoginPassword");
                                    Reg.DeleteValue("LoginType");
                                    break;
                                case 1:
                                    Reg.DeleteValue("GPS");
                                    Reg.DeleteValue("EnableLastGPS");
                                    break;
                                case 2:
                                    Reg.DeleteValue("RazzType");
                                    Reg.DeleteValue("RazzValue");
                                    break;
                                case 3:
                                    Reg.DeleteValue("Speed");
                                    Reg.DeleteValue("DelayCatch");
                                    Reg.DeleteValue("DelayCheck");
                                    Reg.DeleteValue("DelaySupply");
                                    Reg.DeleteValue("DelayWalk");
                                    Reg.DeleteValue("DelayReLogin");
                                    Reg.DeleteValue("DistanceCatch");
                                    Reg.DeleteValue("DistanceSupply");
                                    break;
                                case 4:
                                    Reg.DeleteValue("Incubator");
                                    break;
                                case 5:
                                    Reg.DeleteValue("TransferType");
                                    Reg.DeleteValue("TransferValue");
                                    Reg.DeleteValue("EnableKeepEvolve");
                                    break;
                                case 6:
                                    Reg.DeleteValue("EnableCatch");
                                    Reg.DeleteValue("CatchMoreIV");
                                    Reg.DeleteValue("CatchMoreCP");
                                    Reg.DeleteValue("EnableCatchMoreIV");
                                    Reg.DeleteValue("EnableCatchMoreCP");
                                    Reg.DeleteValue("EnableCatchOR");
                                    Reg.DeleteValue("CatchUseGreat");
                                    Reg.DeleteValue("CatchUseUltra");
                                    Reg.DeleteValue("CatchUseMaster");
                                    break;
                                case 7:
                                    Reg.DeleteValue("EnableEvolve");
                                    break;
                                case 8:
                                    Reg.DeleteValue("ExcludedCatch");
                                    break;
                                case 9:
                                    Reg.DeleteValue("ExcludedTransfer");
                                    break;
                                case 10:
                                    Reg.DeleteValue("ExcludedEvolve");
                                    break;
                                case 11:
                                    Reg.DeleteValue("Backpack");
                                    break;
                                case 12:
                                    Reg.DeleteValue("Device_AB");
                                    Reg.DeleteValue("Device_ABN");
                                    Reg.DeleteValue("Device_DB");
                                    Reg.DeleteValue("Device_DM");
                                    Reg.DeleteValue("Device_DMB");
                                    Reg.DeleteValue("Device_DMI");
                                    Reg.DeleteValue("Device_FB");
                                    Reg.DeleteValue("Device_FF");
                                    Reg.DeleteValue("Device_FTa");
                                    Reg.DeleteValue("Device_FTy");
                                    Reg.DeleteValue("Device_HM");
                                    Reg.DeleteValue("Device_HMf");
                                    Reg.DeleteValue("Device_ID");
                                    Reg.DeleteValue("Device_Type");
                                    break;
                            }
                        }catch(Exception ex) { }
                    }
                Reg.Close();
                OtherCancel();
            }
            else if (button1.Text == "將勾選的設定值匯入")
            {
                RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
                string[] Read = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                var ReadTitle = new List<string>();
                var ReadValue = new List<string>();
                for (int i = 0; i < Read.Length; i++) if (Read[i].IndexOf(":") >= 0) 
                    {
                        ReadTitle.Add(Read[i].Substring(0, Read[i].IndexOf(":")));
                        ReadValue.Add(Read[i].Substring(Read[i].IndexOf(":") + 1));
                    }
                for (int i = 0; i < 13; i++) if (checkedListBox1.GetItemChecked(i))
                    {
                        try
                        {
                            switch (i)
                            {
                                case 0:
                                    Reg.SetValue("LoginAccount", ReadValue[ReadTitle.IndexOf("LoginAccount")]);
                                    Reg.SetValue("LoginPassword", ReadValue[ReadTitle.IndexOf("LoginPassword")]);
                                    Reg.SetValue("LoginType", ReadValue[ReadTitle.IndexOf("LoginType")]);
                                    break;
                                case 1:
                                    Reg.SetValue("GPS", ReadValue[ReadTitle.IndexOf("GPS")]);
                                    Reg.SetValue("EnableLastGPS", ReadValue[ReadTitle.IndexOf("EnableLastGPS")]);
                                    break;
                                case 2:
                                    Reg.SetValue("RazzType", ReadValue[ReadTitle.IndexOf("RazzType")]);
                                    Reg.SetValue("RazzValue", ReadValue[ReadTitle.IndexOf("RazzValue")]);
                                    break;
                                case 3:
                                    Reg.SetValue("Speed", ReadValue[ReadTitle.IndexOf("Speed")]);
                                    Reg.SetValue("DelayCatch", ReadValue[ReadTitle.IndexOf("DelayCatch")]);
                                    Reg.SetValue("DelayCheck", ReadValue[ReadTitle.IndexOf("DelayCheck")]);
                                    Reg.SetValue("DelaySupply", ReadValue[ReadTitle.IndexOf("DelaySupply")]);
                                    Reg.SetValue("DelayWalk", ReadValue[ReadTitle.IndexOf("DelayWalk")]);
                                    Reg.SetValue("DelayReLogin", ReadValue[ReadTitle.IndexOf("DelayReLogin")]);
                                    Reg.SetValue("DistanceCatch", ReadValue[ReadTitle.IndexOf("DistanceCatch")]);
                                    Reg.SetValue("DistanceSupply", ReadValue[ReadTitle.IndexOf("DistanceSupply")]);
                                    break;
                                case 4:
                                    Reg.SetValue("Incubator", ReadValue[ReadTitle.IndexOf("Incubator")]);
                                    break;
                                case 5:
                                    byte TransferType = Convert.ToByte(ReadValue[ReadTitle.IndexOf("TransferType")]);
                                    Reg.SetValue("TransferType", TransferType);
                                    Reg.SetValue("EnableKeepEvolve", ReadValue[ReadTitle.IndexOf("EnableKeepEvolve")]);
                                    if (TransferType == 1) Reg.SetValue("TransferCP", ReadValue[ReadTitle.IndexOf("TransferValue")]);
                                    else if (TransferType == 2) Reg.SetValue("TransferIV", ReadValue[ReadTitle.IndexOf("TransferValue")]);
                                    else if (TransferType != 7) Reg.SetValue("TransferIV", ReadValue[ReadTitle.IndexOf("TransferCount")]);
                                    break;
                                case 6:
                                    Reg.SetValue("EnableCatch", ReadValue[ReadTitle.IndexOf("EnableCatch")]);
                                    Reg.SetValue("CatchMoreIV", ReadValue[ReadTitle.IndexOf("CatchMoreIV")]);
                                    Reg.SetValue("CatchMoreCP", ReadValue[ReadTitle.IndexOf("CatchMoreCP")]);
                                    Reg.SetValue("EnableCatchMoreIV", ReadValue[ReadTitle.IndexOf("EnableCatchMoreIV")]);
                                    Reg.SetValue("EnableCatchMoreCP", ReadValue[ReadTitle.IndexOf("EnableCatchMoreCP")]);
                                    Reg.SetValue("EnableCatchOR", ReadValue[ReadTitle.IndexOf("EnableCatchOR")]);
                                    Reg.SetValue("CatchUseGreat", ReadValue[ReadTitle.IndexOf("CatchUseGreat")]);
                                    Reg.SetValue("CatchUseUltra", ReadValue[ReadTitle.IndexOf("CatchUseUltra")]);
                                    Reg.SetValue("CatchUseMaster", ReadValue[ReadTitle.IndexOf("CatchUseMaster")]);
                                    break;
                                case 7:
                                    Reg.SetValue("EnableEvolve", ReadValue[ReadTitle.IndexOf("EnableEvolve")]);
                                    break;
                                case 8:
                                    Reg.SetValue("ExcludedCatch", ReadValue[ReadTitle.IndexOf("ExcludedCatch")]);
                                    break;
                                case 9:
                                    Reg.SetValue("ExcludedTransfer", ReadValue[ReadTitle.IndexOf("ExcludedTransfer")]);
                                    break;
                                case 10:
                                    Reg.SetValue("ExcludedEvolve", ReadValue[ReadTitle.IndexOf("ExcludedEvolve")]);
                                    break;
                                case 11:
                                    Reg.SetValue("Backpack", ReadValue[ReadTitle.IndexOf("Backpack")]);
                                    break;
                                case 12:
                                    Reg.SetValue("Device_AB", ReadValue[ReadTitle.IndexOf("Device_AB")]);
                                    Reg.SetValue("Device_ABN", ReadValue[ReadTitle.IndexOf("Device_ABN")]);
                                    Reg.SetValue("Device_DB", ReadValue[ReadTitle.IndexOf("Device_DB")]);
                                    Reg.SetValue("Device_DM", ReadValue[ReadTitle.IndexOf("Device_DM")]);
                                    Reg.SetValue("Device_DMB", ReadValue[ReadTitle.IndexOf("Device_DMB")]);
                                    Reg.SetValue("Device_DMI", ReadValue[ReadTitle.IndexOf("Device_DMI")]);
                                    Reg.SetValue("Device_FB", ReadValue[ReadTitle.IndexOf("Device_FB")]);
                                    Reg.SetValue("Device_FF", ReadValue[ReadTitle.IndexOf("Device_FF")]);
                                    Reg.SetValue("Device_FTa", ReadValue[ReadTitle.IndexOf("Device_FTa")]);
                                    Reg.SetValue("Device_FTy", ReadValue[ReadTitle.IndexOf("Device_FTy")]);
                                    Reg.SetValue("Device_HM", ReadValue[ReadTitle.IndexOf("Device_HM")]);
                                    Reg.SetValue("Device_HMf", ReadValue[ReadTitle.IndexOf("Device_HMf")]);
                                    Reg.SetValue("Device_ID", ReadValue[ReadTitle.IndexOf("Device_ID")]);
                                    Reg.SetValue("Device_Type", ReadValue[ReadTitle.IndexOf("Device_Type")]);
                                    break;
                            }
                        }catch(Exception ex) { }
                    }
                Reg.Close();
                OtherCancel();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PokémonGO Rocket設定檔|*.Poké";
            openFileDialog1.Title = "選擇匯入檔案";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                groupBox4.Text = "選擇要從檔案匯入的設定：";
                button1.Text = "將勾選的設定值匯入";
                button2.Visible = false;
                button3.Text = "取消";
                groupBox4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "取消") OtherCancel();
            else
            {
                groupBox4.Text = "選擇要還原預設值的設定：";
                button1.Text = "將勾選的還原預設值";
                button2.Visible = false;
                button3.Text = "取消";
                groupBox4.Visible = true;
            }
        }

        void OtherCancel()
        {
            button1.Text = "匯出設定檔";
            button2.Visible = true;
            button3.Text = "原始設定檔";
            groupBox4.Visible = false;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void razzmodeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
            if (razzmodeCb.SelectedIndex == 0)
            {
                razzSettingText.Value = (int)(Settings.Instance.RazzBerrySetting * 100.0);
                razzSettingText.Maximum = 100;
            }
            else if (razzmodeCb.SelectedIndex == 1)
            {
                razzSettingText.Value = Settings.Instance.RazzBerrySettingCP;
                razzSettingText.Maximum = 5000;
            }
            Reg.Close();
        }

        private void checkBoxMoreOR(object sender, EventArgs e)
        {
            if (checkBoxMoreCP.Checked && checkBoxMoreIV.Checked)
            {
                checkBoxOR.Visible = true;
            }
            else
            {
                checkBoxOR.Visible = false;
                checkBoxOR.Checked = false;
            }
        }
    }
}