using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalloonController : MonoBehaviour
{

    //public GameObject meMyselfEye;
    ///public MyInputAction myInput;
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    //private MyInputController inputController;
    private GameObject balloon;

    //void Start()
    //{
    //    inputController = meMyselfEye.GetComponent<MyInputController>();
    //}

    void Update()
    {
        //if (inputController.ButtonDown())
        //{
        //    NewBalloon();
        //}
        //else if (inputController.ButtonUp())
        //{
        //    ReleaseBalloon();
        //}
        //else if (balloon != null)
        //{
        //    GrowBalloon();
        //}

        //if (myInput.buttonAction == MyInputAction.ButtonAction.PressedDown)
        //{
        //    NewBalloon();
        //}
        //else if (myInput.buttonAction == MyInputAction.ButtonAction.ReleasedUp)
        //{
        //    ReleaseBalloon();
        //}
        //else if (balloon != null)
        //{
        //    GrowBalloon();
        //}

        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void NewBalloon(GameObject parentHand)
    {
        if (balloon == null)
        {
            //balloon = Instantiate(balloonPrefab, Vector3.zero, Quaternion.identity, parentHand.transform);
            balloon = Instantiate(balloonPrefab);
            balloon.transform.SetParent(parentHand.transform);
            balloon.transform.localPosition = Vector3.zero;

        }
    }

    public void ReleaseBalloon()
    {
        if (balloon != null)
        {
            balloon.transform.parent = null;
            balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        }
        balloon = null;
    }

    private void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
