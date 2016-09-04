using PokemonGo.RocketAPI.Enums;

namespace PokemonGo.RocketAPI
{
    public interface ISettings
    {
        AuthType AuthType { get; }
        double DefaultLatitude { get; }
        double DefaultLongitude { get; }
        //double DefaultAltitude { get; }
        string PtcPassword { get; }
        string PtcUsername { get; }
        string GoogleUsername { get; }
        string GooglePassword { get; }
        string DeviceId { get; }
        string AndroidBoardName { get; }
        string AndroidBootloader { get; }
        string DeviceBrand { get; }
        string DeviceModel { get; }
        string DeviceModelIdentifier { get; }
        string DeviceModelBoot { get; }
        string HardwareManufacturer { get; }
        string HardwareModel { get; }
        string FirmwareBrand { get; }
        string FirmwareTags { get; }
        string FirmwareType { get; }
        string FirmwareFingerprint { get; }
    }
}