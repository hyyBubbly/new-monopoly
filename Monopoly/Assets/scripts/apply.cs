using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//挂在空物体下，实现场景跳转
public class apply : MonoBehaviour
{
    public InputField input_name;
    public Dropdown input_sex;
    public Dropdown input_level;

    public Image login_tip;

    public GameObject scriptObj;//挂选择角色脚本的物体
    public PlayerSelect selectState;//获取选择角色脚本中的布尔真值——是否选择角色

    private float m_timer = 0;

    // Start is called before the first frame update


    void Start()
    {
        login_tip.GetComponent<CanvasGroup>().alpha = 0;

        //后续获取PlayerSelect脚本中的布尔值ifSelect
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
