using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if (transform.position != target.position)
        {
        Vector3 tragetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        transform.position =  Vector3.Lerp(transform.position, tragetPosition, smoothing);
        }
    }
}

