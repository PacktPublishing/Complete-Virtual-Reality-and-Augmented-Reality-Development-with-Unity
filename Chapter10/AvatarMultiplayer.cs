using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AvatarMultiplayer : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        GameObject camera = Camera.main.gameObject;
        transform.parent = camera.transform;
        transform.localPosition = Vector3.zero;
    }
}
