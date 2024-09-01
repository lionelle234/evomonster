using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShootController : MonoBehaviour
{
    [SerializeField] private GameObject shoot1, shoot2;
    [SerializeField] private AudioClip shoot1Clip, shoot2Clip;
    private GameObject shoot;
    private AudioSource shootSource;

    private void Awake()
    {
        shootSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootProjectile(int shootInt)
    {
        switch (shootInt)
        {
            case 1:
                shoot = shoot1;
                shootSource.clip = shoot1Clip;
                break;
            case 2:
                shoot = shoot2;
                shootSource.clip = shoot2Clip;
                break;

        }
        Instantiate(shoot, transform.position, Quaternion.identity);
        shootSource.Play();
    }
}
