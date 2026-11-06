using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System;

public class TargetUiTest : MonoBehaviour
{
    List<GameObject> rootObject = new List<GameObject>();
    List<GameObject> frontRed = new List<GameObject>();
    List<GameObject> frontCyan = new List<GameObject>();
    List<GameObject> backRed = new List<GameObject>();
    List<GameObject> backCyan = new List<GameObject>();
    void Start()
    {
        //rootのオブジェクトを取得
        for(int i = 0;i < transform.childCount; i++)
        {
            rootObject.Add(transform.GetChild(i).gameObject);
        }

        //上のオブジェクトを取得
        for(int i = 0;i < rootObject[0].transform.childCount; i++)
        {
            frontRed.Add(rootObject[0].transform.GetChild(i).gameObject);
        }
        for(int i = 0;i < rootObject[1].transform.childCount; i++)
        {
            frontCyan.Add(rootObject[1].transform.GetChild(i).gameObject);
        }

        //下のオブジェクトを取得
        for(int i = 0;i < rootObject[2].transform.childCount; i++)
        {
            backRed.Add(rootObject[2].transform.GetChild(i).gameObject);
        }
        for(int i = 0;i < rootObject[3].transform.childCount; i++)
        {
            backCyan.Add(rootObject[3].transform.GetChild(i).gameObject);
        }

        //オブジェクトを見えなくする
        foreach(var obj in frontRed)
        {
            obj.gameObject.SetActive(false);
        }
        foreach (var obj in frontCyan)
        {
            obj.gameObject.SetActive(false);
        }
        foreach(var obj in backRed)
        {
            obj.gameObject.SetActive(false);
        }
        foreach(var obj in backCyan)
        {
            obj.gameObject.SetActive(false);
        }

    }

    public void TargetUiAnim()
    {
        //オブジェクトを見えるようにする
        //front
        for (int i = 0; i < frontRed.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 3);
            if (randomSetActive == 0)
            {
                int index = i;
                frontRed[i].SetActive(true);
                frontRed[i].transform.DOShakeScale(2f, new Vector3(0f, 0.05f, 0f), 10, 10f, false).OnComplete(() => frontRed[index].SetActive(false));
            }
        }
        for (int i = 0; i < frontCyan.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 3);
            if (randomSetActive == 0)
            {
                int index = i;
                frontCyan[i].SetActive(true);
                frontCyan[i].transform.DOShakeScale(2f, new Vector3(0f, 0.05f, 0f), 10, 10f, false).OnComplete(() => frontCyan[index].SetActive(false));
            }
        }

        //back
        for (int i = 0; i < backRed.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 4);
            if (randomSetActive == 0)
            {
                int index = i;
                backRed[i].SetActive(true);
                backRed[i].transform.DOShakeScale(2f, new Vector3(0f, 0.05f, 0f), 10, 10f, false).OnComplete(() => backRed[index].SetActive(false));
            }
        }
        for (int i = 0; i < backCyan.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 4);
            if (randomSetActive == 0)
            {
                int index = i;
                backCyan[i].SetActive(true);
                backCyan[i].transform.DOShakeScale(2f, new Vector3(0f, 0.05f, 0f), 10, 10f, false).OnComplete(() => backCyan[index].SetActive(false));
            }
        }
    }

    float timeNum = 0;
    private void FixedUpdate()
    {
        timeNum += Time.fixedDeltaTime;
        if(timeNum >= 3.0f)
        {
            TargetUiAnim();
            timeNum = 0;
        }
    }

    private void OnEnable()
    {
        timeNum = 0;
    }

    private void OnDisable()
    {
        timeNum = 0;
    }
}
