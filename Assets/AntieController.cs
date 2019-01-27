using Assets;
using Assets.tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AntieController : MonoBehaviour
{
    public int index;

    public int talkingPercentage;
    public float talkingPeriod;
    public float talkingTimer;

    public Transform wrong;
    public Transform correct;
    public Transform question;

    private Water water;

    private Food food;

    void Start()
    {
        water = new Water();
        food = new Food();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);

        var tranforms = gameObject.transform.GetComponentsInChildren<Transform>(true).ToList();

        if (task != null)
        {
            var ballon = tranforms.Where(t => t.name == "ballon").First();
            ballon.gameObject.SetActive(true);

            var talkings = tranforms.Where(t => t.tag == "talkingSymbol").ToList();
            talkings.Select(t => t.gameObject.GetComponent<ParticleSystem>()).ToList()
                    .ForEach(t => t.Stop());

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
            tranforms.Where(t => t.tag == "dialog").ToList().ForEach(t => t.gameObject.SetActive(false));

            Talking(tranforms);
        }
    }

    public void Talking(List<Transform> transforms)
    {
        talkingTimer += Time.deltaTime;

        if (talkingTimer > talkingPeriod)
        {
            var talkings = transforms.Where(t => t.tag == "talkingSymbol").ToList();

            var percentage = Mathf.RoundToInt(Random.Range(0, 100));

            if (percentage <= talkingPercentage)
            {
                talkings.Select(t => t.gameObject.GetComponent<ParticleSystem>()).ToList()
                        .ForEach(t => t.Play());
            }
            else
            {
                talkings.Select(t => t.gameObject.GetComponent<ParticleSystem>()).ToList()
                        .ForEach(t => t.Stop());
            }

            talkingTimer = 0.0f;
        }
    }

    public void Submit(string prop)
    {
        if (string.IsNullOrEmpty(prop)) return;

        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);
        Transform result = null;
        var position = gameObject.transform.position;
        var resultPosition = new Vector3(position.x + 1.0f, position.y + 1.5f, 0);

        if (task != null)
        {
            switch (task.name)
            {
                case "water":

                    if (water.IsComplete(prop))
                    {
                        task.status = 'S';
                        result = Instantiate(correct, resultPosition, Quaternion.identity);
                    }
                    else
                    {
                        result = Instantiate(wrong, resultPosition, Quaternion.identity);
                    }

                    break;
                case "food":
                    if (food.IsComplete(prop))
                    {
                        task.status = 'S';
                        result = Instantiate(correct, resultPosition, Quaternion.identity);
                    }
                    else
                    {
                        result = Instantiate(wrong, resultPosition, Quaternion.identity);
                    }

                    break;
            }

        }
        else
        {
            result = Instantiate(question, resultPosition, Quaternion.identity);
        }

        if (result != null) result.gameObject.SetActive(true);
    }
}
