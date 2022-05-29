using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the objects that can move(such as rotation“转圈”) on the scene
public class LandScape_move : MonoBehaviour
{
    /// <summary>
    /// 组件
    /// </summary>
    public GameObject rotationMoney_l;//左边的money
    public GameObject rotationMoney_r;//右边的money

    /// <summary>
    /// 属性存储
    /// </summary>
    public float rotationTime = 5f;//设置运动一周时间为5s
    public float restTime = 5f;//记录每个运动周期（一周）的剩余时间

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //剩余时间不为0设置沿着y轴的新角度实现旋转
        if (restTime > 0)
        {
            restTime -= Time.deltaTime;
            rotationMoney_l.transform.rotation = Quaternion.Euler(0.0f, 360 * restTime / rotationTime, 0.0f);//绕着y轴转
            rotationMoney_r.transform.rotation = Quaternion.Euler(0.0f, 360 * restTime / rotationTime, 0.0f);//绕着y轴转
        }
        //剩余时间为0则结束一个周期，剩余时间重新设置为5s
        else
            restTime = 5f;

    }
}
