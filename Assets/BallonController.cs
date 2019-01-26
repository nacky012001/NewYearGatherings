using UnityEngine;

public class BallonController : MonoBehaviour
{
    public float rate = 0.3f;
    public float incrementalTime = 0.2f;

    float currentRate = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        var timer = Time.time;

        var ratio =(Mathf.Sin((timer % 1.0f) * Mathf.PI) + 1) * 0.7f;

        transform.localScale = new Vector3(ratio, ratio, 1);
    }
}
