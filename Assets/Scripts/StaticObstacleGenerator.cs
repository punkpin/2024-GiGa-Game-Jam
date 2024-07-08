using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using DG.Tweening;
using UnityEngine;

public class StaticObstacleGenerator : MonoBehaviour
{
    [SerializeField] private float generateInterval = 3f;
    private float generateIntervalRange;
    [SerializeField] private float generateDistance; 
    [SerializeField] private GameObject RoadBlock;
    [SerializeField] private GameObject Banana; 
    [SerializeField] private GameObject WaterMelon;
    private int choice;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        generateIntervalRange = Random.Range(generateInterval-1,generateInterval+1);
        for(float distance = 0f; distance <= generateDistance; distance += generateIntervalRange){
            generateObstacle(spawnPos);
            spawnPos.x += generateIntervalRange;
            Debug.Log(spawnPos.x);
            generateIntervalRange = Random.Range(generateInterval-1,generateInterval+1);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generateObstacle(Vector3 position){
        choice = Random.Range(-1,1);
        if(choice == -1){
            Instantiate(Banana, position, Quaternion.identity);
        }else if(choice == 0){
            Instantiate(WaterMelon, position, Quaternion.identity);
        }else{
            Instantiate(RoadBlock, position, Quaternion.identity);
        }
    }


}
