using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fluffy : MonoBehaviour
{
    private Vector2 logo;
    [SerializeField][Header("↓↓ロゴのふり幅")][Range(0.0f, 1.0f)]private float logo_time = 0.15f;
    [SerializeField][Header("↓↓ロゴの速度")][Range(0.0f, 5.0f)]private float loge_speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        logo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(logo.x, Mathf.Sin(Time.time * loge_speed) * logo_time + logo.y);
    }
}
