using BrightIdeasSoftware;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.Win32;
using POGOProtos.Data;
using POGOProtos.Data.Player;
using POGOProtos.Enums;
using POGOProtos.Inventory;
using POGOProtos.Inventory.Item;
using POGOProtos.Map.Fort;
using POGOProtos.Map.Pokemon;
using POGOProtos.Networking.Responses;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Exceptions;
using PokemonGo.RocketAPI.Extensions;
using PokemonGo.RocketAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Reflection.Assembly;

namespace PokemonGo.RocketAPI.Window
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public static SynchronizationContext SynchronizationContext;

        //delay between actions, to similate human operation
        private const int ACTIONDELAY = 1500;

        public static Settings ClientSettings;
        private static int _currentlevel = -1;
        private static int _totalExperience;
        private static int _totalPokemon;
        private static bool _stopping;
        private static bool _forceUnbanning;
        private static bool _farmingStops;
        private static bool _farmingPokemons;
        private static readonly DateTime TimeStarted = DateTime.Now;
        public static DateTime InitSessionDateTime = DateTime.Now;

        private static bool _botStarted;
        private readonly GMapOverlay _playerOverlay = new GMapOverlay("players");
        private readonly GMapOverlay _pokemonsOverlay = new GMapOverlay("pokemons");
        private readonly GMapOverlay _pokestopsOverlay = new GMapOverlay("pokestops");

        private readonly GMapOverlay _searchAreaOverlay = new GMapOverlay("areas");

        private Client _client;
        private Client _client2;
        private bool _initialized;
        private LocationManager _locationManager;

        private GMarkerGoogle _playerMarker;

        private IEnumerable<FortData> _pokeStops;
        private IEnumerable<WildPokemon> _wildPokemons;
        bool MoveMap = true;
        int RestartCounte = 0;
        string Title;
        int SupplyCount = 0;
        int CatchCount = 0;

        public MainForm(string[] args)
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
            ClientSettings = Settings.Instance;
            //Client.OnConsoleWrite += Client_OnConsoleWrite;
            Instance = this;

            Text = @"PokémonGO Rocket 繁體中文版 v" + GetExecutingAssembly().GetName().Version;
            Title = Text;
            CenterToScreen();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket");
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            GMapProvider.WebProxy = null;
            gMapControl1.Position = new PointLatLng(ClientSettings.DefaultLatitude, ClientSettings.DefaultLongitude);
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 18;

            gMapControl1.Overlays.Add(_searchAreaOverlay);
            gMapControl1.Overlays.Add(_pokestopsOverlay);
            gMapControl1.Overlays.Add(_pokemonsOverlay);
            gMapControl1.Overlays.Add(_playerOverlay);

            _playerMarker =
                new GMarkerGoogle(new PointLatLng(ClientSettings.DefaultLatitude, ClientSettings.DefaultLongitude),
                    GMarkerGoogleType.orange_dot);
            _playerOverlay.Markers.Add(_playerMarker);

            InitializeMap();
            InitializePokemonForm();
            CheckVersion();
        }

        public void Restart()
        {
            InitializeMap();
            InitializePokemonForm();
        }

        private void InitializeMap()
        {
            _playerMarker.Position = new PointLatLng(ClientSettings.DefaultLatitude, ClientSettings.DefaultLongitude);
            _searchAreaOverlay.Polygons.Clear();
            S2GMapDrawer.DrawS2Cells(
                S2Helper.GetNearbyCellIds(ClientSettings.DefaultLongitude, ClientSettings.DefaultLatitude),
                _searchAreaOverlay);
        }

        public static void ResetMap()
        {
            Instance.gMapControl1.Position = new PointLatLng(ClientSettings.DefaultLatitude,
                ClientSettings.DefaultLongitude);
            Instance._playerMarker.Position = new PointLatLng(ClientSettings.DefaultLatitude,
                ClientSettings.DefaultLongitude);
            Instance._searchAreaOverlay.Polygons.Clear();
            S2GMapDrawer.DrawS2Cells(
                S2Helper.GetNearbyCellIds(ClientSettings.DefaultLongitude, ClientSettings.DefaultLatitude),
                Instance._searchAreaOverlay);
        }

        public static double GetRuntime()
        {
            return (DateTime.Now - TimeStarted).TotalSeconds / 3600;
        }

        public void CheckVersion()
        {
            ColoredConsoleWrite(Color.GreenYellow, "\n　臉書粉絲頁　=>　HTTP://FB.com/HenKu.DC \n有問題請優先在文章中留言\n部分問題可以在文章留言中找到答案\n可以更快找到解決方案並且減少管理員的負擔！");
            //try
            {
                WebClient AutoUpdate = new WebClient();
                if (System.IO.File.Exists("Setup.bat")) System.IO.File.Delete("Setup.bat");
                if (System.IO.File.Exists("Update.7z")) System.IO.File.Delete("Update.7z");
                if (System.IO.File.Exists("Location.Log")) System.IO.File.Delete("Location.Log");
                //AutoUpdate.DownloadFile("https://d616da667f4a968141870ee19196e80ea9594259.googledrive.com/host/0B0PlXevV0aiieW5RX2lXbzVfbVk", "Update.TXT");
                //ColoredConsoleWrite(Color.YellowGreen, "版本更新內容：\n" + System.IO.File.ReadAllText("Update.TXT"));
                //System.IO.File.Delete("Update.TXT");
                AutoUpdate.DownloadFile("https://c970eed9d6654628ff7465e838fc4e6e2fbccf39.googledrive.com/host/0B0PlXevV0aiibThHM0g1Q2VUblk", "Update.TXT");
                string[] OnlineVersions = System.IO.File.ReadAllLines("Update.TXT");
                System.IO.File.Delete("Update.TXT");
                for (int i = 0; i < OnlineVersions.Length; i++)
                {
                    if (OnlineVersions[i].IndexOf("PokémonGO.Rocket") >= 0)
                    {
                        OnlineVersions[i] = OnlineVersions[i].Substring(0, OnlineVersions[i].IndexOf("|"));
                        if (OnlineVersions[i] == GetExecutingAssembly().GetName().Version.ToString()) break;
                        int[] SubStringStart = { 0, 0 };
                        for (int j = 0; j < 4; j++)
                        {
                            int SubStringEnd = OnlineVersions[i].IndexOf(".", SubStringStart[0]);
                            if (SubStringEnd == -1) SubStringEnd = OnlineVersions[i].Length;
                            int OnlineVersion = Convert.ToInt32(OnlineVersions[i].Substring(SubStringStart[0], SubStringEnd - SubStringStart[0]));
                            SubStringStart[0] = SubStringEnd + 1;
                            SubStringEnd = GetExecutingAssembly().GetName().Version.ToString().IndexOf(".", SubStringStart[1]);
                            if (SubStringEnd == -1) SubStringEnd = GetExecutingAssembly().GetName().Version.ToString().Length;
                            int MyVersion = Convert.ToInt32(GetExecutingAssembly().GetName().Version.ToString().Substring(SubStringStart[1], SubStringEnd - SubStringStart[1]));
                            SubStringStart[1] = SubStringEnd + 1;
                            if (MyVersion > OnlineVersion)
                            {
                                ColoredConsoleWrite(Color.Pink, $"您目前使用測試版本{GetExecutingAssembly().GetName().Version}");
                                break;
                            }
                            else if (MyVersion < OnlineVersion)
                            {
                                try
                                {
                                    Registry.ClassesRoot.CreateSubKey("PokeRocket\\Shell\\Open\\Command");
                                    Registry.SetValue("HKEY_CLASSES_ROOT\\PokeRocket", "URL Protocol", "", RegistryValueKind.String);
                                    Registry.SetValue("HKEY_CLASSES_ROOT\\PokeRocket\\Shell\\Open\\Command", "", $"\"{GetType().Assembly.Location}\" \"%1\"");
                                }
                                catch (Exception)
                                {
                                    ColoredConsoleWrite(Color.Red, $"哎呀好像沒有權限！可能沒辦法自動更新！\n如果無法自動更新，請「以管理員身分」啟動本程式！");
                                }
                                ColoredConsoleWrite(Color.Gold, $"有新版本可以更新！目前版本：{GetExecutingAssembly().GetName().Version}\n　自動更新頁　=>　HTTP://HKDC.idv.la/HKDC/PokeRocket/#Update:{GetExecutingAssembly().GetName().Version}　<=　點擊「更新到最新版本」即可自動更新");
                                System.Diagnostics.Process.Start($"HTTP://HKDC.idv.la/HKDC/PokeRocket/#Update:{GetExecutingAssembly().GetName().Version}");
                                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "AutoUpdate", false);
                                timer1.Enabled = true;
                                break;
                                //AutoUpdate.DownloadFile("https://9f849c0c8aab9203add5cf3dfea3794e1c6617a6.googledrive.com/host/0B0PlXevV0aiiTzRzUEtEUGZaeUk/Pok%C3%A9monGO%20Rocket.7z", "Update.7z");
                                //System.IO.File.WriteAllText("Setup.bat", "@ECHO OFF\nCOLOR 73\nTITLE Auto Update...\nSET A=5\n:A\nIF %A% == 0 GOTO B\nECHO Please wait...%A%\nPING -n 2 127.1 > NUL\nSET /A A=A-1\nCLS\nGOTO A\n:B\n7z X -y Update.7z\nSTART \"\" \"PokemonGO Rocket.exe\"\nEXIT", System.Text.Encoding.ASCII);
                                //System.Diagnostics.Process.Start("Setup.bat");
                                //Close();
                            }
                        }
                        break;
                    }
                }
                //var match =
                //    new Regex(
                //        @"\[assembly\: AssemblyVersion\(""(\d{1,})\.(\d{1,})\.(\d{1,})\.(\d{1,})""\)\]")
                //        .Match(DownloadServerVersion());

                //if (!match.Success) return;
                //var gitVersion =
                //    new Version(
                //        string.Format(
                //            "{0}.{1}.{2}.{3}",
                //            match.Groups[1],
                //            match.Groups[2],
                //            match.Groups[3],
                //            match.Groups[4]));
                //// makes sense to display your version and say what the current one is on github
                //ColoredConsoleWrite(Color.Green, "Your version is " + GetExecutingAssembly().GetName().Version);
                //ColoredConsoleWrite(Color.Green, "Github version is " + gitVersion);
                //ColoredConsoleWrite(Color.Green,
                //    "You can find it at www.GitHub.com/TheUnnameOrganization/RocketBot/releases");
            }
            //catch (Exception) { }
        }

        //private static string DownloadServerVersion()
        //{
        //    using (var wC = new WebClient())
        //        return
        //            wC.DownloadString(
        //                "https://raw.githubusercontent.com/TheUnnameOrganization/RocketBot/Beta-Build/src/RocketBotGUI/Properties/AssemblyInfo.cs");
        //}

        public static void ColoredConsoleWrite(Color color, string text, string shield = "")
        {
            if (Instance.InvokeRequired)
            {
                Instance.Invoke(new Action<Color, string, string>(ColoredConsoleWrite), color, text, shield);
                return;
            }

            Instance.logTextBox.Select(Instance.logTextBox.Text.Length, 1); // Reset cursor to last

            string PrintToConsole = text;
            if (shield != "") PrintToConsole = shield;
            var textToAppend = "【" + DateTime.Now.ToString("HH:mm:ss") + "】" + PrintToConsole + "\r\n";
            Instance.logTextBox.SelectionColor = color;
            Instance.logTextBox.AppendText(textToAppend);

            var syncRoot = new object();
            lock (syncRoot) // Added locking to prevent text file trying to be accessed by two things at the same time
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory + @"\Logs";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!System.IO.File.Exists(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".htm"))
                    File.AppendAllText(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".htm", "<meta HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=utf-8\"><Body BGColor=#0>\n");
                File.AppendAllText(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".htm",
                    $"<Font Color=#{Convert.ToString(color.R, 16).PadLeft(2, '0')}{Convert.ToString(color.G, 16).PadLeft(2, '0')}{Convert.ToString(color.B, 16).PadLeft(2, '0')}><Pre>【{DateTime.Now.ToString("HH:mm:ss")}({_getSessionRuntimeInTimeFormat()})】{text}\r\n</Pre></Font>");
                if (color == Color.Red)
                {
                    if (!System.IO.File.Exists(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + "(Error).htm"))
                        File.AppendAllText(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + "(Error).htm", "<meta HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=utf-8\"><Body BGColor=#0>\n");
                    File.AppendAllText(dir + @"\" + DateTime.Today.ToString("yyyyMMdd") + "(Error).htm",
                        $"<Font Color=#{Convert.ToString(color.R, 16).PadLeft(2, '0')}{Convert.ToString(color.G, 16).PadLeft(2, '0')}{Convert.ToString(color.B, 16).PadLeft(2, '0')}><Pre>【{DateTime.Now.ToString("HH:mm:ss")}({_getSessionRuntimeInTimeFormat()})】{text}\r\n</Pre></Font>");
                }
            }
        }

        public void ConsoleClear()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ConsoleClear));
                return;
            }

            logTextBox.Clear();
        }

        public void SetTitleText(bool Type)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetTitleText), Type);
                return;
            }
            if (Type) Text = $"{Title}【{_getSessionRuntimeInTimeFormat()}】";
            else Text = Title;
            TimeSpan RunTime = DateTime.Now - InitSessionDateTime;
            if (RunTime.Seconds == 0) AutoRefreshPokemonList();
            if (RunTime.TotalSeconds % 3600 == 0)
            {
                CatchCount = 0;
                SupplyCount = 0;
            }
        }

        public void SetStatusText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetStatusText), text);
                return;
            }

            statusLabel.Text = text;
        }

        private async Task EvolvePokemons(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            var pokemons =
                inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                    .Where(p => p != null && p?.PokemonId > 0);

            await EvolveAllGivenPokemons(client, pokemons);
        }

        private async Task EvolveAllGivenPokemons(Client client, IEnumerable<PokemonData> pokemonToEvolve)
        {
            var excludedPokemon = Settings.Instance.ExcludedPokemonEvolve;
            foreach (var pokemon in pokemonToEvolve)
            {
                if (excludedPokemon.Contains(pokemon.PokemonId))
                {
                    ColoredConsoleWrite(Color.Orange,
                        $"【{pokemon.PokemonId}】排除進化");
                    continue;
                }

                var countOfEvolvedUnits = 0;
                var xpCount = 0;

                EvolvePokemonResponse evolvePokemonOutProto;
                do
                {
                    evolvePokemonOutProto = await client.Inventory.EvolvePokemon(pokemon.Id);
                    //todo: someone check whether this still works

                    if (evolvePokemonOutProto.Result == EvolvePokemonResponse.Types.Result.Success)
                    {
                        countOfEvolvedUnits++;
                        xpCount += evolvePokemonOutProto.ExperienceAwarded;
                        _totalExperience += evolvePokemonOutProto.ExperienceAwarded;
                    }
                } while (evolvePokemonOutProto.Result == EvolvePokemonResponse.Types.Result.Success);

                if (countOfEvolvedUnits > 0)
                {
                    ColoredConsoleWrite(Color.Cyan, $"進化{countOfEvolvedUnits}隻【{pokemon.PokemonId}】，經驗{xpCount}");
                    await Task.Delay(3000);
                }
            }
        }

        private async Task Execute()
        {
            if (_stopping)
            {
                confirmBotStopped();
                return;
            }
            if (!_initialized)
            {
                new Thread(async () =>
                {
                    while (_botStarted)
                    {
                        SetTitleText(true);
                        await Task.Delay(1000);
                    }
                    _initialized = false;
                }).Start();
                _initialized = true;
            }
            TimeSpan TimeCheck = DateTime.Now - InitSessionDateTime;
            LastReset = (int)TimeCheck.TotalMinutes / ClientSettings.DelayReLogin;
            _client = new Client(ClientSettings, new ApiFailureStrategy());
            _locationManager = new LocationManager(_client);
            try
            {
                switch (ClientSettings.AuthType)
                {
                    case AuthType.Ptc:
                        ColoredConsoleWrite(Color.Green, "登入類型：Pokemon Trainers Club");
                        break;

                    case AuthType.Google:
                        ColoredConsoleWrite(Color.Green, "登入類型：Google");
                        break;
                }

                await _client.Login.DoLogin();
                var profile = await _client.Player.GetPlayer();
                //var settings = await _client.Download.GetSettings();
                //var mapObjects = await _client.Map.GetMapObjects();
                var inventory = await _client.Inventory.GetInventory();
                var pokemons =
                    inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                        .Where(p => p != null && p?.PokemonId > 0);

                // Write the players ingame details
                ColoredConsoleWrite(Color.Yellow, "----------------------------");
                /*// dont actually want to display info but keeping here incase people want to \O_O/
                 * if (ClientSettings.AuthType == AuthType.Ptc)
                {
                    ColoredConsoleWrite(Color.Cyan, "Account: " + ClientSettings.PtcUsername);
                    ColoredConsoleWrite(Color.Cyan, "Password: " + ClientSettings.PtcPassword + "\n");
                }
                else
                {
                    ColoredConsoleWrite(Color.Cyan, "Email: " + ClientSettings.GoogleUsername);
                    ColoredConsoleWrite(Color.Cyan, "Password: " + ClientSettings.GooglePassword + "\n");
                }*/
                var lat2 = Convert.ToString(ClientSettings.DefaultLatitude);
                var longit2 = Convert.ToString(ClientSettings.DefaultLongitude);
                ColoredConsoleWrite(Color.DarkGray, "暱稱：" + profile.PlayerData.Username);
                ColoredConsoleWrite(Color.DarkGray, "陣營：" + profile.PlayerData.Team);
                if (profile.PlayerData.Currencies.ToArray()[0].Amount > 0)
                    // If player has any pokecoins it will show how many they have.
                    ColoredConsoleWrite(Color.DarkGray, "金幣：" + profile.PlayerData.Currencies.ToArray()[0].Amount);
                ColoredConsoleWrite(Color.DarkGray, "星塵：" + profile.PlayerData.Currencies.ToArray()[1].Amount);
                ColoredConsoleWrite(Color.DarkGray, "座標：" + ClientSettings.DefaultLatitude + ", " + ClientSettings.DefaultLongitude);
                //try
                //{
                //    ColoredConsoleWrite(Color.DarkGray,
                //        "國家：" + CallAPI("country", lat2.Replace(',', '.'), longit2.Replace(',', '.')));
                //    ColoredConsoleWrite(Color.DarkGray,
                //        "區域：" + CallAPI("place", lat2.Replace(',', '.'), longit2.Replace(',', '.')));
                //}
                //catch (Exception)
                //{
                //    ColoredConsoleWrite(Color.DarkGray, "無法獲取地區資訊");
                //}

                ColoredConsoleWrite(Color.Yellow, "----------------------------");

                // I believe a switch is more efficient and easier to read.
                switch (ClientSettings.TransferType)
                {
                    case 1:
                        await TransferAllWeakPokemon(_client, ClientSettings.TransferCpThreshold);
                        break;

                    case 2:
                        await TransferAllGivenPokemons(_client, pokemons, ClientSettings.TransferIvThreshold);
                        break;

                    case 3:
                        await TransferAllButStrongestUnwantedPokemon(_client);
                        break;

                    case 4:
                        await TransferDuplicatePokemon(_client);
                        break;

                    case 5:
                        await TransferDuplicateIVPokemon(_client);
                        break;

                    case 6:
                        await TransferDuplicateCPIVPokemon(_client);
                        break;

                    case 7:
                        await TransferAllGivenPokemons(_client, pokemons, ClientSettings.TransferIvThreshold);
                        break;

                    default:
                        ColoredConsoleWrite(Color.DarkGray, "自動傳送已停用");
                        break;
                }

                if (ClientSettings.EvolveAllGivenPokemons) EvolveAllGivenPokemons(_client, pokemons);
                if (ClientSettings.Recycler) await RecycleItems(_client);
                //client.RecycleItems(client);
                //await Task.Delay(5000);

                switch (ClientSettings.UseIncubatorsMode)
                {
                    case 1:
                        await UseIncubators(_client, ClientSettings.UseIncubatorsMode);
                        break;
                    case 2:
                        await UseIncubators(_client, ClientSettings.UseIncubatorsMode);
                        break;
                    default:
                        ColoredConsoleWrite(Color.DarkGray, "自動孵蛋已停用");
                        break;
                }
                await PrintLevel(_client);

                if (Settings.Instance.GPS_Location.Count > 1)
                {
                    _pokestopsOverlay.Routes.Clear();
                    _pokestopsOverlay.Routes.Add(new GMapRoute(Settings.Instance.GPS_Location, "Walking Path"));
                    CustomRoute(_client);
                }

                await ExecuteFarmingPokestopsAndPokemons(_client);

                while (_forceUnbanning)
                    await Task.Delay(25);
                // await ForceUnban(client);
                //if (!_stopping)
                //{
                //    ColoredConsoleWrite(Color.Red, $"No nearby useful locations found. Please wait 5 seconds.");
                //    await Task.Delay(5000);
                //    Execute();
                //}
                //else
                //{
                //    ConsoleClear();
                //    _pokestopsOverlay.Routes.Clear();
                //    _pokestopsOverlay.Markers.Clear();
                //    ColoredConsoleWrite(Color.Red, $"Bot successfully stopped.");
                //    startStopBotToolStripMenuItem.Text = "Start";
                //    _stopping = false;
                //    _botStarted = false;
                //    _pokeStops = null;
                //}
                if (!_stopping)
                {
                    _stopping = true;
                    await Task.Delay(ClientSettings.DelayWalk * 2000);
                    _stopping = false;
                }
                RestartCounte = 0;
            }
            catch (TaskCanceledException)
            {
                ColoredConsoleWrite(Color.Red, "任務意外中斷，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (UriFormatException)
            {
                ColoredConsoleWrite(Color.Red, "系統URI格式異常，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (ArgumentOutOfRangeException)
            {
                ColoredConsoleWrite(Color.Red, "傳入參數超出範圍，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (ArgumentNullException)
            {
                ColoredConsoleWrite(Color.Red, "傳入空的參數，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (NullReferenceException)
            {
                ColoredConsoleWrite(Color.Red, "傳回空的回覆，可能被永久封鎖，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (AccessTokenExpiredException)
            {
                ColoredConsoleWrite(Color.Red, "憑證過期，重新啟動中…" + RestartCounte);
                RestartCounte++;
                //if (!_stopping) Execute();
            }
            catch (GoogleException)
            {
                ColoredConsoleWrite(Color.Red, "無法登入您的Google帳號，請檢察帳號密碼是否有錯誤" + RestartCounte);
                RestartCounte++;
            }
            catch (LoginFailedException)
            {
                ColoredConsoleWrite(Color.Red, "無法登入您的PTC帳號，請檢察帳號密碼是否有錯誤" + RestartCounte);
                RestartCounte++;
            }
            catch (InvalidResponseException)
            {
                ColoredConsoleWrite(Color.Red, "無效的回應，重新啟動中…" + RestartCounte);
                //if (!_stopping) Execute();
                RestartCounte++;
            }
            catch (Exception ex)
            {
                ColoredConsoleWrite(Color.Red, ex.StackTrace, "發生不明錯誤，詳細資訊請檢閱Log記錄檔");
                //if (!_stopping) Execute();
                RestartCounte++;
            }
            if (RestartCounte > 10)
            {
                _pokestopsOverlay.Routes.Clear();
                _pokestopsOverlay.Markers.Clear();
                ColoredConsoleWrite(Color.Yellow, $"機器人已自動關閉…運行了{_getSessionRuntimeInTimeFormat()}");
                startStopBotToolStripMenuItem.Text = "▶ 啟動機器人";
                _stopping = false;
                _botStarted = false;
                _pokeStops = null;
                RestartCounte = 0;
                SetTitleText(false);
            }
        }

        private static string CallAPI(string elem, string lat, string lon)
        {
            using (
                var reader =
                    XmlReader.Create(@"http://api.geonames.org/findNearby?lat=" + lat + "&lng=" + lon +
                                     "&username=pokemongobot"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (elem)
                        {
                            case "country":
                                if (reader.Name == "countryName")
                                {
                                    return reader.ReadString();
                                }
                                break;

                            case "place":
                                if (reader.Name == "name")
                                {
                                    return reader.ReadString();
                                }
                                break;

                            default:
                                return "N/A";
                        }
                    }
                }
            }
            return "Error";
        }

        private async Task ExecuteCatchAllNearbyPokemons(Client client/*, double Latitude, double Longitude*/)
        {
            var mapObjects = await client.Map.GetMapObjects();
            var pokemons = mapObjects.Item1.MapCells.SelectMany(i => i.CatchablePokemons);
            var inventory2 = await client.Inventory.GetInventory();
            var pokemons2 = inventory2.InventoryDelta.InventoryItems
                .Select(i => i.InventoryItemData?.PokemonData)
                .Where(p => p != null && p?.PokemonId > 0)
                .ToArray();
            var excludedPokemon = Settings.Instance.ExcludedPokemonCatch;

            foreach (var pokemon in pokemons)
            {
                if (_forceUnbanning || _stopping)
                    break;
                var currentLoc = new LatLong(_client.CurrentLatitude, _client.CurrentLongitude);
                ulong Distance = Convert.ToUInt64( currentLoc.distanceFrom(new LatLong(pokemon.Latitude, pokemon.Longitude)));
                if (Distance > (ulong)ClientSettings.DistanceCatch)
                    continue;

                if (excludedPokemon.Contains(pokemon.PokemonId))
                {
                    ColoredConsoleWrite(Color.Orange,
                        $"遇到【{pokemon.PokemonId}】，但於排除捕捉選單");
                    continue;
                }

                _farmingPokemons = true;

                //await _locationManager.Update(pokemon.Latitude, pokemon.Longitude);

                string pokemonName;
                pokemonName = Convert.ToString(pokemon.PokemonId);

                var encounterPokemonResponse =
                    await client.Encounter.EncounterPokemon(pokemon.EncounterId, pokemon.SpawnPointId);

                if (encounterPokemonResponse.Status == EncounterResponse.Types.Status.PokemonInventoryFull)
                {
                    ColoredConsoleWrite(Color.Orange,
                        $"神奇寶貝滿了，無法繼續捕捉！");
                    _farmingPokemons = false;
                    break;
                }

                CatchPokemonResponse caughtPokemonResponse;
                var pokemonCp = encounterPokemonResponse?.WildPokemon?.PokemonData?.Cp;
                var pokemonIv = Math.Round(Perfect(encounterPokemonResponse?.WildPokemon?.PokemonData));
                ColoredConsoleWrite(Color.Green, $"遇到【{pokemonName}】（{pokemon.Latitude}, {pokemon.Longitude}）　CP{pokemonCp}　IV{pokemonIv}%");
                //await MovePlayerLocation(pokemon.Latitude, pokemon.Longitude);
                if (ClientSettings.EnableCatchMoreCP && pokemonCp < ClientSettings.CatchMoreCP && ClientSettings.EnableCatchMoreIV && pokemonIv < ClientSettings.CatchMoreIV)
                {
                    ColoredConsoleWrite(Color.Orange, $"但是CP低於{ClientSettings.CatchMoreCP}　IV低於{ClientSettings.CatchMoreIV}%");
                    continue;
                }
                if (ClientSettings.EnableCatchMoreCP && pokemonCp < ClientSettings.CatchMoreCP && !ClientSettings.EnableCatchOR)
                {
                    ColoredConsoleWrite(Color.Orange, $"但是CP低於{ClientSettings.CatchMoreCP}");
                    continue;
                }
                else if (ClientSettings.EnableCatchMoreIV && pokemonIv < ClientSettings.CatchMoreIV && !ClientSettings.EnableCatchOR)
                {
                    ColoredConsoleWrite(Color.Orange, $"但是IV低於{ClientSettings.CatchMoreIV}%");
                    continue;
                }

                await Task.Delay(Settings.Instance.DelayCatch * 1000 / 2);
                var pokemonMarker = new GMarkerGoogle(new PointLatLng(pokemon.Latitude, pokemon.Longitude), GMarkerGoogleType.green_small);
                _pokemonsOverlay.Markers.Add(pokemonMarker);

                do
                {
                    if (ClientSettings.RazzBerryMode == 1)
                        if (pokemonCp > ClientSettings.RazzBerrySettingCP)
                            await UseRazzBerry(client, pokemon.EncounterId, pokemon.SpawnPointId);
                    if (ClientSettings.RazzBerryMode == 0)
                        if (encounterPokemonResponse.CaptureProbability.CaptureProbability_.First() < ClientSettings.RazzBerrySetting)
                            await UseRazzBerry(client, pokemon.EncounterId, pokemon.SpawnPointId);
                    caughtPokemonResponse =
                        await CatchPokemon(pokemon.EncounterId, pokemon.SpawnPointId, pokemon.Latitude, pokemon.Longitude, ItemId.Item寶貝球, pokemonCp);
                     //note: reverted from settings because this should not be part of settings but part of logic
                } while (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchMissed ||
                         caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchEscape);

                //await client.Player.UpdatePlayerLocation(Latitude, Longitude);

                if (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
                {
                    CatchCount++;
                    var c = Color.LimeGreen;
                    if (pokemonIv >= 80)
                    {
                        c = Color.Yellow;
                    }
                    ColoredConsoleWrite(c, $"捕獲【{pokemonName}】（{_client.CurrentLatitude}, {_client.CurrentLongitude}）　距離{Distance}公尺　獲得經驗{caughtPokemonResponse.CaptureAward.Xp.Sum()}點　這個小時抓了{CatchCount}隻寶可夢");
                    //foreach (int xp in caughtPokemonResponse.CaptureAward.Xp)
                    //    TotalExperience += xp;
                    _totalExperience += caughtPokemonResponse.CaptureAward.Xp.Sum();
                    _totalPokemon += 1;
                }
                else ColoredConsoleWrite(Color.Red, $"逃跑【{pokemonName}】");

                await Task.Delay(Settings.Instance.DelayCatch * 1000 / 2);
                // I believe a switch is more efficient and easier to read.
                switch (ClientSettings.TransferType)
                {
                    case 1:
                        await TransferAllWeakPokemon(client, ClientSettings.TransferCpThreshold);
                        break;

                    case 2:
                        await TransferAllGivenPokemons(client, pokemons2, ClientSettings.TransferIvThreshold);
                        break;

                    case 3:
                        await TransferAllButStrongestUnwantedPokemon(client);
                        break;

                    case 4:
                        await TransferDuplicatePokemon(client);
                        break;

                    case 5:
                        await TransferDuplicateIVPokemon(client);
                        break;

                    case 6:
                        await TransferDuplicateCPIVPokemon(client);
                        break;

                    case 7:
                        await TransferAllGivenPokemons(client, pokemons2, ClientSettings.TransferIvThreshold);
                        break;

                    default:
                        ColoredConsoleWrite(Color.DarkGray, "自動傳送已停用");
                        break;
                }

                _farmingPokemons = false;
            }
            pokemons = null;
        }

        async Task MovePlayerLocation(double Latitude, double Longitude)
        {
            while (Latitude != _client.CurrentLatitude && Longitude != _client.CurrentLongitude && !_stopping)
            {
                await _locationManager.Update(Latitude, Longitude);
                UpdatePlayerLocation(_client.CurrentLatitude, _client.CurrentLongitude);
                UpdateMap();
            }
        }

        private void UpdatePlayerLocation(double latitude, double longitude)
        {
            SynchronizationContext.Post(o =>
            {
                _playerMarker.Position = (PointLatLng)o;
                _searchAreaOverlay.Polygons.Clear();
            }, new PointLatLng(latitude, longitude));
            if (MoveMap) AutoUpdateMapLocation();
            //Instance.gMapControl1.Position = new PointLatLng(ClientSettings.DefaultLatitude, ClientSettings.DefaultLongitude);
            //ColoredConsoleWrite(Color.Gray, $"移動至 {latitude}, {longitude}");
            if (ClientSettings.UseLastGPS)
            {
                var GPS = new List<PointLatLng>(Settings.Instance.GPS_Location);
                GPS.RemoveAt(0);
                GPS.Insert(0, new PointLatLng(latitude, longitude));
                Settings.Instance.GPS_Location = GPS;
            }
        }

        void AutoUpdateMapLocation()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AutoUpdateMapLocation));
                return;
            }
            Instance.gMapControl1.Position = new PointLatLng(_client.CurrentLatitude, _client.CurrentLongitude);
        }

        private void UpdateMap()
        {
            if (!_stopping && !_forceUnbanning)
            {
                SynchronizationContext.Post(o =>
                {
                    _pokestopsOverlay.Markers.Clear();
                    var routePoint = new List<PointLatLng>();
                    if (_pokeStops != null)
                        foreach (var pokeStop in _pokeStops)
                        {
                            var type = GMarkerGoogleType.blue_small;
                            if (pokeStop.CooldownCompleteTimestampMs > DateTime.UtcNow.ToUnixTime())
                                type = GMarkerGoogleType.purple_small;
                            var pokeStopLoc = new PointLatLng(pokeStop.Latitude, pokeStop.Longitude);
                            var pokestopMarker = new GMarkerGoogle(pokeStopLoc, type);
                            //pokestopMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            //pokestopMarker.ToolTip = new GMapBaloonToolTip(pokestopMarker);
                            _pokestopsOverlay.Markers.Add(pokestopMarker);

                            routePoint.Add(pokeStopLoc);
                        }
                    if (Settings.Instance.GPS_Location.Count == 1)
                    {
                        _pokestopsOverlay.Routes.Clear();
                        _pokestopsOverlay.Routes.Add(new GMapRoute(routePoint, "Walking Path"));
                    }

                    //_pokemonsOverlay.Markers.Clear();
                    //if (_wildPokemons != null)
                    //{
                    //    foreach (var pokemon in _wildPokemons)
                    //    {
                    //        var pokemonMarker = new GMarkerGoogle(new PointLatLng(pokemon.Latitude, pokemon.Longitude),
                    //            GMarkerGoogleType.red_small);
                    //        _pokemonsOverlay.Markers.Add(pokemonMarker);
                    //    }
                    //}

                    _searchAreaOverlay.Polygons.Clear();
                    S2GMapDrawer.DrawS2Cells(
                        S2Helper.GetNearbyCellIds(ClientSettings.DefaultLongitude, ClientSettings.DefaultLatitude),
                        _searchAreaOverlay);
                }, null);
            }
        }

        int LastReset = 0;
        private async Task CustomRoute(Client client)
        {
            var GPS = new List<PointLatLng>(Settings.Instance.GPS_Location);
            while (!_stopping && !_forceUnbanning)
            {
                await MovePlayerLocation(GPS[1].Lat, GPS[1].Lng);
                GPS = new List<PointLatLng>(Settings.Instance.GPS_Location);
                if (_stopping || _forceUnbanning || GPS.Count == 1) break;
                GPS.Add(GPS[1]);
                GPS.RemoveAt(1);
                Settings.Instance.GPS_Location = GPS;
                _pokestopsOverlay.Routes.Clear();
                _pokestopsOverlay.Routes.Add(new GMapRoute(GPS, "Walking Path"));
            }
        }
        private async Task ExecuteFarmingPokestopsAndPokemons(Client client)
        {
            var mapObjects = await client.Map.GetMapObjects();

            var currentLoc = new LatLong(RangeCenter.Lat, RangeCenter.Lng);
            var rawPokeStops =
                mapObjects.Item1.MapCells.SelectMany(i => i.Forts)
                    .Where(
                        i =>
                            i.Type == FortType.Checkpoint &&
                            i.CooldownCompleteTimestampMs < DateTime.UtcNow.ToUnixTime() &&
                            currentLoc.distanceFrom(new LatLong(i.Latitude, i.Longitude)) < ClientSettings.WalkRange)
                    .ToArray();
            if (rawPokeStops == null || rawPokeStops.Count() <= 0)
            {
                ColoredConsoleWrite(Color.Red,
                    $"找不到任何補給站！請關閉機器人並變更您的位置");
                _stopping = true;
                return;
            }
            _pokeStops = rawPokeStops;
            UpdateMap();
            ColoredConsoleWrite(Color.Cyan, $"正在尋找附近的補給站並規畫最短路徑…");
            if (!_forceUnbanning && !_stopping)
                ColoredConsoleWrite(Color.Cyan, $"發現{_pokeStops.Count()}個補給站！");
            while (!_stopping && !_forceUnbanning)
            {
                TimeSpan TimeCheck;
                var startingLatLong = new LatLong(ClientSettings.DefaultLatitude, ClientSettings.DefaultLongitude);
                _pokeStops = RouteOptimizer.Optimize(rawPokeStops, startingLatLong, _pokestopsOverlay);
                _wildPokemons = mapObjects.Item1.MapCells.SelectMany(i => i.WildPokemons);

                foreach (var pokeStop in _pokeStops)
                {
                    try
                    {
                        if (ClientSettings.CatchPokemon && (ClientSettings.LimitCatch == 0 || ClientSettings.LimitCatch > CatchCount))
                            await ExecuteCatchAllNearbyPokemons(client);

                        _farmingStops = true;

                        if (Settings.Instance.GPS_Location.Count == 1)
                            await MovePlayerLocation(pokeStop.Latitude, pokeStop.Longitude);

                        TimeCheck = DateTime.Now - InitSessionDateTime;
                        if (_forceUnbanning || _stopping || (LastReset != (int)(TimeCheck.TotalMinutes / ClientSettings.DelayReLogin)) || (ClientSettings.LimitSupply > 0 && ClientSettings.LimitSupply <= SupplyCount))
                            break;

                        currentLoc = new LatLong(_client.CurrentLatitude, _client.CurrentLongitude);
                        ulong Distance = Convert.ToUInt64(currentLoc.distanceFrom(new LatLong(pokeStop.Latitude, pokeStop.Longitude)));

                        if (Distance > (ulong)ClientSettings.DistanceSupply || pokeStop.CooldownCompleteTimestampMs > DateTime.UtcNow.ToUnixTime())
                            continue;

                        var fortInfo = await client.Fort.GetFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                        var fortSearch = await client.Fort.SearchFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                        string PokeStopOutput = "";
                        if (fortInfo.Name != string.Empty)
                        {
                            if (fortSearch.ExperienceAwarded != 0)
                                PokeStopOutput += $"　經驗值{fortSearch.ExperienceAwarded}點";
                            if (fortSearch.GemsAwarded != 0)
                                PokeStopOutput += $"　寶石{fortSearch.GemsAwarded}";
                            if (fortSearch.PokemonDataEgg != null)
                            {
                                string EggKM = fortSearch.PokemonDataEgg.ToString();
                                EggKM = EggKM.Substring(EggKM.IndexOf(":", EggKM.IndexOf("eggKmWalkedTarget")) + 2);
                                EggKM = EggKM.Substring(0, EggKM.IndexOf(","));
                                PokeStopOutput += $"　精靈蛋{EggKM}公里1顆";
                            }
                            if (GetFriendlyItemsString(fortSearch.ItemsAwarded) != string.Empty)
                            {
                                PokeStopOutput += $"　{GetFriendlyItemsString(fortSearch.ItemsAwarded)} ";
                            }
                            if (PokeStopOutput != "")
                            {
                                SupplyCount++;
                                pokeStop.CooldownCompleteTimestampMs = DateTime.UtcNow.ToUnixTime() + 300000;
                                UpdateMap();
                                ColoredConsoleWrite(Color.Cyan, $"於補給站【{fortInfo.Name}】（{pokeStop.Latitude}, {pokeStop.Longitude}）　　距離{Distance}公尺　　這個小時領了{SupplyCount}個補給站" +
                                                                "\n　　　　　　獲得" + PokeStopOutput);
                            }
                        }

                        await RecycleItems(client);

                        if (fortSearch.ExperienceAwarded != 0)
                            _totalExperience += fortSearch.ExperienceAwarded;


                    }
                    catch (Exception)
                    {
                    }
                    await Task.Delay(Settings.Instance.DelaySupply * 1000);
                }
                _farmingStops = false;
                //if (!_forceUnbanning && !_stopping)
                //{
                //    await ExecuteFarmingPokestopsAndPokemons(client);
                //}
                TimeCheck = DateTime.Now - InitSessionDateTime;
                if (LastReset != (int)(TimeCheck.TotalMinutes / ClientSettings.DelayReLogin))
                    break;
                await Task.Delay(Convert.ToInt32(ClientSettings.DelayCheck * 1000.0));
            }
        }

        private async Task ForceUnban(Client client)
        {
            if (!_forceUnbanning && !_stopping)
            {
                ColoredConsoleWrite(Color.LightGreen, "等待最後一個動作完成…");
                _forceUnbanning = true;

                while (_farmingStops || _farmingPokemons)
                {
                    await Task.Delay(25);
                }

                ColoredConsoleWrite(Color.LightGreen, "開始解軟封鎖(SoftBan)…");

                _pokestopsOverlay.Routes.Clear();
                _pokestopsOverlay.Markers.Clear();
                var done = false;
                foreach (var pokeStop in _pokeStops)
                {
                    if (pokeStop.CooldownCompleteTimestampMs < DateTime.UtcNow.ToUnixTime())
                    {
                        await MovePlayerLocation(pokeStop.Latitude, pokeStop.Longitude);

                        var fortInfo = await client.Fort.GetFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                        if (fortInfo.Name != string.Empty)
                        {
                            ColoredConsoleWrite(Color.LightGreen,
                                "使用補給站" + fortInfo.Name + "嘗試解除封鎖");
                            for (var i = 1; i <= 50; i++)
                            {
                                var fortSearch =
                                    await client.Fort.SearchFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                                if (fortSearch.Result == FortSearchResponse.Types.Result.Success)
                                {
                                    if (fortSearch.ExperienceAwarded == 0)
                                    {
                                        ColoredConsoleWrite(Color.LightGreen, "嘗試：" + i);
                                    }
                                    else
                                    {
                                        ColoredConsoleWrite(Color.LightGreen,
                                            "正在解除封鎖…總共嘗試：" + i);
                                        done = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    ColoredConsoleWrite(Color.LightGreen,
                                        $"嘗試{i}：補給站發生錯誤{fortSearch.Result}");
                                }
                            }
                            if (done)
                                break;
                        }
                    }
                }
                if (!done)
                    ColoredConsoleWrite(Color.LightGreen, "解軟封鎖(SoftBan)失敗，請稍後再試！");
                _forceUnbanning = false;
            }
            else
            {
                ColoredConsoleWrite(Color.Red, "一個動作正在進行…請稍後…");
            }
        }

        private string GetFriendlyItemsString(IEnumerable<ItemAward> items)
        {
            var enumerable = items as IList<ItemAward> ?? items.ToList();

            if (!enumerable.Any())
                return string.Empty;

            return enumerable.GroupBy(i => i.ItemId)
                .Select(kvp => new { ItemName = kvp.Key.ToString().Substring(4), Amount = kvp.Sum(x => x.ItemCount) })
                .Select(y => $"{y.ItemName}{y.Amount}個")
                .Aggregate((a, b) => $"{a}　{b}");
        }

        private async Task TransferAllButStrongestUnwantedPokemon(Client client)
        {
            var unwantedPokemonTypes = new List<PokemonId>();
            for (var i = 1; i <= 151; i++)
            {
                unwantedPokemonTypes.Add((PokemonId)i);
            }

            var inventory = await client.Inventory.GetInventory();
            var pokemons = inventory.InventoryDelta.InventoryItems
                .Select(i => i.InventoryItemData?.PokemonData)
                .Where(p => p != null && p?.PokemonId > 0)
                .ToArray();

            foreach (var unwantedPokemonType in unwantedPokemonTypes)
            {
                var pokemonOfDesiredType = pokemons.Where(p => p.PokemonId == unwantedPokemonType)
                    .OrderByDescending(p => p.Cp)
                    .ToList();

                var unwantedPokemon =
                    pokemonOfDesiredType.Skip(1) // keep the strongest one for potential battle-evolving
                        .ToList();

                await TransferAllGivenPokemons(client, unwantedPokemon);
            }
        }

        public static double Perfect(PokemonData poke)
        {
            if (poke == null)
                return 0d;
            return PokemonInfo.CalculatePokemonPerfection(poke) * 100d;
        }

        private async Task TransferAllGivenPokemons(Client client, IEnumerable<PokemonData> unwantedPokemons, float keepPerfectPokemonLimit = 80.0f)
        {
            var excludedPokemon = Settings.Instance.ExcludedPokemonTransfer;
            foreach (var pokemon in unwantedPokemons)
            {
                if (excludedPokemon.Contains(pokemon.PokemonId))
                {
                    continue;
                }

                if (Perfect(pokemon) >= keepPerfectPokemonLimit) continue;
                ColoredConsoleWrite(Color.White,
                    $"【{pokemon.PokemonId}】　CP：{pokemon.Cp}　IV：{Math.Round(Perfect(pokemon))}%　（IV低於{keepPerfectPokemonLimit}%）");

                if (pokemon.Favorite == 0)
                {
                    var transferPokemonResponse = await client.Inventory.TransferPokemon(pokemon.Id);

                    /*
                    ReleasePokemonOutProto.Status {
                        UNSET = 0;
                        SUCCESS = 1;
                        POKEMON_DEPLOYED = 2;
                        FAILED = 3;
                        ERROR_POKEMON_IS_EGG = 4;
                    }*/
                    string pokemonName;
                    pokemonName = Convert.ToString(pokemon.PokemonId);
                    if (transferPokemonResponse.Result == ReleasePokemonResponse.Types.Result.Success)
                    {
                        ColoredConsoleWrite(Color.Magenta, $"傳送【{pokemonName}】　CP：{pokemon.Cp}　IV：{Math.Round(Perfect(pokemon))}%");
                    }
                    else
                    {
                        var status = transferPokemonResponse.Result;

                        ColoredConsoleWrite(Color.Red,
                            $"不明原因無法傳送【{pokemonName}】　CP：{pokemon.Cp}　IV：{Math.Round(Perfect(pokemon))}%");
                    }

                    await Task.Delay(3000);
                }
            }
        }

        private async Task TransferDuplicatePokemon(Client client)
        {
            var excludedPokemon = Settings.Instance.ExcludedPokemonTransfer;
            //ColoredConsoleWrite(ConsoleColor.White, $"Check for duplicates");
            var inventory = await client.Inventory.GetInventory();
            var allpokemons =
                inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                    .Where(p => p != null && p?.PokemonId > 0);

            var dupes = allpokemons.OrderBy(x => x.Cp).Select((x, i) => new { index = i, value = x })
                .GroupBy(x => x.value.PokemonId)
                .Where(x => x.Skip(1).Any());
            int KeepCount = ClientSettings.TransferCountThreshold;

            for (var i = 0; i < dupes.Count(); i++)
            {
                if (dupes.ElementAt(i).Count() > KeepCount)
                    for (var j = 0; j < dupes.ElementAt(i).Count() - KeepCount; j++)
                    {
                        var dubpokemon = dupes.ElementAt(i).ElementAt(j).value;

                        if (excludedPokemon.Contains(dubpokemon.PokemonId))
                        {
                            continue;
                        }

                        if (dubpokemon.Favorite == 0)
                        {
                            var transfer = await client.Inventory.TransferPokemon(dubpokemon.Id);
                            string pokemonName;
                            pokemonName = Convert.ToString(dubpokemon.PokemonId);
                            string PrintHighest = "";
                            for (int k = 0; k < KeepCount; k++)
                                PrintHighest += "　" + dupes.ElementAt(i).ElementAt(dupes.ElementAt(i).Count() - k - 1).value.Cp;
                            ColoredConsoleWrite(Color.DarkGreen,
                                $"傳送【{pokemonName}】　CP：{dubpokemon.Cp}　IV：{Math.Round(Perfect(dubpokemon))}%　　（已擁有CP{PrintHighest}）");
                        }
                    }
            }
        }

        private async Task TransferDuplicateIVPokemon(Client client)
        {
            var excludedPokemon = Settings.Instance.ExcludedPokemonTransfer;
            //ColoredConsoleWrite(ConsoleColor.White, $"Check for duplicates");
            var inventory = await client.Inventory.GetInventory();
            var allpokemons =
                inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                    .Where(p => p != null && p?.PokemonId > 0);

            var dupes = allpokemons.OrderBy(x => Perfect(x)).Select((x, i) => new { index = i, value = x })
                .GroupBy(x => x.value.PokemonId)
                .Where(x => x.Skip(1).Any());
            int KeepCount = ClientSettings.TransferCountThreshold;

            for (var i = 0; i < dupes.Count(); i++)
            {
                if (dupes.ElementAt(i).Count() > KeepCount)
                    for (var j = 0; j < dupes.ElementAt(i).Count() - KeepCount; j++)
                    {
                        var dubpokemon = dupes.ElementAt(i).ElementAt(j).value;

                        if (excludedPokemon.Contains(dubpokemon.PokemonId))
                        {
                            continue;
                        }

                        if (dubpokemon.Favorite == 0)
                        {
                            var transfer = await client.Inventory.TransferPokemon(dubpokemon.Id);
                            string pokemonName;
                            pokemonName = Convert.ToString(dubpokemon.PokemonId);
                            string PrintHighest = "";
                            for (int k = 0; k < KeepCount; k++)
                            {
                                int Conv = (int)Perfect(dupes.ElementAt(i).ElementAt(dupes.ElementAt(i).Count() - k - 1).value);
                                PrintHighest += "　" + Conv + "%";
                            }
                            ColoredConsoleWrite(Color.DarkGreen,
                                $"傳送【{pokemonName}】　CP：{dubpokemon.Cp}　IV：{Math.Round(Perfect(dubpokemon))}%　　（已擁有IV{PrintHighest}）");
                        }
                    }
            }
        }

        private async Task TransferDuplicateCPIVPokemon(Client client)
        {
            //ColoredConsoleWrite(Color.White, $"Check for CP/IV duplicates");
            var inventory = await client.Inventory.GetInventory();
            var allpokemons =
                inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                    .Where(p => p != null && p?.PokemonId > 0);

            var dupes = allpokemons.OrderBy(x => Perfect(x)).Select((x, i) => new { index = i, value = x })
                .GroupBy(x => x.value.PokemonId)
                .Where(x => x.Skip(1).Any());

            for (var i = 0; i < dupes.Count(); i++)
            {
                int Count = dupes.ElementAt(i).Count();
                int KeepCount = ClientSettings.TransferCountThreshold;
                if (Count > KeepCount)
                {
                    //var dupes2 = allpokemons.OrderBy(x => x.Cp).Select((x, j) => new { index = j, value = x })
                    //    .GroupBy(x => x.value.PokemonId)
                    //    .Where(x => x.Skip(1).Any());
                    var max_index = new List<ulong>();
                    var dupe_group = dupes.ElementAt(i).OrderByDescending(x => x.value.Cp).Select((x,j) => x.value.Id);
                    for (int j = 0; j < KeepCount; j++)
                        max_index.Add(dupe_group.ElementAt(j));
                    for (int j = 0; j < Count - KeepCount; j++)
                    {
                        var dubpokemon = dupes.ElementAt(i).ElementAt(j).value;
                        int TEST = max_index.IndexOf(dubpokemon.Id);
                        if (dubpokemon.Favorite == 0 && max_index.IndexOf(dubpokemon.Id) == -1) 
                        {
                            var transfer = await client.Inventory.TransferPokemon(dubpokemon.Id);
                            string pokemonName;
                            pokemonName = Convert.ToString(dubpokemon.PokemonId);
                            string[] PrintHighest = { "", "" };
                            for (int k = 0; k < KeepCount; k++)
                            {
                                int Conv = (int)Perfect(dupes.ElementAt(i).ElementAt(dupes.ElementAt(i).Count() - k - 1).value);
                                PrintHighest[0] += "　" + dupes.ElementAt(i).ElementAt(dupes.ElementAt(i).Count() - k - 1).value.Cp;
                                PrintHighest[1] += "　" + Conv + "%";
                            }
                            ColoredConsoleWrite(Color.DarkGreen,
                                $"傳送【{pokemonName}】　CP：{dubpokemon.Cp}　IV：{Math.Round(Perfect(dubpokemon))}%　　（已擁有CP{PrintHighest[0]}；IV{PrintHighest[1]}）");
                        }
                    }
                }
            }
        }

        private async Task TransferAllWeakPokemon(Client client, int cpThreshold)
        {
            //ColoredConsoleWrite(ConsoleColor.White, $"Firing up the meat grinder");

            var inventory = await client.Inventory.GetInventory();
            var pokemons = inventory.InventoryDelta.InventoryItems
                .Select(i => i.InventoryItemData?.PokemonData)
                .Where(p => p != null && p?.PokemonId > 0)
                .ToArray();

            var pokemonToDiscard = pokemons.Where(p => p.Cp < cpThreshold).OrderByDescending(p => p.Cp).ToList();
            ColoredConsoleWrite(Color.Gray, $"Grinding {pokemonToDiscard.Count} pokemon below {cpThreshold} CP.");
            await TransferAllGivenPokemons(client, pokemonToDiscard);

            ColoredConsoleWrite(Color.Gray, $"Finished grinding all the meat");
        }

        public async Task PrintLevel(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            var stats = inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PlayerStats);
            foreach (var v in stats)
                if (v != null)
                {
                    var XpDiff = GetXpDiff(client, v.Level);
                    if (ClientSettings.LevelOutput == "time")
                        ColoredConsoleWrite(Color.Yellow,
                            $"目前等級：" + v.Level + "（" + (v.Experience - XpDiff) + " / " +
                            (v.NextLevelXp - XpDiff) + "）");
                    else if (ClientSettings.LevelOutput == "levelup")
                        if (_currentlevel != v.Level)
                        {
                            _currentlevel = v.Level;
                            ColoredConsoleWrite(Color.Magenta,
                                $"目前" + v.Level + "等，距離升等還要" + (v.NextLevelXp - v.Experience) + "點經驗");
                        }
                }
            if (ClientSettings.LevelOutput == "levelup")
                await Task.Delay(1000);
            else

                await Task.Delay(ClientSettings.LevelTimeInterval * 1000);
            // PrintLevel(client);
        }

        // Pulled from NecronomiconCoding
        public static string _getSessionRuntimeInTimeFormat()
        {
            return (DateTime.Now - InitSessionDateTime).ToString(@"dd\.hh\:mm\:ss");
        }

        public async Task updateUserStatusBar(Client client, GetInventoryResponse inventory, GetPlayerResponse profile)
        {
            var stats =
                inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PlayerStats)
                    .Where(i => i != null)
                    .ToArray();
            short hoursLeft = 0;
            short minutesLeft = 0;
            var secondsLeft = 0;
            double xpSec = 0;
            var v = stats.First();
            if (v != null)
            {
                var XpDiff = GetXpDiff(client, v.Level);
                //Calculating the exp needed to level up
                float expNextLvl = v.NextLevelXp - v.Experience;
                //Calculating the exp made per second
                xpSec = Math.Round(_totalExperience / GetRuntime()) / 60 / 60;
                //Calculating the seconds left to level up
                if (xpSec != 0)
                    secondsLeft = Convert.ToInt32(expNextLvl / xpSec);
                //formatting data to make an output like DateFormat
                while (secondsLeft > 60)
                {
                    secondsLeft -= 60;
                    if (minutesLeft < 60)
                    {
                        minutesLeft++;
                    }
                    else
                    {
                        minutesLeft = 0;
                        hoursLeft++;
                    }
                }
                SetStatusText(
                    string.Format($"【{profile.PlayerData.Username}】　　等級{v.Level}　　經驗值{v.Experience - v.PrevLevelXp - XpDiff}/{v.NextLevelXp - v.PrevLevelXp - XpDiff}　　星塵{profile.PlayerData.Currencies.ToArray()[1].Amount}"));
            }
            await Task.Delay(1000);
        }

        public static int GetXpDiff(Client client, int Level)
        {
            switch (Level)
            {
                case 1:
                    return 0;

                case 2:
                    return 1000;

                case 3:
                    return 2000;

                case 4:
                    return 3000;

                case 5:
                    return 4000;

                case 6:
                    return 5000;

                case 7:
                    return 6000;

                case 8:
                    return 7000;

                case 9:
                    return 8000;

                case 10:
                    return 9000;

                case 11:
                    return 10000;

                case 12:
                    return 10000;

                case 13:
                    return 10000;

                case 14:
                    return 10000;

                case 15:
                    return 15000;

                case 16:
                    return 20000;

                case 17:
                    return 20000;

                case 18:
                    return 20000;

                case 19:
                    return 25000;

                case 20:
                    return 25000;

                case 21:
                    return 50000;

                case 22:
                    return 75000;

                case 23:
                    return 100000;

                case 24:
                    return 125000;

                case 25:
                    return 150000;

                case 26:
                    return 190000;

                case 27:
                    return 200000;

                case 28:
                    return 250000;

                case 29:
                    return 300000;

                case 30:
                    return 350000;

                case 31:
                    return 500000;

                case 32:
                    return 500000;

                case 33:
                    return 750000;

                case 34:
                    return 1000000;

                case 35:
                    return 1250000;

                case 36:
                    return 1500000;

                case 37:
                    return 2000000;

                case 38:
                    return 2500000;

                case 39:
                    return 1000000;

                case 40:
                    return 1000000;
            }
            return 0;
        }

        public void confirmBotStopped()
        {
            _pokestopsOverlay.Routes.Clear();
            _pokestopsOverlay.Markers.Clear();
            ColoredConsoleWrite(Color.Red, $"機器人已關閉！運行了{_getSessionRuntimeInTimeFormat()}");
            startStopBotToolStripMenuItem.Text = "▶ 啟動機器人";
            _botStarted = false;
            _pokeStops = null;
            SetTitleText(false);
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        PointLatLng RangeCenter;
        private void startStopBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_botStarted)
            {
                InitSessionDateTime = DateTime.Now;
                ConsoleClear();
                _pokemonsOverlay.Markers.Clear();
                _stopping = false;
                _botStarted = true;
                startStopBotToolStripMenuItem.Text = "■ 關閉機器人";
                RangeCenter.Lat = ClientSettings.DefaultLatitude;
                RangeCenter.Lng = ClientSettings.DefaultLongitude;
                Task.Run(async () =>
                {
                    //CheckVersion();
                    while (true)
                    {
                        try
                        {
                            //ColoredConsoleWrite(ConsoleColor.White, "Coded by Ferox - edited by NecronomiconCoding");
                            if (!_botStarted)
                            {
                                break;
                            }
                            await Execute();
                        }
                        catch (PtcOfflineException)
                        {
                            ColoredConsoleWrite(Color.Red, "PTC伺服器可能關閉或您的憑證錯誤，請嘗試使用Google");
                        }
                        catch (Exception ex)
                        {
                            ColoredConsoleWrite(Color.Red, ex.StackTrace, "發生不明錯誤，詳細資訊請檢閱Log記錄檔");
                        }
                    }
                });
            }
            else
            {
                if (!_forceUnbanning)
                {
                    _stopping = true;
                    ColoredConsoleWrite(Color.Red, $"正在停止機器人…請等待最後一個動作結束！");
                }
                else
                {
                    ColoredConsoleWrite(Color.Red, $"動作正在進行，請先等待它完成再進行下一個動作！");
                }
            }
        }

        private void Client_OnConsoleWrite(ConsoleColor color, string message)
        {
            var c = Color.White;
            switch (color)
            {
                case ConsoleColor.Green:
                    c = Color.Green;
                    break;

                case ConsoleColor.DarkCyan:
                    c = Color.DarkCyan;
                    break;
            }
            ColoredConsoleWrite(c, message);
        }

        private async void forceUnbanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_client != null && _pokeStops != null)
            {
                if (_forceUnbanning)
                {
                    ColoredConsoleWrite(Color.Red, "正在嘗試解除軟封鎖(SoftBan)，請稍後…");
                }
                else
                {
                    await ForceUnban(_client);
                }
            }
            else
            {
                startStopBotToolStripMenuItem_Click(sender, e);
                ColoredConsoleWrite(Color.Red, "請先啟動機器人並等待地圖載入完成，再嘗試解除軟封鎖(SoftBan)");
            }
        }

        private void todoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        #region POKEMON LIST

        private IEnumerable<Candy> families;
        IEnumerable<PokemonData> ContinuePowerUp;
        private void InitializePokemonForm()
        {
            olvPokemonList.ButtonClick += PokemonListButton_Click;

            pkmnName.ImageGetter = delegate (object rowObject)
            {
                var pokemon = rowObject as PokemonObject;

                var key = pokemon.PokemonId.ToString();
                if (!olvPokemonList.SmallImageList.Images.ContainsKey(key))
                {
                    var img = GetPokemonImage((int)pokemon.PokemonId);
                    olvPokemonList.SmallImageList.Images.Add(key, img);
                }
                return key;
            };

            olvPokemonList.FormatRow += delegate (object sender, FormatRowEventArgs e)
            {
                var pok = e.Model as PokemonObject;
                if (olvPokemonList.Objects.Cast<PokemonObject>()
                        .Select(i => i.PokemonId)
                        .Where(p => p == pok.PokemonId)
                        .Count() > 1)
                    e.Item.BackColor = Color.LightGreen;

                foreach (OLVListSubItem sub in e.Item.SubItems)
                {
                    if (sub.Text.Equals("進化") && !pok.CanEvolve)
                    {
                        sub.CellPadding = new Rectangle(100, 100, 0, 0);
                    }
                }
            };

            cmsPokemonList.Opening += delegate (object sender, CancelEventArgs e)
            {
                e.Cancel = false;
                cmsPokemonList.Items.Clear();

                var pokemons = olvPokemonList.SelectedObjects.Cast<PokemonObject>().Select(o => o.PokemonData);
                var canAllEvolve =
                    olvPokemonList.SelectedObjects.Cast<PokemonObject>()
                        .Select(o => o)
                        .Where(o => o.CanEvolve == false)
                        .Count() == 0;
                var count = pokemons.Count();

                if (count < 1)
                {
                    e.Cancel = true;
                    return;
                }

                var pokemonObject = olvPokemonList.SelectedObjects.Cast<PokemonObject>().Select(o => o).First();

                var item = new ToolStripMenuItem();
                var separator = new ToolStripSeparator();
                item.Text = "傳送選取的" + count + "隻神奇寶貝";
                item.Click += delegate { TransferPokemon(pokemons); };
                cmsPokemonList.Items.Add(item);

                item = new ToolStripMenuItem();
                item.Text = "重新取名";
                item.Click += delegate
                {
                    using (var form = count == 1 ? new NicknamePokemonForm(pokemonObject) : new NicknamePokemonForm())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            NicknamePokemon(pokemons, form.txtNickname.Text);
                        }
                    }
                };
                cmsPokemonList.Items.Add(item);

                if (canAllEvolve)
                {
                    item = new ToolStripMenuItem();
                    item.Text = "進化選取的" + count + "隻神奇寶貝";
                    item.Click += delegate { EvolvePokemon(pokemons); };
                    cmsPokemonList.Items.Add(item);
                }

                if (count == 1)
                {
                    item = new ToolStripMenuItem();
                    item.Text = "升級神奇寶貝（直到滿等或沒素材）";
                    item.Click += delegate {
                        ContinuePowerUp = pokemons;
                        PowerUpPokemon(pokemons);
                    };
                    cmsPokemonList.Items.Add(item);

                    cmsPokemonList.Items.Add(separator);

                    item = new ToolStripMenuItem();
                    item.Text = "傳送相同的神奇寶貝（只保留最高IV）";
                    item.Click += delegate { CleanUpTransferPokemon(pokemonObject, "IV"); };
                    cmsPokemonList.Items.Add(item);

                    item = new ToolStripMenuItem();
                    item.Text = "傳送相同的神奇寶貝（只保留最高CP）";
                    item.Click += delegate { CleanUpTransferPokemon(pokemonObject, "CP"); };
                    cmsPokemonList.Items.Add(item);

                    item = new ToolStripMenuItem();
                    item.Text = "進化相同的神奇寶貝（IV高的優先）";
                    item.Click += delegate { CleanUpEvolvePokemon(pokemonObject, "IV"); };
                    cmsPokemonList.Items.Add(item);

                    item = new ToolStripMenuItem();
                    item.Text = "進化相同的神奇寶貝（CP高的優先）";
                    item.Click += delegate { CleanUpEvolvePokemon(pokemonObject, "CP"); };
                    cmsPokemonList.Items.Add(item);

                    cmsPokemonList.Items.Add(separator);
                }
            };
        }

        private Image GetPokemonImage(int pokemonId)
        {
            return (Image)Properties.Resources.ResourceManager.GetObject("Pokemon_" + pokemonId);
        }
        
        private void SetState(bool state)
        {
            btnRefresh.Enabled = state;
            olvPokemonList.Enabled = state;
            flpItems.Enabled = state;
        }

        async void AutoRefreshPokemonList()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AutoRefreshPokemonList));
                return;
            }
            await ReloadPokemonList(true);
        }

        private async Task ReloadPokemonList(bool State = false)
        {
            SetState(State);

            try
            {
                _client2 = new Client(ClientSettings, new ApiFailureStrategy());
                await _client2.Login.DoLogin();

                var inventory = await _client2.Inventory.GetInventory();
                var profile = await _client2.Player.GetPlayer();
                var itemTemplates = await _client2.Download.GetItemTemplates();

                await updateUserStatusBar(_client2, inventory, profile);

                var appliedItems = new Dictionary<ItemId, DateTime>();
                var inventoryAppliedItems =
                    inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.AppliedItems);

                foreach (var aItems in inventoryAppliedItems)
                {
                    if (aItems != null && aItems.Item != null)
                    {
                        foreach (var item in aItems.Item)
                        {
                            appliedItems.Add(item.ItemId, Utils.FromUnixTimeUtc(item.ExpireMs));
                        }
                    }
                }

                PokemonObject.Initilize(itemTemplates);

                var pokemons =
                    inventory.InventoryDelta.InventoryItems.Select(i => i?.InventoryItemData?.PokemonData)
                        .Where(p => p != null && p?.PokemonId > 0)
                        .OrderByDescending(PokemonInfo.CalculatePokemonPerfection)
                        .OrderByDescending(key => key.Cp)
                        .OrderBy(key => key.PokemonId);
                families = inventory.InventoryDelta.InventoryItems
                    .Select(i => i.InventoryItemData.Candy)
                    .Where(p => p != null && p.FamilyId > 0)
                    .OrderByDescending(p => p.FamilyId);

                var pokemonObjects = new List<PokemonObject>();
                foreach (var pokemon in pokemons)
                {
                    var pokemonObject = new PokemonObject(pokemon);
                    var family =
                        families.Where(i => (int)i.FamilyId <= (int)pokemon.PokemonId)
                            .First();
                    pokemonObject.Candy = family.Candy_;
                    pokemonObjects.Add(pokemonObject);
                }

                var prevTopItem = olvPokemonList.TopItemIndex;
                olvPokemonList.SetObjects(pokemonObjects);
                olvPokemonList.TopItemIndex = prevTopItem;

                var pokemoncount =
                    inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                        .Where(p => p != null && p?.PokemonId > 0)
                        .Count();
                var eggcount =
                    inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.PokemonData)
                        .Where(p => p != null && p?.IsEgg == true)
                        .Count();

                var items =
                    inventory.InventoryDelta.InventoryItems
                        .Select(i => i.InventoryItemData?.Item)
                        .Where(i => i != null)
                        .OrderBy(i => i.ItemId);
                var itemscount =
                    inventory.InventoryDelta.InventoryItems
                        .Select(i => i.InventoryItemData?.Item)
                        .Where(i => i != null)
                        .Sum(i => i.Count) + 1;

                flpItems.Controls.Clear();
                foreach (var item in items)
                {
                    var box = new ItemBox(item);
                    if (appliedItems.ContainsKey(item.ItemId))
                        box.expires = appliedItems[item.ItemId];
                    box.ItemClick += ItemBox_ItemClick;
                    flpItems.Controls.Add(box);
                }

                lblPokemonList.Text = "你擁有" + pokemoncount + "隻神奇寶貝和" + eggcount +
                    "顆蛋　|　寶可夢空間" + (pokemoncount + eggcount) + " / " + profile.PlayerData.MaxPokemonStorage + "（" + ((pokemoncount + eggcount) * 100 / profile.PlayerData.MaxPokemonStorage) +
                    "%）　|　背包空間" + itemscount + " / " + profile.PlayerData.MaxItemStorage + "（" + (itemscount * 100 / profile.PlayerData.MaxItemStorage) + "%）";
                btnRefresh.Text = "更新神奇寶貝/背包狀態（最後更新於" + DateTime.Now.ToString("HH:mm:ss") + "）";
            }
            catch (GoogleException)
            {
                ColoredConsoleWrite(Color.Red, "無法登入您的Google帳號，請檢察帳號密碼是否有錯誤");
            }
            catch (LoginFailedException)
            {
                ColoredConsoleWrite(Color.Red, "無法登入您的PTC帳號，請檢察帳號密碼是否有錯誤");
            }
            catch (AccessTokenExpiredException ex)
            {
                ColoredConsoleWrite(Color.Red, ex.Message, "發生不明錯誤，詳細資訊請檢閱Log記錄檔");
            }
            catch (Exception ex)
            {
                ColoredConsoleWrite(Color.Red, ex.StackTrace, "發生不明錯誤，詳細資訊請檢閱Log記錄檔");

                //_pokestopsOverlay.Routes.Clear();
                //_pokestopsOverlay.Markers.Clear();
                //ColoredConsoleWrite(Color.Red, $"機器人已關閉！");
                //startStopBotToolStripMenuItem.Text = "▶ 啟動機器人";
                //_stopping = false;
                //_botStarted = false;
                //_pokeStops = null;
                //_client2 = null;
            }
            SetState(true);
        }

        private async void ItemBox_ItemClick(object sender, EventArgs e)
        {
            var item = (ItemData)sender;

            using (var form = new ItemForm(item))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SetState(false);
                    if (item.ItemId == ItemId.ItemLuckyEgg)
                    {
                        if (!_botStarted)
                        {
                            ColoredConsoleWrite(Color.Red, $"機器人必須先啟動才能使用幸運蛋！");
                            SetState(true);
                            return;
                        }
                        var response = await _client.Inventory.UseItemXpBoost();
                        if (response.Result == UseItemXpBoostResponse.Types.Result.Success)
                        {
                            ColoredConsoleWrite(Color.Green, $"正在使用幸運蛋…");
                            ColoredConsoleWrite(Color.Yellow, $"幸運蛋的時效將持續至{DateTime.Now.AddMinutes(30)}");
                        }
                        else if (response.Result == UseItemXpBoostResponse.Types.Result.ErrorXpBoostAlreadyActive)
                        {
                            ColoredConsoleWrite(Color.Orange, $"上一個幸運蛋的時效還沒結束！");
                        }
                        else if (response.Result == UseItemXpBoostResponse.Types.Result.ErrorLocationUnset)
                        {
                            ColoredConsoleWrite(Color.Red, $"機器人必須先啟動才能使用幸運蛋！");
                        }
                        else
                        {
                            ColoredConsoleWrite(Color.Red, $"使用幸運蛋失敗！");
                        }
                    }
                    else if (item.ItemId == ItemId.ItemIncenseOrdinary)
                    {
                        if (!_botStarted)
                        {
                            ColoredConsoleWrite(Color.Red, $"機器人必須先啟動才能使用薰香！");
                            SetState(true);
                            return;
                        }
                        var response = await _client.Inventory.UseIncense(ItemId.ItemIncenseOrdinary);
                        if (response.Result == UseIncenseResponse.Types.Result.Success)
                        {
                            ColoredConsoleWrite(Color.Green, $"正在使用薰香…");
                            ColoredConsoleWrite(Color.Yellow, $"薰香的時效將持續至{DateTime.Now.AddMinutes(30)}");
                        }
                        else if (response.Result == UseIncenseResponse.Types.Result.IncenseAlreadyActive)
                        {
                            ColoredConsoleWrite(Color.Orange, $"上一個薰香的時效還沒結束！");
                        }
                        else if (response.Result == UseIncenseResponse.Types.Result.LocationUnset)
                        {
                            ColoredConsoleWrite(Color.Red, $"機器人必須先啟動才能使用薰香！");
                        }
                        else
                        {
                            ColoredConsoleWrite(Color.Red, $"使用薰香失敗！");
                        }
                    }
                    else
                    {
                        var response =
                            await _client2.Inventory.RecycleItem(item.ItemId, decimal.ToInt32(form.numCount.Value));
                        if (response.Result == RecycleInventoryItemResponse.Types.Result.Success)
                        {
                            ColoredConsoleWrite(Color.DarkCyan,
                                $"丟棄{decimal.ToInt32(form.numCount.Value)}個{item.ItemId.ToString().Substring(4)}");
                        }
                        else
                        {
                            ColoredConsoleWrite(Color.Red,
                                $"無法丟棄{decimal.ToInt32(form.numCount.Value)}個{item.ItemId.ToString().Substring(4)}");
                        }
                    }
                    await ReloadPokemonList();
                }
            }
        }

        private async void PokemonListButton_Click(object sender, CellClickEventArgs e)
        {
            try
            {
                var pokemon = e.Model as PokemonObject;
                var olv = new List<string>();
                for (int i = 0; i < olvPokemonList.AllColumns.Count; i++)
                    if (olvPokemonList.AllColumns[i].IsVisible) olv.Add(olvPokemonList.AllColumns[i].Text);
                if (olv[e.ColumnIndex] == "▲傳送") 
                {
                    TransferPokemon(new List<PokemonData> { pokemon.PokemonData });
                }
                else if (olv[e.ColumnIndex] == "▲升級") 
                {
                    PowerUpPokemon(new List<PokemonData> { pokemon.PokemonData });
                }
                else if (olv[e.ColumnIndex] == "▲進化") 
                {
                    EvolvePokemon(new List<PokemonData> { pokemon.PokemonData });
                }
                else
                {
                    ColoredConsoleWrite(Color.Red, "傳入代碼錯誤！請將列表擷圖並描述過程回報給工程師");
                }
            }
            catch (Exception ex)
            {
                ColoredConsoleWrite(Color.Red, ex.StackTrace, "發生不明錯誤，詳細資訊請檢閱Log記錄檔");
                _client2 = null;
                await ReloadPokemonList();
            }
        }

        private async void TransferPokemon(IEnumerable<PokemonData> pokemons)
        {
            SetState(false);
            foreach (var pokemon in pokemons)
            {
                var transferPokemonResponse = await _client2.Inventory.TransferPokemon(pokemon.Id);
                if (transferPokemonResponse.Result == ReleasePokemonResponse.Types.Result.Success)
                {
                    ColoredConsoleWrite(Color.Magenta,
                        $"{pokemon.PokemonId}被傳送走了！獲得{transferPokemonResponse.CandyAwarded}顆糖果");
                }
                else
                {
                    ColoredConsoleWrite(Color.Magenta, $"{pokemon.PokemonId}無法被傳送！");
                }
            }
            await ReloadPokemonList();
        }

        private async void PowerUpPokemon(IEnumerable<PokemonData> pokemons)
        {
            SetState(false);
            do
            {
                foreach (var pokemon in pokemons)
                {
                    var evolvePokemonResponse = await _client2.Inventory.UpgradePokemon(pokemon.Id);
                    if (evolvePokemonResponse.Result == UpgradePokemonResponse.Types.Result.Success)
                    {
                        ColoredConsoleWrite(Color.Magenta, $"{pokemon.PokemonId}成功被升級！");
                    }
                    else
                    {
                        if (ContinuePowerUp == null) ColoredConsoleWrite(Color.Magenta, $"{pokemon.PokemonId}無法被升級！");
                        else ContinuePowerUp = null;
                        break;
                    }
                }
            } while (pokemons == ContinuePowerUp);
            await ReloadPokemonList();
        }

        private async void EvolvePokemon(IEnumerable<PokemonData> pokemons)
        {
            SetState(false);
            foreach (var pokemon in pokemons)
            {
                var evolvePokemonResponse = await _client2.Inventory.EvolvePokemon(pokemon.Id);
                if (evolvePokemonResponse.Result == EvolvePokemonResponse.Types.Result.Success)
                {
                    ColoredConsoleWrite(Color.Magenta,
                        $"{pokemon.PokemonId}成功被進化成{evolvePokemonResponse.EvolvedPokemonData.PokemonId}\n獲得{evolvePokemonResponse.ExperienceAwarded}經驗和{evolvePokemonResponse.CandyAwarded}糖果");
                }
                else
                {
                    ColoredConsoleWrite(Color.Magenta, $"{pokemon.PokemonId}無法被進化！");
                }
            }
            await ReloadPokemonList();
        }

        private async Task UseIncubators(Client client, int mode)
        {
            var profile = (await GetProfile(client)).FirstOrDefault();

            if (profile == null)
                return;

            var kmWalked = profile.KmWalked;

            var unusedEggs = (await getUnusedEggs(client))
                .Where(x => string.IsNullOrEmpty(x.EggIncubatorId))
                .OrderBy(x => x.EggKmWalkedTarget - x.EggKmWalkedStart)
                .ToList();
            var incubators = (await getUnusedIncubators(client))
                .Where(x => x.UsesRemaining > 0 || x.ItemId == ItemId.ItemIncubatorBasicUnlimited)
                .OrderByDescending(x => x.ItemId == ItemId.ItemIncubatorBasicUnlimited)
                .OrderByDescending(x => x.PokemonId != 0)
                .ToList();

            var num = 1;

            foreach (var inc in incubators)
            {
                var usesLeft = (inc.ItemId == ItemId.ItemIncubatorBasicUnlimited) ?
                "∞" : inc.UsesRemaining.ToString();
                if (inc.PokemonId == 0)
                {
                    if (mode == 1 && inc.ItemId != ItemId.ItemIncubatorBasicUnlimited)
                        continue;

                    var egg = (inc.ItemId == ItemId.ItemIncubatorBasicUnlimited && incubators.Count > 1)
                    ? unusedEggs.FirstOrDefault()
                    : unusedEggs.LastOrDefault();

                    if (egg == null)
                        continue;

                    var useIncubator = await client.Inventory.UseItemEggIncubator(inc.Id, egg.Id);
                    unusedEggs.Remove(egg);
                    var eggKm = egg.EggKmWalkedTarget;
                    ColoredConsoleWrite(Color.YellowGreen, $"孵蛋器#{num}成功裝入一顆{eggKm}公里的蛋，孵蛋器#{num}還剩下{usesLeft}個");
                }
                else
                {
                    var remainingDistance = String.Format("{0:0.00}", (inc.TargetKmWalked - kmWalked));
                    var eggKm = inc.TargetKmWalked - inc.StartKmWalked;
                    ColoredConsoleWrite(Color.YellowGreen, $"【狀態】孵蛋器#{num}還有{usesLeft}個，孵化狀態{remainingDistance}/{eggKm}公里");
                }
                num++;
            }
        }

        private async void CleanUpTransferPokemon(PokemonObject pokemon, string type)
        {
            var ET = pokemon.EvolveTimes;
            var pokemonCount =
                olvPokemonList.Objects.Cast<PokemonObject>()
                    .Where(p => p.PokemonId == pokemon.PokemonId)
                    .Count();

            if (pokemonCount < ET)
            {
                await ReloadPokemonList();
                return;
            }

            if (ET == 0)
                ET = 1;

            if (type.Equals("IV"))
            {
                var pokemons =
                    olvPokemonList.Objects.Cast<PokemonObject>()
                        .Where(p => p.PokemonId == pokemon.PokemonId)
                        .Select(p => p.PokemonData)
                        .OrderBy(p => p.Cp)
                        .OrderBy(PokemonInfo.CalculatePokemonPerfection)
                        .Take(pokemonCount - ET);

                TransferPokemon(pokemons);
            }
            else if (type.Equals("CP"))
            {
                var pokemons =
                    olvPokemonList.Objects.Cast<PokemonObject>()
                        .Where(p => p.PokemonId == pokemon.PokemonId)
                        .Select(p => p.PokemonData)
                        .OrderBy(PokemonInfo.CalculatePokemonPerfection)
                        .OrderBy(p => p.Cp)
                        .Take(pokemonCount - ET);

                TransferPokemon(pokemons);
            }
        }

        private async void CleanUpEvolvePokemon(PokemonObject pokemon, string type)
        {
            var ET = pokemon.EvolveTimes;

            if (ET < 1)
            {
                await ReloadPokemonList();
                return;
            }

            if (type.Equals("IV"))
            {
                var pokemons =
                    olvPokemonList.Objects.Cast<PokemonObject>()
                        .Where(p => p.PokemonId == pokemon.PokemonId)
                        .Select(p => p.PokemonData)
                        .OrderByDescending(p => p.Cp)
                        .OrderByDescending(PokemonInfo.CalculatePokemonPerfection)
                        .Take(ET);

                EvolvePokemon(pokemons);
            }
            else if (type.Equals("CP"))
            {
                var pokemons =
                    olvPokemonList.Objects.Cast<PokemonObject>()
                        .Where(p => p.PokemonId == pokemon.PokemonId)
                        .Select(p => p.PokemonData)
                        .OrderByDescending(PokemonInfo.CalculatePokemonPerfection)
                        .OrderByDescending(p => p.Cp)
                        .Take(ET);

                EvolvePokemon(pokemons);
            }
        }

        public async Task<IEnumerable<ItemData>> GetItems(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            return inventory.InventoryDelta.InventoryItems
                .Select(i => i.InventoryItemData?.Item)
                .Where(p => p != null);
        }

        private async Task<IEnumerable<EggIncubator>> getUnusedIncubators(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            return inventory.InventoryDelta.InventoryItems.
            Where(x => x.InventoryItemData?.EggIncubators != null).
            SelectMany(x => x.InventoryItemData.EggIncubators.EggIncubator).
            Where(x => x != null);
        }

        private async Task<IEnumerable<PokemonData>> getUnusedEggs(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            return inventory.InventoryDelta.InventoryItems.
            Select(i => i.InventoryItemData?.PokemonData).
            Where(p => p != null && p.IsEgg).ToList().
            Where(x => string.IsNullOrEmpty(x.EggIncubatorId)).
            OrderBy(x => x.EggKmWalkedTarget - x.EggKmWalkedStart);
        }

        private async Task<IEnumerable<PlayerStats>> GetProfile(Client client)
        {
            var inventory = await client.Inventory.GetInventory();
            return inventory.InventoryDelta.InventoryItems
                .Select(i => i.InventoryItemData?.PlayerStats)
                .Where(p => p != null);
        }

        public async Task<IEnumerable<ItemData>> GetItemsToRecycle(ISettings _settings, Client client)
        {
            var itemCounts = (_settings as Settings).ItemCounts;
            var settings = (Settings)_settings;
            var myItems = await GetItems(client);
            var itemsToRecycle = new List<ItemData>();
            int[] TypeMax = { 0, 0, 0, 0 };
            foreach (var itemCount in itemCounts)
            {
                int ItemType = GetItemType(itemCount.ItemId);
                if (ItemType == 0) continue;
                TypeMax[ItemType - 1] += itemCount.Count;
            }
            int[] TypeCount = { 0, 0, 0, 0 };
            foreach (var itemData in myItems)
            {
                int ItemType = GetItemType(itemData.ItemId);
                if (ItemType == 0) continue;
                TypeCount[ItemType - 1] += itemData.Count;
            }
            byte RecycleTpye = 0;
            var ItemList = new List<ItemId>();
            ItemList.Add(ItemId.Item寶貝球);
            ItemList.Add(ItemId.Item高級球);
            ItemList.Add(ItemId.Item超級球);
            ItemList.Add(ItemId.Item頂級球);
            for(int i = 0; i < ItemList.Count; i++)
            {
                int RecycleCount = TypeCount[RecycleTpye] - TypeMax[RecycleTpye];
                if (RecycleCount <= 0) break;
                foreach (var itemData in myItems)   if(itemData.ItemId == ItemList[i])
                    {
                        int Recycle = 0;
                        if (itemData.Count >= RecycleCount) Recycle = RecycleCount; else Recycle = itemData.Count;
                        TypeCount[RecycleTpye] -= Recycle;
                        var itemToRecycle = new ItemData();
                        itemToRecycle.ItemId = itemData.ItemId;
                        itemToRecycle.Count = Recycle;
                        itemsToRecycle.Add(itemToRecycle);
                    }
            }
            RecycleTpye++;
            ItemList.Clear();
            ItemList.Add(ItemId.Item莓果);
            for (int i = 0; i < ItemList.Count; i++)
            {
                int RecycleCount = TypeCount[RecycleTpye] - TypeMax[RecycleTpye];
                if (RecycleCount <= 0) break;
                foreach (var itemData in myItems) if (itemData.ItemId == ItemList[i])
                    {
                        int Recycle = 0;
                        if (itemData.Count >= RecycleCount) Recycle = RecycleCount; else Recycle = itemData.Count;
                        TypeCount[RecycleTpye] -= Recycle;
                        var itemToRecycle = new ItemData();
                        itemToRecycle.ItemId = itemData.ItemId;
                        itemToRecycle.Count = Recycle;
                        itemsToRecycle.Add(itemToRecycle);
                    }
            }
            RecycleTpye++;
            ItemList.Clear();
            ItemList.Add(ItemId.Item藥水);
            ItemList.Add(ItemId.Item強效藥水);
            ItemList.Add(ItemId.Item超級藥水);
            ItemList.Add(ItemId.Item頂級藥水);
            for (int i = 0; i < ItemList.Count; i++)
            {
                int RecycleCount = TypeCount[RecycleTpye] - TypeMax[RecycleTpye];
                if (RecycleCount <= 0) break;
                foreach (var itemData in myItems) if (itemData.ItemId == ItemList[i])
                    {
                        int Recycle = 0;
                        if (itemData.Count >= RecycleCount) Recycle = RecycleCount; else Recycle = itemData.Count;
                        TypeCount[RecycleTpye] -= Recycle;
                        var itemToRecycle = new ItemData();
                        itemToRecycle.ItemId = itemData.ItemId;
                        itemToRecycle.Count = Recycle;
                        itemsToRecycle.Add(itemToRecycle);
                    }
            }
            RecycleTpye++;
            ItemList.Clear();
            ItemList.Add(ItemId.Item復活石);
            ItemList.Add(ItemId.Item頂級復活石);
            for (int i = 0; i < ItemList.Count; i++)
            {
                int RecycleCount = TypeCount[RecycleTpye] - TypeMax[RecycleTpye];
                if (RecycleCount <= 0) break;
                foreach (var itemData in myItems) if (itemData.ItemId == ItemList[i])
                    {
                        int Recycle = 0;
                        if (itemData.Count >= RecycleCount) Recycle = RecycleCount; else Recycle = itemData.Count;
                        TypeCount[RecycleTpye] -= Recycle;
                        var itemToRecycle = new ItemData();
                        itemToRecycle.ItemId = itemData.ItemId;
                        itemToRecycle.Count = Recycle;
                        itemsToRecycle.Add(itemToRecycle);
                    }
            }
            //foreach (var itemData in myItems)
            //{
            //    int ItemType = GetItemType(itemData.ItemId);
            //    foreach (var itemData2 in myItems)
            //    {
            //        int ItemType2 = GetItemType(itemData2.ItemId);
            //        if (ItemType == ItemType2) TypeCount[ItemType - 1] += itemData.Count;
            //    }
            //    foreach (var itemCount in itemCounts)
            //    {
            //        //int ItemType2 = GetItemType(itemCount.ItemId);
            //        //if (ItemType == ItemType2) TypeMax += itemCount.Count;
            //        //if (ItemType == 1 && TypeCount > Ball[0].) 
            //        if (itemData.ItemId == itemCount.ItemId && itemData.Count > itemCount.Count)
            //        {
            //            var itemToRecycle = new ItemData();
            //            itemToRecycle.ItemId = itemData.ItemId;
            //            itemToRecycle.Count = itemData.Count - itemCount.Count;
            //            itemsToRecycle.Add(itemToRecycle);
            //        }
            //    }
            //}

            return itemsToRecycle;
        }

        byte GetItemType(ItemId Item)
        {
            var Ball = new List<ItemId>() ;
            Ball.Add(ItemId.Item寶貝球);
            Ball.Add(ItemId.Item高級球);
            Ball.Add(ItemId.Item超級球);
            Ball.Add(ItemId.Item頂級球);
            var Berry = new List<ItemId>();
            Berry.Add(ItemId.Item莓果);
            var Potion = new List<ItemId>();
            Potion.Add(ItemId.Item藥水);
            Potion.Add(ItemId.Item強效藥水);
            Potion.Add(ItemId.Item超級藥水);
            Potion.Add(ItemId.Item頂級藥水);
            var Revive = new List<ItemId>();
            Revive.Add(ItemId.Item復活石);
            Revive.Add(ItemId.Item頂級復活石);
            for (int i = 0; i < Ball.Count; i++) if (Item == Ball[i]) return 1;
            for (int i = 0; i < Berry.Count; i++) if (Item == Berry[i]) return 2;
            for (int i = 0; i < Potion.Count; i++) if (Item == Potion[i]) return 3;
            for (int i = 0; i < Revive.Count; i++) if (Item == Revive[i]) return 4;
            return 0;
        }

        public async Task RecycleItems(Client client)
        {
            var items = await GetItemsToRecycle(client.Settings, client);

            foreach (var item in items)
            {
                var transfer = await client.Inventory.RecycleItem(item.ItemId, item.Count);
                ColoredConsoleWrite(Color.DarkCyan, $"丟棄{item.Count}個{item.ItemId.ToString().Substring(4)}");
                //await Task.Delay(500);
            }
        }

        public async Task UseRazzBerry(Client client, ulong encounterId, string spawnPointGuid)
        {
            var myItems = await GetItems(client);
            var RazzBerries = myItems.Where(i => i.ItemId == ItemId.Item莓果);
            var RazzBerry = RazzBerries.FirstOrDefault();
            if (RazzBerry != null)
            {
                var useRazzBerry =
                    await client.Encounter.UseCaptureItem(encounterId, ItemId.Item莓果, spawnPointGuid);
                ColoredConsoleWrite(Color.Green, $"使用一個莓果，還剩下{RazzBerry.Count}個");
                await Task.Delay(2000);
            }
            else
            {
                ColoredConsoleWrite(Color.Red, $"你沒有莓果可以使用了！");
            }
        }

        public async Task<CatchPokemonResponse> CatchPokemon(ulong encounterId, string spawnPointGuid, double pokemonLat,
            double pokemonLng, ItemId pokeball, int? pokemonCP)
        {
            return await _client.Encounter.CatchPokemon(encounterId, spawnPointGuid, GetBestBall(pokemonCP).Result);
        }

        private async Task<ItemId> GetBestBall(int? pokemonCP)
        {
            var inventory = await _client.Inventory.GetInventory();

            var ballCollection = inventory.InventoryDelta.InventoryItems.Select(i => i.InventoryItemData?.Item)
                .Where(p => p != null)
                .GroupBy(i => i.ItemId)
                .Select(kvp => new { ItemId = kvp.Key, Amount = kvp.Sum(x => x.Count) })
                .Where(y => y.ItemId == ItemId.Item寶貝球
                            || y.ItemId == ItemId.Item高級球
                            || y.ItemId == ItemId.Item超級球
                            || y.ItemId == ItemId.Item頂級球);

            var pokeBallsCount = ballCollection.Where(p => p.ItemId == ItemId.Item寶貝球).
                DefaultIfEmpty(new { ItemId = ItemId.Item寶貝球, Amount = 0 }).FirstOrDefault().Amount;
            var greatBallsCount = ballCollection.Where(p => p.ItemId == ItemId.Item高級球).
                DefaultIfEmpty(new { ItemId = ItemId.Item高級球, Amount = 0 }).FirstOrDefault().Amount;
            var ultraBallsCount = ballCollection.Where(p => p.ItemId == ItemId.Item超級球).
                DefaultIfEmpty(new { ItemId = ItemId.Item超級球, Amount = 0 }).FirstOrDefault().Amount;
            var masterBallsCount = ballCollection.Where(p => p.ItemId == ItemId.Item頂級球).
                DefaultIfEmpty(new { ItemId = ItemId.Item頂級球, Amount = 0 }).FirstOrDefault().Amount;

            // Use better balls for high CP pokemon
            if (masterBallsCount > 0 && pokemonCP >= ClientSettings.CatchUseMaster) 
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆頂級球！還剩下{masterBallsCount - 1}顆");
                return ItemId.Item頂級球;
            }

            if (ultraBallsCount > 0 && pokemonCP >= ClientSettings.CatchUseUltra)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆超級球！還剩下{ultraBallsCount - 1}顆");
                return ItemId.Item超級球;
            }

            if (greatBallsCount > 0 && pokemonCP >= ClientSettings.CatchUseGreat)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆高級球！還剩下{greatBallsCount - 1}顆");
                return ItemId.Item高級球;
            }

            // If low CP pokemon, but no more pokeballs; only use better balls if pokemon are of semi-worthy quality
            if (pokeBallsCount > 0)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆寶貝球！還剩下{pokeBallsCount - 1}顆");
                return ItemId.Item寶貝球;
            }
            if (greatBallsCount > 0)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆高級球！還剩下{greatBallsCount - 1}顆");
                return ItemId.Item高級球;
            }
            if (ultraBallsCount > 0)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆超級球！還剩下{ultraBallsCount - 1}顆");
                return ItemId.Item超級球;
            }
            if (masterBallsCount > 0)
            {
                ColoredConsoleWrite(Color.Green, $"已使用１顆頂級球！還剩下{masterBallsCount - 1}顆");
                return ItemId.Item頂級球;
            }

            return ItemId.Item寶貝球;
        }

        public async void NicknamePokemon(IEnumerable<PokemonData> pokemons, string nickname)
        {
            SetState(false);
            foreach (var pokemon in pokemons)
            {
                var newName = new StringBuilder(nickname);
                newName.Replace("{Name}", Convert.ToString(pokemon.PokemonId));
                newName.Replace("{CP}", Convert.ToString(pokemon.Cp));
                newName.Replace("{IV}", Convert.ToString(Math.Round(Perfect(pokemon))));
                newName.Replace("{IA}", Convert.ToString(pokemon.IndividualAttack));
                newName.Replace("{ID}", Convert.ToString(pokemon.IndividualDefense));
                newName.Replace("{IS}", Convert.ToString(pokemon.IndividualStamina));
                if (nickname.Length > 12)
                {
                    ColoredConsoleWrite(Color.Red, $"「{newName}」太長了，請使用其他名稱");
                    if (pokemons.Count() == 1)
                    {
                        SetState(true);
                        return;
                    }
                    continue;
                }
                var response = await _client2.Inventory.NicknamePokemon(pokemon.Id, newName.ToString());
                if (response.Result == NicknamePokemonResponse.Types.Result.Success)
                {
                    ColoredConsoleWrite(Color.Green, $"成功將【{pokemon.PokemonId}】改名為「{newName}」");
                }
                else
                {
                    ColoredConsoleWrite(Color.Red, $"無法將【{pokemon.PokemonId}】改名為「{newName}」");
                }
                await Task.Delay(ACTIONDELAY);
            }
            await ReloadPokemonList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ReloadPokemonList();
        }
        #endregion POKEMON LIST

        private void timer1_Tick(object sender, EventArgs e)
        {
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", true);
            bool Update = Convert.ToBoolean(Reg.GetValue("AutoUpdate", false));
            if (Update)
            {
                ColoredConsoleWrite(Color.Purple, "正在下載更新…請稍後…");
                Refresh();
                WebClient AutoUpdate = new WebClient();
                AutoUpdate.DownloadFile("https://9f849c0c8aab9203add5cf3dfea3794e1c6617a6.googledrive.com/host/0B0PlXevV0aiiTzRzUEtEUGZaeUk/Pok%C3%A9monGO%20Rocket.7z", "Update.7z");
                AutoUpdate.DownloadFile("https://9f849c0c8aab9203add5cf3dfea3794e1c6617a6.googledrive.com/host/0B0PlXevV0aiiTzRzUEtEUGZaeUk/RecketSetup.bat", "Setup.bat");
                System.Diagnostics.Process.Start("Setup.bat");
                Close();
            }
        }

        private void logTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void gMapControl1_MouseEnter(object sender, EventArgs e)
        {
            MoveMap = false;
        }

        private void gMapControl1_MouseLeave(object sender, EventArgs e)
        {
            MoveMap = true;
        }

        private void olvPokemonList_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("移動");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Temp = olvPokemonList.Columns[5];
            olvPokemonList.Columns.RemoveAt(5);
            olvPokemonList.Columns.Insert(2,Temp);
        }
    }
}