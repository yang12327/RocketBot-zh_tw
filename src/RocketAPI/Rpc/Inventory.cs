using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;

namespace PokemonGo.RocketAPI.Rpc
{
    public class Inventory : BaseRpc
    {
        public Inventory(Client client) : base(client)
        {
        }

        public async Task<ReleasePokemonResponse> TransferPokemon(ulong pokemonId)
        {
            var message = new ReleasePokemonMessage
            {
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, ReleasePokemonResponse>(RequestType.ReleasePokemon, message);
        }

        public async Task<EvolvePokemonResponse> EvolvePokemon(ulong pokemonId)
        {
            var message = new EvolvePokemonMessage
            {
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, EvolvePokemonResponse>(RequestType.EvolvePokemon, message);
        }

        public async Task<UpgradePokemonResponse> UpgradePokemon(ulong pokemonId)
        {
            var message = new UpgradePokemonMessage()
            {
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, UpgradePokemonResponse>(RequestType.UpgradePokemon, message);
        }

        public async Task<GetInventoryResponse> GetInventory()
        {
            return await PostProtoPayload<Request, GetInventoryResponse>(RequestType.GetInventory, new GetInventoryMessage());
        }

        public async Task<RecycleInventoryItemResponse> RecycleItem(ItemId itemId, int amount)
        {
            var message = new RecycleInventoryItemMessage
            {
                ItemId = itemId,
                Count = amount
            };
            
            return await PostProtoPayload<Request, RecycleInventoryItemResponse>(RequestType.RecycleInventoryItem, message);
        }

        public async Task<UseItemXpBoostResponse> UseItemXpBoost()
        {
            var message = new UseItemXpBoostMessage()
            {
                ItemId = ItemId.ItemLuckyEgg
            };
            
            return await PostProtoPayload<Request, UseItemXpBoostResponse>(RequestType.UseItemXpBoost, message);
        }

        public async Task<UseItemEggIncubatorResponse> UseItemEggIncubator(string itemId, ulong pokemonId)
        {
            var message = new UseItemEggIncubatorMessage()
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, UseItemEggIncubatorResponse>(RequestType.UseItemEggIncubator, message);
        }

        public async Task<GetHatchedEggsResponse> GetHatchedEgg()
        {
            return await PostProtoPayload<Request, GetHatchedEggsResponse>(RequestType.GetHatchedEggs, new GetHatchedEggsMessage());
        }

        public async Task<UseItem藥水Response> UseItem藥水(ItemId itemId, ulong pokemonId)
        {
            var message = new UseItem藥水Message()
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, UseItem藥水Response>(RequestType.UseItem藥水, message);
        }

        public async Task<UseItemEggIncubatorResponse> UseItem復活石(ItemId itemId, ulong pokemonId)
        {
            var message = new UseItem復活石Message()
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return await PostProtoPayload<Request, UseItemEggIncubatorResponse>(RequestType.UseItemEggIncubator, message);
        }

        public async Task<UseIncenseResponse> UseIncense(ItemId incenseType)
        {
            var message = new UseIncenseMessage()
            {
                IncenseType = incenseType
            };

            return await PostProtoPayload<Request, UseIncenseResponse>(RequestType.UseIncense, message);
        }

        public async Task<UseItemGymResponse> UseItemInGym(string gymId, ItemId itemId)
        {
            var message = new UseItemGymMessage()
            {
                ItemId = itemId,
                GymId = gymId,
                PlayerLatitude = _client.CurrentLatitude,
                PlayerLongitude = _client.CurrentLongitude
            };

            return await PostProtoPayload<Request, UseItemGymResponse>(RequestType.UseItemGym, message);
        }

        public async Task<NicknamePokemonResponse> NicknamePokemon(ulong pokemonId, string nickName)
        {
            var message = new NicknamePokemonMessage()
            {
                PokemonId = pokemonId,
                Nickname = nickName
            };

            return await PostProtoPayload<Request, NicknamePokemonResponse>(RequestType.NicknamePokemon, message);
        }

        public async Task<SetFavoritePokemonResponse> SetFavoritePokemon(ulong pokemonId, bool isFavorite)
        {
            var message = new SetFavoritePokemonMessage()
            {
                PokemonId = pokemonId,
                IsFavorite = isFavorite
            };

            return await PostProtoPayload<Request, SetFavoritePokemonResponse>(RequestType.SetFavoritePokemon, message);
        }
    }
}