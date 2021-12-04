using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPosition;//位置偏移
    private bool isRotating = false;

    public float distance = 0;
    public float ScrollSpeed = 10;
    public float rotateSpeed = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    void Update()
    {
        transform.position = offsetPosition + player.position;
        //处理视野的旋转
        RotateView();
        //处理视野拉近拉远效果
        ScrollView();
    }

    void ScrollView()
    {
        //print(Input.GetAxis("Mouse ScrollWheel"));//向后返回负值（拉远）向前返回正值（拉近）
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel")*ScrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);//将数字限制在一定范围内
        offsetPosition = offsetPosition.normalized * distance;
    }

    void RotateView()
    {
        // Input.GetAxis("Mouse X");//得到鼠标在水平方向的滑动
        // Input.GetAxis("Mouse Y");
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            transform.RotateAround(player.position,player.up, rotateSpeed * Input.GetAxis("Mouse X"));//点，轴，度
            Vector3 originaPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, transform.right,- rotateSpeed * Input.GetAxis("Mouse Y"));//影响的属性有两个，一个是position，一个是rotation
            float x = transform.eulerAngles.x;

            if (x < 10 || x > 80)
            {//当超出范围之后，我们将属性归为原来的，让旋转无效
                transform.position = originaPos;
                transform.rotation = originalRotation;
            }
            x = Mathf.Clamp(x, 10, 80);
            transform.eulerAngles = new Vector3(x,transform.eulerAngles.y, transform.eulerAngles.z);
        }
        offsetPosition = transform.position - player.position;
    }
}
