using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scooterMove : MonoBehaviour
{
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move by letters
        if(Input.GetKey(KeyCode.W)){       //Move forward
            transform.Translate(0.0f, 0f, 0.1f);
        }
        
        if(Input.GetKey(KeyCode.S)){       //Move backward
            transform.Translate(0.0f, 0f, -0.1f);
        }

        if(Input.GetKey(KeyCode.D)){       //Move right
            transform.Translate(-0.1f, 0f, 0.0f);
        }

        if(Input.GetKey(KeyCode.A)){       //Move left
            transform.Translate(0.1f, 0f, 0.0f);
        }
    }
}
