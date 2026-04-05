using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.andytampan.Entities;

[CustomEntity("andytampan/KillRefill")]
public class KillRefill : Refill
{
    public KillRefill(EntityData data, Vector2 offset) : base(data.Position + offset, false, true)
    {
        sprite.Path = "objects/andytampan/refill/kill/idle";
        sprite.Stop();
        sprite.ClearAnimations();
        sprite.AddLoop("idle", "", 0.1f);
        sprite.Play("idle");

        flash.Path = "objects/andytampan/refill/kill/flash";
        flash.ClearAnimations();
        flash.Add("flash", "", 0.05f);

        p_glow = new ParticleType(P_Glow)
        {
            Color = Calc.HexToColor("#E75555"),
            Color2 = Calc.HexToColor("#B71A1A")
        };
        p_regen = new ParticleType(P_Regen)
        {
            Color = Calc.HexToColor("#E75555"),
            Color2 = Calc.HexToColor("#B71A1A")
        };
        p_shatter = new ParticleType(P_Shatter)
        {
            Color = Calc.HexToColor("#E75555"),
            Color2 = Calc.HexToColor("#B71A1A")
        };

    }
    public override void Update()
    {
        base.Update();
        if (Collidable == false)
        {
            if (Scene.Tracker.GetEntity<Player>() is Player player)
            {
                player.Die(new Vector2(0.0f, -1f), false, true);
            }
        }
    }

}