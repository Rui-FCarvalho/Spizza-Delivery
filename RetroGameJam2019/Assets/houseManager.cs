using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum House
    {
        Red,
        Green,
        Blue,
        Yellow
    }

public class houseManager : MonoBehaviour

{
    public House currentHouse;

    public Sprite red;
    public Sprite blue;
    public Sprite yellow;
    public Sprite green;

    public House house;

     public void changeHouseColor()
    {
        switch (house)
        {
            case House.Blue:
                this.GetComponent<SpriteRenderer>().sprite = blue;
                break;
            case House.Green:
                this.GetComponent<SpriteRenderer>().sprite = green;
                break;
            case House.Red:
                this.GetComponent<SpriteRenderer>().sprite = red;
                break;
            case House.Yellow:
                this.GetComponent<SpriteRenderer>().sprite = yellow;
                break;
        }
    }
    public House switchHouse()
    {
        switch(Random.Range(0, 4))
        {
            case 0:
                house = House.Red;
                break;
            case 1:
                house = House.Green;
                break;
            case 2:
                house = House.Blue;
                break;
            case 3:
                house = House.Yellow;
                break;
        }
        return house;
    }


    public void enterFase2()
    {
        this.GetComponent<Animator>().SetBool("isExit", false);
        this.GetComponent<Animator>().SetBool("intro2part", true);
    }

    public void ExitFase2()
    {
        this.GetComponent<Animator>().SetBool("intro2part", false);
        this.GetComponent<Animator>().SetBool("isExit", true);
    }
    void Start()
    {
       currentHouse = switchHouse();
       changeHouseColor();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
