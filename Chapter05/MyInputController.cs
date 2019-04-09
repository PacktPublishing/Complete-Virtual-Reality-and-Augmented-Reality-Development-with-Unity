using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyInputController : MonoBehaviour {
    ///public MyInputAction myInput;

    public UnityEvent ButtonDownEvent = new UnityEvent();
    public UnityEvent ButtonUpEvent = new UnityEvent();

#if UNITY_STANDALONE
    //public SteamVR_TrackedObject rightHand;

    //private SteamVR_Controller.Device device;
#endif

    void Update () {
        ButtonTest();
        //if (ButtonDown())
        //{
        //    myInput.buttonAction = MyInputAction.ButtonAction.PressedDown;
        //}
        //else if (ButtonUp())
        //{
        //    myInput.buttonAction = MyInputAction.ButtonAction.ReleasedUp;
        //}
        //else
        //{
        //    myInput.buttonAction = MyInputAction.ButtonAction.None;
        //}

        if (ButtonDown())
        {
            ButtonDownEvent.Invoke();
        }
        else if (ButtonUp())
        {
            ButtonUpEvent.Invoke();
        }
    }

    private void ButtonTest()
    {
        string msg = null;

        if (Input.GetButtonDown("Fire1"))
            msg = "Fire1 down";

        if (Input.GetButtonUp("Fire1"))
            msg = "Fire1 up";

#if UNITY_STANDALONE
        // SteamVR
        //device = SteamVR_Controller.Input((int)rightHand.index);
        //if (device != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    msg = "Trigger press";
        //    device.TriggerHapticPulse(700);
        //}
        //if (device != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            msg = "Trigger release";
#endif

        if (msg != null)
            Debug.Log("Input: " + msg);
    }

    public bool ButtonDown()
    {
#if UNITY_ANDROID
        return GvrControllerInput.ClickButtonDown;
#else
        return Input.GetButtonDown("Fire1");
#endif
    }

    public bool ButtonUp()
    {
#if UNITY_ANDROID
        return GvrControllerInput.ClickButtonUp;
#else
        return Input.GetButtonUp("Fire1");
#endif
    }
}
