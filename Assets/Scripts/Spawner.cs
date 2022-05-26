using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> bodies;
    [SerializeField] GameObject[] deadBody;
    [SerializeField] int randomNumberStart;
    [SerializeField] int randomNumberBusy;
    [SerializeField] int randomNumberNormal;
    [SerializeField] int randomNumberLone;
    [SerializeField] int howmanyBusy;
    [SerializeField] int howmanyNormal;
    [SerializeField] int howmanyLone;
    [SerializeField] int howmanyRounds;
    bool ender;
    bool alreadyEnded;
    [SerializeField] float allCoins;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject[] starss;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private void Update()
    {
        if (ender && !alreadyEnded)
        {
            if(bodies.Count == 0)
            {
                alreadyEnded = true;
                winPanel.SetActive(true);
                CalculateCoins();
                print("Win");
            }
        }
    }

    void CalculateCoins()
    {
        float playerCoins = (float)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().coin;
        print("Player" + playerCoins);
        float stars = (playerCoins / allCoins) * 100;
        print("Stars" + stars);
        if (stars <= 34)
        {
            starss[0].SetActive(true);
        }
        else if(stars <= 67)
        {
            starss[0].SetActive(true);
            starss[1].SetActive(true);
        }
        else
        {
            starss[0].SetActive(true);
            starss[1].SetActive(true);
            starss[2].SetActive(true);
        }
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(randomNumberStart);
        SpawnNext();
        for (int j = 1; j <= howmanyRounds; j++)
        {
            int whichMode = Random.Range(0, 2);
            switch (whichMode)
            {
                case 0:
                    for (int i = 1; i <= howmanyLone; i++)
                    {
                        yield return new WaitForSeconds(Random.Range(randomNumberNormal, randomNumberLone));
                        SpawnNext();
                    }
                    break;
                case 1:
                    for (int i = 1; i <= howmanyNormal; i++)
                    {
                        yield return new WaitForSeconds(Random.Range(randomNumberBusy, randomNumberNormal));
                        SpawnNext();
                    }
                    break;
                case 2:
                    for (int i = 1; i <= howmanyBusy; i++)
                    {
                        yield return new WaitForSeconds(Random.Range(randomNumberBusy, randomNumberBusy + 2));
                        SpawnNext();
                    }
                    break;
            }
        }
        StartCoroutine(FindZombies());
    }

    IEnumerator FindZombies()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if (zombies.Length == 0 && bodies.Count == 0)
        {
            yield return new WaitForSeconds(0.5f);
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health >= 1)
            {
                ender = true;
            }
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FindZombies());
        }
    }

    void SpawnNext()
    {
        GameObject newDeadBody = Instantiate(deadBody[Random.Range(0, deadBody.Length)]);
        bodies.Add(newDeadBody);
        allCoins += 10;
        Vector3 randomPosition = new Vector3(Random.Range(0f, 3f), 0, 0);
        newDeadBody.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1) + randomPosition;
    }
}
