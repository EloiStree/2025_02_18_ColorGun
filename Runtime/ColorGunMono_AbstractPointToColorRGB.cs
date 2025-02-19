using UnityEngine;
using UnityEngine.Events;

public abstract class ColorGunMono_AbstractPointToColorRGB : MonoBehaviour
{
    public Transform m_point;

    public Transform m_anchorColorCenter;
    public Transform m_anchorRed;
    public Transform m_anchorGreen;
    public Transform m_anchorBlue;

    public Color m_currentColor;
    public UnityEvent<Color> m_onColorChanged;
    public Renderer[] m_renderers;

    public Vector3 m_localGreen;
    public Vector3 m_localBlue;
    public Vector3 m_localRed;
    public Vector3 m_localDirection;

    public bool m_useOnValidate=true;

    private void OnValidate()
    {
        if (m_useOnValidate)
        {
            Update();
        }

    }
    void Update()
    {

        RelocateWorldToLocal(m_anchorColorCenter, m_anchorRed, out m_localRed);
        RelocateWorldToLocal(m_anchorColorCenter, m_anchorGreen, out m_localGreen);
        RelocateWorldToLocal(m_anchorColorCenter, m_anchorBlue, out m_localBlue);
        RelocateWorldToLocal(m_anchorColorCenter, m_point, out m_localDirection);

        Debug.DrawLine(Vector3.zero, m_localRed, Color.red);
        Debug.DrawLine(Vector3.zero, m_localGreen, Color.green);
        Debug.DrawLine(Vector3.zero, m_localBlue, Color.blue);
        Debug.DrawLine(m_localRed, m_localGreen, new Color(1,1,0));
        Debug.DrawLine(m_localGreen, m_localBlue, new Color(0, 1, 1));
        Debug.DrawLine(m_localBlue, m_localRed, new Color(1, 0, 1));
        Debug.DrawLine(Vector3.zero, m_localDirection, Color.yellow);

        GetColor(out m_currentColor);
        m_onColorChanged.Invoke(m_currentColor);

        if (Application.isPlaying) {

            foreach (var renderer in m_renderers)
            {
                if (renderer != null)
                    renderer.material.color = m_currentColor;
            }
        }

    }

    public abstract void GetColor(out Color color);

    public void RelocateWorldToLocal(Transform center, Transform point, out Vector3 localPoint) {

        localPoint = point.position - center.position;
        localPoint = Quaternion.Inverse(center.rotation) * localPoint;


    }
}
