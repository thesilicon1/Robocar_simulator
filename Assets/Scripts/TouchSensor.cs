using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{
    public Rigidbody robotBody;

    // Start is called before the first frame update
    void Start()
    {
        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = robotBody;
        //fixedJoint.breakForce = Mathf.Infinity; // ����� ������ �� ������� ��� �������������
        //fixedJoint.breakTorque = Mathf.Infinity; // �� �� ����� ��� ��������
    }

    void OnCollisionEnter(Collision collision)
    {
        // print(collision.gameObject.name);
        print(1);
    }

    void OnCollisionExit(Collision collision)
    {
        print(0);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
