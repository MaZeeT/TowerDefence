using UnityEngine;
using System.Collections;
using Valve.VR;

public class BuildingMenu : MonoBehaviour
{

    Vector3 BenjaminPoints = new Vector3();
    SteamVR_TrackedObject obj; // finding the controller
    [Header("Setup")]
    public int itemID;
    public GameObject buttonHolder; //empty object that contains the buttons
    public GameObject Hand;
    public GameObject TowerFoundation;
    public GameObject BuildingBall;

    [Header("Debug")]
    public bool buttonEnabled; // saying whether or the empty object is enabled

    // Public booleans, need to be accesed in other scripts
    public bool holding;
    public bool holdingFoundation;
    public bool holdingBall;



    void Start()
    {
        obj = GetComponent<SteamVR_TrackedObject>();
        buttonHolder.SetActive(false);
        buttonEnabled = false;
        holdingFoundation = false;
        holdingBall = false;
        holding = false;


    } // Start end

    void Update()
    {
        MenuOpen();
        CheckItemID();
        PlaceObject();
    } // Update end

    void MenuOpen()
    {

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
    }// MenuOpen end

    void CheckItemID()
    {
        var device = SteamVR_Controller.Input(4);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Axis0)) {
            itemID++;
            Debug.Log(itemID);
        } else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Axis1)) {
            itemID--;
            Debug.Log(itemID);
        }
    }

    void PlaceObject()
    {

        var device = SteamVR_Controller.Input(3);



        if (holdingFoundation)
        {

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.DrawRay(Hand.transform.position, Hand.transform.forward * 50, Color.red);

            }
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Vector3 vec = new Vector3(Hand.transform.position.x, 0.1f, Hand.transform.position.z);
                Instantiate(TowerFoundation, vec, Quaternion.identity);

                holdingFoundation = false;
                holding = false;
            }


        }
        if (holdingBall)
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.DrawRay(Hand.transform.position, Hand.transform.forward * 50, Color.red);

            }

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Vector3 vec = new Vector3(Hand.transform.position.x, Hand.transform.position.y, Hand.transform.position.z);
                Instantiate(BuildingBall, vec, Hand.transform.rotation);

                holdingBall = false;
                holding = false;

            }
        }
    } // PlaceObjecft end

} // BuildingMenu end