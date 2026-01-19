using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.andytampan.Entities;

[CustomEntity("andytampan/KillRefill")]
public class KillRefill : Refill {
    public KillRefill(EntityData data, Vector2 offset): base(data.Position + offset, false, true) {

    }
    public override void Update()
    {
        base.Update();
        if (Collidable == false)
        {
            if (Scene.Tracker.GetEntity<Player>() is Player player)
            {
                player.Die(new Vector2(0.0f, -1f), false,true);
            }
        }
    }

}