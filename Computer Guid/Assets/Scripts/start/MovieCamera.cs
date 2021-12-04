using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCamera : MonoBehaviour
{

    public float speed = 10;
    private float endZ = -25;

    void Update()
    {
        if (transform.position.z < endZ)//镜头缓慢移动，还没有到达目标位置
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        
    }
}
