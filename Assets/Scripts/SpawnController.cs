using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //public ref to no.of active enemies
    public int activeEnemies = 0;
    [SerializeField]
    GameObject EnemyPrefab;
    private float xPos, yPos, zPos;
    private int startingEnemies = 4;

    private List<GameObject> Enemies = new List<GameObject>();
    
    private void Start()
    {
        xPos = Random.Range(10f, 30f);
        yPos = Random.Range(10f, 30f);
        zPos = Random.Range(10f, 30f);
       for(int i =0;i<startingEnemies;i++)
       { 
            GameObject newEnemy = Instantiate(EnemyPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            activeEnemies++;
            Enemies.Add(newEnemy);
       }
    }

    private void FixedUpdate()
    {
        if(activeEnemies < 2)
        {
            xPos = Random.Range(10f, 30f);
            yPos = Random.Range(10f, 30f);
            zPos = Random.Range(10f, 30f);
            foreach(GameObject enemy in Enemies)
            {
                if(enemy.activeSelf == false)
                {
                    enemy.transform.position = new Vector3(xPos, yPos, zPos);
                    enemy.SetActive(true);
                    activeEnemies++;
                }
            }
        }
    }


}
