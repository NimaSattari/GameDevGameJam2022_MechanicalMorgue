using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DeadBody : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] Image timerImage;
    [SerializeField] GameObject timerFather;
    public bool gb, nb, c, a, v;
    public bool wash, mass, clot, coff, burn, ern, raft, alka;
    public bool stayed;
    public bool done;
    public float zombieTimer = 0;
    public float initalZombieTimer = 10;
    GameObject zombieInstant;

    [SerializeField] int coinGift;

    private void Start()
    {
        zombieTimer = initalZombieTimer;
    }

    void Update()
    {
        zombieTimer -= Time.deltaTime;
        if (zombieTimer <= 0)
        {
            if (zombieInstant == null)
            {
                zombieInstant = Instantiate(zombiePrefab, transform.position, transform.localRotation, null);
                Destroy(gameObject);
            }
        }
        if (stayed)
        {
            timerImage.fillAmount = zombieTimer / initalZombieTimer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            agent = other.GetComponent<NavMeshAgent>();
            if (other.gameObject.GetComponent<PlayerController>().isPickingUp)
            {
                if (agent.isStopped || agent.remainingDistance <= agent.stoppingDistance)
                {
                    print("PickUp");
                    stayed = false;
                    timerFather.gameObject.SetActive(false);
                    zombieTimer = 100;
                    transform.parent = other.gameObject.transform;
                    other.gameObject.GetComponent<PlayerController>().isPickingUp = false;
                    other.gameObject.GetComponent<PlayerController>().pickedUp = true;
                    if (gb)
                    {
                        if (!wash)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("gb", "not");
                        }
                        else if (wash && !mass)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("gb", "wash");
                        }
                        else if (wash && mass && !clot)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("gb", "mass");
                        }
                        else if (wash && mass && clot && !coff)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("gb", "clot");
                        }
                        else if (done)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("gb", "coff");
                        }
                    }
                    if (nb)
                    {
                        if (!wash)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("nb", "not");
                        }
                        else if (wash && !mass)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("nb", "wash");
                        }
                        else if (wash && mass && !clot)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("nb", "mass");
                        }
                        else if (done)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("nb", "clot");
                        }
                    }
                    if (c)
                    {
                        if (!burn)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("c", "not");
                        }
                        else if (burn && !ern)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("c", "burn");
                        }
                        else if (done)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("c", "ern");
                        }
                    }
                    if (a)
                    {
                        if (!mass)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("a", "not");
                        }
                        else if (mass && !alka)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("a", "mass");
                        }
                        else if (mass && alka && !ern)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("a", "alka");
                        }
                        else if (done)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("a", "ern");
                        }
                    }
                    if (v)
                    {
                        if (!wash)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("v", "not");
                        }
                        else if (wash && !mass)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("v", "wash");
                        }
                        else if (wash && mass && !clot)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("v", "mass");
                        }
                        else if (wash && mass && clot && !raft)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("v", "clot");
                        }
                        else if (done)
                        {
                            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().PopulateObjectives("v", "raft");
                        }
                    }
                }
            }
        }
        else if (other.tag == "Machine")
        {
            if (stayed) return;
            zombieTimer = 100;
            if (!agent.gameObject.GetComponent<PlayerController>().isPickingUp && !agent.gameObject.GetComponent<PlayerController>().pickedUp)
            {
                if (/*agent.isStopped || */agent.remainingDistance <= agent.stoppingDistance)
                {
                    print("In Machine");
                    transform.parent = null;
                    GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().DeleteObjectives();
                    if (gb)
                    {
                        stayed = true;
                        if (!wash)
                        {
                            if (other.GetComponent<Machine>().wash)
                            {
                                print("Right");
                                wash = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && !mass)
                        {
                            if (other.GetComponent<Machine>().mass)
                            {
                                print("Right");
                                mass = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && mass && !clot)
                        {
                            if (other.GetComponent<Machine>().clot)
                            {
                                print("Right");
                                clot = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && mass && clot && !coff)
                        {
                            if (other.GetComponent<Machine>().coff)
                            {
                                print("Right");
                                coff = true;
                                done = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                    }
                    if (nb)
                    {
                        stayed = true;
                        if (!wash)
                        {
                            if (other.GetComponent<Machine>().wash)
                            {
                                print("Right");
                                wash = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && !mass)
                        {
                            if (other.GetComponent<Machine>().mass)
                            {
                                print("Right");
                                mass = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && mass && !clot)
                        {
                            if (other.GetComponent<Machine>().clot)
                            {
                                print("Right");
                                clot = true;
                                done = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                    }
                    if (c)
                    {
                        stayed = true;
                        if (!burn)
                        {
                            if (other.GetComponent<Machine>().burn)
                            {
                                print("Right");
                                burn = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (burn && !ern)
                        {
                            if (other.GetComponent<Machine>().ern)
                            {
                                print("Right");
                                ern = true;
                                done = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                    }
                    if (a)
                    {
                        stayed = true;
                        if (!mass)
                        {
                            if (other.GetComponent<Machine>().mass)
                            {
                                print("Right");
                                mass = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (mass && !alka)
                        {
                            if (other.GetComponent<Machine>().alka)
                            {
                                print("Right");
                                alka = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (mass && alka && !ern)
                        {
                            if (other.GetComponent<Machine>().ern)
                            {
                                print("Right");
                                ern = true;
                                done = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                    }
                    if (v)
                    {
                        stayed = true;
                        if (!wash)
                        {
                            if (other.GetComponent<Machine>().wash)
                            {
                                print("Right");
                                wash = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && !mass)
                        {
                            if (other.GetComponent<Machine>().mass)
                            {
                                print("Right");
                                mass = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && mass && !clot)
                        {
                            if (other.GetComponent<Machine>().clot)
                            {
                                print("Right");
                                clot = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                        else if (wash && mass && clot && !raft)
                        {
                            if (other.GetComponent<Machine>().raft)
                            {
                                print("Right");
                                raft = true;
                                done = true;
                                ProcessByMachine(other.transform);
                            }
                            else
                            {
                                print("wrong");
                            }
                        }
                    }
                }
            }
        }
        else if (other.tag == "Finish")
        {
            GameObject.FindGameObjectWithTag("OBJ").GetComponent<ObjectivePanel>().DeleteObjectives();
            if (done)
            {
                agent.gameObject.GetComponent<PlayerController>().UpdateCoin(coinGift);
                print("Well Done");
            }
            else
            {
                print("You Suck");
            }
            Destroy(gameObject);
        }
    }

    private void ProcessByMachine(Transform machineTransform)
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(enumerator(machineTransform));
    }
    IEnumerator enumerator(Transform machineTransform)
    {
        yield return new WaitForSeconds(4f);
        transform.position = machineTransform.position + new Vector3(3, 1.5f - machineTransform.transform.position.y, 0);
        //transform.localEulerAngles = new Vector3(0, 0, 0);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        timerFather.gameObject.SetActive(true);
        zombieTimer = initalZombieTimer;
    }
}