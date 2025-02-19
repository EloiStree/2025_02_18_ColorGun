using UnityEngine;
using UnityEngine.Events;

public class ColorGunMono_ColorSensitiveHandler : MonoBehaviour, I_ColorSensitiveHandler
{
    public Color m_lastReceived;
    public UnityEvent<Color> m_onColorReceived;
    public void OnColorReceived(Color color)
    {
        m_lastReceived = color;
        m_onColorReceived.Invoke(color);
    }
}
