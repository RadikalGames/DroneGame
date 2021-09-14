using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;


public class DroneController : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField]
    private float dronepitch = 4f;
    [SerializeField]
    private float droneroll = 4f;
    [SerializeField]
    private float droneyaw = 4f;
    #endregion

    #region Private Variables
    private DroneControlsListener dcl;
    private List<IEngine> Engines = new List<IEngine>();
    private Rigidbody rb;
    #endregion
    private void Start()
    {   //Initialize Listener
        dcl = GetComponent<DroneControlsListener>();
        //Initialize Engines
        Engines = GetComponentsInChildren<IEngine>().ToList();
       

        //Initialize rigidbody
        rb = GetComponent<Rigidbody>();
        
        

    }

    private void FixedUpdate()
    {
        foreach (IEngine engine in Engines)
        {
            engine.UpdateEngine(rb, dcl);
        }
        float pitch = dcl.Rotational.y * dronepitch;
        float roll = -dcl.Rotational.x * droneroll;


        Quaternion dronerotation = Quaternion.Euler(pitch,0, roll);
        rb.MoveRotation(dronerotation);
    }


}
