using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10; //speed player moves

    private GameObject targetNpc;

    private GameObject targetWidget;
    
    private string holdingObject;

    public void Update()
    {
        MoveForward(); // Player Movement 

        ShowHoldingObject();
    }

    public void ShowHoldingObject()
    {
        var transform = gameObject.transform.GetComponentsInChildren<Transform>(true).ToList();

        if (holdingObject == "water")
        {
            var water = transform.Where(t => t.name == "water").First();
            water.gameObject.SetActive(true);
        }
        else
        {
            transform.Select(t => t.gameObject).Where(t => t.tag == "prop").ToList().ForEach(t => t.gameObject.SetActive(false));
        }
    }

    public void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (targetNpc != null)
            {
                var antieController = targetNpc.GetComponent<AntieController>() as AntieController;
                if (antieController != null)
                {
                    antieController.Submit(holdingObject);
                    holdingObject = null;
                }
            }

            if(targetWidget != null)
            {
                var waterConroller = targetWidget.GetComponent<WaterController>() as WaterController;
                if (waterConroller != null) holdingObject = waterConroller.Use();
            }
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
                FindObjectOfType<NPC7Controller>().GoBack();
                break;
            case "TV":
                FindObjectOfType<TVController>().NextChannel();
                break;
            case "GrandMa":
                FindObjectOfType<GrandMaController>().StartWalk();
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
                FindObjectOfType<GrandMaController>().GoBackFail();
                break;
        }
    }
}


