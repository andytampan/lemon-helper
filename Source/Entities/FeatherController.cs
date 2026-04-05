using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using Monocle;

namespace Celeste.Mod.andytampan.Entities
{
    [CustomEntity("andytampan/FeatherController")]

    [Tracked]
public class FeatherController : Entity 
{
        public float length;
        public float refill;
        public bool additive;
        public float cap;
        public bool available;
        public FeatherController(EntityData data, Vector2 offset) : base(data.Position + offset)
        {

            length = data.Float("length");
            refill = data.Float("refill");
            additive = data.Bool("additive");
            cap = data.Float("cap");
        }
    }

}
