using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    //public Text scoreText; 
    public TMP_Text scoreText;

    private float countDown;

    // Use this for initialization
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        if (scoreText != null)
            scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if (countDown > 0f)
            {
                // on target
                countDown -= Time.deltaTime;

                hitEffect.transform.position = hit.point;
                hitEffect.Play();

            }
            else
            {
                // killed
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                if (scoreText != null)
                    scoreText.text = "Score: " + score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0f, z);
    }
}