using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public int BaseScore;
    public float currentScore;
    public TextMesh scoreUI;


    public float extraSpeed_modifier=1;
    public float incrementer_extraSpeed_modifier = 0.5f;
    public acelarate acelarate;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = BaseScore;
    }

    // Update is called once per frame
    void Update()
    {
     
            if (Input.GetKey(KeyCode.Space) && !acelarate.IsPart2)
            {
                currentScore -= Time.deltaTime* extraSpeed_modifier;
                scoreUI.text = ((int)currentScore).ToString();
                extraSpeed_modifier += incrementer_extraSpeed_modifier;
            }
        else
        {
            extraSpeed_modifier = 1;
        }
        
        
    }
}
