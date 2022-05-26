using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject gunModel;
    [SerializeField] Animator animator;
    NavMeshAgent agent;
    Renderer _renderer;
    [SerializeField] GameObject bullet;

    [SerializeField] Image healthImage;
    public float health;
    [SerializeField] float maxHealth;

    [SerializeField] TextMeshProUGUI coinText;
    public int coin;

    RaycastHit hit;

    LayerMask playerLayerMask = 1 << 6;
    LayerMask groundLayerMask = 1 << 7;
    LayerMask bodyLayerMask = 1 << 8;
    LayerMask machineLayerMask = 1 << 9;

    [SerializeField] bool isSelected;
    public bool isPickingUp, pickedUp;
    GameObject pickedUpDeadBody;

    [SerializeField] bool gun;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();

        health = maxHealth;
        healthImage.fillAmount = health / maxHealth;
    }

    private void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (EventSystem.current.IsPointerOverGameObject())    // is the click on the GUI
            {
                // GUI Action
                return;
            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, bodyLayerMask))
            {
                print("Go To Dead Body");
                pickedUpDeadBody = hit.transform.gameObject;
                agent.destination = pickedUpDeadBody.transform.position + new Vector3(0, 0, 1);
                //_renderer.material.color = Color.red;
                //isSelected = false;
                isPickingUp = true;
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, machineLayerMask))
            {
                print("Move Dead Body To Machine");
                agent.destination = hit.point;
                //_renderer.material.color = Color.red;
                //isSelected = false;
                isPickingUp = false;
                pickedUp = false;
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, groundLayerMask))
            {
                //print("Go To Position");
                agent.destination = hit.point;
                //_renderer.material.color = Color.red;
                //isSelected = false;
            }
        }
        else if (!isSelected && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, playerLayerMask))
            {
                if (hit.transform == transform)
                {
                    print("Select");
                    _renderer.material.color = Color.blue;
                    isSelected = true;
                }
            }
        }

        if (gun && isSelected && Input.GetMouseButtonDown(1))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            animator.SetTrigger("fire");
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), transform.localRotation, null);
        }
        UpdateAnimator();
    }
    private void UpdateAnimator()
    {
        var velocity = agent.velocity;
        var localvelocity = transform.InverseTransformDirection(velocity);
        var speed = localvelocity.z;
        animator.SetFloat("forward", speed);
    }
    public void UpdateHealth(float healthChange)
    {
        health += healthChange;
        healthImage.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            print("Game Over");
            GameObject.FindGameObjectWithTag("PauseWin").GetComponent<PauseWin>().LoseGame();
            Destroy(gameObject);
        }
        else if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void UpdateCoin(int coinChange)
    {
        coin += coinChange;
        coinText.text = coin.ToString();
    }

    public void PowerUp(string power)
    {
        if(power == "speed")
        {
            agent.speed = agent.speed * 1.5f;
            StartCoroutine(PowerDown("speed"));
        }
        else if(power == "health")
        {
            UpdateHealth(20f);
        }
        else if(power == "gun")
        {
            gunModel.SetActive(true);
            gun = true;
            StartCoroutine(PowerDown("gun"));
        }
    }
    public IEnumerator PowerDown(string power)
    {
        yield return new WaitForSeconds(10f);
        if(power == "speed")
        {
            agent.speed = agent.speed / 1.5f;
        }
        else if(power == "gun")
        {
            gunModel.SetActive(false);
            gun = false;
        }
    }
}
