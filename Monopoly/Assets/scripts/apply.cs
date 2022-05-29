using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//���ڿ������£�ʵ�ֳ�����ת
public class apply : MonoBehaviour
{
    public InputField input_name;
    public Dropdown input_sex;
    public Dropdown input_level;

    public Image login_tip;

    public GameObject scriptObj;//��ѡ���ɫ�ű�������
    public PlayerSelect selectState;//��ȡѡ���ɫ�ű��еĲ�����ֵ�����Ƿ�ѡ���ɫ

    private float m_timer = 0;

    // Start is called before the first frame update


    void Start()
    {
        login_tip.GetComponent<CanvasGroup>().alpha = 0;

        //������ȡPlayerSelect�ű��еĲ���ֵifSelect
        scriptObj = GameObject.Find("PlayerSelectScript");
        selectState = scriptObj.GetComponent<PlayerSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > 3)
        {
            login_tip.GetComponent<CanvasGroup>().alpha = 0;
            m_timer = 0;
        }
    }

    public void Apply()
    {
        if (input_name.text == "")
        {
            login_tip.GetComponent<CanvasGroup>().alpha = 1;
        }
        if(selectState.ifselect == false)
        {
            login_tip.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
            SceneManager.LoadScene("Main_Scene");
    }

   
}
