using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour
{

    //1游戏数据的保存，和场景之间游戏数据的的传递使用PlayerPrefs
    //2场景的分类 
            //2.1开始场景
            //2.2角色选择界面
            //2.3游戏玩家打怪的界面，就是游戏实际的运行场景、村庄、野兽。。。
    //开始游戏
   public void OnNewGame()
    {//加载我们的选择角色的场景2.2
        PlayerPrefs.SetInt("DataFromSave", 0);
    }
    //加载已经保存的游戏
    public void OnLoadGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);//DataFromSave保存数据
        //加载场景2.3
        

    }
}
