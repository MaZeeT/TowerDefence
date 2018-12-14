using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrade : MonoBehaviour {
    Tower towerStats;
    public int maxLevel;
    public int upgradeLevel;
    public float upgradeRange;
    public int upgradeDamage;

    public bool testUpgrade;

    
    private void Start()
    {
        towerStats = GetComponent<Tower>();
    }

    private void Update()
    {
        //the test button, which add a level per click
        if (testUpgrade == true)
        {
            upgradeStats();
            testUpgrade = false;
        }
    }

    public void upgradeStats()
    {
        if(upgradeLevel < maxLevel) { 
        upgradeLevel++;

            upDamage();
            upRange();

        
        }
    }

    private void upDamage()
    {
        int damage;
        damage = towerStats.getDamage() + upgradeDamage;
        towerStats.setDamage(damage);
    }

    private void upRange()
    {
        float range;
        range = towerStats.getRange() + upgradeRange;
        towerStats.setRange(range);
    }


    /*
        [Header("Attributes")]
        public float range;
        public float roundsPerMinut;
        private float reloadTime;
        public float reloadProgress = 0f;

        [Header("Projectile Settings")]
        public float speed;
        public int damageAmount;
    */
}
