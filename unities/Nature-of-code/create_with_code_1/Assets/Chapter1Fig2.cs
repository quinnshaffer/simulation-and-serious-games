using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chapter1Fig2 : MonoBehaviour
{
    // Variables for the location and speed of mover
    private Vector3 location = new Vector3(0F, 0F,0F);
    private Vector3 velocity = new Vector3(0.1F, 0.1F,.2F);

    // Variables to limit the mover within the screen space
    private Vector3 minimumPos, maximumPos;

    // A Variable to represent our mover in the scene
    private GameObject mover;

    // Start is called before the first frame update
    void Start()
    {
        // We want to start by setting the camera's projection to Orthographic mode
        Camera.main.orthographic = true;

        // Next we grab the minimum and maximum position for the screen
        minimumPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maximumPos.z = 6;
        // We now can set the mover as a primitive sphere in unity
        mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
        Camera.main.orthographic = false;
        Debug.Log(maximumPos);
    }

    // Update is called once per frame forever and ever (until you quit).
    void Update()
    {
        // Each frame, we will check to see if the mover has touched a boarder
        // We check if the X/Y position is greater than the max position OR if it's less than the minimum position
        bool xHitBorder = location.x > maximumPos.x || location.x < minimumPos.x;
        bool yHitBorder = location.y > maximumPos.y || location.y < minimumPos.y;
        bool zHitBorder = location.z > maximumPos.z || location.z < minimumPos.z;
        // If the mover has hit at all, we will mirror it's speed with the corrisponding boarder

        if (xHitBorder)
        {
            velocity.x = -velocity.x;
        }

        if (yHitBorder)
        {
            velocity.y = -velocity.y;
        }
        if (zHitBorder) {
            velocity.z = -velocity.z;
            Debug.Log("hit z");
        }
        // Lets now update the location of the mover
        location += velocity;

        // Now we apply the positions to the mover to put it in it's place
        mover.transform.position = new Vector3(location.x, location.y, location.z);
    }
}