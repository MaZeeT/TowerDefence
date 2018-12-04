using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour {
    public GameObject pathR, pathF, pathL;

    public List<GameObject> GetBetterList() {
        List<GameObject> pathPoints = new List<GameObject>();

        if (pathF != null)
        {
            pathPoints.Add(pathF);
        }
        if (pathR != null) {
            pathPoints.Add(pathR);
        }
        if (pathL != null) {
            pathPoints.Add(pathL);
        }

        return pathPoints;
    }
}
