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
        foreach(var entities in GetEntities<Components>())
        {
            Vector3 direction = entities.transform.position - entities.target.transform.position;
            //float moveSpeed = entities.moveComponent.speed;
            float moveSpeed = 2;
            
            entities.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }


    /*
    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;

        foreach (var entities in GetEntities<Components>())
        {
            Vector3 moveVector;
            GameObject targetObject;

            float speed = entities.moveComponent.speed;
            targetObject = entities.target.target; 
            moveVector = targetObject.transform.position - entities.transform.position;
            var movePosition = entities.rigidbody.position + moveVector.normalized * speed * deltaTime;

            entities.rigidbody.MovePosition(movePosition);

            //entities.transform.Translate(direction.normalized * 1 * Time.deltaTime, Space.World);
        }
    }

     Vector3 position;
            position = entities.transform.position;

            Quaternion rotation;
            rotation = entities.transform.rotation;

            float speed;
            speed = entities.moveComponent.speed;

            Vector3 moveVector;
            moveVector = entities.target.transform.position - entities.transform.position;

            var movePosition = entities.rigidbody.position + moveVector.normalized * speed * Time.deltaTime;
            entities.rigidbody.MovePosition(movePosition);
            //entities.transform.SetPositionAndRotation(position + moveVector, rotation);


    */
}
