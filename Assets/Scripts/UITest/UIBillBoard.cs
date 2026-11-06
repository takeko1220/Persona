using Unity.Mathematics;
using UnityEngine;

public class UIBillBoard : MonoBehaviour
{

    private void Awake()
    {
        Vector3 plaeyr = Camera.main.transform.position;
        Vector3 thisObject = this.transform.position;

        plaeyr.y = thisObject.y;

        //Vector3 rotate = plaeyr - thisObject;
        transform.LookAt(plaeyr);
        this.transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {

    }
}
