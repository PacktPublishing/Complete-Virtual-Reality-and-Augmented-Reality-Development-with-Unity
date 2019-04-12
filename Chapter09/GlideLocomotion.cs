using UnityEngine;

public class GlideLocomotion : MonoBehaviour
{
    public float velocity = 0.7f;
    public float comfortAngle = 30f;

    private CharacterController character;
    private bool isWalking = false;
    private bool hasRotated = true;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Vector3 moveDirection = Camera.main.transform.forward;
        //moveDirection *= velocity * Time.deltaTime;
        //moveDirection.y = 0f;
        ////transform.position += moveDirection;
        //character.Move(moveDirection);

        if (Input.GetButtonDown("Fire1"))
            isWalking = true;
        else if (Input.GetButtonUp("Fire1"))
            isWalking = false;

        if (isWalking)
            character.SimpleMove(transform.forward * velocity);

        float axis = Input.GetAxis("Horizontal");
        if (hasRotated)
        {
            if (axis == 0f)
                hasRotated = false;
        } else
        {
            if (axis > 0.5f)
            {
                transform.Rotate(0, comfortAngle, 0);
                hasRotated = true;
            }
            if (axis < -0.5f)
            {
                transform.Rotate(0, -comfortAngle, 0);
                hasRotated = true;
            }

        }
    }
}
