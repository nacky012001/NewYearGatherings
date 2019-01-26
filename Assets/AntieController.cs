using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AntieController : MonoBehaviour
{
    public int index;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var list = FindObjectOfType<main>().gameTasks;

        var task = list.Where(l => l.index == index).FirstOrDefault();
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
}
