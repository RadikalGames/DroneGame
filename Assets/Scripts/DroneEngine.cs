using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class DroneEngine : MonoBehaviour,IEngine
{
    //Assign fan

    [SerializeField]
    private Transform fan;
    [SerializeField]
    private float fanspeed = 200f;
    public void initEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb,DroneControlsListener input)
    {
        /* if source of call is Player Drone Controller we use input value if from Enemy drone then Enemyvalue, source ==1 is Player 2 is Enemy*/
        //Adding a force to each engine
      
            Vector3 engineforce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Upandown)) / 4f;
            rb.AddForce(engineforce, ForceMode.Force);
       
           
       
        fan.Rotate(Vector3.up, fanspeed);
    }
    public void UpdateEngine(Rigidbody rb, int Enemyvalue)
    {
        Vector3 engineforce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (Enemyvalue/3f)) / 4f;
        rb.AddForce(engineforce, ForceMode.Force);

        fan.Rotate(Vector3.up, fanspeed);
    }

    
}
