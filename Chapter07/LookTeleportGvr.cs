using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookTeleportGvr : MonoBehaviour
{

    public GameObject target;
    public GameObject ground;

    void Update()
    {
        Transform cam = Camera.main.transform;
        Ray ray;
        RaycastHit hit;

        if (GvrControllerInput.ClickButtonDown)
        {
            target.SetActive(true);
        }
        else if (GvrControllerInput.ClickButtonUp)
        {
            //Debug.Log("Button up");
            target.SetActive(false);
            transform.position = target.transform.position;
        }
        else if (target.activeSelf)
        {
            ray = new Ray(cam.position, cam.rotation * Vector3.forward);
            //if (Physics.Raycast(ray, out hit) &&
            //    (hit.collider.gameObject == ground))
            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Teleport")))
            {
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 1.0f, NavMesh.AllAreas))
                    target.transform.position = navHit.position;
            }
            else
            {
                //Debug.Log("Not hit ground");
                target.transform.position = transform.position;
            }
        }

    }
}
