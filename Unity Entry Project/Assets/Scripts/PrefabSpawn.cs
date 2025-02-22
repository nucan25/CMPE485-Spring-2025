using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab to be assigned via Inspector
    public Transform spawnPoint; // Spawn location for the objects

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // When the SPACE key is pressed
        {
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity); // Instantiate the prefab
        }
    }
}
