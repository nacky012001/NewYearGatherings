using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed; //speed player moves

    public float dashDistance;

    public Transform dashStars;

    private GameObject targetNpc;

    private GameObject targetWidget;
    
    private string holdingObject;

    private Rigidbody2D rigidbody2D;
    private List<KeyCode> runKey = new List<KeyCode>() { KeyCode.LeftShift, KeyCode.RightShift };
    private List<KeyCode> actionKey = new List<KeyCode>() { KeyCode.G, KeyCode.L };
    public int playerIndex;

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var direction = new Vector3(Input.GetAxis("P"+ playerIndex + "_Horizontal"), Input.GetAxis("P" + playerIndex + "_Vertical"), 0).normalized;

        if (Input.GetKeyDown(runKey[playerIndex - 1]) && direction.magnitude > 0)
        {
            var lastPosition = gameObject.transform.position;

            rigidbody2D.velocity = new Vector3(dashDistance * direction.x, dashDistance * direction.y, 0);

            var starts = Instantiate(dashStars, lastPosition, Quaternion.Euler(direction.y * 90, direction.x * -90, 0));
            starts.gameObject.SetActive(true);
            starts.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            rigidbody2D.velocity = new Vector3(playerSpeed * Input.GetAxis("P" + playerIndex + "_Horizontal"), playerSpeed * Input.GetAxis("P" + playerIndex + "_Vertical"), 0);
        }
        if (Input.GetKeyDown(actionKey[playerIndex - 1]))
        {
            if (targetNpc != null)
            {
                var antieController = targetNpc.GetComponent<AntieController>() as AntieController;
                if (antieController != null)
                {
                    antieController.Submit(holdingObject);
                    holdingObject = null;
                }

                var tvController = targetNpc.GetComponentInChildren<TVController>() as TVController;
                if (tvController != null)
                {
                    tvController.NextChannel();
                    holdingObject = null;
                }
            }

            if (targetWidget != null)
            {
                var waterConroller = targetWidget.GetComponent<WaterController>() as WaterController;
                if (waterConroller != null) holdingObject = waterConroller.Use();


                var foodController = targetWidget.GetComponent<FoodController>() as FoodController;
                if (foodController != null) holdingObject = foodController.Use();
            }
        }

        ShowHoldingObject();
    }

    public void ShowHoldingObject()
    {
        var transform = gameObject.transform.GetComponentsInChildren<Transform>(true).ToList();

        transform.Select(t => t.gameObject).Where(t => t.tag == "prop").ToList().ForEach(t => t.gameObject.SetActive(false));

        if (holdingObject == "water")
        {
            var water = transform.Where(t => t.name == "water").First();
            water.gameObject.SetActive(true);
        }
        else if(holdingObject == "food") {
            var food = transform.Where(t => t.name == "food").First();
            food.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "npc":
                targetNpc = collider.gameObject;
                break;
            case "widget":
                targetWidget = collider.gameObject;
                break;
            case "npc7":
                collider.gameObject.GetComponent<NPC7Controller>().GoBack();
                break;
            case "GrandMa":
                collider.gameObject.GetComponent<GrandMaController>().StartWalk();
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "npc":
                targetNpc = null;
                break;
            case "widget":
                targetWidget = null;
                break;
            case "GrandMa":
               collider.gameObject.GetComponent<GrandMaController>().GoBackFail();
                break;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);

        switch (collision.collider.tag)
        {
            case "npc":
                targetNpc = collision.collider.gameObject;
                break;
            case "widget":
                targetWidget = collision.collider.gameObject;
                break;
            case "npc7":
                collision.collider.gameObject.GetComponent<NPC7Controller>().GoBack();
                break;
            case "GrandMa":
                collision.collider.gameObject.GetComponent<GrandMaController>().StartWalk();
                break;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "npc":
                targetNpc = null;
                break;
            case "widget":
                targetWidget = null;
                break;
            case "GrandMa":
                collision.collider.gameObject.GetComponent<GrandMaController>().GoBackFail();
                break;
        }
    }
}


