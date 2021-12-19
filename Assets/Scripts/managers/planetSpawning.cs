using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSpawning : MonoBehaviour
{
    public int maxSpawn = 5;
    public GameObject[] spawnPoints;
    public GameObject[] planets;

    int[] exPlanets;
    int[] usedPoints;
    int spawnNum, planNum, i, alive;
    float t1;
    int t2, t3;
    IEnumerator spawnCoroutine;

    void Start() {
        // Populate spawn points array with children
        alive = 1;
        spawnNum = transform.childCount;
        planNum = planets.Length;

        spawnPoints = new GameObject[spawnNum];

        for(i = 0; i < spawnNum; i++)
            spawnPoints[i] = this.gameObject.transform.GetChild(i).gameObject;

        // make sure max number of spawns makes sense
        if(maxSpawn > spawnNum)
            maxSpawn = spawnNum;

        Spawning();

    }

    void Update() {
        if(alive == maxSpawn) {
            Spawning();
        }
    }

    void Spawning() {
        if(alive < maxSpawn) {
            t1 = Random.Range(5.0f, 10.0f);
            t2 = Random.Range(0, spawnNum);
            t3 = Random.Range(0, planNum);

            // generate new spot if seat is already taken
            if(this.gameObject.transform.GetChild(t2).childCount == 0) {
                Debug.Log("Initiating spawning in " + t1.ToString() + "seconds....");
                spawnCoroutine = SpawnPlanet(t1, t2, t3);
                StartCoroutine(spawnCoroutine);
                alive += 1;
            } else {
                Spawning();
            }
        }
    }

    public void DecrementCount() {
        if(alive > 0) {
            alive -= 1;
            Spawning();
        }
        else
            Debug.Log("no more planets to despawn...");
    }

    private IEnumerator SpawnPlanet(float waitTime, int pos, int planetType) {
        //wait before spawning to give a breather
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Spawning new planet...");
        Instantiate(planets[planetType], spawnPoints[pos].transform);
        Spawning();
    }
}
