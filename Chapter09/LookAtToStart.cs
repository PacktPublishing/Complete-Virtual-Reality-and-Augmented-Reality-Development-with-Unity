using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LookAtToStart : MonoBehaviour
{
    public PlayableDirector timeline;
    public float timeToSelect = 3f;
    private float countDown;
    private bool playToSetup;
    private double duration;
    private bool resetSetup;
    void Start()
    {
        countDown = timeToSelect;
        resetSetup = true;
     }

    void Update()
    {
        if (timeline.state == PlayState.Playing)
        {
            return;
        }
        if (resetSetup)
        {
            StartCoroutine("PlayToSetup");
            resetSetup = false;
        }

        // Is user looking here?
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == gameObject))
        {
            if (countDown > 0f)
            {
                countDown -= Time.deltaTime;
                Debug.Log("Counting" + countDown);
            }
            else
            {
                // go!
                Debug.Log("Go!");
                timeline.Play();
                resetSetup = true;
            }
        }
        else
        {
            // reset timer
            Debug.Log("ResetTimer");
            countDown = timeToSelect;
        }
    }

    IEnumerator PlayToSetup()
    {
        timeline.Play();
        yield return new WaitForSeconds(0.1f);
        timeline.Stop();
    }
}
