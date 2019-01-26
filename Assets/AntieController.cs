using Assets;
using Assets.tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AntieController : MonoBehaviour
{
    public int index;

    private Water water;

    private Food food;

    void Start()
    {
        water = new Water();
        food = new Food();
    }

    // Update is called once per frame
    void Update()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);

        var tranforms = gameObject.transform.GetComponentsInChildren<Transform>(true).ToList();
        var ballon = tranforms.Where(t => t.name == "ballon").First();

        if (task != null)
        {
            ballon.gameObject.SetActive(true);

            switch (task.name)
            {
                case "water":
                    var water = tranforms.Where(t => t.name == "water").First();

                    water.gameObject.SetActive(true);

                    break;

                case "food":
                    var food = tranforms.Where(t => t.name == "food").First();

                    food.gameObject.SetActive(true);

                    break;
            }
        }
        else
        {
            ballon.gameObject.SetActive(false);
            var food = tranforms.Where(t => t.name == "food").First();
            food.gameObject.SetActive(false);
            var water = tranforms.Where(t => t.name == "water").First();
            water.gameObject.SetActive(false);
        }
    }

    public void Submit(string prop)
    {

        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);

        if(task != null)
        {
            switch (task.name)
            {
                case "water":
                    if (water.IsComplete(prop))
                    {
                        task.status = 'S';    
                    }

                    break;
                case "food":
                    if (food.IsComplete(prop))
                    {
                        task.status = 'S';
                    }

                    break;
            }
        }
    }
}
