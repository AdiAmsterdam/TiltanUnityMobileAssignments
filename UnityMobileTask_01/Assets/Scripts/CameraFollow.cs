using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float cameraY;
    private void Start()
    {
        cameraY = 750;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, cameraY, target.position.z);
    }
}
