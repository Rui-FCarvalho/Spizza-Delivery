using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFase : MonoBehaviour
{
    // Start is called before the first frame update
    public acelarate ac;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ac.isPart2)
        {
            this.GetComponent<TextMesh>().text = "Pizza Delivery Phase";
        }
        else
        {
            this.GetComponent<TextMesh>().text = "Acceleration Phase";
            if(ac.rounds > 3)
            {
                this.GetComponent<TextMesh>().text = "<color=purple>Final score: " + ac.score + "\n" + "R to play again</color>";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    ac.rounds = 0;
                    ac.score = 0;
                }
            }
        }
    }
}
