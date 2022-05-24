using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] deadBody;
    [SerializeField] int randomNumberStart;
    [SerializeField] int randomNumberBusy;
    [SerializeField] int randomNumberNormal;
    [SerializeField] int randomNumberLone;
    [SerializeField] int howmanyBusy;
    [SerializeField] int howmanyNormal;
    [SerializeField] int howmanyLone;
    [SerializeField] int howmanyRounds;

    private void Start()
    {
        StartCoroutine(StartSpawning());
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
    }

    void SpawnNext()
    {
        GameObject newDeadBody = Instantiate(deadBody[Random.Range(0, deadBody.Length)]);
        Vector3 randomPosition = new Vector3(Random.Range(0f, 3f), 0, 0);
        newDeadBody.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1) + randomPosition;
    }
}
