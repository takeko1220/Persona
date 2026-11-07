using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.InputSystem;

public class TargetUi : MonoBehaviour
{
    List<GameObject> rootObject = new List<GameObject>();
    List<GameObject> frontRed = new List<GameObject>();
    List<GameObject> frontCyan = new List<GameObject>();
    List<GameObject> backRed = new List<GameObject>();
    List<GameObject> backCyan = new List<GameObject>();
    GameObject maskObject;
    [SerializeField] List<GameObject> movePosition = new List<GameObject>();
    [SerializeField] private GameObject startPostion;
    float timeCount = 0;

    int positionIndex = 0;
    GameObject nomalScale;
    GameObject maskNomalScale;

    [SerializeField] private GameObject lineImage;
    [SerializeField] private Transform canvas;

    [SerializeField] public List<GameObject> enemyPos = new List<GameObject>();

    int enemyPosIndex;

    private void Awake()
    {
        maskObject = transform.Find("Target_Mask").gameObject;
        nomalScale = this.gameObject;
        maskNomalScale = maskObject;
        enemyPosIndex = (int)enemyPos.Count / 2;
    }

    void Start()
    {
        //if(maskObject != null)
        //{
        //    Debug.Log("!!");
        //}

        //frontRed frontCyan backRed backCyanの順番でリストに入れた。
        rootObject.Add(transform.Find("UIEffect_front").gameObject);
        rootObject.Add(transform.Find("UIEffect_front_Cyan").gameObject);
        for(int i = 0;i < maskObject.transform.childCount; i++)
        {
            rootObject.Add(maskObject.transform.GetChild(i).gameObject);
        }

        //上のオブジェクトを取得
        for (int i = 0; i < rootObject[0].transform.childCount; i++)
        {
            frontRed.Add(rootObject[0].transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < rootObject[1].transform.childCount; i++)
        {
            frontCyan.Add(rootObject[1].transform.GetChild(i).gameObject);
        }

        //下のオブジェクトを取得
        for (int i = 0; i < rootObject[2].transform.childCount; i++)
        {
            backRed.Add(rootObject[2].transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < rootObject[3].transform.childCount; i++)
        {
            backCyan.Add(rootObject[3].transform.GetChild(i).gameObject);
        }

        //オブジェクトを見えなくする
        foreach (var obj in frontRed)
        {
            obj.gameObject.SetActive(false);
        }
        foreach (var obj in frontCyan)
        {
            obj.gameObject.SetActive(false);
        }
        foreach (var obj in backRed)
        {
            obj.gameObject.SetActive(false);
        }
        foreach (var obj in backCyan)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if(enemyPosIndex != 0)
            {
                enemyPosIndex--;
            }
            Debug.Log("a");
            SwitchTarget();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if(enemyPosIndex != enemyPos.Count - 1)
            {
                enemyPosIndex++;
            }
            Debug.Log("d");
            SwitchTarget();
            //ScaleSpeedLine();
        }

        timeCount += Time.deltaTime;
        if (timeCount >= 1.2f)
        {
            positionIndex = Random.Range(0, movePosition.Count);
            maskObject.transform.DOLocalMove(movePosition[positionIndex].transform.localPosition, 0.2f);
            TargetUiAnim();
            timeCount = 0;
        }
    }

    private void OnEnable()
    {
        timeCount = 0;
        maskObject.transform.position = startPostion.transform.position;
        //ScaleSpeedLine();
    }

    private void OnDisable()
    {
        timeCount = 0;
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
                frontRed[i].transform.DOShakeScale(1f, new Vector3(0f, 0.02f, 0f), 10, 10f, false).OnComplete(() => frontRed[index].SetActive(false));
            }
        }
        for (int i = 0; i < frontCyan.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 3);
            if (randomSetActive == 0)
            {
                int index = i;
                frontCyan[i].SetActive(true);
                frontCyan[i].transform.DOShakeScale(1f, new Vector3(0f, 0.02f, 0f), 10, 10f, false).OnComplete(() => frontCyan[index].SetActive(false));
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
                backRed[i].transform.DOShakeScale(1f, new Vector3(0f, 0.02f, 0f), 10, 10f, false).OnComplete(() => backRed[index].SetActive(false));
            }
        }
        for (int i = 0; i < backCyan.Count; i++)
        {
            int randomSetActive = UnityEngine.Random.Range(0, 4);
            if (randomSetActive == 0)
            {
                int index = i;
                backCyan[i].SetActive(true);
                backCyan[i].transform.DOShakeScale(1f, new Vector3(0f, 0.02f, 0f), 10, 10f, false).OnComplete(() => backCyan[index].SetActive(false));
            }
        }
    }

    public void SwitchTarget()
    {
        Sequence seq = DOTween.Sequence();
        maskObject.transform.localPosition = Vector3.zero;
        seq.Append(this.transform.DOScale(new Vector3(0.05f, 0.05f, 0f), 0.1f).SetRelative()
            .OnComplete(() => this.transform.DOScale(new Vector3(-0.05f, -0.05f, 0f), 0.1f).SetRelative().SetDelay(0.5f)));
        seq.Join(maskObject.transform.DOScale(new Vector3(0.06f, 0.06f, 0f), 0.1f).SetRelative()
            .OnComplete(() => maskObject.transform.DOScale(new Vector3(-0.06f, -0.06f, 0f), 0.1f).SetRelative()));

        seq.Append(this.transform.DOMoveX(enemyPos[enemyPosIndex].transform.position.x, 0.2f));
        seq.Join(this.transform.DOMoveY(enemyPos[enemyPosIndex].transform.position.y, 0.2f));
    }

    public void ScaleSpeedLine()
    {
        //インスタンスを生成
        GameObject insObj = Instantiate(lineImage);
        insObj.transform.SetParent(canvas, false);

        RectTransform rectTransform = insObj.GetComponent<RectTransform>();
        //ここで位置の変更
        Vector2 screenPos = Camera.main.WorldToScreenPoint(enemyPos[enemyPosIndex].transform.position);
        rectTransform.position = screenPos;

        rectTransform.localScale = Vector3.one;

        List<GameObject> lineImageTriangle = new List<GameObject>();
        List <GameObject> lineImageTriangleBack = new List<GameObject>();//メインで使うリスト
        //出した線を取得、初期化
        for(int i = 0;i < insObj.transform.childCount; i++)
        {
            lineImageTriangle.Add(insObj.transform.GetChild(i).gameObject);
        }
        for(int i = 0;i < lineImageTriangle.Count;i++)
        {
            lineImageTriangleBack.Add(lineImageTriangle[i].transform.GetChild(0).gameObject);
        }
        foreach(GameObject obj in lineImageTriangleBack)
        {
            obj.SetActive(false);
        }


        for(int i = 0;i < lineImageTriangle.Count; i++)
        {
            int lineIndex = i;
            RectTransform frontTransform = lineImageTriangle[lineIndex].GetComponent<RectTransform>();
            frontTransform.DOScaleY(4f, 1f).OnComplete(() =>
            {
                RectTransform rearTransform = lineImageTriangleBack[lineIndex].GetComponent<RectTransform>();
                rearTransform.localScale = new Vector3(1f, 0.3f, 1f);
                lineImageTriangleBack[lineIndex].SetActive(true);
                frontTransform.pivot = new Vector2(0.5f, 1f);
            });
        }
    }
}
