using UnityEngine;
using System.Collections;

public class cameraBehaviour : MonoBehaviour {

    public Transform followThis;

    public float radius = 10;
    public float angle = 0;

    public float runningSpeed = 5f;
    public float turningSpeed = 5f;
    public float zoomSpeed = 5f;

    public float yOffset = 5f;

    private Vector3 velocity = new Vector3();

    private DroneControlsListener dcl;

    private void Start()
    {
        dcl = followThis.GetComponent<DroneControlsListener>();
    }
    void Update()
    {
        if (false) angle -= turningSpeed * Time.deltaTime;
        if (false) angle += turningSpeed * Time.deltaTime;

        if (dcl.Rotational.y == 1) radius -= zoomSpeed * Time.deltaTime;
        if (dcl.Rotational.y == -1) radius += zoomSpeed * Time.deltaTime;


        float x = Mathf.Cos(angle) * radius + followThis.position.x;
        float y = followThis.position.y + radius / 2f;
        float z = Mathf.Sin(angle) * radius + followThis.position.z;

        transform.position = new Vector3(x, y, z);//  Vector3.SmoothDamp(transform.position, new Vector3(x, y, z), ref velocity, runningSpeed);// * Time.deltaTime);
        transform.LookAt(followThis);
    }


}
