using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    public List<Material> bookMaterials;
    [SerializeField] private MeshRenderer bookMat;
    private int currentMat = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeTexture();
        }
    }

    public void ChangeTexture()
    {
        currentMat++;
        if (currentMat < bookMaterials.Count)
        {
            bookMat.material = bookMaterials[currentMat];
        }
    }
}
