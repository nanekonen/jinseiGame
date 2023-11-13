using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

public class Player:MonoBehaviour
{

    public SpriteRenderer sr;

    public int id; 

    public int position;

    public float speed;
    public float error;
    private bool move;

    private Vector3 dst;
    private Vector3 dir;

    public PlayerInformation pi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += dir * speed;
            if((dst - transform.position).sqrMagnitude < error)
            {
                move = false;
                transform.position = dst;
                Map.map.getSquare(position).execution(this);
            }
        }
    }
    public void initialization(int id)
    {
        this.pi = PlayerInformation.getInformation(id);
        this.id = id;

        position = 0;
        sr.color = new Color(Random.value, Random.value, Random.value, 1f);
        Map.map.addPosition(id);
        arrange();
    }

    private void arrange()
    {
        position = Map.map.getPosition(id);
        int a = Map.map.getArragement(id);
        transform.position = Map.map.getRoute(position);
        transform.position += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
    }

    public void proceed(int number)
    {
        Debug.Log("proceed");
        Map.map.setPosition(id,(Map.map.getPosition(id) + number)%GameMain.gameMain.lengthOfSeason);
        arrange();
        Map.map.getSquare(position).execution(this);
        GameMain.gameMain.turn = true;
    }


}
