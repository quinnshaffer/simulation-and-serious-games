using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exercis1_5 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float velocity = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow) == true) velocity += .1f;
        else if (velocity >= .2f) velocity -= .2f;
        else velocity = 0;
        transform.Translate(new Vector3(0, velocity * speed*Time.deltaTime, 0));
        while (transform.position.y > 6) transform.Translate(new Vector3(0, -12, 0));
        Debug.Log(velocity);
    }
}
