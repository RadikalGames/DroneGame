using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemydroneController : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField]
    private float dronepitch = 4f;
    [SerializeField]
    private float droneroll = 4f;
    [SerializeField]
    private float droneyaw = 4f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    float pitch = 0.07f;
    float roll = 0.07f;
    #endregion

    #region Private Variables
    private bool isWandering = false;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;
    private bool isMoving = false;
    private bool isGoingUp = false;
    private bool isGoingDown = false;
    private bool isUp = false;
    private bool isConstraining = false;
    
    private List<IEngine> Engines = new List<IEngine>();
    private Rigidbody rb;
    #endregion
    private void Start()
    {   
        //Initialize Engines
        Engines = GetComponentsInChildren<IEngine>().ToList();


        //Initialize rigidbody
        rb = GetComponent<Rigidbody>();



    }

    private void FixedUpdate()
    {
        //Manually clamping height at which enemy drones stay
        if (transform.position.y > 30f)
        {

            rb.AddForce(Vector3.down * movementSpeed);
        }
        if(transform.position.y < 5f)
        {
            rb.AddForce(Vector3.up * movementSpeed);
        }

        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isTurningRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isTurningLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if (isMoving)
        {
            Quaternion dronerotation;
            if (Random.Range(1,3) == 1)
            {
                //dronerotation = Quaternion.Euler(pitch, 0, roll);
                rb.AddForce(Vector3.right * movementSpeed);
            }
            else
            {
                // dronerotation = Quaternion.Euler(-pitch, 0, -roll);
                rb.AddForce(Vector3.left * movementSpeed);
            }
              
           //rb.MoveRotation(dronerotation);
               
            
        }
        if (isGoingUp)
        {
            //foreach(IEngine Engine in Engines)
            // {
            //     Engine.UpdateEngine(rb, 1);
            // }
            rb.AddForce(Vector3.up * movementSpeed);
        }
        if (isGoingDown)
        {
            rb.AddForce(Vector3.down * movementSpeed);
        }
    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 3);
        int moveWait = Random.Range(1, 3);
        int moveTime = Random.Range(1, 5);
        int verticalDirection = Random.Range(1, 3);
        int verticalWait = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(moveWait);
        isMoving = true;
        yield return new WaitForSeconds(moveTime);
        isMoving = false;
        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isTurningLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isTurningLeft = false;
        }
        if (rotateDirection == 2)
        {
            isTurningRight = true;
            yield return new WaitForSeconds(rotationTime);
            isTurningRight = false;
        }
        if (verticalDirection == 1)
        {
            isGoingUp = true;
            yield return new WaitForSeconds(verticalWait);
            isGoingUp = false;
        }
        if (verticalDirection == 2)
        {
            isGoingDown = true;
            yield return new WaitForSeconds(verticalWait);
            isGoingDown = false;
        }

        isWandering = false;



    }
}
