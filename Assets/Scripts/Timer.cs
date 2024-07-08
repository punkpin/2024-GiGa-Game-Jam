using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    [SerializeField] private TextMeshProUGUI timeValue;
    private float time = 0;
    private bool isTiming;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTiming = true;
        timeValue.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTiming){
            time += Time.deltaTime;
            timeValue.text = time.ToString("F1");
        }        
    }

    public void stopTiming(){
        isTiming = false;
    }

    public float getTime(){
        return time;
    }
}
