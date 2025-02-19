using UnityEngine;

public class ColorGunMono_V0PointToColorRGB : ColorGunMono_AbstractPointToColorRGB
{

    [Range(0,1)]
    float r, g, b;
    public override void GetColor(out Color color)
    {
        Vector3 flat = m_localDirection;
        flat.y = 0;
        float blueDistance = base.m_localBlue.magnitude;
        float redDistance = base.m_localRed.magnitude;
        float greenDistance = base.m_localGreen.magnitude;
        float blueDistanceOfFlat = Vector3.Distance(flat, base.m_localBlue);
        float redDistanceOfFlat = Vector3.Distance(flat, base.m_localRed);
        float greenDistanceOfFlat = Vector3.Distance(flat, base.m_localGreen);
        if (blueDistanceOfFlat < blueDistance)  
            b = 1f- blueDistanceOfFlat / blueDistance;
        else b = 0;

        if (redDistanceOfFlat < redDistance)
            r = 1f - redDistanceOfFlat / redDistance;
        else r = 0;

        if (greenDistanceOfFlat < greenDistance)
            g = 1f - greenDistanceOfFlat / greenDistance;
        else g = 0;
        color = new Color(r, g, b);

        }
}
