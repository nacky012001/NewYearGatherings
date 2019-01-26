using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pd_c : MonoBehaviour
{
    int a;
    int b;
    // Start is called before the first frame update
    private void Awake()
    {


    }
    void Start()
    {
        a = 0;
        b = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (a < 100)
        {
            a = a + 1;
        gameObject.transform.position += new Vector3(0, 0.05f, 0);
    }
        while (b < 50)
        {
            b = b + 1;
            gameObject.transform.position += new Vector3(0.05f, 0f, 0);
        }
        
        
          
    }
}


