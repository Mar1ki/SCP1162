﻿using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCP1162
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
            ItemType.KeycardO5,
            ItemType.SCP500,
            ItemType.KeycardMTFOperative,
            ItemType.GunCOM15,
            ItemType.SCP207,
            ItemType.Adrenaline,
            ItemType.GunCOM18,
            ItemType.KeycardFacilityManager,
            ItemType.Medkit,
            ItemType.KeycardMTFCaptain,
            ItemType.KeycardGuard,
            ItemType.GrenadeHE,
            ItemType.KeycardZoneManager,
            ItemType.KeycardGuard,
            ItemType.Radio,
            ItemType.GrenadeFlash,
            ItemType.KeycardScientist,
            ItemType.KeycardJanitor,
            ItemType.Coin,
            ItemType.Flashlight
        };

    }
}