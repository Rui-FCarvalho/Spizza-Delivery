using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acelarate : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;
    public float speedIncrement = 0.1f;
    private Animator animator;
    private Animator animatorFire;
    public GameObject hero;
    public GameObject heroFire;
    bool trigger = false;
    private bool end = false;
    public bool isPart2 = false;
    public int roundCounter = 3;
    public houseManager house2;
    public count count;
    public int rounds = 0;

    public bool End
    {
        get { return end; }

        set
        {
            if(end != value && value==true)
            {
                house2.switchHouse();
                house2.changeHouseColor();
                house2.enterFase2();
            }
            if (end != value && value == false)
            {              
                Debug.Log("End Ended");
            }
                end = value;
        }
    }

    public bool IsPart2
    {
        get { return isPart2;}
        set
        {
            if (value != isPart2  && value == false) //sai da parte 2
            {
                timer = 3f;
                count.currentScore = Random.Range(400, 700);
                Debug.Log("hi");
                count.extraSpeed_modifier = 0.5f;
                house2.ExitFase2();
            }
            isPart2 = value;
        }
    }

    int input;

    int removeScore;

    public int score;

    public float timer = 5f;

    void Start()
    {
        velocityModule = GetComponent<ParticleSystem>().velocityOverLifetime;
        animator = hero.GetComponent<Animator>();
        animatorFire = heroFire.GetComponent<Animator>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(house2.house);
        input = GameObject.Find("ArduinoController").GetComponent<ReadHardware>().input;

        if (!IsPart2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
               // Debug.Log("Hi" + trigger);
                velocityModule.zMultiplier += speedIncrement;
                animator.SetBool("isHyper", true);
                animatorFire.SetBool("isHyperFire", true);
                trigger = true;
            }
            if(Input.GetKeyUp(KeyCode.Space) && trigger == true)
            {
                End = true;
            }

            if(end == true) //Começo da parte 2
            {
                IsPart2 = true;
                velocityModule.zMultiplier = 1;
                animator.SetBool("isHyper", false);
                animatorFire.SetBool("isHyperFire", false);
                removeScore = Mathf.Abs((int)count.currentScore);
                if(removeScore >= 100)
                {
                    Debug.Log("You missed");
                    End = false;
                    IsPart2 = false;
                    rounds++;
                    if (rounds == 5)
                    {
                        Debug.Log("End Game");
                    }
                    
                }
            }
        }
        else
        {
            if (input < 40f)
            {
                timer -= Time.deltaTime;
                //Debug.Log(timer);
            }
            if(input >= 40f && timer < 5f)
            {
                timer = 3f;
            }

            if(timer <= 0)
            {
                

                if (house2.house == House.Red)
                {
                    if(input <= 19 && input >= 15)
                    {
                        score += (100 - removeScore);
                        hero.GetComponent<Animator>().SetTrigger("win");
                        Debug.Log("You win");

                    }
                    else
                    {
                        Debug.Log("You lose");
                        hero.GetComponent<Animator>().SetTrigger("lose");
                    }
                }

                if (house2.house == House.Yellow)
                {
                    if (input <= 14 && input >= 10)
                    {
                        score += (100 - removeScore);
                        hero.GetComponent<Animator>().SetTrigger("win");
                        Debug.Log("You win");
 
                    }
                    else
                    {
                        Debug.Log("You lose");
                        hero.GetComponent<Animator>().SetTrigger("lose");

                    }
                }

                if (house2.house == House.Green)
                {
                    if (input <= 9 && input >= 4)
                    {
                        score += (100 - removeScore);
                        hero.GetComponent<Animator>().SetTrigger("win");

                        Debug.Log("You win");
                    }
                    else
                    {
                        Debug.Log("You lose");
                        hero.GetComponent<Animator>().SetTrigger("lose");
                    }
                }

                if (house2.house == House.Blue)
                {
                    if (input <= 4 && input >= 0)
                    {
                        score += (100 - removeScore);
                        hero.GetComponent<Animator>().SetTrigger("win");
                        Debug.Log("You win");
             
                    }
                    else
                    {
                        Debug.Log("You lose");
                        hero.GetComponent<Animator>().SetTrigger("lose");
                    }
                }
                End = false;
                IsPart2 = false;
                rounds++;
                if(rounds >= 3)
                {
                    Debug.Log("End Game");
                }
            }
        }
    }
}
