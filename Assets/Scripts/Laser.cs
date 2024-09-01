using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private GameObject laser;
    private bool shoot;
    private AudioSource audioSource;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.StateMachine.CurrentState == enemy.LaserState)
        {

            if (!shoot)
            {

                Instantiate(laser, transform.position, transform.rotation);
                audioSource.Play();
                shoot = true;
            }
        }
        else
        {
            shoot = false;
        }
    }
}
