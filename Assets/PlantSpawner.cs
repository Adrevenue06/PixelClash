using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plant;
    public bool Spawn;



    public IEnumerator SpawnPlant()
    {
        yield return new WaitForSeconds(4.5f);
        Instantiate(plant, transform.position, quaternion.identity);
        

    }
    void Update()
    {
        if (Spawn)
        {
            StartCoroutine(SpawnPlant());
            Spawn = false;
        }
    }


}
