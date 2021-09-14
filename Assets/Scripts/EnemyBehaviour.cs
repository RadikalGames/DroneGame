using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //private Serialzied variables
    [SerializeField]
    private float movementSpeed = 40f;
    [SerializeField]
    private float rotationSpeed = 40f;
    
    private ScoreManager scm;
   
    private SpawnController spwn;


    //private Variables
    private bool isWandering = false;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;
    private bool isMoving = false;
    private bool isGoingUp = false;
    private bool isGoingDown = false;
    private bool isUp = false;

    private Rigidbody rb;


    private void Start()
    {
        scm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        spwn = GameObject.Find("Spawner").GetComponent<SpawnController>();
    }

    public void OnKilled()
    {
        gameObject.SetActive(false);
        scm.AddScore();
        spwn.activeEnemies--;
    }
    


}
