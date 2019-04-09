using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosZ;

    void Start()
    {
        defaultPosZ = transform.localPosition.z;
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.localPosition = new Vector3(0, 0, hit.distance);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, defaultPosZ);
        }
    }
}
