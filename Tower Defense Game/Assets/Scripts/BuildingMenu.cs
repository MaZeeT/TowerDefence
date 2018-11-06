using UnityEngine;
using System.Collections;
using Valve.VR;

//This script essentially enables an object object that
//has something as simple as blocks as children. When you
//press the button above the d pad on the controller this
//script is attached to it will do the following

//make sure you make the empty object a child of either controller you wish to enable it on.


public class BuildingMenu: MonoBehaviour
{
    SteamVR_TrackedObject obj; // finding the controller

    public GameObject buttonHolder; //empty object that contains the buttons

    public bool buttonEnabled; // saying whether or the empty object is enabled


    void Awake()
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