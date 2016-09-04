using System;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Extensions;

namespace PokemonGo.RocketAPI.Window
{
    public class LocationManager
    {
        private readonly Client _client;

        public LocationManager(Client client)
        {
            _client = client;
        }
        
        public double GetDistance(double lat, double lng)
        {
            var currentLoc = new LatLong(_client.CurrentLatitude, _client.CurrentLongitude);
            return currentLoc.distanceFrom(new LatLong(lat, lng));
        }

        public async Task Update(double lat, double lng)
        {
            double waitTime = GetDistance(lat, lng) / (Convert.ToDouble(Settings.Instance.TravelSpeed) / 3600.0);
            int RunCount = (int)waitTime / (int)(Settings.Instance.DelayWalk * 1000.0);
            double[] RunLocation = { (_client.CurrentLatitude - lat) / RunCount, (_client.CurrentLongitude - lng) / RunCount };
            await Task.Delay((int)(Settings.Instance.DelayWalk * 1000.0));
            if (RunCount > 0) await _client.Player.UpdatePlayerLocation(_client.CurrentLatitude - RunLocation[0], _client.CurrentLongitude - RunLocation[1]);
            else await _client.Player.UpdatePlayerLocation(lat, lng);
        }
    }
}