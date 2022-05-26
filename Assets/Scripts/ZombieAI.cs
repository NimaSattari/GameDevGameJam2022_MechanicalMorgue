using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] float damage;
    [SerializeField] GameObject model, mylight;
    [SerializeField] ParticleSystem dieEffect;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(player != null)
        {
            agent.destination = player.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().UpdateHealth(-damage);
            GetComponent<BoxCollider>().enabled = false;
            model.SetActive(false);
            mylight.SetActive(false);
            dieEffect.Play();
            Camera camera = Camera.main;
            StartCoroutine(camera.GetComponent<CameraShake>().Shake(0.15f, 0.4f));
            Destroy(gameObject, 2f);
        }
    }

}
