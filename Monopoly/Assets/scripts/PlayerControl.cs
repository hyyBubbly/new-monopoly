//PlayerControl脚本，挂在了物体Player上

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// 按键判断
    /// </summary>

    /// <summary>
    /// 按键判断
    /// </summary>
    public bool isSpaceInput;//此时是否按下空格

    /// <summary>
    /// 属性判断
    /// </summary>
    public bool isGameOver;//游戏是否结束
    public bool alreadyInputSpace;//曾经是否按下空格，即是否已按下空格投掷骰子
    public bool alreadyRandom;//是否已经投完骰子
    public bool startMove;//移动是否开始
    public bool alreadyMove;//移动完毕

    /// <summary>
    /// 属性存储
    /// </summary>
    public string direct = "right";
    public int moveSpeed;
    public int diceCount;//骰子点数
    public int whoseTurn;//保存现在是谁的回合，玩家的回合==0，电脑一号的回合==1，电脑二号的回合==2，当三人各自行动完一次，whoseTurn==3，此时总游戏回合数加一
    Vector3 moveAmount;
    Vector3 normal = new Vector3(1, 1, 0);
    private float walkSpeed = 2;//角色移动的速度
    private float turnSpeed = 3;//角色转身的速度
    DateTime startTime;
    /// <summary>
    /// 组件
    /// </summary>
    public GameObject actionCanvas;

    /// <summary>
    /// 摄像机跟随相关属性
    /// </summary>
    public Camera myCamera;
    private Vector3 offset = new Vector3(0, 0, 0);//玩家上一个位置，为了实现摄像机视觉跟随
    //private float rotateSpeed = 2;//鼠标控制镜头围绕角色旋转的速度


    // Start is called before the first frame update
    void Start()
    {
        initState();//初始化
        whoseTurn = 0;//开始是玩家的回合

        offset = this.transform.position;//记录角色一开始的位置
    }

    // Update is called once per frame
    private void Update()
    {
        if(!isGameOver)//如果游戏没有结束
        {
           //是谁的回合
           if(whoseTurn == 0)//玩家的回合
            {
                if (!alreadyRandom) { throwDicePlayer(); }//如果还没扔骰子，那么玩家扔骰子
                else if (alreadyRandom && !startMove) 
                {
                    startTime = DateTime.Now;
                    movePlayer(startTime); 
                }//如果扔完了骰子，但还没有移动，那么移动
                else if (alreadyMove) { actionPlayer(); }
                else 
                {
                    DateTime currentTime = DateTime.Now;
                    TimeSpan span = currentTime.Subtract(startTime);
                    if(span.Seconds >= 1 * diceCount) 
                    {
                        CancelInvoke("moveOnce");
                        alreadyMove = true; 
                    }//移动完毕

                }//移动中
            }
           else if(whoseTurn == 1)//电脑一的回合
            {

            }
           else if(whoseTurn == 2)//电脑二的回合
            {

            }
            else { }
        }
    }
    //实现视觉跟随的代码放在LateUpdate(){}里面
    void LateUpdate()
    {
        //摄像机跟随角色移动，移动量=角色当前位置-角色上一个位置
        myCamera.transform.position += this.transform.position - offset;
        offset = this.transform.position;//然后再记录人物位置
        //以下代码实现视角随着鼠标方向旋转
        ////获取鼠标水平方向的输入
        //float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        ////让摄像机以角色的位置，绕Y轴旋转角度
        //myCamera.transform.RotateAround(this.transform.position, Vector3.up, mouseX);
    }


    void initState()//初始化
    {
        isGameOver = false;
        isSpaceInput = false;
        alreadyInputSpace = false;
        alreadyRandom = false;
        startMove = false;
        alreadyMove = false;
        actionCanvas.SetActive(false);
    }
    void throwDicePlayer()//玩家扔骰子
    {
        if (!alreadyInputSpace)//如果未曾按下空格，更新检测是否按下空格
        {
            isSpaceInput = Input.GetKey(KeyCode.Space);
            Debug.Log(isSpaceInput);
            if (isSpaceInput)//按下了空格
            {
                alreadyInputSpace = true;
            }
        }
        else //已经按下了空格，准备投骰子
        {
            if (!alreadyRandom)//没投骰子
            {
                diceCount = UnityEngine.Random.Range(1, 7);//生成一个一到六的整数，包括1，包括6
                alreadyRandom = true;
            }
            else //投完了
            { 
                
            }
        }
    }

    void movePlayer(DateTime startTime)//开始移动
    {

        InvokeRepeating("moveOnce", 0.5f,1f);
        startMove = true;
        
    }
    void actionPlayer()//做出行动，比如是否购买土地
    {
        actionCanvas.SetActive(true);

    }
    void moveOnce()//移动一次
    {
        moveAmount = normal * moveSpeed;
        Vector3 nowPosition = transform.position;

        if (direct == "right")
        { nowPosition.x += moveAmount.x; }

        transform.position = nowPosition;
    }
}
