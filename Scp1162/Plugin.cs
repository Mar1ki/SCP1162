using System;
using Exiled.API.Features;
using SCP1162.Configs;

namespace SCP1162
{
    public class Plugin : Plugin<Config, Configs.Translations>
    {
        public override string Prefix => "Scp-1162";
        public override string Name => "Scp-1162";
        public override string Author => "Mariki";
        public override Version Version { get; } = new Version(1, 8, 0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 6, 0);
        public static Plugin Instance;
        private EventHandler _eventHandler;


        public override void OnEnabled()
        {
            Instance = this;
            _eventHandler = new EventHandler();
            Exiled.Events.Handlers.Player.PickingUpItem += _eventHandler.PickingScp1162;
            Exiled.Events.Handlers.Server.RoundStarted += _eventHandler.OnRoundStart;
            base.OnEnabled();

        }
        public override void OnDisabled()
        {
            Instance = this;
            _eventHandler = new EventHandler();
            Exiled.Events.Handlers.Player.PickingUpItem -= _eventHandler.PickingScp1162;
            Exiled.Events.Handlers.Server.RoundStarted -= _eventHandler.OnRoundStart;
            base.OnDisabled();


        }

    }

}

