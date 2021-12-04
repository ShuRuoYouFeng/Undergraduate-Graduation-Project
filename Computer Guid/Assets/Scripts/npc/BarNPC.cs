using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC :NPC
{

    public TweenPosition questTween;
    public UILabel desLabel;
    public GameObject acceptBtnGo;
    public GameObject okBtnGo;
    public GameObject cancelBtnGo;
    public bool isInTask = false;//表示是否在任务中
    public int killCount = 0;//表示任务进度，已经杀死了几只小野狼

    private PlayerStatus status;
    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    void OnMouseOver()//当鼠标位于这个collider之上的时候，会在每一帧调用这个方法
    {
        
        if (Input.GetMouseButtonDown(0))//当我们点击了老头
        {
            
           if (isInTask)
            {
                ShowTaskProgress();
            }
            else
            {
                ShowTaskDes();
            }
            ShowQuest();
        }
        
    }
    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }

    void HideQuest()
    {
        questTween.PlayReverse();
    }

    void ShowTaskDes()
    {
        desLabel.text = "任务：\n为了了解操作系统的组成，请帮助老爷爷杀死10只小野狼。\n\n奖励：\n1000金币";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
    }
    void ShowTaskProgress()
    {
        desLabel.text = "任务：\n为了了解操作系统的组成，你已经帮老爷爷杀死了" + killCount + "/10只狼\n\n奖励：\n1000金币";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
    }
    //任务系统 任务对话框上的按钮点击事件的处理
    public void OnCloseButtonClick()
    {
        HideQuest();
    }

    public void OnAcceptButtonClick()
    {
        ShowTaskProgress();
        isInTask = true;//表示在任务中
    }
    public void OnOkButtonClick()
    {
        if (killCount >= 10)
        {//完成任务
            status.GetCoint(1000);
            killCount = 0;
            ShowTaskDes();
        }
        else
        {//没有完成任务
            HideQuest();
        }
    }
    public void OnCancelButtonClick()
    {
        HideQuest();
    }
}
