using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingElement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 startPos;
    private float realSize;
    private float size;
    private float movement;

    private void Awake()
    {
        startPos = transform.position;
        size = GetComponent<SpriteRenderer>().size.x;
        float escala = transform.localScale.x;
        realSize = size * escala;
    }


    void Update()
    {
        movement = Mathf.Repeat(speed * Time.time, realSize);
        transform.position = startPos + Vector3.left * movement;

    }
}
