using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    /// <summary>
    /// 八个可选角色
    /// </summary>
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;

    /// <summary>
    /// 属性存储
    /// </summary>
    public float rotationTime = 5f;//设置运动一周时间为5s
    public float restTime = 5f;//记录每个运动周期（一周）的剩余时间
    private float temp;//把停止转动的角度记录下来
    public int selectid = 1;//默认选择第一个角色
    public bool ifselect = false;
    //通过射线选中角色，每个角色都放在了一个透明Cube下，Cube的标签为ClicObj
    Ray ray;
    RaycastHit hit;
    GameObject obj;
    GameObject playerTemp;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //检测鼠标输入，获取角色选择
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (ifselect)
                    playerTemp = obj;
                else
                    playerTemp = player1;//初始化一下，防止空指针情况
                obj = hit.collider.gameObject;
                //通过标签
                if (obj.tag == "ClicObj")
                {
                    Debug.Log("点中" + obj.name);
                    ifselect = true;//已经选中角色

                    switch (obj.name)
                    {
                        case "select1":
                            selectid = 1;
                            break;
                        case "select2":
                            selectid = 2;
                            break;
                        case "select3":
                            selectid = 3;
                            break;
                        case "select4":
                            selectid = 4;
                            break;
                        case "select5":
                            selectid = 5;
                            break;
                        case "select6":
                            selectid = 6;
                            break;
                        case "select7":
                            selectid = 7;
                            break;
                        case "select8":
                            selectid = 8;
                            break;
                        default: break;
                    }
                }
            }
        }

        //没选择的时候所有可选角色的旋转展示
        if (!ifselect)
        {
            //剩余时间不为0设置沿着y轴的新角度实现旋转
            if (restTime > 0)
            {
                restTime -= Time.deltaTime;
                playerRotate(player1, restTime, rotationTime);
                playerRotate(player2, restTime, rotationTime);
                playerRotate(player3, restTime, rotationTime);
                playerRotate(player4, restTime, rotationTime);
                playerRotate(player5, restTime, rotationTime);
                playerRotate(player6, restTime, rotationTime);
                playerRotate(player7, restTime, rotationTime);
                playerRotate(player8, restTime, rotationTime);
            }
            //剩余时间为0则结束一个周期，剩余时间重
            //新设置为5s
            else
                restTime = 5f;
        }
        //选中之后只让选中的旋转
        else
        {
            if (restTime > 0)
            {
                restTime -= Time.deltaTime;
                playerTemp.transform.rotation = Quaternion.Euler(0.0f, temp, 0.0f);
                playerRotate(obj, restTime, rotationTime);
            }
            else
                restTime = 5f;
        }


    }

    public void playerRotate(GameObject player, float restTime, float rotationTime)
    {
        player.transform.rotation = Quaternion.Euler(0.0f, 360 * restTime / rotationTime, 0.0f);
    }
}