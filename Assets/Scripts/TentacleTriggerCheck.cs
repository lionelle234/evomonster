using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTriggerCheck : MonoBehaviour
{
    [HideInInspector] public bool onPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(onPlayer);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onPlayer = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onPlayer = false;
        }
    }
}
