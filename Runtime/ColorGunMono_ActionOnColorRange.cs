using UnityEngine;
using UnityEngine.Events;

public class ColorGunMono_ActionOnColorRange : MonoBehaviour, I_ColorSensitiveHandler
{
    public Color m_targetColor;
    public float m_range = 0.1f;

    public Color m_lastReceived;
    public bool m_isInRange;
    public UnityEvent<Color> m_onColorReceived;
    public UnityEvent m_onInRangeEnter;
    public UnityEvent m_onInRangeExit;

    public void OnColorReceived(Color color)
    {
        bool isIn = IsInColorRange(color, m_targetColor, m_range);
        m_isInRange = isIn;
        m_lastReceived = color;
        m_onColorReceived.Invoke(color);
    }
    private bool IsInColorRange(Color color, Color m_targetColor, float m_range)
    {
        float r = Mathf.Abs(color.r - m_targetColor.r);
        float g = Mathf.Abs(color.g - m_targetColor.g);
        float b = Mathf.Abs(color.b - m_targetColor.b);
        return r < m_range && g < m_range && b < m_range;
    }
}