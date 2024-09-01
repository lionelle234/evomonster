using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public ShootStats stats;
    private Player player;
    private Vector3 playerPos;
    private Vector3 moveDir;
    [SerializeField] private bool target;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform.position;
        moveDir = (playerPos - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target)
        {
            rb2d.AddForce(new Vector3(stats.speedX, stats.speedY), ForceMode2D.Impulse);
            rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity, stats.speed);
        }
        else
        {
            rb2d.velocity = moveDir;
        }

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
