using UnityEngine;

public class DestroyTimeout : MonoBehaviour
{
    public float timer = 15f;

    void Start()
    {
        Destroy(gameObject, timer);
    }

}
