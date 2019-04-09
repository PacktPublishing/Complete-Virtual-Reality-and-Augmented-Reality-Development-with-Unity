using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {
    public float timer = 15f;

    //void Start()
    //{
    //    Destroy(gameObject, timer);
    //}

    void Update () {
        if (transform.position.y < -5f)
            DisableMe();
            //Destroy(gameObject);
	}

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Invoke("DisableMe", timer);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
