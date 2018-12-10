using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeUpgrade : MonoBehaviour
{

    public string type;

    public GameObject TowerFire;
    public GameObject TowerWater;
    public GameObject TowerLightning;
    public GameObject TowerPhysical;

    // Upgrades tower to the specific tower type
    void OnCollisionEnter(Collider Other)
    {
        Debug.Log("fuck");
        if (Other.tag == "BasicTower")
        {

            Vector3 vec = Other.gameObject.transform.position;
            Destroy(Other.gameObject);

            switch (type)
            {

                case "Fire":

                    Instantiate(TowerFire, vec, Quaternion.identity);

                    break;

                case "Water":

                    Instantiate(TowerWater, vec, Quaternion.identity);

                    break;

                case "Lightning":

                    Instantiate(TowerLightning, vec, Quaternion.identity);


                    break;

                case "Physical":

                    Instantiate(TowerPhysical, vec, Quaternion.identity);

                    break;

            }
        }
    }
}
