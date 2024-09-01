using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    #region

    //Components
    #region
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Animator eneMator;
    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public CircleCollider2D cc2d;
    #endregion

    //Damage
    #region
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public bool isShielded;
    #endregion



    //Misc
    #region
    private string stateStr;
    [SerializeField] private Material flashMaterial;
    private float flashTimer;
    private Material ogMaterial;
    private Coroutine flashRoutine;
    private string currentAnim;
    public float speedY;
    public int scoreValue;
    public bool flashed;
    public bool actionFinished;
    #endregion

    //Children
    #region
    [HideInInspector] public SpawnerShootEnemyController shoot;
    #endregion

    //Controllers
    #region
    [HideInInspector] public HUDController hud;
    #endregion

    #endregion

    //States
    #region
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyDefaultState DefaultState { get; set; }
    public EnemyAggroState AggroState { get; set; }
    public EnemySecondPhaseState SecondPhase { get; set; }
    public EnemyThirdPhaseState ThirdPhase { get; set; }
    public EnemyLaserState LaserState { get; set; }
    public EnemyDeadState DeadState { get; set; }   
    #endregion

    //Scriptable Objects
    #region
    [SerializeField]
    private EnemyDefaultMachine EnemyDefault;
    [SerializeField]
    private EnemyAggroMachine EnemyAggro;

    public EnemyDefaultMachine EnemyDefaultInstance { get; set; }
    public EnemyAggroMachine EnemyAggroInstance { get; set; }
    #endregion

    //Create
    #region
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        eneMator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        cc2d = GetComponent<CircleCollider2D>();

        flashTimer = 0.1f;
        ogMaterial = spr.material;

        EnemyDefaultInstance = Instantiate(EnemyDefault);
        EnemyAggroInstance = Instantiate(EnemyAggro);

        StateMachine = new EnemyStateMachine();

        DefaultState = new EnemyDefaultState(this, StateMachine);
        AggroState = new EnemyAggroState(this, StateMachine);
        SecondPhase = new EnemySecondPhaseState(this, StateMachine);
        ThirdPhase = new EnemyThirdPhaseState(this, StateMachine);
        LaserState = new EnemyLaserState(this, StateMachine);
        DeadState = new EnemyDeadState(this, StateMachine);

        shoot = GetComponentInChildren<SpawnerShootEnemyController>();

        hud = FindAnyObjectByType<HUDController>();




    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        EnemyDefaultInstance.Initialize(gameObject, this);
        EnemyAggroInstance.Initialize(gameObject, this);

        StateMachine.Create(DefaultState);

    }
    #endregion

    //Update
    #region
    // Update is called once per frame
    void Update()
    {

        StateMachine.CurrentState.Frame();
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
        if (collision.gameObject.tag == "Hazard")
        {
            speedY *= -1;

        }

        if (collision.gameObject.tag == "ShootPlayer")
        {

            collision.gameObject.gameObject.GetComponent<ShootController>().Destroy();

            if (!isShielded)
            {

                Damaged(collision.gameObject.gameObject.GetComponent<ShootController>().stats.dmg);

            }
        }
    }


    #endregion

    //Damage
    #region
    public void Damaged(int dmg)
    {
        Flash();
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            ChangeState("dead");
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

        flashed = true;
        spr.material = flashMaterial;

        yield return new WaitForSeconds(flashTimer);


        spr.material = ogMaterial;

        flashRoutine = null;

    }
    #endregion

    //Change
    #region

    public void ChangeAnimation(string newAnim)
    {
        if (currentAnim == newAnim) return;

        eneMator.Play(newAnim);

        currentAnim = newAnim;
    }
    public void ChangeState(string state)
    {
        stateStr = state;
        EnemyState enemyState = null;
        switch (state)
        {
            case "default":
                enemyState = DefaultState;
                break;
            case "aggro":
                enemyState = AggroState;
                break;
            case "secondphase":
                enemyState = SecondPhase;
                break;
            case "thirdphase":
                enemyState = ThirdPhase;
                break;
            case "laser":
                enemyState = LaserState;
                break;
            case "dead":
                enemyState = DeadState;
                break;



        }
        StateMachine.ChangeState(enemyState);
    }
    #endregion

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void AnimationTrigger(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentState.AnimationTrigger(triggerType);
    }
    public enum AnimationTriggerType
    {

    }
}
