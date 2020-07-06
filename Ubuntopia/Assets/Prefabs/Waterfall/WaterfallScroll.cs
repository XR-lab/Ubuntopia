using UnityEngine;

public class WaterfallScroll : MonoBehaviour
{
    public float ScrollX = 0.0f;
    public float ScrollY = 1.0f;


    // Update is called once per frame
    void Update()
    {
     float OffsetX = Time. time * ScrollX;
     float OffsetY = Time. time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
        
    }
}
