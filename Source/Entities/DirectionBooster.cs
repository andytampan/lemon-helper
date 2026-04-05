using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.andytampan.Entities;

[CustomEntity("andytampan/DirectionBooster")]
public class DirectionBooster : Booster
{
    public enum BoosterDirection
    {
        up,
        upright,
        right,
        downright,
        down,
        downleft,
        left,
        upleft,
    };
    public BoosterDirection boosterDir;
    public DirectionBooster(EntityData data, Vector2 offset) : base(data.Position + offset, data.Bool("red"))
    {
        boosterDir = data.Enum<BoosterDirection>("direction");
        bool arrow = data.Bool("arrow");
        if (arrow == true)
        {
            if (boosterDir == BoosterDirection.right)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowHorizontal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowHorizontal"));
            }
            if (boosterDir == BoosterDirection.left)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowHorizontal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowHorizontal"));
                sprite2.Rotation = MathHelper.Pi * 1;
            }
            if (boosterDir == BoosterDirection.up)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowHorizontal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowHorizontal"));
                sprite2.Rotation = MathHelper.Pi * 1.5f;
            }
            if (boosterDir == BoosterDirection.down)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowHorizontal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowHorizontal"));
                sprite2.Rotation = MathHelper.Pi * 0.5f;
            }
            if (boosterDir == BoosterDirection.upright)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowDiagonal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowDiagonal"));
            }
            if (boosterDir == BoosterDirection.downright)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowDiagonal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowDiagonal"));
                sprite2.Rotation = MathHelper.Pi * 0.5f;
            }
            if (boosterDir == BoosterDirection.downleft)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowDiagonal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowDiagonal"));
                sprite2.Rotation = MathHelper.Pi * 1f;
            }
            if (boosterDir == BoosterDirection.upleft)
            {
                Sprite sprite2;
                Add(sprite2 = new Sprite(GFX.Game, "objects/andytampan/directionBooster/arrowDiagonal"));
                Add(sprite2 = GFX.SpriteBank.Create("arrowDiagonal"));
                sprite2.Rotation = MathHelper.Pi * 1.5f;
            }
        }
        ;
    }
}