using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject scriptObj;//��ѡ���ɫ�ű�������
    public PlayerSelect selectWhich;//��ȡѡ���ɫ�ű��е�ѡ��Ľ�ɫֵ

    public int selectId;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡPlayerSelect�ű�
        scriptObj = GameObject.Find("PlayerSelectScript");
        selectWhich = scriptObj.GetComponent<PlayerSelect>();
        //��ȡ�ű��е�selectid
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