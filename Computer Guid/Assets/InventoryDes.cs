using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDes : MonoBehaviour
{

    public static InventoryDes _instance;
    private UILabel label;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        label = this.GetComponentInChildren<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(int id)
    {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        string des = "";
        switch (info.type)
        {
            case ObjectType.Drug:
                des = GetDrugDes(info);
                break;
        }
        label.text = des;
    }

    string GetDrugDes(ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        str += "+HP:" + info.hp + "\n";
        str += "+MP:" + info.mp + "\n";
        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy;

        return "";
    }
}
