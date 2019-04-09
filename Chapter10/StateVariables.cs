using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StateVariables : NetworkBehaviour
{

    [SyncVar(hook = "OnColorChanged")]
    public Color color;

    public void SetColor(Color changedColor)
    {
        color = changedColor;
        GetComponent<Renderer>().material.color = color;
    }

    void OnColorChanged(Color networkColor)
    {
        Debug.Log("color " + networkColor);
        GetComponent<Renderer>().material.color = networkColor;
    }
}
