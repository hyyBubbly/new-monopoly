using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject scriptObj;//挂选择角色脚本的物体
    public PlayerSelect selectWhich;//获取选择角色脚本中的选择的角色值

    public int selectId;

    // Start is called before the first frame update
    void Start()
    {
        //获取PlayerSelect脚本
        scriptObj = GameObject.Find("PlayerSelectScript");
        selectWhich = scriptObj.GetComponent<PlayerSelect>();
        //获取脚本中的selectid
        selectId = selectWhich.selectid;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}