using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Player : MonoBehaviour
{
    //Variables
    #region

    //Components
    #region
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public Animator playerMator;
    [HideInInspector] public CircleCollider2D cc2d;
    [HideInInspector] public PlayerInput playerInput;
    [SerializeField] private AudioSource eatSource;
    private AudioSource audioSource;
    #endregion

    //Movement
    #region
    [HideInInspector] public Vector3 movInput;
    public float moveSpeed;
    public float lungeSpeed;
    public bool limitReach;
    #endregion

    //Shoot
    #region
    private float shootCount;
    private float shootTimer;
    #endregion

    //Input Receivers
    #region
    [HideInInspector] public bool canReceiveInputShoot;
    [HideInInspector] public bool inputReceivedShoot;
    [HideInInspector] public bool canReceiveInputLunge;
    [HideInInspector] public bool inputReceivedLunge;
    [HideInInspector] public bool canReceiveInputShield;
    [HideInInspector] public bool inputReceivedShield;
    [HideInInspector] public bool canReceiveInputMovementUp;
    [HideInInspector] public bool canReceiveInputMovementDown;
    #endregion

    //Children
    #region
    [HideInInspector] public SpawnerShootController shoot;
    #endregion

    //Stats
    #region
    public int maxHealth;
    [HideInInspector] public int foodAmount;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentEvo;
    #endregion

    //Misc
    #region
    [HideInInspector] public string stateStr;
    [HideInInspector]public float startPosX;
    [HideInInspector] public float startPosY;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashTimer;
    private Material ogMaterial;
    private Coroutine flashRoutine;
    public bool isVulnerable;
    [HideInInspector] public bool isLunging;
    private string currentAnim;
    [HideInInspector] public DirectorController director;
    public bool isShooting { get; set; }
    public bool lungePress { get; set; }
    public bool shootPress;
    public int shootLocked = 1;
    public int index = 1;
    public bool actionFinished;
    private bool ate;
    private float timer;
    #endregion

    #endregion


    //States
    #region
    public PlayerStateMachine StateMachine { get; set; }
    public PlayerDefaultState DefaultState { get; set; }
    public PlayerLungeState LungeState { get; set; }
    public PlayerRetreatState RetreatState { get; set; }
    public PlayerEvoState EvoState { get; set; }
    public PlayerShieldState ShieldState { get; set; }
    public PlayerDeadState DeadState { get; set; }
    #endregion


    //Create
    #region
    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        playerMator = GetComponent<Animator>();
        cc2d = GetComponent<CircleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();

        ogMaterial = spr.material;
        

        DefaultState = new PlayerDefaultState(this, StateMachine);
        LungeState = new PlayerLungeState(this, StateMachine);
        RetreatState = new PlayerRetreatState(this, StateMachine);
        EvoState = new PlayerEvoState(this, StateMachine);
        ShieldState = new PlayerShieldState(this, StateMachine);
        DeadState = new PlayerDeadState(this, StateMachine);


        StateMachine = new PlayerStateMachine();


        shoot = GetComponentInChildren<SpawnerShootController>();
        director = FindAnyObjectByType<DirectorController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        currentHealth = maxHealth;
        isVulnerable = true;
        currentEvo = 1;

        

        StateMachine.Create(DefaultState);

    }
    #endregion


    //Update
    #region
    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.Frame();

        if (ate)
        {

            if (timer < 0.3f)
            {
                timer += Time.deltaTime;
                isVulnerable = false;
            }
            else
            {
                timer = 0;
                isVulnerable = true;
                ate = false;
            }
        }

        if (currentEvo == 1)
        {
            shootCount = 0.2f;
        }
        else
        {
            shootCount = 0.13f;
        }


        if (StateMachine.CurrentState == DefaultState)
        {
            if (isShooting)
            {
                if (shootTimer < shootCount)
                {
                    shootTimer += Time.deltaTime;
                }
                else
                {

                    if (inputReceivedShoot)
                    {

                        shoot.ShootProjectile(currentEvo);
                    }
                    else
                    {
                        isShooting = false;
                    }

                    shootTimer = 0;


                }
            }
        }

        //Debug.Log(shootLocked);
        //Debug.Log(StateMachine.CurrentState);

    }


    private void FixedUpdate()
    {
        StateMachine.CurrentState.Physics();


    }
    #endregion


    //Collision
    #region
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            limitReach = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {   
            if (isVulnerable)
            {
                Damaged(1);
            }


        }

        if (collision.gameObject.tag == "Food")
        {
            if (StateMachine.CurrentState == LungeState)
            {
                HUD.instance.EvoUp();
                collision.gameObject.GetComponent<Enemy>().Destroy();
                foodAmount += 1;
                ate = true;
                eatSource.Play();
                if (foodAmount == 3)
                {   
                    HUD.instance.EnableShield();
                    ChangeState("evo");
                }

            }
        }

        if (collision.gameObject.tag == "Restore")
        {
            if (StateMachine.CurrentState == LungeState)
            {
                collision.gameObject.GetComponent<Enemy>().Destroy();

                currentHealth = maxHealth;
                ate = true;
                eatSource.Play();
                HUD.instance.HeartHeal();

            }
        }



        if (collision.gameObject.tag == "ShootEnemy")
        {   
            if (isVulnerable)
            {
                Damaged(collision.gameObject.gameObject.GetComponent<ShootController>().stats.dmg);
                collision.gameObject.gameObject.GetComponent<ShootController>().Destroy();
            }
            else
            {
                collision.gameObject.GetComponent<ShootController>().Destroy();
            }

        }



    }
    #endregion


    //Movement
    #region
    public void OnMovement(InputValue value)
    {   

        movInput = value.Get<Vector2>();
    }

    public void MovementUp()
    {
        
        if (!canReceiveInputMovementUp)
        {

            canReceiveInputMovementUp = true;
            movInput.y = 1;
            
        }
        else
        {
            return;
        }


    }

    public void MovementDown()
    {
        if (!canReceiveInputMovementDown)
        {

            canReceiveInputMovementDown = true;
            movInput.y = -1;

        }
        else
        {
            return;
        }


    }

    public void MovementNeutral()
    {
        if (canReceiveInputMovementUp)
        {

            canReceiveInputMovementUp = false;
            movInput.y = 0;
        }

        if (canReceiveInputMovementDown)
        {
            canReceiveInputMovementDown = false;
            movInput.y = 0;
        }

    }


    #endregion

    //Actions
    #region
    public void OnShoot()
    {


        shootLocked *= -1;

        if (StateMachine.CurrentState == DefaultState)
        {

            if (canReceiveInputShoot)
            {
                if (!inputReceivedShoot)
                {
                    inputReceivedShoot = true;

                    if (!isShooting)
                    {
                        isShooting = true;
                        shoot.ShootProjectile(currentEvo);
                    }


                }
                else
                {
                    inputReceivedShoot = false;
                }



            }

        }




    }

    public void OnLunge()
    {

        if (canReceiveInputLunge)
        {
            if (!inputReceivedLunge)
            {
                inputReceivedLunge = true;
            }
        }

    }

    public void OnShield()
    {   
        if (currentEvo > 1)
        {
            if (canReceiveInputShield)
            {
                if (!inputReceivedShield)
                {
                    inputReceivedShield = true;
                }
            }
        }


    }


    public void OnPause()
    {

        if (Time.timeScale > 0)
        {

            DirectorController.instance.PauseGame();
        }
        else
        {
            DirectorController.instance.UnPauseGame();
        }
    }

    public void OnReturn()
    {
        DirectorController.instance.RestartScene(); 
    }
    #endregion

    //Damage
    #region
    public void Damaged(int dmg)
    {
        HUD.instance.HeartDmg();
        Flash();
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            ChangeState("dead");
        }
        else
        {

            audioSource.Play();
        }

    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        isVulnerable = false;

        spr.material = flashMaterial;

        yield return new WaitForSeconds(flashTimer);

        isVulnerable = true;

        spr.material = ogMaterial;

        flashRoutine = null;
    }
    #endregion

    //Change
    #region

    public void ChangeAnimation(string newAnim)
    {
        if (currentAnim == newAnim) return;

        playerMator.Play(newAnim);

        currentAnim = newAnim;

    }
    public void ChangeState(string state)
    {
        stateStr = state;
        PlayerState playerState = null;
        switch (state)
        {
            case "default":
                playerState = DefaultState;
                break;
            case "lunge":
                playerState = LungeState;
                break;
            case "retreat":
                playerState = RetreatState;
                break;
            case "evo":
                playerState = EvoState;
                break;
            case "shield":
                playerState = ShieldState;
                break;
            case "dead":
                playerState = DeadState;
                break;



        }
        StateMachine.ChangeState(playerState);
    }
    #endregion

    public void Death()
    {

        director.RestartScene();
    }

    //AnimationTriggers
    #region
    private void AnimationTrigger(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentState.AnimationTrigger(triggerType);
    }
    public enum AnimationTriggerType
    {

    }
    #endregion

}
