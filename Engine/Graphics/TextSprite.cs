using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VoodooFramework.Engine.Graphics;

public class TextSprite : Drawable
{
    public override void Draw(SpriteBatch spriteBatch, GameTime delta)
    {
        spriteBatch.DrawString(Font, Text, Position, Color, Rotation, Origin, Scale, Effects, Depth);
    }
    
    //Public Properties:
    public SpriteFont Font { get; set; }
    public string Text { get; set; } = "DEBUG_TEXT";
}