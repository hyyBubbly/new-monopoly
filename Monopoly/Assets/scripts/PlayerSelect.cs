using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    /// <summary>
    /// �˸���ѡ��ɫ
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
    /// ���Դ洢
    /// </summary>
    public float rotationTime = 5f;//�����˶�һ��ʱ��Ϊ5s
    public float restTime = 5f;//��¼ÿ���˶����ڣ�һ�ܣ���ʣ��ʱ��
    private float temp;//��ֹͣת���ĽǶȼ�¼����
    public int selectid = 1;//Ĭ��ѡ���һ����ɫ
    public bool ifselect = false;
    //ͨ������ѡ�н�ɫ��ÿ����ɫ��������һ��͸��Cube�£�Cube�ı�ǩΪClicObj
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
        //���������룬��ȡ��ɫѡ��
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (ifselect)
                    playerTemp = obj;
                else
                    playerTemp = player1;//��ʼ��һ�£���ֹ��ָ�����
                obj = hit.collider.gameObject;
                //ͨ����ǩ
                if (obj.tag == "ClicObj")
                {
                    Debug.Log("����" + obj.name);
                    ifselect = true;//�Ѿ�ѡ�н�ɫ

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

        //ûѡ���ʱ�����п�ѡ��ɫ����תչʾ
        if (!ifselect)
        {
            //ʣ��ʱ�䲻Ϊ0��������y����½Ƕ�ʵ����ת
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
            //ʣ��ʱ��Ϊ0�����һ�����ڣ�ʣ��ʱ����
            //������Ϊ5s
            else
                restTime = 5f;
        }
        //ѡ��֮��ֻ��ѡ�е���ת
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