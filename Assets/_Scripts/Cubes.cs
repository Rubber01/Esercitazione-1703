using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public GameObject cube;
    public int initCubePosition = 299600;
    public int initValue = 300;
    public Transform parent;

    private void Awake()
    {
        InitCubes();
    }

    public void InitCubes()
    {
        for (int i = 0; i < initValue; i += 2)
        {
            Vector3 v = new(3, 0, initCubePosition + i);
            Vector3 v2 = new(-3, 0, initCubePosition + i);

            GameObject newCube = Instantiate(cube, parent);
            GameObject newCube2 = Instantiate(cube, parent);

            newCube.AddComponent<OriginShiftController>();
            newCube2.AddComponent<OriginShiftController>();

            newCube.transform.position = v;
            newCube2.transform.position = v2;

            newCube.isStatic = true;
            newCube2.isStatic = true;
        }
    }
}
