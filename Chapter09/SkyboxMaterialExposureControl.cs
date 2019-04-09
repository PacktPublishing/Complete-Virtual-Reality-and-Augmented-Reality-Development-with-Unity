using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxMaterialExposureControl : MonoBehaviour
{
    public Material skyboxMaterial;
    public float exp = 1.0f;

    private void Update()
    {
        SetExposure(exp);
    }

    public void SetExposure(float value)
    {
        skyboxMaterial.SetFloat("_Exposure", value);
    }
}
