using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //grouped each variable
    public GameObject player; //hero
    public GameObject[] spawnPoints;
    public GameObject alien;

    public int maxAliensOnScreen; //how many aliens on screen at a time
    public int totalAliens; //# of aliens hero needs to kill to claim victory
    public int aliensPerSpawn; //how many aliens appear during spawn

    public float minSpawnTime; //rate the aliens appear
    public float maxSpawnTime;

    private int aliensOnScreen = 0; //will track # of aliens on screen .. whether to spawn or not

    private float generatedSpawnTime = 0f; //track time between spawns
    private float currentSpawnTime = 0f; //tack milliseconds since last spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime += Time.deltaTime; //time passed between frames

        if (currentSpawnTime > generatedSpawnTime) 
        {
            currentSpawnTime = 0;
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }

        if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens) //determines whether to spawn or not
        {
            List<int> previousSpawnLocations = new List<int>(); //creates array to track where you spawn each wave

            if (aliensPerSpawn > spawnPoints.Length) //limits # aliens you can spawn by the # of spawn points
            {
                aliensPerSpawn = spawnPoints.Length - 1;
            }

            aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn; //spawning event will never more than the max alien config

            for (int i = 0; i < aliensPerSpawn; i++) //spawning event
            {
                if (aliensOnScreen < maxAliensOnScreen)//makes sure aliensOnScreen is less than max
                {
                    aliensOnScreen += 1;
                    //1 generates spawn point
                    int spawnPoint = -1;
                    //2 runs until it finds a spawn point
                    while (spawnPoint == -1)
                    {
                        //3 random number for spawn point
                        int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                        //4 checks spawn point .. no match you found a spawn point
                        if (!previousSpawnLocations.Contains(randomNumber))
                        {
                            previousSpawnLocations.Add(randomNumber);
                            spawnPoint = randomNumber;
                        }
                    }
                    GameObject spawnLocation = spawnPoints[spawnPoint];
                    GameObject newAlien = Instantiate(alien) as GameObject; //create an instance of prefab

                    newAlien.transform.position = spawnLocation.transform.position; //positions alien at spawnpoint
                    Alien alienScript = newAlien.GetComponent<Alien>(); //reference to alien script
                    alienScript.target = player.transform; //sets target to hero current position
                    Vector3 targetRotation = new Vector3(player.transform.position.x,newAlien.transform.position.y, player.transform.position.z); //rotates alien towards hero
                    newAlien.transform.LookAt(targetRotation);
                }
            }
        }


    }
}
