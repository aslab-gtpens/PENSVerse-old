using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRInputReader : MonoBehaviour
{
    private InputDevice rightHand;
    private InputDevice leftHand;
    private InputDevice headGear;

    [Header("button")]
    public bool button_A;
    public bool button_B;
    public bool button_X;
    public bool button_Y;

    [Header("trigger button")]
    public bool trigger_Right;
    public bool trigger_Left;
    public bool gripTrigger_Right;
    public bool gripTrigger_Left;

    [Header("trigger value")]
    public float triggerValue_right;
    public float triggerValue_left;
    public float gripTriggerValue_rigt;
    public float gripTriggerValue_left;

    [Header("Joystick")]
    public Vector2 joystick_right;
    public bool joystickClick_right;
    public Vector2 joystick_left;
    public bool joystickClick_left;

    private void Start()
    {
        StartCoroutine(SearchAllDevices());
    }

    private void Update()
    {
        //Right Hand
        rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out button_A);
        rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out button_B);

        rightHand.TryGetFeatureValue(CommonUsages.gripButton, out gripTrigger_Right);
        rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger_Right);

        rightHand.TryGetFeatureValue(CommonUsages.trigger, out triggerValue_right);
        rightHand.TryGetFeatureValue(CommonUsages.grip, out gripTriggerValue_rigt);

        rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystick_right);
        rightHand.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out joystickClick_right);
        
        //Left Hand
        leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out button_Y);
        leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out button_X);

        leftHand.TryGetFeatureValue(CommonUsages.gripButton, out gripTrigger_Left);
        leftHand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger_Left);

        leftHand.TryGetFeatureValue(CommonUsages.trigger, out triggerValue_left);
        leftHand.TryGetFeatureValue(CommonUsages.grip, out gripTriggerValue_left);

        leftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystick_left);
        leftHand.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out joystickClick_left);
    }




    //Test Tomorow
    IEnumerator SearchAllDevices()
    {
        bool notFound = true;
        while (notFound)
        {
            //Debug.Log("searching devices");
            List<InputDevice> devices = new List<InputDevice>();

            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, devices);
            if (devices.Count > 0)
            {
                //Debug.Log("Head");
                headGear = devices[0];
            }
            else
            {
                notFound = true;
                notFound = false;
            }

            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, devices);
            if (devices.Count > 0)
            {
                //Debug.Log("rHand");
                rightHand = devices[0];
                notFound = false;
            }
            else
            {
                notFound = true;
            }

            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, devices);
            if (devices.Count > 0)
            {
                //Debug.Log("lHand");
                leftHand = devices[0];
                notFound = false;
            }
            else
            {
                notFound = true;
            }

            yield return new WaitForSeconds(5);
        }


    }

}
