using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API.Features;
using InventorySystem;
using InventorySystem.Items;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using Utf8Json.Formatters;


namespace SCP1162
{
    public class EventHandler
    {
        private ushort _scp1162;

        private static Vector3 GetGlobalCords(Vector3 localCords, Room room)
        {
            var rotation = room.Rotation;
            if (Math.Abs(rotation.eulerAngles.y - 0.0f) < 1.0)
                return new Vector3(room.Position.x + localCords.x, room.Position.y + localCords.y, room.Position.z + localCords.z);
            if (Math.Abs(rotation.eulerAngles.y - 90f) < 1.0)
                return new Vector3(room.Position.x + localCords.z, room.Position.y + localCords.y, room.Position.z - localCords.x);
           
            if (Math.Abs(rotation.eulerAngles.y - 180f) < 1.0)
                return new Vector3(room.Position.x - localCords.x, room.Position.y + localCords.y, room.Position.z - localCords.z);
            return Math.Abs((rotation).eulerAngles.y - 270f) < 1.0 ? new Vector3(room.Position.x - localCords.z, room.Position.y + localCords.y, room.Position.z + localCords.x) : new Vector3(111f, 222f, 333f);
        }
        
        private void SpawnScp1162()
        {
            var localPos = new Vector3(17f, 13.1f, 3f);
            var rot= new Vector3(90f, 1f, 0.0f);
            var room = Room.Get(RoomType.Lcz173);
            var globalCords = GetGlobalCords(localPos, room);
            var rotation = room.Rotation;
            var quaternion = Quaternion.Euler(rot.x, rotation.eulerAngles.y + rot.y, rot.z);
            var scp1162Pick = Pickup.CreateAndSpawn(ItemType.SCP500, globalCords, quaternion);
            scp1162Pick.Rigidbody.useGravity = false;
            scp1162Pick.Rigidbody.detectCollisions = false;
            scp1162Pick.Scale = new Vector3(10,10,10);
            _scp1162 = scp1162Pick.Serial;
        }
        public bool CalculatePercent(int chance)
        {
            int num = Random.Range(0, 100);
            if (num <= chance)
            {
                return true;
            }
            return false;
        }
        public void OnRoundStart()
        {
            if (CalculatePercent(Plugin.Instance.Config.PercentSpawn))
            {
                SpawnScp1162();
            }
        }

        private static void GiveItem(Player player)
        {
            var items = Plugin.Instance.Config.ItemsToGive.Select(itemType => Item.Create(itemType)).ToList();
            
            player.ShowHint(Plugin.Instance.Translation.InteractionHint,20);
            player.RemoveHeldItem();
            player.CurrentItem = null;
            
            Timing.CallDelayed(0.1f, () => player.CurrentItem = items.RandomItem());
        }
        public void PickingScp1162(PickingUpItemEventArgs ev)
        {
            if (_scp1162 != ev.Pickup.Serial) return;
            var percentDisappearing = Plugin.Instance.Config.PercentDisappearing;
            if (ev.Player.CurrentItem != null)
            {
                if (percentDisappearing == 0) GiveItem(ev.Player);
                else
                {
                    if (Random.Range(0f, 100f) > percentDisappearing) GiveItem(ev.Player);
                    else
                    {
                        ev.Player.RemoveHeldItem();
                        ev.Player.ShowHint(Plugin.Instance.Translation.LostItemHint, 10);
                    }
                }
            }
            else
            {
                if (Plugin.Instance.Config.HealthMinus != 0)
                {
                    ev.Player.Hurt(Plugin.Instance.Config.HealthMinus, DamageType.Custom);
                    ev.Player.EnableEffect(EffectType.Burned, 3);
                    ev.Player.ShowHint(Plugin.Instance.Translation.DamageHint, 15);
                }

            }
            ev.IsAllowed = false;
        }
    }
}
