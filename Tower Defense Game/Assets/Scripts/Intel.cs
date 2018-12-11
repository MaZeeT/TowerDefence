using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intel : MonoBehaviour
{
    public bool reportIntel = false;
    public string intel;
    private float health;    

    void Update()
    {
        health = GetComponent<Health>().health;

        if(health <= 3){
            generateIntel();
            reportIntel = true;
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
