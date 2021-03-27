using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    //
    //new mission control object to get data
    //new astronaut/suit object to get data
    public GameObject AstronautNode;

    //
    public float x;
    public float y;
    public float z;
    //public Vector3 position = new Vector3(0.0f,0.0f,0.0f);
    public Vector3 pos;
    //public Vector3 transform.position = new Vector3(10, 20, 30);

    // Start is called before the first frame update
    void Start()
    {
        // get component (suit/astronaut/missionCtrl) so you can constantly monitor position through mission and update current coordinates
        Rigidbody suit = AstronautNode.GetComponent<Rigidbody>();
        //gameObject.GetComponent(typeof())
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 astroPosition = AstronautNode.transform.position;
        transform.position = astroPosition;

        //Debug.Log("x: " + x);
        //Debug.Log("y: " + y);
        //Debug.Log("x: " + x);
        pos = transform.position;
        Debug.Log("line " + pos);

    }
}
