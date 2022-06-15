using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNextScene : MonoBehaviour
{

    public Transform SpawnPoint;
    public GameObject CloseDoorPrefabs;
    public GameObject OpenDoorPrefabs;
    bool spawn;
    int spawnCounter = 1;

    GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
        instance = Instantiate(CloseDoorPrefabs, SpawnPoint.position, Quaternion.Euler(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {

        

        if (spawn == true && spawnCounter >= 1)
        {
            Instantiate(OpenDoorPrefabs, SpawnPoint.position, Quaternion.Euler(0,0,0));
            spawnCounter -= 1;
            Destroy(instance);
        }
    }




   public void SummonNextScene()
    {
        spawn = true;
    }
}
