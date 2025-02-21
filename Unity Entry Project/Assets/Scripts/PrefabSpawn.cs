using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Inspector'dan atanacak Prefab
    public Transform spawnPoint; // Nesnelerin çıkacağı nokta

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // SPACE tuşuna basıldığında
        {
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity); // Prefab’i oluştur
        }
    }
}

