using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VoodooFramework.Engine.Input;

/// <summary>
/// This class handles the inputs from the Keyboard only (Mouse is currently ignored).
/// </summary>
public class KeyboardInputDevice : IInputDevice
{
    //Private Members:
    private readonly Dictionary<Enum, Keys> _keyMappings = new();
    private KeyboardState _previousKeyboardState = Keyboard.GetState();
    private KeyboardState _currentKeyboardState = Keyboard.GetState();

    public void Reset()
    {
        _keyMappings.Clear();
    }

    public void SetKeyMap(Enum gameKey, Enum deviceKey)
    {
        _keyMappings[gameKey] = (Keys)deviceKey;
    }

    public void Update(GameTime gameTime)
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
    }

    public bool IsKeyPressed(Enum gameKey)
    {
        return _currentKeyboardState.IsKeyUp(_keyMappings[gameKey]) &&
               _previousKeyboardState.IsKeyDown(_keyMappings[gameKey]);
    }

    public bool IsKeyHeldDown(Enum gameKey)
    {
        //TODO: This currently only supports checking the two last frames, which may be too fast on some devices. Need to implement some kind of timer-based control.
        return _currentKeyboardState.IsKeyDown(_keyMappings[gameKey]) &&
               _previousKeyboardState.IsKeyDown(_keyMappings[gameKey]);
    }

    public bool IsAnyKeyPressed()
    {
        return _currentKeyboardState.GetPressedKeyCount() > 0;
    }

    //Public Properties:
    public EInputDevices DeviceId { get; } = EInputDevices.Keyboard;
    public Enum ExitKey { get; init; }
}