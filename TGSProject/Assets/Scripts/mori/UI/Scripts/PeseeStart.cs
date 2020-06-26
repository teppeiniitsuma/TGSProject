using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeseeStart : MonoBehaviour
{
    private bool yes;
    private float alpha;
    private float red, green, blue;
    private float Max = 1.0f;
    [SerializeField] [Header("↓↓0に近づけるほど透明になる")] [Range(0.0f, 1.0f)] private float Mix;
    [SerializeField] [Header("↓↓点滅する速度")] private float speed;

    void Start()
    {
        alpha = GetComponent<SpriteRenderer>().color.a;
        red = GetComponent<SpriteRenderer>().color.r;
        green = GetComponent<SpriteRenderer>().color.g;
        blue = GetComponent<SpriteRenderer>().color.b;
        alpha = 1.0f;
        GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        yes = false;
    }

    private void Aho()
    {
        if(alpha < Mix) { yes = true; }
        else if(alpha > Max) { yes = false; }
    }

    void Update()
    {
        Aho();
        if(yes)
        {
            alpha = alpha + Time.deltaTime * speed;
            GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        }
        else if(!yes)
        {
            alpha = alpha + Time.deltaTime * -speed;
            GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        }
    }
}
