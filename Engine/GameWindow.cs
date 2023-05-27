using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
    }

    protected override void Draw(GameTime gameTime)
    {
        //Clearing the screen:
        GraphicsDevice.Clear(ClearScreenColor);
    }
    
    //Public Properties:
    public Color ClearScreenColor { get; set; } = Color.Black;
}