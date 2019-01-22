using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem {

    struct Components
    {
        public MoveComponent move;
        public DestinationComponent destination;
        public Rigidbody rigidbody;
    }

    protected override void OnUpdate()
    {
        foreach (var entities in GetEntities<Components>())
        {
            float moveSpeed = entities.move.speed;
            var moveVector = (Vector3)(entities.destination.rigidbody.position 
                                       - entities.rigidbody.position);
            var movePosition = entities.rigidbody.position 
            + moveVector.normalized * moveSpeed * Time.deltaTime;

            entities.rigidbody.MovePosition(movePosition);
        }
    }
}
