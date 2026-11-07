using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIMove : MonoBehaviour
{
    [SerializeField]private float UITime = 0.25f;
    [SerializeField] private GameObject nowPlayer;
    private void Awake()
    {
        //Vector3 plaeyr = Camera.main.transform.position;
        //Vector3 thisObject = this.transform.position;

        //plaeyr.y = thisObject.y;

        ////Vector3 rotate = plaeyr - thisObject;
        //transform.LookAt(plaeyr);
        //this.transform.Rotate(0f, 180f, 0f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        this.transform.position = nowPlayer.transform.position;
        GameObject tKeyObject = transform.Find("TKeyRoot").gameObject;
        GameObject wKeyObject = transform.Find("WKeyRoot").gameObject;
        GameObject eKeyObject = transform.Find("EKeyRoot").gameObject;
        GameObject rKeyObject = transform.Find("RKeyRoot").gameObject;
        GameObject cKeyObject = transform.Find("CKeyRoot").gameObject;
        GameObject spaceKeyObject = transform.Find("SpaceKeyRoot").gameObject;
        GameObject orderObject = transform.Find("OrderRoot").gameObject;
        GameObject gunObject = transform.Find("GunRoot").gameObject;
        GameObject personaObject = transform.Find("PersonaRoot").gameObject;
        GameObject itemObject = transform.Find("ItemRoot").gameObject;
        GameObject guardObject = transform.Find("GuardRoot").gameObject;
        GameObject swordObject = transform.Find("SwordRoot").gameObject;
        GameObject other = transform.Find("OtherRoot").gameObject;

        Dictionary<string, Vector3> objectPosition = new Dictionary<string, Vector3>();
        objectPosition.Add("tKey", tKeyObject.transform.position);
        objectPosition.Add("wKey", wKeyObject.transform.position);
        objectPosition.Add("eKey", eKeyObject.transform.position);
        objectPosition.Add("rKey", rKeyObject.transform.position);
        objectPosition.Add("cKey", cKeyObject.transform.position);
        objectPosition.Add("spaceKey", spaceKeyObject.transform.position);
        objectPosition.Add("order", orderObject.transform.position);
        objectPosition.Add("gun", gunObject.transform.position);
        objectPosition.Add("persona", personaObject.transform.position);
        objectPosition.Add("item", itemObject.transform.position);
        objectPosition.Add("guard", guardObject.transform.position);
        objectPosition.Add("sword", swordObject.transform.position);
        Vector3 otherScale = other.gameObject.transform.localScale;

        other.transform.localScale = Vector3.zero;
        //↓動きの初期にいく
        //order
        tKeyObject.gameObject.transform.position += new Vector3(-1f, 1f, 0);/*Translate(-1f, 1f, 0f);*/
        orderObject.gameObject.transform.position += new Vector3(-1f, 0f, 0f);/*Translate(-1f, 0f, 0f);*/
        //gun
        wKeyObject.gameObject.transform.position += new Vector3(-1f, -1f, 0f); /*Translate(-1f, -1f, 0f);*/
        gunObject.gameObject.transform.position += new Vector3(-1f, 0f, 0f);/*Translate(-1f, 0f, 0f);*/
        //persona
        eKeyObject.gameObject.transform.Translate(1f, 1f, 0f);
        personaObject.gameObject.transform.Translate(1f, 0f, 0f);
        //item
        rKeyObject.gameObject.transform.Translate(1f, 1f, 0f);
        itemObject.gameObject.transform.Translate(1f, 0f, 0f);
        //guard
        cKeyObject.gameObject.transform.Translate(1f, 1f, 0f);
        guardObject.gameObject.transform.Translate(1f, 0f, 0f);
        //sword
        spaceKeyObject.gameObject.transform.Translate(1f, 1f, 0f);
        swordObject.gameObject.transform.Translate(1f, 0f, 0f);

        //初期位置に戻る(0.5秒)
        //order
        tKeyObject.gameObject.transform.DOMove(objectPosition["tKey"], UITime);
        orderObject.gameObject.transform.DOMove(objectPosition["order"], UITime);
        //gun
        wKeyObject.gameObject.transform.DOMove(objectPosition["wKey"], UITime);
        gunObject.gameObject.transform.DOMove(objectPosition["gun"], UITime);
        //persona
        eKeyObject.gameObject.transform.DOMove(objectPosition["eKey"], UITime);
        personaObject.gameObject.transform.DOMove(objectPosition["persona"], UITime);
        //item
        rKeyObject.gameObject.transform.DOMove(objectPosition["rKey"], UITime);
        itemObject.gameObject.transform.DOMove(objectPosition["item"], UITime);
        //guard
        cKeyObject.gameObject.transform.DOMove(objectPosition["cKey"], UITime);
        guardObject.gameObject.transform.DOMove(objectPosition["guard"], UITime);
        //sword
        spaceKeyObject.gameObject.transform.DOMove(objectPosition["spaceKey"], UITime);
        swordObject.gameObject.transform.DOMove(objectPosition["sword"], UITime);
        //other
        other.gameObject.transform.DOScale(otherScale, UITime);
    }
}
