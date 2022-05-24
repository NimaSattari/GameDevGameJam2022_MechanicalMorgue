using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpwanPoint : MonoBehaviour
{
    [SerializeField] GameObject power;
    [SerializeField] GameObject[] points;
    [SerializeField] float timer;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timer);
        int number = Random.Range(0, points.Length);
        Instantiate(power, points[number].transform.position, power.transform.localRotation, null);
        StartCoroutine(Spawn());
    }
}
