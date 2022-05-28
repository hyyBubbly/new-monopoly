//Map脚本，挂在了Floor/Map上
//注：将Map脚本的执行顺序提到了PlayerControl的前面

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//地图单元，也就是一个个格子
public class MapUnit
{
    public Vector3 location;//角色所在位置
    //public string direction;//表示角色在这个位置前进的时候坐标增加的方向 x+/x-/z+/z- （y轴不用变，角色一直站在地上）
    public bool ifTurnRight = false;//表示角色在这个位置是否需要右转
    public bool ifTurnLeft = false;//表示角色在这个位置是否需要左转

}


public class Map : MonoBehaviour
{
    /// <summary>
    /// 属性判断
    /// </summary>

    /// <summary>
    /// 地图数组
    /// </summary>
    public MapUnit[] map = new MapUnit[38];//地图上有38个可走的位置,记录的是游戏角色的位置
    
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

    //太蠢了这两个个函数我要单独写藏起来，我实在想不到办法了
    void directionInit()
    {
        //位置下标为2，10，21，31的位置需要右转
        map[2].ifTurnRight = true;
        map[10].ifTurnRight = true;
        map[21].ifTurnRight = true;
        map[31].ifTurnRight = true;
        //位置下标为4，7，13，17，24，27，33，37的位置需要左转
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
        }//y坐标不用变，游戏角色一直走在地上

        //以下设置x和y
        map[0].location.x = 6.25f;
        map[0].location.z = 1.3f;
        for(i=1;i<=2;i++)//从0-2位置，以下以此类推
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
