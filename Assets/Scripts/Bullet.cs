using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody rigidbody1;
    private void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
        StartCoroutine(Die());
    }

    private void LateUpdate()
    {
        rigidbody1.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
        else if(other.tag == "Zombie")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
