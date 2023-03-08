using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform UncleBillTransform;
    [SerializeField]
    private float CameraSpeed = 20;
    [SerializeField]
    private float fixedZDistance = -10f;
    [SerializeField]
    private float fixedYDistance = 2f;
    [SerializeField]
    private float fixedXDistance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        UncleBillTransform = GameObject.Find("UncleBill").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (UncleBillTransform != null)
        {
            Vector3 desiredPosition = UncleBillTransform.position + new Vector3(fixedXDistance, fixedYDistance, fixedZDistance);
            Vector3 smoothedHorizontalPosition = Vector3.MoveTowards(transform.position, desiredPosition, CameraSpeed * Time.deltaTime);
            transform.position = smoothedHorizontalPosition;
        }
    }
}
