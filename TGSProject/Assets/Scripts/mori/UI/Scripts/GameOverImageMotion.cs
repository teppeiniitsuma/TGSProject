using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverImageMotion : MonoBehaviour
{
    private Vector2 _imageMotion;
    [SerializeField] [Header("↓↓画像のふり幅")] [Range(0.0f, 100.0f)] private float _imageMotion_time = 0.15f;
    [SerializeField] [Header("↓↓画像の速度")] [Range(0.0f, 20.0f)] private float _imageMotion_speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _imageMotion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(_imageMotion.x, Mathf.Sin
            (Time.time * _imageMotion_speed) * _imageMotion_time + _imageMotion.y);
    }
}
