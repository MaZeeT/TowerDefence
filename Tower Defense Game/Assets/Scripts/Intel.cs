using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intel : MonoBehaviour
{
    public bool reportIntel;
    public string intel;
    public float range;
    private float health;
    private Targeting targeting;
    public bool printList;

 
    private List<GameObject> spottedList;

    private void Start()
    {   
        spottedList = new List<GameObject>();
        targeting = GetComponent<Targeting>();
    }


    void Update()
    {
        if (targeting.FindTarget(range) != null)
        {   //add a non-null Tower-GameObject to the List
            AddTarget(targeting.FindTarget(range));         
        }

        health = GetComponent<Health>().health;

        if (health <= 3){
            generateIntel();
            reportIntel = true;
        }

        if (printList == true) printListDebug();
        
    }

    void printListDebug()
    {
        for (int i = 0; i < spottedList.Count; i++)
        {
           Debug.Log(spottedList[i].name);
        }
        printList = false;
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

    public List<GameObject> getSpottedList()
    {
        return spottedList;
    }
}
