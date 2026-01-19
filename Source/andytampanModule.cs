using Celeste;
using Celeste.Mod.andytampan.Entities;
using Microsoft.Xna.Framework;
using MonoMod.Utils;
using System;
using static Celeste.GaussianBlur;
using static Celeste.Mod.andytampan.Entities.DirectionBooster;
using static MonoMod.InlineRT.MonoModRule;

namespace Celeste.Mod.andytampan;

public class andytampanModule : EverestModule {
    public static andytampanModule Instance { get; private set; }

    public override Type SettingsType => typeof(andytampanModuleSettings);
    public static andytampanModuleSettings Settings => (andytampanModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(andytampanModuleSession);
    public static andytampanModuleSession Session => (andytampanModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(andytampanModuleSaveData);
    public static andytampanModuleSaveData SaveData => (andytampanModuleSaveData) Instance._SaveData;

    public andytampanModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(andytampanModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(andytampanModule), LogLevel.Info);
#endif
    }

    public override void Load() {
        // TODO: apply any hooks that should always be active
        On.Celeste.Booster.PlayerBoosted += Booster_PlayerBoosted;
    }

    private void Booster_PlayerBoosted(On.Celeste.Booster.orig_PlayerBoosted orig, Booster self, Player player, Vector2 direction)
    {
        orig(self, player, direction);
        if (self is DirectionBooster)
        {
            if (self is DirectionBooster dBooster)
            {
                if (dBooster.boosterDir == BoosterDirection.up)
                {
                    var xSpeed = 0f;
                    var ySpeed = -240f;
                    player.Speed = new (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.upright)
                {
                    var xSpeed = 160f;
                    var ySpeed = -160f;
                    player.Speed = new  (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.right)
                {
                    var xSpeed = 240f;
                    var ySpeed = 0f;
                    player.Speed = new  (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.downright)
                {
                    var xSpeed = 160f;
                    var ySpeed = 160f;
                    player.Speed = new  (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.down)
                {
                    var xSpeed = 0f;
                    var ySpeed = 160f;
                    player.Speed = new  (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.downleft)
                {
                    var xSpeed = -160f;
                    var ySpeed = 160f;
                    player.Speed = new  (xSpeed, ySpeed);
                    player.DashDir = new  (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.left)
                {
                    var xSpeed = -240f;
                    var ySpeed = 0f;
                    player.Speed = new (xSpeed, ySpeed);
                    player.DashDir = new (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.upleft)
                {
                    var xSpeed = -160f;
                    var ySpeed = -160f;
                    player.Speed = new (xSpeed, ySpeed);
                    player.DashDir = new (Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
            }
        }
    }
    public override void Unload() {
    }
}