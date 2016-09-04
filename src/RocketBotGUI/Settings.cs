#region

using Microsoft.Win32;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using PokemonGo.RocketAPI.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;

#endregion

namespace PokemonGo.RocketAPI.Window
{
    public class Settings : ISettings
    {
        private static volatile Settings _instance;
        private static readonly object SyncRoot = new object();
        string RegPath = "HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket";
        int Reg()
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket");
            return 0;
        }

        string GetPassword
        {
            get
            {
                string SafePassword = Convert.ToString(Registry.GetValue(RegPath, "LoginPassword", ""));
                string ComputerName = Environment.MachineName;
                byte[] ComputerByte = System.Text.Encoding.UTF8.GetBytes(ComputerName);
                while (ComputerByte.Length < 16)
                {
                    ComputerName += ComputerName;
                    ComputerByte = System.Text.Encoding.UTF8.GetBytes(ComputerName);
                }
                string Password = "";
                
                for (int i = 0; i < (SafePassword.Length / 3); i++)
                {
                    int[] Temp = { 0, Convert.ToInt32(SafePassword.Substring(3 * i, 3), 16), 0 };
                    if (i < 16) Temp[2] = Convert.ToInt32(ComputerByte[i]);
                    Temp[0] = Temp[1] - Temp[2];
                    if (Temp[0] == 0) continue;
                    byte[] PasswordByte = { Convert.ToByte(Temp[0]) };
                    Password += System.Text.Encoding.UTF8.GetString(PasswordByte);
                }
                
                return Password;
            }
        }
        public static Settings Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Settings();
                }

                return _instance;
            }
        }

        /// <summary>
        ///     Don't touch. User settings are in Console/App.config
        /// </summary>
        
        //public string TransferType => GetSetting() != string.Empty ? GetSetting() : "none";
        public int TransferType => Convert.ToInt32(Registry.GetValue(RegPath, "TransferType", 6));

        //public int TransferCpThreshold => GetSetting() != string.Empty ? int.Parse(GetSetting(), CultureInfo.InvariantCulture) : 0;
        public int TransferCpThreshold => Convert.ToInt32(Registry.GetValue(RegPath, "TransferCP", 1000));

        //public int TransferIvThreshold => GetSetting() != string.Empty ? int.Parse(GetSetting(), CultureInfo.InvariantCulture) : 0;
        public int TransferIvThreshold => Convert.ToInt32(Registry.GetValue(RegPath, "TransferIV", 80));

        public int TransferCountThreshold => Convert.ToInt32(Registry.GetValue(RegPath, "TransferCount", 2));

        public int DelayCatch => Convert.ToInt32(Registry.GetValue(RegPath, "DelayCatch", 3));
        public int DelaySupply => Convert.ToInt32(Registry.GetValue(RegPath, "DelaySupply", 2));
        public int DelayWalk => Convert.ToInt32(Registry.GetValue(RegPath, "DelayWalk", 2));
        public int DelayCheck => Convert.ToInt32(Registry.GetValue(RegPath, "DelayCheck", 2));
        public int DelayReLogin => Convert.ToInt32(Registry.GetValue(RegPath, "DelayReLogin", 20));
        public int DistanceSupply => Convert.ToInt32(Registry.GetValue(RegPath, "DistanceSupply", 40));
        public int DistanceCatch => Convert.ToInt32(Registry.GetValue(RegPath, "DistanceCatch", 100));
        public int WalkRange
        {
            get { return Convert.ToInt32(Registry.GetValue(RegPath, "WalkRange", 1000)); }
            set { Registry.SetValue(RegPath, "WalkRange", value); }
        }
        public int LimitSupply
        {
            get { return Convert.ToInt32(Registry.GetValue(RegPath, "LimitSupply", 0)); }
            set { Registry.SetValue(RegPath, "LimitSupply", value); }
        }
        public int LimitCatch
        {
            get { return Convert.ToInt32(Registry.GetValue(RegPath, "LimitCatch", 0)); }
            set { Registry.SetValue(RegPath, "LimitCatch", value); }
        }

        public int CatchMoreIV => Convert.ToInt32(Registry.GetValue(RegPath, "CatchMoreIV", 80));
        public int CatchMoreCP => Convert.ToInt32(Registry.GetValue(RegPath, "CatchMoreCP", 1000));
        public bool EnableCatchMoreIV => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableCatchMoreIV", false));
        public bool EnableCatchMoreCP => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableCatchMoreCP", false));
        public bool EnableCatchOR => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableCatchOR", false));
        public int CatchUseGreat => Convert.ToInt32(Registry.GetValue(RegPath, "CatchUseGreat", 1000));
        public int CatchUseUltra => Convert.ToInt32(Registry.GetValue(RegPath, "CatchUseUltra", 1300));
        public int CatchUseMaster => Convert.ToInt32(Registry.GetValue(RegPath, "CatchUseMaster", 1600));

        //public int TravelSpeed => GetSetting() != string.Empty ? int.Parse(GetSetting(), CultureInfo.InvariantCulture) : 60;
        public int TravelSpeed => Convert.ToInt32(Registry.GetValue(RegPath, "Speed", 10));

        public int ImageSize => GetSetting() != string.Empty ? int.Parse(GetSetting(), CultureInfo.InvariantCulture) : 50;

        //public bool EvolveAllGivenPokemons => GetSetting() != string.Empty && Convert.ToBoolean(GetSetting(), CultureInfo.InvariantCulture);
        public bool EvolveAllGivenPokemons => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableEvolve", false));

        public bool EnableKeepEvolve => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableKeepEvolve", false));

        //public bool CatchPokemon => GetSetting() != string.Empty && Convert.ToBoolean(GetSetting(), CultureInfo.InvariantCulture);
        public bool CatchPokemon => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableCatch", true));

        public bool UseLastGPS => Convert.ToBoolean(Registry.GetValue(RegPath, "EnableLastGPS", true));

        //public string PtcUsername => GetSetting() != string.Empty ? GetSetting() : "username";
        public string PtcUsername => Convert.ToString(Registry.GetValue(RegPath, "LoginAccount", ""));

        //public string PtcPassword => GetSetting() != string.Empty ? GetSetting() : "password";
        public string PtcPassword => GetPassword;

        public string LevelOutput => GetSetting() != string.Empty ? GetSetting() : "time";

        public int LevelTimeInterval => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 600;

        public bool Recycler => GetSetting() != string.Empty && Convert.ToBoolean(GetSetting(), CultureInfo.InvariantCulture);

        private int MaxItem寶貝球 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem高級球 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem超級球 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItemMasterBall => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem莓果 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem復活石 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem藥水 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem強效藥水 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem超級藥水 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;
        private int MaxItem頂級藥水 => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 500;

        public ICollection<KeyValuePair<ItemId, int>> ItemRecycleFilter => new[]
        {
            new KeyValuePair<ItemId, int>(ItemId.Item寶貝球, MaxItem寶貝球),
            new KeyValuePair<ItemId, int>(ItemId.Item高級球, MaxItem高級球),
            new KeyValuePair<ItemId, int>(ItemId.Item超級球, MaxItem超級球),
            new KeyValuePair<ItemId, int>(ItemId.Item頂級球, MaxItemMasterBall),
            new KeyValuePair<ItemId, int>(ItemId.Item莓果, MaxItem莓果),
            new KeyValuePair<ItemId, int>(ItemId.Item復活石, MaxItem復活石),
            new KeyValuePair<ItemId, int>(ItemId.Item藥水, MaxItem藥水),
            new KeyValuePair<ItemId, int>(ItemId.Item強效藥水, MaxItem強效藥水),
            new KeyValuePair<ItemId, int>(ItemId.Item超級藥水, MaxItem超級藥水),
            new KeyValuePair<ItemId, int>(ItemId.Item頂級藥水, MaxItem頂級藥水)
        };

        //public int RecycleItemsInterval => GetSetting() != string.Empty ? Convert.ToInt16(GetSetting()) : 0;

        //public string Language => GetSetting() != string.Empty ? GetSetting() : "tChinese";

        //public string RazzBerryMode => GetSetting() != string.Empty ? GetSetting() : "CP";
        public int RazzBerryMode => Convert.ToInt32(Registry.GetValue(RegPath, "RazzType", 0));

        //public double RazzBerrySetting => GetSetting() != string.Empty ? double.Parse(GetSetting(), CultureInfo.InvariantCulture) : 500;
        public double RazzBerrySetting => Convert.ToDouble(Registry.GetValue(RegPath, "RazzValue", 0.4));
        public int RazzBerrySettingCP => Convert.ToInt32(Registry.GetValue(RegPath, "RazzCP", 1000));

        //public string UseIncubatorsMode => GetSetting() != string.Empty ? GetSetting() : "Disabled";
        public int UseIncubatorsMode => Convert.ToInt32(Registry.GetValue(RegPath, "Incubator", 2));

        public List<ItemData> ItemCounts
        {
            get
            {
                var itemCounts = new List<ItemData>();
                var items = Convert.ToString(Registry.GetValue(RegPath, "Backpack", "Item寶貝球,20;Item高級球,20;Item超級球,50;Item莓果,50;Item藥水,20;Item強效藥水,20;Item超級藥水,20;Item頂級藥水,50;Item復活石,20;Item頂級復活石,50"));
                if (items.Contains(";"))
                {
                    foreach (var item in items.Split(';'))
                    {
                        if (item.Contains(","))
                        {
                            var itemId = item.Split(',')[0];
                            var count = Int32.Parse(item.Split(',')[1]);
                            foreach (ItemId id in Enum.GetValues(typeof(ItemId)))
                            {
                                if (id.ToString().Equals(itemId))
                                {
                                    ItemData itemData = new ItemData();
                                    itemData.ItemId = id;
                                    itemData.Count = count;
                                    itemCounts.Add(itemData);
                                    break;
                                }
                            }
                        }
                    }
                }
                return itemCounts;
            }

            set
            {
                var items = "";
                foreach (var itemData in value)
                {
                    items += itemData.ItemId.ToString() + "," + itemData.Count + ";";
                }
                if (items != string.Empty)
                {
                    items = items.Remove(items.Length - 1, 1);
                }
                Registry.SetValue(RegPath, "Backpack", items);
            }
        }

        public List<GMap.NET.PointLatLng> GPS_Location
        {
            get
            {
                var GPS = new List<GMap.NET.PointLatLng>();
                var items = Convert.ToString(Registry.GetValue(RegPath, "GPS", "24.161653,120.647146;"));
                if (items.Contains(";"))
                    foreach (var item in items.Split(';'))
                        if (item.Contains(","))
                            GPS.Add(new GMap.NET.PointLatLng(Convert.ToDouble(item.Split(',')[0]), Convert.ToDouble(item.Split(',')[1])));
                return GPS;
            }

            set
            {
                var items = "";
                foreach (var GPS in value)
                    items += GPS.Lat + "," + GPS.Lng + ";";
                Registry.SetValue(RegPath, "GPS", items);
            }
        }

        public List<PokemonId> ExcludedPokemonCatch
        {
            get
            {
                var pokemonIdList = new List<PokemonId>();
                var pokemons = Convert.ToString(Registry.GetValue(RegPath, "ExcludedCatch", ""));
                if (pokemons.Contains(","))
                {
                    foreach (var pokemon in pokemons.Split(','))
                    {
                        foreach (PokemonId id in Enum.GetValues(typeof(PokemonId)))
                        {
                            if (id.ToString().Equals(pokemon))
                            {
                                pokemonIdList.Add(id);
                                break;
                            }
                        }
                    }
                }
                return pokemonIdList;
            }

            //set
            //{
            //    var pokemonIds = "";
            //    foreach (var pokemonId in value)
            //    {
            //        pokemonIds += pokemonId + ",";
            //    }
            //    if (pokemonIds != string.Empty)
            //    {
            //        pokemonIds = pokemonIds.Remove(pokemonIds.Length - 1, 1);
            //    }
            //    SetSetting(pokemonIds);
            //}
        }

        public List<PokemonId> ExcludedPokemonTransfer
        {
            get
            {
                var pokemonIdList = new List<PokemonId>();
                var pokemons = Convert.ToString(Registry.GetValue(RegPath, "ExcludedTransfer", ""));
                if (pokemons.Contains(","))
                {
                    foreach (var pokemon in pokemons.Split(','))
                    {
                        foreach (PokemonId id in Enum.GetValues(typeof(PokemonId)))
                        {
                            if (id.ToString().Equals(pokemon))
                            {
                                pokemonIdList.Add(id);
                                break;
                            }
                        }
                    }
                }
                return pokemonIdList;
            }

            //set
            //{
            //    var pokemonIds = "";
            //    foreach (var pokemonId in value)
            //    {
            //        pokemonIds += pokemonId + ",";
            //    }
            //    if (pokemonIds != string.Empty)
            //    {
            //        pokemonIds = pokemonIds.Remove(pokemonIds.Length - 1, 1);
            //    }
            //    SetSetting(pokemonIds);
            //}
        }

        public List<PokemonId> ExcludedPokemonEvolve
        {
            get
            {
                var pokemonIdList = new List<PokemonId>();
                var pokemons = Convert.ToString(Registry.GetValue(RegPath, "ExcludedEvolve", ""));
                if (pokemons.Contains(","))
                {
                    foreach (var pokemon in pokemons.Split(','))
                    {
                        foreach (PokemonId id in Enum.GetValues(typeof(PokemonId)))
                        {
                            if (id.ToString().Equals(pokemon))
                            {
                                pokemonIdList.Add(id);
                                break;
                            }
                        }
                    }
                }
                return pokemonIdList;
            }

            //set
            //{
            //    var pokemonIds = "";
            //    foreach (var pokemonId in value)
            //    {
            //        pokemonIds += pokemonId + ",";
            //    }
            //    if (pokemonIds != string.Empty)
            //    {
            //        pokemonIds = pokemonIds.Remove(pokemonIds.Length - 1, 1);
            //    }
            //    SetSetting(pokemonIds);
            //}
        }

        public AuthType AuthType
        {
            get
            {
                if (Convert.ToInt32(Registry.GetValue(RegPath, "LoginType", 0)) == 1)
                    return AuthType.Ptc;
                else
                    return AuthType.Google;
                //return (GetSetting() != string.Empty ? GetSetting() : "PTC") == "PTC" ? AuthType.Ptc : AuthType.Google;
            }

            //set { SetSetting(value.ToString()); }
        }
        
        public double DefaultLatitude
        {
            get
            {
                return GPS_Location[0].Lat;
                //return GetSetting() != string.Empty ? double.Parse(GetSetting(), CultureInfo.InvariantCulture) : 51.22640;
            }

            //set { SetSetting(value); }
        }

        public double DefaultLongitude
        {
            get
            {
                return GPS_Location[0].Lng;
                //return GetSetting() != string.Empty ? double.Parse(GetSetting(), CultureInfo.InvariantCulture) : 6.77874;
            }

            //set { SetSetting(value); }
        }

        //public double DefaultAltitude
        //{
        //    get
        //    {
        //        return GetSetting() != string.Empty ? double.Parse(GetSetting(), CultureInfo.InvariantCulture) : 0.0;
        //    }
        //    //set { SetSetting(value); }
        //}

        string ISettings.PtcPassword
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "LoginAccount", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "password"; }
            //set { SetSetting(value); }
        }

        string ISettings.PtcUsername
        {
            get { return GetPassword; }
            //get { return GetSetting() != string.Empty ? GetSetting() : "username"; }
            //set { SetSetting(value); }
        }

        public string GoogleUsername
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "LoginAccount", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "username"; }
            //set { SetSetting(value); }
        }

        public string GooglePassword
        {
            get { return GetPassword; }
            //get { return Convert.ToString(Registry.GetValue(RegPath, "LoginPassword", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "password"; }
            //set { SetSetting(value); }
        }

        public string DeviceId
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_ID", "8525f6d8251f71b7")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "8525f6d8251f71b7"; }

            //set { SetSetting(value); }
        }

        public string AndroidBoardName
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_ABN", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "msm8994"; }

            //set { SetSetting(value); }
        }

        public string AndroidBootloader
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_AB", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "unknown"; }

            //set { SetSetting(value); }
        }

        public string DeviceBrand
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_DB", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "OnePlus"; }

            //set { SetSetting(value); }
        }

        public string DeviceModel
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_DM", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "OnePlus2"; }

            //set { SetSetting(value); }
        }

        public string DeviceModelIdentifier
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_DMI", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "ONE A2003_24_160604"; }

            //set { SetSetting(value); }
        }

        public string DeviceModelBoot
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_DMB", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "qcom"; }

            //set { SetSetting(value); }
        }

        public string HardwareManufacturer
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_HMf", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "OnePlus"; }

            //set { SetSetting(value); }
        }

        public string HardwareModel
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_HM", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "ONE A2003"; }

            //set { SetSetting(value); }
        }

        public string FirmwareBrand
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_FB", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "OnePlus2"; }

            //set { SetSetting(value); }
        }

        public string FirmwareTags
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_FTa", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "dev-keys"; }

            //set { SetSetting(value); }
        }

        public string FirmwareType
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_FTy", "")); }
            //get { return GetSetting() != string.Empty ? GetSetting() : "user"; }

            //set { SetSetting(value); }
        }

        public string FirmwareFingerprint
        {
            get { return Convert.ToString(Registry.GetValue(RegPath, "Device_FF", "")); }
            //get
            //{
            //    return GetSetting() != string.Empty
            //        ? GetSetting()
            //        : "OnePlus/OnePlus2/OnePlus2:6.0.1/MMB29M/1447840820:user/release-keys";
            //}

            //set { SetSetting(value); }
        }

        public void Reload()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }

        private string GetSetting([CallerMemberName] string key = null)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void SetSetting(string value, [CallerMemberName] string key = null)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (key != null)
            {
                configFile.AppSettings.Settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Full);
        }

        public void SetSetting(double value, [CallerMemberName] string key = null)
        {
            var customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (key != null) configFile.AppSettings.Settings[key].Value = value.ToString();
            configFile.Save(ConfigurationSaveMode.Full);
        }
    }
}