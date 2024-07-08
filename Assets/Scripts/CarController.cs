using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private float scaleTo = 0.5f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private GameObject ObjectToScale;
    [SerializeField] private WarningSignController instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void StartScale(){
        Debug.Log("Start scale");
        ObjectToScale.transform.DOScale(scaleTo,duration).SetEase(Ease.OutBounce);
        Destroy(ObjectToScale,1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("In area");
        if(other.gameObject.CompareTag("Player")){
            instance.Blink();
            Invoke("StartScale",4f);
        }
    }
}
