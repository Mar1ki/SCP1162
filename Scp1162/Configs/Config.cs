﻿using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP1162.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        [Description("Should a user get damaged when interacting with Scp-1162 without holding an item in hand")]
        public bool ShouldDamage { get; set; } = true;
        [Description("Minimum Health to use Scp-1162")]
        public int HealthMinus { get; set; } = 25;
        [Description("The chance that the item disappears in % (set to 0 to disable)")]
        public float PercentDisappearing { get; set; } = 30;
        [Description("What items should Scp-1162 be able to give")]
        public List<ItemType> ItemsToGive { get; set; } = new List<ItemType>
        {
            ItemType.KeycardJanitor,
            ItemType.KeycardZoneManager,
            ItemType.KeycardScientist,
            ItemType.KeycardContainmentEngineer,
            ItemType.KeycardResearchCoordinator,
            ItemType.KeycardMTFPrivate,
            ItemType.KeycardMTFOperative,
            ItemType.KeycardMTFCaptain,
            ItemType.KeycardFacilityManager,
            ItemType.KeycardChaosInsurgency,
            ItemType.KeycardO5,
            ItemType.GunCOM15,
            ItemType.GunCOM18,
            ItemType.Painkillers,
            ItemType.Medkit,
            ItemType.Adrenaline,
            ItemType.SCP500,
            ItemType.SCP207,
            ItemType.AntiSCP207,
            ItemType.GrenadeHE,
            ItemType.GrenadeFlash,
            ItemType.Coin,
            ItemType.Flashlight,
            ItemType.Radio,
        };

    }
}
