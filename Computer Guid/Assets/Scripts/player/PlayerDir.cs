using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{

    public GameObject effect_click_prefab;

    public Vector3 targetPosition = Vector3.zero;
    private bool isMoving = false;//表示鼠标是否按下
    private playerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        playerMove = this.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UICamera.isOverUI == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//将鼠标的一个点转化为射线
            RaycastHit hitInfo;//碰撞信息
            bool isCollider = Physics.Raycast(ray, out hitInfo);//是否碰撞上什么东西
            if (isCollider & hitInfo.collider.tag == Tags.ground)//碰撞的地方是否是地面
            {
                isMoving = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            //得到要移动的目标位置
            //让角色朝向目标位置

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//将鼠标的一个点转化为射线
            RaycastHit hitInfo;//碰撞信息
            bool isCollider = Physics.Raycast(ray, out hitInfo);//是否碰撞上什么东西
            if (isCollider & hitInfo.collider.tag == Tags.ground)//碰撞的地方是否是地面
            {
                LookAtTarget(hitInfo.point);
            }

        }
        else
        {
            if (playerMove.isMoving)
            {
                LookAtTarget(targetPosition);
            }
        }
    }
    //实例化出来点击的效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //让角色朝向目标位置
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.transform.LookAt(targetPosition);//朝向targetPosition
    }
}
