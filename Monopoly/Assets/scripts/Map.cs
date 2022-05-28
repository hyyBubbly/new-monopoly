//Map�ű���������Floor/Map��
//ע����Map�ű���ִ��˳���ᵽ��PlayerControl��ǰ��

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//��ͼ��Ԫ��Ҳ����һ��������
public class MapUnit
{
    public Vector3 location;//��ɫ����λ��
    //public string direction;//��ʾ��ɫ�����λ��ǰ����ʱ���������ӵķ��� x+/x-/z+/z- ��y�᲻�ñ䣬��ɫһֱվ�ڵ��ϣ�
    public bool ifTurnRight = false;//��ʾ��ɫ�����λ���Ƿ���Ҫ��ת
    public bool ifTurnLeft = false;//��ʾ��ɫ�����λ���Ƿ���Ҫ��ת

}


public class Map : MonoBehaviour
{
    /// <summary>
    /// �����ж�
    /// </summary>

    /// <summary>
    /// ��ͼ����
    /// </summary>
    public MapUnit[] map = new MapUnit[38];//��ͼ����38�����ߵ�λ��,��¼������Ϸ��ɫ��λ��
    
    // Start is called before the first frame update
    void Start()
    {
        initMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initMap()
    {
        directionInit();
        locationInit();
    }

    //̫������������������Ҫ����д����������ʵ���벻���취��
    void directionInit()
    {
        //λ���±�Ϊ2��10��21��31��λ����Ҫ��ת
        map[2].ifTurnRight = true;
        map[10].ifTurnRight = true;
        map[21].ifTurnRight = true;
        map[31].ifTurnRight = true;
        //λ���±�Ϊ4��7��13��17��24��27��33��37��λ����Ҫ��ת
        map[4].ifTurnLeft = true;
        map[7].ifTurnLeft = true;
        map[13].ifTurnLeft = true;
        map[17].ifTurnLeft = true;
        map[24].ifTurnLeft = true;
        map[27].ifTurnLeft = true;
        map[33].ifTurnLeft = true;
        map[37].ifTurnLeft = true;

    }
    void locationInit()
    {
        int i; 
        for (i = 0; i < 38; i++)
        {
            map[i].location.y = 1.8f;
        }//y���겻�ñ䣬��Ϸ��ɫһֱ���ڵ���

        //��������x��y
        map[0].location.x = 6.25f;
        map[0].location.z = 1.3f;
        for(i=1;i<=2;i++)//��0-2λ�ã������Դ�����
        {
            map[i].location.x = map[i - 1].location.x + 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for(i=3;i<=4;i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z - 1f;
        }
        for(i=5;i<=7;i++)
        {
            map[i].location.x = map[i - 1].location.x + 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for(i=8;i<=10;i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z + 1f;
        }
        for(i=11;i<=13;i++)
        {
            map[i].location.x = map[i - 1].location.x + 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for(i=14;i<=17;i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z + 1f;
        }
        for(i=18;i<=21;i++)
        {
            map[i].location.x = map[i - 1].location.x - 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for(i=22;i<=24;i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z + 1f;
        }
        for(i=25;i<=27;i++)
        {
            map[i].location.x = map[i - 1].location.x - 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for(i=28;i<=31;i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z - 1f;
        }
        for(i=32;i<=33;i++)
        {
            map[i].location.x = map[i - 1].location.x - 1f;
            map[i].location.z = map[i - 1].location.z;
        }
        for (i=34;i<=37; i++)
        {
            map[i].location.x = map[i - 1].location.x;
            map[i].location.z = map[i - 1].location.z - 1f;
        }

    }
}
