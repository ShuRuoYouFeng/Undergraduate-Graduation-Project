using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory _instance;

    private TweenPosition tween;
    private int coinCount = 1000;//金币数量

    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinNumberLabel;
    public GameObject inventoryItem;

    private void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetId(Random.Range(1001, 1004));
        }
    }
    //拾取到id的物品，并添加到物品栏里面
    //处理拾取物品功能
    public void GetId(int id)
    {
        //第一步查找在所有的物品中是否存在该物品，
        //如果存在 num+1
        //如果不存在，查找空的方格，然后把新创建的inventoryitem放到这个空的方格中
        InventoryItemGrid grid = null;
        foreach(InventoryItemGrid temp in itemGridList)
        {
            if (temp.id == id)
            {
                grid = temp;break;
            }
        }
        if (grid != null)
        {//存在的情况
            grid.PlusNumber();
        }
        else
        {//不存在的情况
            foreach(InventoryItemGrid temp in itemGridList)
            {
                if (temp.id == 0)
                {
                    grid = temp;break;
                }
            }
            if (grid != null)//第三 不过不存在，查找空的方格，然后把新建的inventoryitem放到这个空的方格里面
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 8;
                grid.SetId(id);
            }
        }
    }

    private bool isShow = false;

    private void Show()
    {
        isShow = true;
        tween.PlayForward();
    }

    private void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

   
    
    public void TransformState()
    {//转变状态 显示隐藏
        if (isShow == false)
        {
            Show();
        }
        else
        {
            Hide();
        }

    }
}
