using Microsoft.Xna.Framework;

namespace VoodooFramework.Engine.Input;

public class InputManager
{
    //Private Members:
    private readonly Dictionary<EInputDevices, IInputDevice> _inputDevices = new();

    public void RegisterDevice(IInputDevice device, bool setAsActive = false)
    {
        _inputDevices[device.DeviceId] = device;

        if (setAsActive)
            ActiveInputDevice = device.DeviceId;
    }
    
    public void Update(GameTime gameTime)
    {
        _inputDevices[ActiveInputDevice].Update(gameTime);
    }

    public bool IsKeyPressed(Enum gameKey)
    {
        return _inputDevices[ActiveInputDevice].IsKeyPressed(gameKey);
    }
    
    public bool IsKeyHeldDown(Enum gameKey)
    {
        return _inputDevices[ActiveInputDevice].IsKeyHeldDown(gameKey);
    }
    
    public bool IsAnyKeyPressed()
    {
        return _inputDevices[ActiveInputDevice].IsAnyKeyPressed();
    }

    public bool IsExitRequested()
    {
        return _inputDevices[ActiveInputDevice].IsKeyPressed(_inputDevices[ActiveInputDevice].ExitKey);
    }
    
    //Public Properties:
    public EInputDevices ActiveInputDevice { get; set; }
}