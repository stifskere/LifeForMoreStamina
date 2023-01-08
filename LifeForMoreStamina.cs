using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace LifeForMoreStamina
{
    public class LifeForMoreStamina : Plugin<PluginConfig>
    {
        public override string Author => "Memw#6969";
        public override string Name => "LifeForMoreStamina";
        public override Version Version => new Version(1, 3, 0);

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
            if (ev.Player.Role.Side == Side.Scp) return;
            if (!(ev.Player.Stamina <= 0.025f)) return;
            ev.Player.Stamina = Convert.ToSingle(Config.StaminaAdded);
            ev.Player.Health -= Config.HpRemoved;
        }
    }
}
