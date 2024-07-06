using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        Pos = Player.transform.position - gameObject.transform.position;
        Pos.z = 0;
        gameObject.transform.position += Pos;
    }
}
