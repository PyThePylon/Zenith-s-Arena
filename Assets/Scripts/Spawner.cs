using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public float timer = 3f;
    private float time;
    public Transform objectSpawn;

    // Start is called before the first frame update
    void Start()
    {
        time = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time <= 0f) {
            Spawn();
            time = timer;
        } else {
            time -= Time.deltaTime;
        }
    }

    void Spawn() {
        //GameObject.Instantiate(spawnedObject);
        GameObject g = Instantiate(spawnedObject, objectSpawn.position, objectSpawn.rotation) as GameObject;
    }
}
