using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed =5f;
    private float leftedge;


    void Start()
    {
        leftedge=Camera.main.ScreenToWorldPoint(Vector3.zero).x-1f;
    }


    private void Update(){
        transform.position+=Vector3.left*speed *Time.deltaTime;
        if(transform.position.x<leftedge){
            Destroy(gameObject);
        }
    }
   
}
