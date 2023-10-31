using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour
{

    public SpriteRenderer sr;

    //Status
    public string name;
    public int id;
    public bool sex;//true:man,false:woman
    public bool love_interest;//true:man,false:woman
    public int academic;
    public int apperance;
    public Sprite sprite;
    public int luck;
    public List<int> favorability = new List<int>();
    public int lover;
    public int activity;
    public int position;

    public float speed;
    public float error;

    private bool move;
    private Vector3 dst;
    private Vector3 dir;

    private void Awake()
    {
        move = false;
    }
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
        PlayerInformation pi = PlayerInformation.getInformation(id);
        name = pi.name;this.id = id;sex = pi.sex;
        love_interest = pi.love_interest;
        academic = pi.academic;
        apperance = pi.apperance;
        sprite = pi.sprite;
        luck = pi.luck;
        position = 0;
        sr.color = new Color(Random.value, Random.value, Random.value, 1f);
        Map.map.addPosition(id);
        arrangement();
    }

    private void arrangement()
    {
        position = Map.map.getPosition(id);
        int a = Map.map.getArragement(id);
        transform.position = Map.map.route[position];
        transform.position += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
    }

    public void proceed(int number)
    {
        Map.map.setPosition(id,(Map.map.getPosition(id) + number)%GameMain.gameMain.numberOfPlayer);
        arrangement();
        Map.map.getSquare(position).execution(this);
        GameMain.gameMain.turn = true;
    }
}
