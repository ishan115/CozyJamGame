using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    private GameObject hazardPrefab;
    [SerializeField]
    private GameObject powerUpOne;
    [SerializeField]
    private GameObject powerUpTwo;
    [SerializeField]
    private GameObject powerUpThree;
    [SerializeField]
    private GameObject powerUpFrenzy;
    [SerializeField]
    private GameObject powerUpInv;
    [SerializeField]
    private float timeToSlowObjects;

    private bool instantiatedObjectsBeingSlowed=false;
    private float maxTimeBetweenHazardSpawns = 2;
    private List<GameObject> instantiatedObjects = new List<GameObject>(); //List that contains all hazards and powerups that are instantiated

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HazardSpawnTimer");
        StartCoroutine("HoldPowerUpSpawnUntilOffScreen");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Used to test spawning
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnHazard();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            SpawnPowerUp();
        }
        */
    }


    public void SpawnHazard()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8, 8), -4);
        GameObject newHazard = Instantiate(hazardPrefab, spawnPoint, Quaternion.identity);
        instantiatedObjects.Add(newHazard);
        if(instantiatedObjectsBeingSlowed == true)
        {
            SlowAllInstantiatedObjects();
        }
    }

    public void SpawnPowerUp()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8, 8), -4);
        int randomPowerUp = Random.Range(1, 6);
        if (randomPowerUp == 1)
        {
            GameObject newPowerUp = Instantiate(powerUpOne, spawnPoint, Quaternion.identity);
            instantiatedObjects.Add(newPowerUp);
            if (instantiatedObjectsBeingSlowed == true)
            {
                SlowAllInstantiatedObjects();
            }
        }
        else if (randomPowerUp == 2)
        {
            GameObject newPowerUp = Instantiate(powerUpTwo, spawnPoint, Quaternion.identity);
            instantiatedObjects.Add(newPowerUp);
            if (instantiatedObjectsBeingSlowed == true)
            {
                SlowAllInstantiatedObjects();
            }
        }
        else if (randomPowerUp == 3)
        {
            GameObject newPowerUp = Instantiate(powerUpThree, spawnPoint, Quaternion.identity);
            instantiatedObjects.Add(newPowerUp);
            if (instantiatedObjectsBeingSlowed == true)
            {
                SlowAllInstantiatedObjects();
            }
        }
        else if (randomPowerUp == 4)
        {
            GameObject newPowerup = Instantiate(powerUpFrenzy, spawnPoint, Quaternion.identity);
            instantiatedObjects.Add(newPowerup);
            if(instantiatedObjectsBeingSlowed == true)
            {
                SlowAllInstantiatedObjects();
            }
        }
        else if (randomPowerUp == 5)
        {
            GameObject newPowerup = Instantiate(powerUpInv, spawnPoint, Quaternion.identity);
            instantiatedObjects.Add(newPowerup);
            if (instantiatedObjectsBeingSlowed == true)
            {
                SlowAllInstantiatedObjects();
            }
        }

    }

    public void StartSlowTimer()
    {
        StartCoroutine("SlowTimer");
    }

    public void SlowAllInstantiatedObjects()
    {    
            foreach (GameObject instantiated in instantiatedObjects)
            {
                instantiated.GetComponent<HazardsAndPowerups>().SlowDown();
            }   
    }

    public void RemoveInstantiatedObjectFromList(GameObject destroyedGameObject)
    {
        instantiatedObjects.Remove(destroyedGameObject);
    }

    private IEnumerator HazardSpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(0, maxTimeBetweenHazardSpawns));
        SpawnHazard();
        StartCoroutine(HazardSpawnTimer());
    }

    private IEnumerator PowerUpSpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(0, 2));
        SpawnPowerUp();
        StartCoroutine(HoldPowerUpSpawnUntilOffScreen());
    }

    private IEnumerator HoldPowerUpSpawnUntilOffScreen()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(PowerUpSpawnTimer());
    }

    private IEnumerator SlowTimer()
    {
        SlowAllInstantiatedObjects();
        instantiatedObjectsBeingSlowed = true;
        yield return new WaitForSeconds(timeToSlowObjects);
        instantiatedObjectsBeingSlowed = false;

    }


}
