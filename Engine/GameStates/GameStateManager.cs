using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VoodooFramework.Engine.Input;

namespace VoodooFramework.Engine.GameStates;

public class GameStateManager
{
    //Private Members:
    private readonly Stack<GameState> _loadedStates = new();

    public void ChangeState(GameState state)
    {
        //Removing all current states:
        while (_loadedStates.Count > 0) 
            _loadedStates.Pop().CleanUp();

        //Initializing the new state:
        if (!state.Init())
            throw new Exception("FATAL: Failed to initialize the requested GameState. Exiting.");
        
        //Saving:
        _loadedStates.Push(state);
    }

    public void HandleEvents(InputManager inputManager)
    {
        _loadedStates.Peek().HandleEvents(inputManager);
    }
    
    public void Update(GameTime gameTime)
    {
        _loadedStates.Peek().Update(gameTime);
    }
    
    public void Draw(SpriteBatch spriteBatch, GameTime delta)
    {
        _loadedStates.Peek().Draw(spriteBatch, delta);
    }
}