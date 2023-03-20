using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    public int animalIndex;
    public float zRangeToDestroy;
    private Vector3 spawnVector;
    public float xRangeStart;
    public float xRangeEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            animalIndex=Random.Range(0, animalPrefab.Length);
            spawnVector= new Vector3 (Random.Range(xRangeStart,xRangeEnd),0,17);
            Instantiate(animalPrefab[animalIndex], spawnVector, animalPrefab[animalIndex].transform.rotation);
            
        }
        if (animalPrefab[animalIndex].transform.position.z < zRangeToDestroy)
        {
            Destroy(animalPrefab[animalIndex]);
        }
    }
}
