using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerControl : MonoBehaviour
{
    

    /// <summary>
    /// �����ж�
    /// </summary>
    public bool isSpaceInput;//��ʱ�Ƿ��¿ո�

    /// <summary>
    /// �����ж�
    /// </summary>
    public bool isGameOver;//��Ϸ�Ƿ����
    public bool alreadyInputSpace;//�����Ƿ��¿ո񣬼��Ƿ��Ѱ��¿ո�Ͷ������
    public bool alreadyRandom;//�Ƿ��Ѿ�Ͷ������
    public bool startMove;//�ƶ��Ƿ�ʼ
    public bool alreadyMove;//�ƶ����

    /// <summary>
    /// ���Դ洢
    /// </summary>
    public string direct = "right";
    public int moveSpeed;
    public int diceCount;//���ӵ���
    public int whoseTurn;//����������˭�Ļغϣ���ҵĻغ�==0������һ�ŵĻغ�==1�����Զ��ŵĻغ�==2�������˸����ж���һ�Σ�whoseTurn==3����ʱ����Ϸ�غ�����һ
    Vector3 moveAmount;
    Vector3 normal = new Vector3(1, 1, 0);
    DateTime startTime;
    /// <summary>
    /// ���
    /// </summary>
    public GameObject actionCanvas;



    // Start is called before the first frame update
    void Start()
    {
        initState();//��ʼ��
        whoseTurn = 0;//��ʼ����ҵĻغ�
    }

    // Update is called once per frame
    private void Update()
    {
        if(!isGameOver)//�����Ϸû�н���
        {
           //��˭�Ļغ�
           if(whoseTurn == 0)//��ҵĻغ�
            {
                if (!alreadyRandom) { throwDicePlayer(); }//�����û�����ӣ���ô���������
                else if (alreadyRandom && !startMove) 
                {
                    startTime = DateTime.Now;
                    movePlayer(startTime); 
                }//������������ӣ�����û���ƶ�����ô�ƶ�
                else if (alreadyMove) { actionPlayer(); }
                else 
                {
                    DateTime currentTime = DateTime.Now;
                    TimeSpan span = currentTime.Subtract(startTime);
                    if(span.Seconds >= 1 * diceCount) 
                    {
                        CancelInvoke("moveOnce");
                        alreadyMove = true; 
                    }//�ƶ����

                }//�ƶ���
            }
           else if(whoseTurn == 1)//����һ�Ļغ�
            {

            }
           else if(whoseTurn == 2)//���Զ��Ļغ�
            {

            }
            else { }
        }
    }
    void initState()//��ʼ��
    {
        isGameOver = false;
        isSpaceInput = false;
        alreadyInputSpace = false;
        alreadyRandom = false;
        startMove = false;
        alreadyMove = false;
        actionCanvas.SetActive(false);
    }
    void throwDicePlayer()//���������
    {
        if (!alreadyInputSpace)//���δ�����¿ո񣬸��¼���Ƿ��¿ո�
        {
            isSpaceInput = Input.GetKey(KeyCode.Space);
            Debug.Log(isSpaceInput);
            if (isSpaceInput)//�����˿ո�
            {
                alreadyInputSpace = true;
            }
        }
        else //�Ѿ������˿ո�׼��Ͷ����
        {
            if (!alreadyRandom)//ûͶ����
            {
                diceCount = UnityEngine.Random.Range(1, 7);//����һ��һ����������������1������6
                alreadyRandom = true;
            }
            else //Ͷ����
            { 
                
            }
        }
    }

    void movePlayer(DateTime startTime)//��ʼ�ƶ�
    {

        InvokeRepeating("moveOnce", 0.5f,1f);
        startMove = true;
        
    }
    void actionPlayer()//�����ж��������Ƿ�������
    {
        actionCanvas.SetActive(true);

    }
    void moveOnce()//�ƶ�һ��
    {
        moveAmount = normal * moveSpeed;
        Vector3 nowPosition = transform.position;

        if (direct == "right")
        { nowPosition.x += moveAmount.x; }

        transform.position = nowPosition;
    }
}
