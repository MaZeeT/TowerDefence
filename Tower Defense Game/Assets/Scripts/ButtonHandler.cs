using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
    public bool button1;
    public bool button2;
    public bool button3;

    public GameObject TowerFoundation;
    public GameObject BuildingBall;

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "VRHand2")
        {
            if (button1)
            {
                Vector3 vec = new Vector3(Other.transform.position.x, 0.01f, Other.transform.position.z);
                Instantiate(TowerFoundation, vec, Quaternion.identity);
            }
            if (button2)
            {
                Vector3 vec = new Vector3(Other.transform.position.x, 0.01f, Other.transform.position.z);
                Instantiate(BuildingBall, vec, Quaternion.identity);
            }
            if (button3)
            {
                //does not do anything
            }
        }
    }
}
