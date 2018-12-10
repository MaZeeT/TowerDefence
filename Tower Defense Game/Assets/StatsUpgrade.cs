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
        if (testUpgrade == true)
        {
            upgradeStates();
            testUpgrade = false;
        }
    }

    public void upgradeStates()
    {
        if(upgradeLevel < maxLevel) { 
        upgradeLevel++; 
        
        int damage;
        damage = towerStats.getDamage() + upgradeDamage;
        towerStats.setDamage(damage);

        float range;
        range = towerStats.getRange() + upgradeRange;
        towerStats.setRange(range);
        }
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
