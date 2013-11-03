using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class ItemSparseEntry
    {
        public uint Id;
        public uint Quality;
        public uint Flags;
        public uint Flags2;
        public float Unk1;
        public float Unk2;
        public uint BuyCount;
        public uint BuyPrice;
        public uint SellPrice;
        public uint InventoryType;
        public int AllowableClass;
        public int AllowableRace;
        public uint ItemLevel;
        public int RequiredLevel;
        public uint RequiredSkill;
        public uint RequiredSkillRank;
        public uint RequiredSpell;
        public uint RequiredHonorRank;
        public uint RequiredCityRank;
        public uint RequiredReputationFaction;
        public uint RequiredReputationRank;
        public uint MaxCount;
        public uint Stackable;
        public uint ContainerSlots;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 10)]
        public int[] ItemStatType;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 10)]
        public uint[] ItemStatValue;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 10)]
        public int[] ItemStatUnk1;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 10)]
        public int[] ItemStatUnk2;
        public uint ScalingStatDistribution;
        public uint DamageType;
        public uint Delay;
        public float RangedModRange;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellId;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellTrigger;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellCharges;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellCooldown;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellCategory;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 5)]
        public int[] SpellCategoryCooldown;
        public uint Bonding;
        public string Name;
        public string Name2;
        public string Name3;
        public string Name4;
        public string Description;
        public uint PageText;
        public uint LanguageID;
        public uint PageMaterial;
        public uint StartQuest;
        public uint LockID;
        public int Material;
        public uint Sheath;
        public uint RandomProperty;
        public uint RandomSuffix;
        public uint ItemSet;
        public uint Area;
        public uint Map;
        public uint BagFamily;
        public uint TotemCategory;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[] Color;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[] Content;
        public int SocketBonus;
        public uint GemProperties;
        public float ArmorDamageModifier;
        public uint Duration;
        public uint ItemLimitCategory;
        public uint HolidayId;
        public float StatScalingFactor;
        public int CurrencySubstitutionId;
        public int CurrencySubstitutionCount;
    }
}
