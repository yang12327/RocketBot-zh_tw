// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: POGOProtos/Inventory/Item/ItemId.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace POGOProtos.Inventory.Item {

  /// <summary>Holder for reflection information generated from POGOProtos/Inventory/Item/ItemId.proto</summary>
  public static partial class ItemIdReflection {

    #region Descriptor
    /// <summary>File descriptor for POGOProtos/Inventory/Item/ItemId.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ItemIdReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiZQT0dPUHJvdG9zL0ludmVudG9yeS9JdGVtL0l0ZW1JZC5wcm90bxIZUE9H",
            "T1Byb3Rvcy5JbnZlbnRvcnkuSXRlbSrHBQoGSXRlbUlkEhAKDElURU1fVU5L",
            "Tk9XThAAEhIKDklURU1fUE9LRV9CQUxMEAESEwoPSVRFTV9HUkVBVF9CQUxM",
            "EAISEwoPSVRFTV9VTFRSQV9CQUxMEAMSFAoQSVRFTV9NQVNURVJfQkFMTBAE",
            "Eg8KC0lURU1fUE9USU9OEGUSFQoRSVRFTV9TVVBFUl9QT1RJT04QZhIVChFJ",
            "VEVNX0hZUEVSX1BPVElPThBnEhMKD0lURU1fTUFYX1BPVElPThBoEhAKC0lU",
            "RU1fUkVWSVZFEMkBEhQKD0lURU1fTUFYX1JFVklWRRDKARITCg5JVEVNX0xV",
            "Q0tZX0VHRxCtAhIaChVJVEVNX0lOQ0VOU0VfT1JESU5BUlkQkQMSFwoSSVRF",
            "TV9JTkNFTlNFX1NQSUNZEJIDEhYKEUlURU1fSU5DRU5TRV9DT09MEJMDEhgK",
            "E0lURU1fSU5DRU5TRV9GTE9SQUwQlAMSEwoOSVRFTV9UUk9ZX0RJU0sQ9QMS",
            "EgoNSVRFTV9YX0FUVEFDSxDaBBITCg5JVEVNX1hfREVGRU5TRRDbBBITCg5J",
            "VEVNX1hfTUlSQUNMRRDcBBIUCg9JVEVNX1JBWlpfQkVSUlkQvQUSFAoPSVRF",
            "TV9CTFVLX0JFUlJZEL4FEhUKEElURU1fTkFOQUJfQkVSUlkQvwUSFQoQSVRF",
            "TV9XRVBBUl9CRVJSWRDABRIVChBJVEVNX1BJTkFQX0JFUlJZEMEFEhgKE0lU",
            "RU1fU1BFQ0lBTF9DQU1FUkEQoQYSIwoeSVRFTV9JTkNVQkFUT1JfQkFTSUNf",
            "VU5MSU1JVEVEEIUHEhkKFElURU1fSU5DVUJBVE9SX0JBU0lDEIYHEiEKHElU",
            "RU1fUE9LRU1PTl9TVE9SQUdFX1VQR1JBREUQ6QcSHgoZSVRFTV9JVEVNX1NU",
            "T1JBR0VfVVBHUkFERRDqB2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::POGOProtos.Inventory.Item.ItemId), }, null));
    }
    #endregion

  }
  #region Enums
  public enum ItemId {
    [pbr::OriginalName("ITEM_UNKNOWN")] ItemUnknown = 0,
    [pbr::OriginalName("ITEM_POKE_BALL")] Item�_���y = 1,
    [pbr::OriginalName("ITEM_GREAT_BALL")] Item���Ųy = 2,
    [pbr::OriginalName("ITEM_ULTRA_BALL")] Item�W�Ųy = 3,
    [pbr::OriginalName("ITEM_MASTER_BALL")] Item���Ųy = 4,
    [pbr::OriginalName("ITEM_POTION")] Item�Ĥ� = 101,
    [pbr::OriginalName("ITEM_SUPER_POTION")] Item�j���Ĥ� = 102,
    [pbr::OriginalName("ITEM_HYPER_POTION")] Item�W���Ĥ� = 103,
    [pbr::OriginalName("ITEM_MAX_POTION")] Item�����Ĥ� = 104,
    [pbr::OriginalName("ITEM_REVIVE")] Item�_���� = 201,
    [pbr::OriginalName("ITEM_MAX_REVIVE")] Item���Ŵ_���� = 202,
    [pbr::OriginalName("ITEM_LUCKY_EGG")] ItemLuckyEgg = 301,
    [pbr::OriginalName("ITEM_INCENSE_ORDINARY")] ItemIncenseOrdinary = 401,
    [pbr::OriginalName("ITEM_INCENSE_SPICY")] ItemIncenseSpicy = 402,
    [pbr::OriginalName("ITEM_INCENSE_COOL")] ItemIncenseCool = 403,
    [pbr::OriginalName("ITEM_INCENSE_FLORAL")] ItemIncenseFloral = 404,
    [pbr::OriginalName("ITEM_TROY_DISK")] ItemTroyDisk = 501,
    [pbr::OriginalName("ITEM_X_ATTACK")] ItemXAttack = 602,
    [pbr::OriginalName("ITEM_X_DEFENSE")] ItemXDefense = 603,
    [pbr::OriginalName("ITEM_X_MIRACLE")] ItemXMiracle = 604,
    [pbr::OriginalName("ITEM_RAZZ_BERRY")] Item���G = 701,
    [pbr::OriginalName("ITEM_BLUK_BERRY")] ItemBlukBerry = 702,
    [pbr::OriginalName("ITEM_NANAB_BERRY")] ItemNanabBerry = 703,
    [pbr::OriginalName("ITEM_WEPAR_BERRY")] ItemWeparBerry = 704,
    [pbr::OriginalName("ITEM_PINAP_BERRY")] ItemPinapBerry = 705,
    [pbr::OriginalName("ITEM_SPECIAL_CAMERA")] ItemSpecialCamera = 801,
    [pbr::OriginalName("ITEM_INCUBATOR_BASIC_UNLIMITED")] ItemIncubatorBasicUnlimited = 901,
    [pbr::OriginalName("ITEM_INCUBATOR_BASIC")] ItemIncubatorBasic = 902,
    [pbr::OriginalName("ITEM_POKEMON_STORAGE_UPGRADE")] ItemPokemonStorageUpgrade = 1001,
    [pbr::OriginalName("ITEM_ITEM_STORAGE_UPGRADE")] ItemItemStorageUpgrade = 1002,
  }

  #endregion

}

#endregion Designer generated code
