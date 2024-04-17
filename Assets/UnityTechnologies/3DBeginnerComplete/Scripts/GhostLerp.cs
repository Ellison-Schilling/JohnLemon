using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLerp : MonoBehaviour
{

    public Vector3 start = new Vector3(-5f, 0f, 0f);
    public Vector3 end = new Vector3(-15f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        start.x =transform.position.x;
        end.x = transform.position.x-10;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.Lerp(start, end, Mathf.PingPong(Time.time, 0.5f));
    }
}
