using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerater : MonoBehaviour
{
    [SerializeField] private float timeInterval = 10f;
    [SerializeField] private GameObject ball;
    private float timer;
    private bool canGenerate;
    // Start is called before the first frame update
    void Start()
    {
        canGenerate = true;
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if((timer > timeInterval) && canGenerate){
            SpawnBall();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnBall(){
        Vector3 spawnPos = transform.position;
        GameObject ballObject = Instantiate(ball, spawnPos, Quaternion.identity);

        Destroy(ballObject,60f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            canGenerate = false;
        }
    }
}
