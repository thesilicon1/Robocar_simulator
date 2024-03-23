using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSensor : MonoBehaviour
{
    public Rigidbody robotBody;
    // Start is called before the first frame update
    void Start()
    {
        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = robotBody;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        // ����� ����
        float rayLength = 63f;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red); // ��� �����������
            float distance = hit.distance;
            Debug.Log("���������� �� �������: " + distance);
        }
     
    }
}
