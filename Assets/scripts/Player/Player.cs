using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

public class Player:MonoBehaviour
{

    public SpriteRenderer sr;

    public int id;

    public int position;

    private float moveTotaltime = 0.5f;

    private float movingTimer;
    private bool moving  = false;

    private Vector3 start;
    private Vector3 middle;
    private Vector3 goal;

    public PlayerInformation pi = new PlayerInformation();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            movingTimer += Time.deltaTime;
            float normalizedtime = movingTimer / moveTotaltime;
            if(normalizedtime > 1)
            {
                moving = false;
            }
            else
            {
                transform.position = Vector3.Lerp(Vector3.Lerp(start, middle, normalizedtime), 
                        Vector3.Lerp(middle, goal, normalizedtime), normalizedtime);
            }
        }
    }
    public void initialize(int id)
    {
        this.id = id;

        position = 0;
        sr.color = new Color(Random.value, Random.value, Random.value, 1f);
        pi.color = sr.color;
        Map.map.addPosition(id);
        arrange();
    }
    public void resetPosition()
    {
        position = 0;
        Map.map.setPosition(id, 0);
        arrange();
    }

    private void arrange()
    {
        position = Map.map.getPosition(id);
        int a = Map.map.getArragement(id);
        transform.position = Map.map.getRoute(position);
        transform.position += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
    }
    private IEnumerator move(int number)
    {
        start = transform.position;
        goal = Map.map.getRoute((Map.map.getPosition(id) + 1) % Season.lengthOfSeason);
        if(number == 1)
        {
            Map.map.setPosition(id, (Map.map.getPosition(id) + number) % Season.lengthOfSeason);
            int a = Map.map.getArragement(id);
            goal += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
        }
        for(int i0 = 0;i0 < number; i0++)
        {
            middle = ((start + goal) / 2 + new Vector3(0, (start - goal).sqrMagnitude, 0));
            moving = true;
            movingTimer = 0;
            while (moving)
            {
                yield return null;
            }
            start = Map.map.getRoute((Map.map.getPosition(id) + i0 + 1) % Season.lengthOfSeason);
            goal = Map.map.getRoute((Map.map.getPosition(id) + i0 + 2) % Season.lengthOfSeason);
            if(i0 + 2 == number)
            {
                Map.map.setPosition(id, (Map.map.getPosition(id) + number) % Season.lengthOfSeason);
                int a = Map.map.getArragement(id);
                goal += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
            }
        }
        
    }

    public IEnumerator proceed(int number)
    {
        Debug.Log("proceed");
        //Map.map.setPosition(id,(Map.map.getPosition(id) + number)%Season.lengthOfSeason);
        yield return move(number);
        arrange();
        Map.map.getSquare(position).execute(this);
        yield return null;
    }


}
