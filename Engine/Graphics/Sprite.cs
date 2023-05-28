using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoodooFramework.Engine.Graphics;

public class Sprite : Drawable
{
    public override void Draw(SpriteBatch spriteBatch, GameTime delta)
    {
        spriteBatch.Draw(Texture, TextureRect, null, Color, Rotation, Origin, Effects, Depth);
    }
    
    //Public Properties:
    public Texture2D Texture { get; set; }
    public Rectangle TextureRect { get; set; }
}