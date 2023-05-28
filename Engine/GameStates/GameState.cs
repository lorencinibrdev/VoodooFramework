using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VoodooFramework.Engine.Input;

namespace VoodooFramework.Engine.GameStates;

public abstract class GameState
{
    protected GameState(GameWindow game)
    {
        Game = game;
    }

    public abstract bool Init();
    public abstract void CleanUp();

    public abstract void Pause();
    public abstract void Resume();
    
    public abstract void HandleEvents(InputManager inputManager);
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch, GameTime delta);
    
    //Protected Properties:
    protected GameWindow Game { get; }
}