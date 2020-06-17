using UnityEngine;

public class RotationFix : MonoBehaviour
{
    // _________________________________________________________________________________________________________/ Rotate
    public void Rotate(float difrence)
    {
        transform.Rotate(0, -difrence, 0);
    }
}
