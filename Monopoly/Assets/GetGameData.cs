using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int param = GameObject.Find("GameData").GetComponent<GameData>().selectId;
        Debug.Log(param); //���Դ�ֵ�Ƿ�ɹ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
