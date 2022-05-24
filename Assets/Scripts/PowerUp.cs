using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] bool speed, health, gun;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (speed)
            {
                player.PowerUp("speed");
            }
            if (health)
            {
                player.PowerUp("health");
            }
            if (gun)
            {
                player.PowerUp("gun");
            }
        }
    }
}
