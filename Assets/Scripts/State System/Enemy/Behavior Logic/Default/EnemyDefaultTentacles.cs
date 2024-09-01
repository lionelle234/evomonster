using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Default-Tentacles", menuName = "Enemy Logic/Default Logic/Tentacles")]

public class EnemyDefaultTentacles : EnemyDefaultMachine
{
    private GameObject tentacleH, tentacleV;
    private Rigidbody2D rb2dH, rb2dV;
    private TentacleTriggerCheck tentacleCheck;
    private float timer, timerAtk, timerRetract, timerPrepare, count, counter;
    [SerializeField] private float count1, count2, countAtkH, countAtkV, countRetractH, countRetractV, countPrepare, dirVA, dirVR;
    [SerializeField] private int count3, count4;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        
        timer = 0;
        timerAtk = 0;
        timerRetract = 0;
        timerPrepare = 0;
        count = Random.Range(count1, count2);
        counter = Random.Range(count3, count4);
        tentacleV = enemy.transform.GetChild(0).gameObject;
        tentacleH = enemy.transform.GetChild(1).gameObject;
        rb2dH = tentacleH.GetComponent<Rigidbody2D>();
        rb2dV = tentacleV.GetComponent<Rigidbody2D>();
        tentacleCheck = gameObject.GetComponentInChildren<TentacleTriggerCheck>();

    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();





    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        if (timer < count)
        {   
            if (tentacleCheck.onPlayer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
 
        }
        else
        {
            if (counter > 2)
            {   
                if (timerPrepare < countPrepare)
                {
                    timerPrepare += Time.deltaTime;
                    tentacleV.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    tentacleV.GetComponent<SpriteRenderer>().color = Color.white;

                    if (timerAtk < countAtkV)
                    {
                        timerAtk += Time.deltaTime;
                        rb2dV.AddForce(new Vector3(0, 6) * dirVA, ForceMode2D.Impulse);
                        rb2dV.velocity = Vector3.ClampMagnitude(rb2dV.velocity, 6);
                    }
                    else
                    {
                        rb2dV.velocity = Vector3.zero;

                        if (timerRetract < countRetractV)
                        {

                            timerRetract += Time.deltaTime;
                            tentacleV.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 6) * dirVR, ForceMode2D.Impulse);
                            rb2dV.velocity = Vector3.ClampMagnitude(rb2dV.velocity, 6);
                        }
                        else
                        {
                            rb2dV.velocity = Vector3.zero;
                            count = Random.Range(count1, count2);
                            counter = Random.Range(count3, count4);
                            timer = 0;
                            timerAtk = 0;
                            timerRetract = 0;
                            timerPrepare = 0;

                        }
                    }
                }



            }
            else
            {



                if (timerPrepare < countPrepare)
                {
                    timerPrepare += Time.deltaTime;
                    tentacleH.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {


                    tentacleH.GetComponent<SpriteRenderer>().color = Color.white;

                    if (timerAtk < countAtkH)
                    {
                        timerAtk += Time.deltaTime;
                        tentacleH.GetComponent<Rigidbody2D>().AddForce(new Vector3(6, 0) * -1, ForceMode2D.Impulse);
                        rb2dH.velocity = Vector3.ClampMagnitude(rb2dH.velocity, 6);
                    }
                    else
                    {
                        rb2dH.velocity = Vector3.zero;

                        if (timerRetract < countRetractH)
                        {

                            timerRetract += Time.deltaTime;
                            tentacleH.GetComponent<Rigidbody2D>().AddForce(new Vector3(6, 0), ForceMode2D.Impulse);
                            rb2dH.velocity = Vector3.ClampMagnitude(rb2dH.velocity, 6);
                        }
                        else
                        {
                            rb2dH.velocity = Vector3.zero;
                            count = Random.Range(count1, count2);
                            counter = Random.Range(count3, count4);
                            timer = 0;
                            timerAtk = 0;
                            timerRetract = 0;
                            timerPrepare = 0;

                        }
                    }
                }

            }
        }




    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
