﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VoodooFramework.Engine.GameStates;
using VoodooFramework.Engine.Input;

namespace VoodooFramework.Engine;

public class GameWindow : Game
{
    //Private Members:
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public GameWindow()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        //TODO: Read all this from a configuration file in the game's folder, or create a default one in case it does not exists.
        //Setting some default graphics properties:
        _graphics.PreferredBackBufferWidth = 1980;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.IsFullScreen = false;
        _graphics.SynchronizeWithVerticalRetrace = true;
        _graphics.ApplyChanges();
        
        //Setting some window properties:
        IsMouseVisible = true;
        Window.Title = "Awesome Game";

        base.Initialize();
    }

    protected override void LoadContent()
    {
        //The spritebatch that will be used for drawing:
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        //Checking for Exit:
        if (InputManager.IsExitRequested())
            Exit();
        
        //Updating the input system:
        InputManager.Update(gameTime);
        GameStateManager.HandleEvents(InputManager);
        
        //Updating the game state:
        GameStateManager.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //Clearing the screen:
        GraphicsDevice.Clear(ClearScreenColor);
        
        //Drawing the game state:
        GameStateManager.Draw(_spriteBatch, gameTime);
    }
    
    //Public Properties:
    public Color ClearScreenColor { get; set; } = Color.Black;
    
    //Public Managers:
    public GameStateManager GameStateManager { get; } = new();
    public InputManager InputManager { get; } = new();
}