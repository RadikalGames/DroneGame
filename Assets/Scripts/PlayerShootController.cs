using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    private Transform DroneGun;
    [SerializeField]
    private AudioClip laserSound;
    private AudioSource asc;
    
    private void Start()
    {
        asc = GetComponent<AudioSource>();
    }

    public void Shoot()
    {   
        asc.PlayOneShot(laserSound);
        RaycastHit hit;
        if (Physics.Raycast(DroneGun.transform.position, DroneGun.transform.forward, out hit))
        {
            
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<EnemyBehaviour>().OnKilled();
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {  
        if(asc.isPlaying)
        asc.Stop();
    }
    private void OnCollisionExit(Collision collision)
    {
        asc.Play();
    }



}
