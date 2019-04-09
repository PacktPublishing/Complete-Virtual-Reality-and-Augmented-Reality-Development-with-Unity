using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class BallsFromHeaven : MonoBehaviour
{
    //public GameObject ball;
    public float startHeight = 10f;
    public float interval = 0.5f;

    private float nextBallTime = 0f;
    private ObjectPooler pool;

    private void Start()
    {
        pool = GetComponent<ObjectPooler>();
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + interval;
            Vector3 position = new Vector3(Random.Range(-4f, 4f), startHeight, Random.Range(-4f, 4f));
            //Instantiate(ball, position, Quaternion.identity);
            GameObject ball = pool.GetPooledObject();
            ball.transform.position = position;
            ball.transform.rotation = Quaternion.identity;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.SetActive(true);
        }
    }
}
