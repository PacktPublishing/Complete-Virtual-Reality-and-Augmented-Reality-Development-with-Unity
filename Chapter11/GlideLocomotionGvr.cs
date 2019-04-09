using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideLocomotionGvr : MonoBehaviour
{
    public float velocity = 0.4f;
    public float comfortAngle = 30f;

    private CharacterController character;
    private bool isWalking = false;
    private bool hasRotated = false;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (GvrControllerInput.ClickButtonDown)
            isWalking = true;
        else if (GvrControllerInput.ClickButtonUp)
            isWalking = false;

        if (isWalking)
            character.SimpleMove(transform.forward);

        //float axis = Input.GetAxis("Horizontal");
        Vector2 touchPos = GvrControllerInput.TouchPosCentered;
        float axis = touchPos.x;

        Debug.Log(axis);
        if (axis > 0.5f)
        {
            if (!hasRotated)
                transform.Rotate(0, comfortAngle, 0);
            hasRotated = true;
        }
        else if (axis < -0.5f)
        {
            if (!hasRotated)
                transform.Rotate(0, -comfortAngle, 0);
            hasRotated = true;
        }
        else
        {
            hasRotated = false;
        }

    }
}
