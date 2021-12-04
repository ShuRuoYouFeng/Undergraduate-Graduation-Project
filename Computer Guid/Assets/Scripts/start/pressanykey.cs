using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressanykey : MonoBehaviour
{

    private bool isAnyKeyDown = false;//是否有任何按键按下
    private GameObject buttonContainer;
   
    void Start()
    {
        buttonContainer=this.transform.parent.Find("buttonContainer").gameObject;
    }

   
    void Update()
    {
        if (isAnyKeyDown == false)
        {
            if (Input.anyKey)
            {
                //显示按键
                ShowButton();
            }
        }
    }
    void ShowButton()
    {
        buttonContainer.SetActive(true);
        this.gameObject.SetActive(false);
        isAnyKeyDown = true;
    }
}
