using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10; //speed player moves

    public GameObject targetNpc;

    public void Update()
    {

        MoveForward(); // Player Movement 
    }

    public void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.J))//Press up arrow key to move forward on the Y AXIS
        {
            if (targetNpc != null)
                Debug.Log(targetNpc.name);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "npc")
        {
            targetNpc = collider.gameObject;
        }
        if (collider.tag == "npc7")
        {
            FindObjectOfType<NPC7Controller>().GoBack();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "npc")
        {
            targetNpc = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "npc")
        {
            targetNpc = collision.collider.gameObject;
        }   
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "npc")
        {
            targetNpc = null;
        }
    }
}


