using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float minLook, maxLook;
    public float x, y;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        x = 280;
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X");
        y += Input.GetAxis("Mouse Y");
        y = Mathf.Clamp(y, minLook, maxLook);
        transform.rotation = Quaternion.Euler(0, x, 0);
        camera.localRotation = Quaternion.Euler(-y, 0, 0);
    }
}
