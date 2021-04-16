using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideShowPizza : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject myBody;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void hideme()
    {
        myBody.SetActive(false);
    }

    public  void showme()
    {
        myBody.SetActive(true);
    }
}
