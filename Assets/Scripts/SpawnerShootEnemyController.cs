using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShootEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootProjectile()
    {   
        audioSource.Play();
        Instantiate(shoot, transform.position, Quaternion.identity);
    }


}
