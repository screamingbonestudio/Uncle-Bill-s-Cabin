using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform UncleBillTransform;
    public Vector3 offset;
    public float fixedZDistance = -10f;
    public float fixedYDistance = 2f;
    public float fixedXDistance = 0f;
    public float cameraHorizontalSpeed;
    public float cameraVerticalSpeed;
    UncleBill uncleBillScript;
    // Start is called before the first frame update
    void Start()
    {
        UncleBillTransform = GameObject.Find("UncleBill").transform;
        UncleBillTransform = GameObject.Find("UncleBill").transform;
        uncleBillScript = UncleBillTransform.GetComponent<UncleBill>();
        cameraHorizontalSpeed = uncleBillScript.UncleBill_Speed;
        cameraVerticalSpeed = uncleBillScript.UncleBill_Jump;
    }

    // Update is called once per frame
    void Update()
    {
        if (UncleBillTransform != null)
        {
            Vector3 desiredPosition = UncleBillTransform.position + new Vector3(fixedXDistance, fixedYDistance, fixedZDistance);
            Vector3 smoothedHorizontalPosition = Vector3.MoveTowards(transform.position, desiredPosition, cameraHorizontalSpeed * Time.deltaTime);
            transform.position = smoothedHorizontalPosition;
        }
    }
}
