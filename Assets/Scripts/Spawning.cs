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

    private float maxTimeBetweenHazardSpawns = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HazardSpawnTimer");
        StartCoroutine("HoldPowerUpSpawnUntilOffScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnHazard();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            SpawnPowerUp();
        }
    }


    public void SpawnHazard()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8, 8), -4);
        Instantiate(hazardPrefab, spawnPoint, Quaternion.identity);
    }

    public void SpawnPowerUp()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-8, 8), -4);
        int randomPowerUp = Random.Range(1, 4);
        if(randomPowerUp==1)
        {
            Instantiate(powerUpOne, spawnPoint, Quaternion.identity);
        }
        else if(randomPowerUp==2)
        {
            Instantiate(powerUpTwo, spawnPoint, Quaternion.identity);
        }
        else if(randomPowerUp==3)
        {
            Instantiate(powerUpThree, spawnPoint, Quaternion.identity);
        }
        
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

}

