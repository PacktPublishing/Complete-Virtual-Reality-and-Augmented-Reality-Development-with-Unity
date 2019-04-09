using UnityEngine;
using UnityEngine.AI;

public class LookTeleport : MonoBehaviour
{
    public GameObject target;
    public GameObject ground;

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            target.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            target.SetActive(false);
            transform.position = target.transform.position;
        }
        else if (target.activeSelf)
        {
            ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            //if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == ground))
            //{
            //    target.transform.position = hit.point;
            //}
            //else
            //{
            //    target.transform.position = transform.position;
            //}

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Teleport")))
            {
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 1f, NavMesh.AllAreas))
                    target.transform.position = navHit.position;
            }
            else
            {
                target.transform.position = transform.position;
            }
        }
    }

}
