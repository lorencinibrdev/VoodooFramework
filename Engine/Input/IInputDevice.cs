using Microsoft.Xna.Framework;

namespace VoodooFramework.Engine.Input;

//TODO: Add some kind of event callback system, for registering function on specific key events.

public interface IInputDevice
{
    /// <summary>
    /// Resets the Input device's key mappings to the engine´s defaults.
    /// </summary>
    void Reset();

    /// <summary>
    /// Saves a Key mapping for a given GameKey (Customizable) and a DeviceKey
    /// </summary>
    /// <param name="gameKey">The customized GameKey</param>
    /// <param name="deviceKey">The Device's related key, from Monogame</param>
    void SetKeyMap(Enum gameKey, Enum deviceKey);

    /// <summary>
    /// Updates the internals of the Input Device.
    /// </summary>
    /// <param name="gameTime">The elapsed GameTime parameter from the engine</param>
    void Update(GameTime gameTime);

    /// <summary>
    /// Checks if a given key was pressed in the last frame.
    /// </summary>
    /// <param name="gameKey">The customized GameKey</param>
    /// <returns>True if key was pressed in the last frame, False otherwise.</returns>
    bool IsKeyPressed(Enum gameKey);
    
    /// <summary>
    /// Checks if a given key is being held down for more than two frames.
    /// </summary>
    /// <param name="gameKey">The customized GameKey</param>
    /// <returns>True if key was pressed in the last frame, and is still pressed in the current frame, false otherwise.</returns>
    bool IsKeyHeldDown(Enum gameKey);
    
    /// <summary>
    /// Checks if ANY key is pressed in on the entire mapping for this Input Device.
    /// </summary>
    /// <returns>True if ANY key is currently pressed, false otherwise.</returns>
    bool IsAnyKeyPressed();
    
    //Public Properties:
    public EInputDevices DeviceId { get; }
    public Enum ExitKey { get; init; }
}