using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody rigidbody1;
    [SerializeField] ParticleSystem dieEffect;
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
            dieEffect.Play();
            Destroy(other.gameObject);
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, 2f);
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
