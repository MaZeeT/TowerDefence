using UnityEngine;
using System.Collections;
using Valve.VR;

public class BuildingMenu: MonoBehaviour
{
    SteamVR_TrackedObject obj; // finding the controller

    public GameObject buttonHolder; //empty object that contains the buttons

    public bool buttonEnabled; // saying whether or the empty object is enabled

    public bool holding;
    public bool holdingFoundation;
    public bool holdingBall;

    public GameObject TowerFoundation;
    public GameObject BuildingBall;
    public GameObject Hand;


 
    void Start()
    {
        obj = GetComponent<SteamVR_TrackedObject>();
        buttonHolder.SetActive(false);
        buttonEnabled = false;
        holdingFoundation = false;
        holdingBall = false;
        holding = false;
    }

    void Update()
    {

        MenuOpen();
        PlaceObject();
    }

    void MenuOpen () {

        var device = SteamVR_Controller.Input(4); //you are getting the device and setting it here
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

    void PlaceObject() {

        var device = SteamVR_Controller.Input(3);

        if (holdingFoundation) {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {

                Vector3 vec = new Vector3(Hand.transform.position.x, 0.01f, Hand.transform.position.z);
                Instantiate(TowerFoundation, vec, Quaternion.identity);
                holdingFoundation = false;
                holding = false;
            }

        }
        if (holdingBall) {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {

                Vector3 vec = new Vector3(Hand.transform.position.x, 0.01f, Hand.transform.position.z);
                Instantiate(BuildingBall, vec, Quaternion.identity);
                holdingBall = false;
                holding = false;
            }
        }
    } // placeObjecft end
} // BuildingMenu end