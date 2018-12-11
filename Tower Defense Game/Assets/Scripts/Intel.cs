using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intel : MonoBehaviour
{
    public bool reportIntel = false;
    public string intel;
    public float spottingRange;
    private float health;
    private GameObject spottedTower;
    private Targeting targeting;

    public float range;
    private List<GameObject> spottedList;

    private void Start()
    {
        targeting = GetComponent<Targeting>();
        spottedTower = null;
    }

    void Update()
    {
        health = GetComponent<Health>().health;

        if (health <= 3){
            generateIntel();
            reportIntel = true;
        }

        //spottedTower = GameObject.FindGameObjectWithTag("TowerUpgradeAble");
        //spottedTower = targeting.FindTarget(spottingRange) as GameObject;

        if (spottedTower != null)
        {
            //AddTarget(spottedTower);
            Debug.Log("added");
            Debug.Log(spottedTower.GetComponent<Tower>().getDamageType());
        }
        else
        {
            Debug.Log("not so much");
        }
    }

    void printListDebug()
    {
        for (int i = 0; i < spottedList.Count; i++)
        {
           Debug.Log(spottedList[i].GetType());
        }
        
    }
    void AddTarget(GameObject target)
    {
       // This statement adds spotted towers to a list of gameObjects rather than their types.
       // This is to ensure that we dont end up with a list of strings so that a minion can spot multiple towers of the same type. 
        if(!spottedList.Contains(target)) 
        {
            spottedList.Add(target);
        }
      
    }
    void generateIntel(){
        intel = "I'm fucked";
    }
    void generateIntel(string msg)
    {
        intel = msg;
    }
    void clearIntel(){
        intel = null;
    }    
}
