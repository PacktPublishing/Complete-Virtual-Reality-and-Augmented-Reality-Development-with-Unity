using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GameObject bird;
    public List<GameObject> targets = new List<GameObject>();
    public int animIndex;

    public bool collideWithObjects = false;
    public float birdScale = 1.0f;

    private int prevIndex;

    void Start()
    {
        prevIndex = 0;
    }

    void Update()
    {
        if (animIndex != prevIndex && animIndex > 0 && animIndex < targets.Count)
        {
            prevIndex = animIndex;
            bird.gameObject.SendMessage("FlyToTarget", targets[animIndex].transform.position);
        }
    }
}