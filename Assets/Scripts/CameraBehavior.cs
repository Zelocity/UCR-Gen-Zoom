using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject scooter; //store reference to scooter object
    private Vector3 offset; //offset distance between the scooter and camera
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - scooter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LateUpdate(){
        transform.position = scooter.transform.position + offset;
    }
}
