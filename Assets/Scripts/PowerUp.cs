using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] bool speed, health, gun;
    [SerializeField] GameObject speed1, health1, gun1;

    private void Start()
    {
        int number = Random.Range(0, 3);
        if(number == 0)
        {
            speed = true;
            speed1.SetActive(true);
        }
        else if (number == 1)
        {
            health = true;
            health1.SetActive(true);
        }
        else if (number == 2)
        {
            gun = true;
            gun1.SetActive(true);
        }
        StartCoroutine(Die());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (speed)
            {
                player.PowerUp("speed");
                Destroy(gameObject);
            }
            if (health)
            {
                player.PowerUp("health");
                Destroy(gameObject);
            }
            if (gun)
            {
                player.PowerUp("gun");
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
