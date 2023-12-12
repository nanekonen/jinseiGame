using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    //from
    public Vector3 startPosition;
    //to
    public Vector3 targetPosition;
    //movingspeed
    public float moveSpeed = 5f;
    //flag for judging
    private bool isMoving = false;
    //elapsed time
    private float elapsedTime = 0f;
    private bool isMoveStarted = false;
    public float arrivalDuration = 1f;
    private float arrivalElapsedTime = 0f;


    void Start()
    {
        //initialize position
        transform.position = startPosition;
        //start moving
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveStarted)
        {
            elapsedTime += Time.deltaTime;
            arrivalElapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / Vector3.Distance(startPosition, targetPosition) * 2f);
            float easedT = CustomEaseInOut(t);
            transform.position = Vector3.Lerp(startPosition, targetPosition, easedT);

            if (t >= 1.0f && arrivalElapsedTime >= arrivalDuration)
            {
                elapsedTime = 0f;
                arrivalElapsedTime = 0f;
                isMoveStarted = false;
            }
        }
    }
    void StartMovement()
    {
        isMoving = true;
        isMoveStarted = true;
    }

    float CustomEaseInOut(float t)
    {
        return 1f - Mathf.Pow(1f - t, 175f);
    }
}
