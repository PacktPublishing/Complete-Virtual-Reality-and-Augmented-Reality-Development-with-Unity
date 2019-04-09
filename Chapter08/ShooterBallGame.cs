using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class ShooterBallGame : MonoBehaviour
{
    public Transform shootAt;
    public Transform shooter0;
    public Transform shooter1;
    public float speed = 5.0f;
    public float interval = 3f;

    private float nextBallTime = 0f;
    private ObjectPooler pool;
    private GameObject activeBall;
    private int shooterId = 0;
    private Transform shooter;

    private AudioSource soundEffect;

    private void Start()
    {
        if (shootAt == null)
        {
            shootAt = Camera.main.transform;
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
            if (shooterId == 0)
            {
                shooterId = 1;
                shooter = shooter1;
            }

            else
            {
                shooterId = 0;
                shooter = shooter0;
            }

            nextBallTime = Time.time + interval;
            ShootBall();
        }   
    }

    private void ShootBall()
    {
        soundEffect.Play();
        activeBall = pool.GetPooledObject();
        activeBall.transform.position = shooter.position;
        activeBall.transform.rotation = Quaternion.identity;
        shooter.transform.LookAt(shootAt);
        activeBall.GetComponent<Rigidbody>().velocity = shooter.forward * speed;
        activeBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        activeBall.SetActive(true);
    }
}
