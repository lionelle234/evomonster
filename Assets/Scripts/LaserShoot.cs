using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public bool actionFinished, shot;
    [SerializeField] private BoxCollider2D bc2d;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actionFinished)
        {
            Destroy(gameObject);
        }

        
        if (shot)
        {
            if (timer < 0.3)
            {   
                bc2d.enabled = false;   
                timer += Time.deltaTime;
            }
            else
            {
                bc2d.enabled = true;
                timer = 0;
                shot = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shot = true;
            Debug.Log("log");
            collision.gameObject.GetComponent<Player>().Damaged(1);
        }
    }
}
