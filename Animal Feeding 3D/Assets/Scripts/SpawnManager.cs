using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject[] animalPrefab;
    public GameObject Player;
    public GameObject PlayButton;
    public GameObject PlayScreen;
    
    private int animalIndex;
    public float zRangeToDestroy;

    private Vector3 spawnVector;
    public float xRangeStart;
    public float xRangeEnd;
    private float startDelay = 1.0f;
    public float spawnInterval = 2.0f;
    private bool isSpawning = false;
    private void Awake()
    {
        instance = this;
        PlayScreen.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (animalPrefab[animalIndex].transform.position.z < zRangeToDestroy)
        {
            Destroy(animalPrefab[animalIndex]);
        }
    }

    void SpawnAnimals()
    {
        if (isSpawning)
        {
            animalIndex = Random.Range(0, animalPrefab.Length);
            spawnVector = new Vector3(Random.Range(xRangeStart, xRangeEnd), 0, 17);
            Instantiate(animalPrefab[animalIndex], spawnVector, animalPrefab[animalIndex].transform.rotation);
        }
    }
    public void StartSpawning()
    {
        if(!isSpawning)
        {
            if(PlayButton.activeSelf)
            {
                PlayButton.SetActive(false);
                PlayScreen.SetActive(true);
            }
            isSpawning = true;
            InvokeRepeating("SpawnAnimals", startDelay, spawnInterval);
        }
    }
    public void Reset()
    {
        Player.transform.position = Vector3.zero;
        Player.SetActive(true);
        HealthManager.instance.RestartGame();
    }
    public void StopSpawning()
    {
        isSpawning = false;
        Player.SetActive(false);
        CancelInvoke("SpawnAnimals");
    }
}