using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMover : MonoBehaviour
{
    private const float k_maxLength = 1f;
    private const string k_propName = "_MainTex";

    [SerializeField]
    private Vector3 m_offsetSpeed;
    private Material m_material;

    void Start()
    {
        if(GetComponent<Image>() is Image i)
        {
            m_material = i.material;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (m_material)
        {
            //repeating value of x and y between 0 and 1
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        {
            if (m_material)
            {
                m_material.SetTextureOffset(k_propName, Vector2.zero);
            }
        }
    }
}
