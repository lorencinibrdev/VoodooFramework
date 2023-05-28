using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoodooFramework.Engine.Graphics;

public abstract class Drawable
{
    public abstract void Draw(SpriteBatch spriteBatch, GameTime delta);

    //Public Properties:
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;
    public Color Color { get; set; } = Color.White;
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;
    public float Rotation { get; set; } = 0f;
    public float Depth { get; set; } = 0f;
}