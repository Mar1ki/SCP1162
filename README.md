<div align="center">
  <h1>SCP1162 - EXILED</h1>
  <img src="https://github.com/Marikider/SCP1162/blob/main/image.png?raw=true" width="800" height="400">
</div>

# Installation
Please use Exiled [9.2.2](https://github.com/ExMod-Team/EXILED/releases/tag/v9.2.2) or above for this project

1. Download the latest release
2. Put the plugin into the `.config/EXILED/Plugins` folder

# Issues
If you have any issues, please try these following steps before creating an issue:
- Maybe your Exiled version is outdated so please try using a newer one
- Try using an older build

# Config
```yaml
Scp-1162:
  is_enabled: true
  debug: true
  # Should a user get damaged when interacting with Scp-1162 without holding an item in hand
  should_damage: true
  # How much damage should players get when using Scp-1162 without holding an item in hand
  health_minus: 25
  # The chance that the item disappears in % (set to 0 to disable)
  percent_disappearing: 30
  # What items should Scp-1162 be able to give
  items_to_give:
  - KeycardJanitor
  - KeycardZoneManager
  - KeycardScientist
  - KeycardContainmentEngineer
  - KeycardResearchCoordinator
  - KeycardMTFPrivate
  - KeycardMTFOperative
  - KeycardMTFCaptain
  - KeycardFacilityManager
  - KeycardChaosInsurgency
  - KeycardO5
  - GunCOM15
  - GunCOM18
  - Painkillers
  - Medkit
  - Adrenaline
  - SCP500
  - SCP207
  - AntiSCP207
  - GrenadeHE
  - GrenadeFlash
  - Coin
  - Flashlight
  - Radio
```

# Translation
```yaml
Scp-1162:
# Message sent when interacting with Scp-1162 without holding an item in hand
  damage_hint: '<color=red>Dont stick your Hand in unknown holes ( ͡° ͜ʖ ͡° )</color>'
  # Message sent when interacting with Scp-1162
  interaction_hint: '<i>You put an item into </i><color=yellow>SCP-1162</color><i> and got Another!</i>'
  # Message sent when the item disappears
  lost_item_hint: '<color=red>You lost your item</color>'
```

# Credit
<a href="https://github.com/Marikider"><img src="https://avatars.githubusercontent.com/u/68015763?v=4" width="50"></a>
<a href="https://github.com/Vxrpenter"><img src="https://avatars.githubusercontent.com/u/110356385?v=4" width="50"></a>
