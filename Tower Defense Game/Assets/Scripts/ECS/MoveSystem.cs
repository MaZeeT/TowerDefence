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
            var moveVector = new Vector3(1, 0, 1);
            var movePosition = entities.rigidbody.position 
            + moveVector.normalized * moveSpeed * Time.deltaTime;

            entities.rigidbody.MovePosition(movePosition);
        }
    }
}
