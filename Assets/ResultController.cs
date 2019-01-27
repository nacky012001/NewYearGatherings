using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public float showDuration;
    private float showTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showTimer += Time.deltaTime;

        if (showTimer > showDuration) Destroy(gameObject);
    }
}
