using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] float Speed = 3;
    [SerializeField] int num = 0;
    Renderer  rend;
     private float alfa = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
        }
        if(num == 1)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                ColorChange();
            }
        }
        if(num == 2)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ColorChange();
            }
        }
        if(num == 3)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                ColorChange();
            }
        }
        if(num == 4)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                ColorChange();
            }
        }
        if(num == 5)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ColorChange();
            }
        }
        alfa -= Speed * Time.deltaTime;
    }
    void ColorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
    }
}