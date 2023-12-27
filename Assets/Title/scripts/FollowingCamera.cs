using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 offset = new Vector3(0, 1, 2);

    // Start is called before the first frame updateValue
    void Start()
    {
        if(mainCamera != null)
        {
            transform.position = mainCamera.WorldToScreenPoint(mainCamera.transform.position + offset);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
