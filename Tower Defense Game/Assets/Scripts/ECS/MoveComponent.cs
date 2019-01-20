using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public struct MoveComponent : IComponentData
{
    public float speed;
}
/*
public class MoveComponent : IComponentData {

    public float movementSpeed;
}
*/
public class MoveSpeedComponent : ComponentDataWrapper<MoveComponent> { }
