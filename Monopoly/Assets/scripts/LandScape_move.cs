using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the objects that can move(such as rotation��תȦ��) on the scene
public class LandScape_move : MonoBehaviour
{
    /// <summary>
    /// ���
    /// </summary>
    public GameObject rotationMoney_l;//��ߵ�money
    public GameObject rotationMoney_r;//�ұߵ�money

    /// <summary>
    /// ���Դ洢
    /// </summary>
    public float rotationTime = 5f;//�����˶�һ��ʱ��Ϊ5s
    public float restTime = 5f;//��¼ÿ���˶����ڣ�һ�ܣ���ʣ��ʱ��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ʣ��ʱ�䲻Ϊ0��������y����½Ƕ�ʵ����ת
        if (restTime > 0)
        {
            restTime -= Time.deltaTime;
            rotationMoney_l.transform.rotation = Quaternion.Euler(0.0f, 360 * restTime / rotationTime, 0.0f);//����y��ת
            rotationMoney_r.transform.rotation = Quaternion.Euler(0.0f, 360 * restTime / rotationTime, 0.0f);//����y��ת
        }
        //ʣ��ʱ��Ϊ0�����һ�����ڣ�ʣ��ʱ����������Ϊ5s
        else
            restTime = 5f;

    }
}
