using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs;

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
            ev.NewState = PlayerMovementState.Sprinting;
            if (!(ev.Player.Stamina.RemainingStamina <= 0.025f)) return;
            ev.Player.Stamina.RemainingStamina = 0.050f;
            ev.Player.Health -= Config.HpRemoved;
            ev.NewState = PlayerMovementState.Sprinting;
        }
    }
}
