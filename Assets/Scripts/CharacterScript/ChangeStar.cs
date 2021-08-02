using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStar : MonoBehaviour
{
    SkinnedMeshRenderer skin;

    Material mat1, mat2;

    // Update is called once per frame
    void Awake()
    {
         skin = GetComponent<SkinnedMeshRenderer>();
         mat1 =Resources.Load("PBR") as Material;
         mat2 = Resources.Load("Star") as Material;
    }

    public void powerUp()
    {
        changeMaterial(mat2);
    }

    private void changeMaterial(Material mat)
    {
        Material[] mats = skin.materials;
        mats[0] = mat;
        skin.materials = mats;

    }

    public void restoreSkin()
    {
        changeMaterial(mat1);
    }
}
