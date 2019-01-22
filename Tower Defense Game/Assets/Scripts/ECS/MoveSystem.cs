using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem {

    struct Components
    {
        public Transform transform;
        public MoveComponent move;
        public DestinationComponent destination;
    }

    protected override void OnUpdate()
    {
        foreach(var entities in GetEntities<Components>())
        {
            Vector3 direction = entities.transform.position - entities.destination.transform.position;
            float moveSpeed = entities.move.speed;

            entities.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
