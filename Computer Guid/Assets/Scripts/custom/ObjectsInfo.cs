using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour
{

    public static ObjectsInfo _instance;

    private Dictionary<int, ObjectInfo> objectInfoDict = new Dictionary<int, ObjectInfo>();


    public TextAsset objectsInfoListText;

    private void Awake()
    {
        _instance = this;
        ReadInfo();
        print("asdasdasd");
        print(objectInfoDict.Keys.Count);
    }

    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info=null;

        objectInfoDict.TryGetValue(id, out info);

        return info;
    }
    
    void ReadInfo()
    {
        string text = objectsInfoListText.text;
        string[] strArray = text.Split('\n');

        foreach (string str in strArray) {
            string[] proArray = str.Split(',');
            ObjectInfo info =new ObjectInfo();

            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;
            switch (str_type) {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }
            info.id = id;
            info.name = name;
            info.icon_name = icon_name;
            info.type = type;
            if(type == ObjectType.Drug)
            {
                int hp =int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                info.hp = hp;
                info.mp = mp;
                info.price_buy = price_buy;
                info.price_sell = price_sell;
            }

            objectInfoDict.Add(id, info);//添加到字典中，id为key，可以很方便的根据id查找到这个物品信息
        }
    }

}


public enum ObjectType
{
    Drug,
    Equip,
    Mat
}
public class ObjectInfo
{
    public int id;
    public string name;
    public string icon_name;//这个名称是存储在图集中的名称
    public ObjectType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;
}
