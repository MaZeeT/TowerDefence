using UnityEngine;
using System.Collections;
using Valve.VR;

public class BuildingMenu: MonoBehaviour
{
    SteamVR_TrackedObject obj; // finding the controller

    public GameObject buttonHolder; //empty object that contains the buttons

    public bool buttonEnabled; // saying whether or the empty object is enabled


    void Start()
    {
        obj = GetComponent<SteamVR_TrackedObject>();
        buttonHolder.SetActive(false);
        buttonEnabled = false;
    }


    void Update()
    {
        var device = SteamVR_Controller.Input((int)obj.index); //you are getting the device and setting it here
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) //When you press the button above the Dpad you will do this function
        {
            Debug.Log("Buttons should be enabled");
            if (buttonEnabled == false)
            {
                buttonHolder.SetActive(true);
                buttonEnabled = true;
            }
            else if (buttonEnabled == true)
            {
                buttonHolder.SetActive(false);
                buttonEnabled = false;
            }
        }
    }
}