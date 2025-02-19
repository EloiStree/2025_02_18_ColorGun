using System;
using UnityEngine;
using UnityEngine.Events;

public interface I_ColorSensitiveHandler 
{
    /// <summary>
    /// Color is going to be given to the handler.
    /// </summary>
    /// <param name="color"></param>
    public void OnColorReceived(Color color);
}
