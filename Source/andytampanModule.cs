using Celeste.Mod.andytampan.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using System;
using System.Linq;
using static Celeste.Mod.andytampan.Entities.DirectionBooster;

namespace Celeste.Mod.andytampan;

public class andytampanModule : EverestModule
{
    public static andytampanModule Instance { get; private set; }

    public override Type SettingsType => typeof(andytampanModuleSettings);
    public static andytampanModuleSettings Settings => (andytampanModuleSettings)Instance._Settings;

    public override Type SessionType => typeof(andytampanModuleSession);
    public static andytampanModuleSession Session => (andytampanModuleSession)Instance._Session;

    public override Type SaveDataType => typeof(andytampanModuleSaveData);
    public static andytampanModuleSaveData SaveData => (andytampanModuleSaveData)Instance._SaveData;

    public andytampanModule()
    {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(andytampanModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(andytampanModule), LogLevel.Info);
#endif
    }

    public override void Load()
    {
        // TODO: apply any hooks that should always be active
        On.Celeste.Booster.PlayerBoosted += Booster_PlayerBoosted;
        On.Celeste.FlyFeather.OnPlayer += FlyFeather_OnPlayer;
        On.Celeste.Player.RefillDash += Player_RefillDash;
        On.Celeste.Player.StarFlyBegin += Player_StarFlyBegin;
    }

    private static void Booster_PlayerBoosted(On.Celeste.Booster.orig_PlayerBoosted orig, Booster self, Player player, Vector2 direction)
    {
        orig(self, player, direction);
        if (self is DirectionBooster)
        {
            if (self is DirectionBooster dBooster)
            {
                /*  if (dBooster.boosterDir == BoosterDirection.up)
                {
                    var xSpeed = 0f;
                    var ySpeed = -240f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.upright)
                {
                    var xSpeed = 160f;
                    var ySpeed = -160f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.right)
                {
                    var xSpeed = 240f;
                    var ySpeed = 0f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.downright)
                {
                    var xSpeed = 160f;
                    var ySpeed = 160f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.down)
                {
                    var xSpeed = 0f;
                    var ySpeed = 240f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.downleft)
                {
                    var xSpeed = -160f;
                    var ySpeed = 160f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.left)
                {
                    var xSpeed = -240f;
                    var ySpeed = 0f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Math.Sign(xSpeed), Math.Sign(ySpeed));
                }
                else if (dBooster.boosterDir == BoosterDirection.upleft)
                {
                    var xSpeed = -160f;
                    var ySpeed = -160f;
                    player.Speed = new(xSpeed, ySpeed);
                    player.DashDir = new(Masth.Sign(xSpeed), Math.Sign(ySpeed));
                } */
                BoosterDirection[] left = 
                {
                    BoosterDirection.downleft,
                    BoosterDirection.left,
                    BoosterDirection.upleft
                };
                BoosterDirection[] right =
                [
                    BoosterDirection.downright,
                    BoosterDirection.right,
                    BoosterDirection.upright
                ];
                BoosterDirection[] up = 
                {
                    BoosterDirection.upleft,
                    BoosterDirection.up,
                    BoosterDirection.upright
                };
                BoosterDirection[] down = 
                {
                    BoosterDirection.downleft,
                    BoosterDirection.down,
                    BoosterDirection.downright
                };
                var xDirection = 0;
                var yDirection = 0;
                if (left.Contains(dBooster.boosterDir))
                {
                    xDirection = -1;
                }
                else if (right.Contains(dBooster.boosterDir))
                {
                    xDirection = 1;
                }
                if (down.Contains(dBooster.boosterDir))
                {
                    yDirection = 1;
                }
                else if (up.Contains(dBooster.boosterDir))
                {
                    yDirection = -1;
                }
                player.DashDir = new(xDirection, yDirection);
                player.DashDir.Normalize();
                player.Speed = player.DashDir * 240;

            }
        }
    }


    private static bool Player_RefillDash(On.Celeste.Player.orig_RefillDash orig, Player self)
    {

        if (self.Scene.Tracker.GetEntity<FeatherController>() is FeatherController feather)
            if (self.StateMachine == 19 & self.starFlyTransforming == false & feather.available)
            {
                self.starFlyTimer = feather.length;
                feather.available = false;
            }
        return orig(self);

    }

    private static void Player_StarFlyBegin(On.Celeste.Player.orig_StarFlyBegin orig, Player self)
    {

        if (self.Scene.Tracker.GetEntity<FeatherController>() is FeatherController feather)
            if (self.StateMachine == 19 & self.starFlyTransforming == false & feather.available)
            { 
                self.starFlyTimer = feather.length;
                feather.available = false;
            }
        orig(self);

    }

    private static void FlyFeather_OnPlayer(On.Celeste.FlyFeather.orig_OnPlayer orig, FlyFeather self, Player player)
    {
        orig(self, player);
        if (player.Scene.Tracker.GetEntity<FeatherController>() is FeatherController feather)
        {
            feather.available = true;
            if (player.StateMachine == 19)
                if (feather.additive == true)
                {
                    player.starFlyTimer = feather.refill + player.starFlyTimer;
                    if (player.starFlyTimer > feather.cap & feather.cap > 0) 
                    {
                        player.starFlyTimer = feather.cap;
                    }
                }

                else
                {
                    player.starFlyTimer = feather.refill;
                }
        }


    }

    public override void Unload()
    {
        On.Celeste.Booster.PlayerBoosted -= Booster_PlayerBoosted;
        On.Celeste.FlyFeather.OnPlayer -= FlyFeather_OnPlayer;
        On.Celeste.Player.RefillDash -= Player_RefillDash;
        On.Celeste.Player.StarFlyBegin -= Player_StarFlyBegin;

    }

}