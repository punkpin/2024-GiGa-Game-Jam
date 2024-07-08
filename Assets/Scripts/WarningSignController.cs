using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WarningSignController : MonoBehaviour
{
    [SerializeField] private GameObject WarningSign;
    [SerializeField] private float blinkDuration = 1f;
    [SerializeField] private int blinkCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Blink(){
        WarningSign.SetActive(true);
        Sequence blinkSequence = DOTween.Sequence();
        for(int i = 0; i < blinkCount; i++){
            blinkSequence.Append(WarningSign.GetComponent<Image>().DOFade(0f,blinkDuration / 2f));
            blinkSequence.Append(WarningSign.GetComponent<Image>().DOFade(1f,blinkDuration / 2f));
        }

        blinkSequence.Play();
        Debug.Log("Start blink");
        Invoke("closeSign",3f);
    }

    private void closeSign(){
        WarningSign.SetActive(false);
    }
}
