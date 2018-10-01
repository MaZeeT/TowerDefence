using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 50f;
    public int damage = 1;

    public void Seek(Transform _target) {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {

        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            DamageTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void DamageTarget() {
        EnemySpecs e = target.GetComponent<EnemySpecs>();
        e.Damaged(damage);
        Destroy(gameObject);
    }
}
