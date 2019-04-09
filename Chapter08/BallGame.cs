using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class BallGame : MonoBehaviour
{
    public Transform dropPoint;
    public float startHeight = 10f;
    public float interval = 3f;

    private float nextBallTime = 0f;
    private ObjectPooler pool;
    private GameObject activeBall;
 
    private AudioSource soundEffect;

    private void Start()
    {
        if (dropPoint == null)
        {
            dropPoint = Camera.main.transform;
        }
        soundEffect = GetComponent<AudioSource>();
        pool = GetComponent<ObjectPooler>();
        if (pool == null)
        {
            Debug.LogError("BallGame requires ObjectPooler component");
        }
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + interval;
            soundEffect.Play();
            Vector3 position = new Vector3(dropPoint.position.x, startHeight, dropPoint.position.z);
            activeBall = pool.GetPooledObject();
            activeBall.transform.position = position;
            activeBall.transform.rotation = Quaternion.identity;
            activeBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            activeBall.SetActive(true);
        }
    }
}
