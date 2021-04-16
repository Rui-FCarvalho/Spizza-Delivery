using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class ReadHardware : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM3", 9600);
    public int input;
    public int input2;
    string read;
    string firstLetter;
    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 7;
        
    }

    void Update()
    {
        if (stream.IsOpen)
        {
            try
            {
                read = stream.ReadLine();
                firstLetter = read[0].ToString();
               // Debug.Log(read);
              //  Debug.Log(firstLetter);
               // Debug.Log(read);
                input = int.Parse(read);
                Debug.Log(input);
                //else
                //{
                //    input2 = int.Parse(read);
                //    //Debug.Log(input2);
                //}
            }
            catch (System.Exception)
            {
            }            
        }
        //this.gameObject.GetComponent<Text>().text = input.ToString();
    }
   
}
