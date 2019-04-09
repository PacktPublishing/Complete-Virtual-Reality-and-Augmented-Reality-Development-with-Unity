using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

#if UNITY_STANDALONE
    public SteamVR_TrackedObject rightHand;

    private SteamVR_Controller.Device device;
#endif

    // Use this for initialization
    //void Start () {
    //    device = SteamVR_Controller.Input((int)rightHand.index);
    //    if (device == null)
    //        Debug.Log("Device is null");
    //    else
    //        Debug.Log("Device: " + device.index);
    //}

    // Update is called once per frame
    void Update () {
        string msg = null;

        if (Input.GetButtonDown("Fire1"))
            msg = "Fire1 down";
        if (Input.GetButtonUp("Fire1"))
            msg = "Fire1 up";

#if UNITY_STANDALONE
        // SteamVR
        device = SteamVR_Controller.Input((int)rightHand.index);
        if (device != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            msg = "Trigger press";
            device.TriggerHapticPulse(700);
        }
        if (device != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            msg = "Trigger release";
#endif
#if UNITY_ANDROID
        if (GvrControllerInput.ClickButtonDown)
            msg = "Button down";
        if (GvrControllerInput.ClickButtonUp)
            msg = "Button up";
#endif

        if (msg != null)
            Debug.Log("Input: " + msg);

    }

}
