using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int param = GameObject.Find("GameData").GetComponent<GameData>().selectId;
        Debug.Log(param); //测试传值是否成功

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
