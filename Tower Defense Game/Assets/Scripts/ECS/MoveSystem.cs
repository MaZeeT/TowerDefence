using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem {

    struct Components
    {
        public Transform transform;
        public MoveComponent moveComponent;
        public MoveToTargetComponent target;
        public Rigidbody rigidbody;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;

        foreach (var entities in GetEntities<Components>())
        {
            Vector3 moveVector;
            float speed = entities.moveComponent.speed;

            moveVector = entities.target.transform.position - entities.transform.position;
            var movePosition = entities.rigidbody.position + moveVector.normalized * speed * deltaTime;

            entities.rigidbody.MovePosition(movePosition);

            //entities.transform.Translate(direction.normalized * 1 * Time.deltaTime, Space.World);
        }
    }

}
