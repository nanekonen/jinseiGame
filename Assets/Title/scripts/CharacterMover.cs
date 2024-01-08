using UnityEngine;
using UnityEngine.UI;

public class CharacterMover : MonoBehaviour
{
    //start, target
    private Vector3 startPosition;
    private Vector3 targetPosition;
    public Vector3 startScale = new Vector3(1f, 1f, 1f);
    public Vector3 endScale = new Vector3(2f, 2f, 2f);

    //execute time
    public float scaleDuration = 2f;
    public float moveDuration = 2f;
    //distance
    public float moveDistance = 200f;
    //wait time
    public float delayTime = 1f;

    //elapsedTime,flag,component
    private float elapsedTime = 0f;
    private bool isAnimationStarted = false;
    private RectTransform rectTransform;

    // Start is called before the first frame updateValue
    void Start()
    {
        //initialize
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = startScale;
        startPosition = rectTransform.anchoredPosition;

        // calculate target
        targetPosition = startPosition - new Vector3(moveDistance, 0f, 0f);

        // start Animation
        Invoke("StartAnimation",delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimationStarted)
        {
            elapsedTime += Time.deltaTime;

            // changing scale
            float tScale = Mathf.Clamp01(elapsedTime / scaleDuration);
            float easedTScale = CustomEaseIn(tScale);
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, easedTScale);

            // moving
            float tMove = Mathf.Clamp01(elapsedTime / moveDuration);
            float easedTMove = CustomEaseIn(tMove);
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, easedTMove);

            // reset
            if (tMove >= 1.0f)
            {
                elapsedTime = 0f;
                isAnimationStarted = false;
            }
        }
    }
    void StartAnimation()
    {
        isAnimationStarted = true;
    }
    float CustomEaseIn(float t)
    {
        return 1f - Mathf.Pow(1f - t, 2f);
    }
}
