using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem {

    struct Components
    {
        public Transform transform;
        public MoveComponent moveComponent;
        public PathFinding pathFinding;
    }

    protected override void OnUpdate()
    {
        foreach (var entities in GetEntities<Components>())
        {

        }
        throw new System.NotImplementedException();
    }

}
