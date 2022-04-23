using System;
using Assets._Scripts.Dissonance;
using CommandSystem.Commands.RemoteAdmin.Doors;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using Player = Exiled.Events.Handlers.Player;

namespace LifeForMoreStamina
{
    public class LifeForMoreStamina : Plugin<PluginConfig>
    {
        public override string Author => "Memw#6969";
        public override string Name => "LifeForMoreStamina";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.ChangingMoveState += PlayerRunning;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingMoveState -= PlayerRunning;
            base.OnDisabled();
        }

        private void PlayerRunning(ChangingMoveStateEventArgs ev)
        {
            if (ev.NewState != PlayerMovementState.Walking) return;
            if (!(ev.Player.Stamina.RemainingStamina <= 0.015f)) return;
            ev.Player.Stamina.RemainingStamina = 0.050f;
            ev.Player.Health--;
            ev.NewState = PlayerMovementState.Sprinting;
        }
    }
}