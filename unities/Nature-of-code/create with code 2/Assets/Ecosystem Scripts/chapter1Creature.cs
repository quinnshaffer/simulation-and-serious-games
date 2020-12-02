using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter1Creature
{
    // Start is called before the first frame update
    Vector2 location, acceleration, velocity;
    float topSpeed;
    Vector2 minPosition, maxPosition;
    GameObject octopus = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    bool burst;
    public chapter1Creature()
    {
        
        findWindowLimits();
        location = Vector2.zero; // Vector2.zero is a (0, 0) vector
        velocity = Vector2.zero;
        acceleration = Vector2.zero;
        topSpeed = 2F;
        burst = false;

        // this.ExecRoutine(accelerationState());
    }


    public void move() {

        float accelerationF=Random.Range(0,1000);
        Vector2 slowAcceleration = new Vector2(.1f, 0f);
        Vector2 fastAcceleration = new Vector2(1f, 0f);
        if (burst)
        {
            if (accelerationF <= 10) { 
                burst = false;
                Debug.Log("slow");
            }
        }
        else if (accelerationF <= 5)
        {
            burst = true;
            Debug.Log("burst");
        }
        if (burst) acceleration = fastAcceleration;
        else acceleration = slowAcceleration;

        velocity += acceleration * Time.deltaTime; // Time.deltaTime is the time passed since the last frame.

        // Limit Velocity to the top speed
        velocity = Vector2.ClampMagnitude(velocity, topSpeed);

        // Moves the mover
        location += velocity * Time.deltaTime;
        octopus.transform.position = new Vector2(location.x, location.y);
        Debug.Log("acceleration: "+acceleration);
    }

   /* public IEnumerator accelerationState() {
        
        Debug.Log("Top of the state");
        yield return new WaitForSeconds(2);
       this.ExecRoutine(accelerationAction());
    }

    public IEnumerator accelerationAction() {

        Vector2 slowAcceleration = new Vector2(.1f, 0f);
        Vector2 fastAcceleration = new Vector2(1f, 0f);
        Debug.Log("Top of action");
        acceleration = slowAcceleration;
        yield return new WaitForSeconds(3);
        acceleration = fastAcceleration;
        //MonoBehaviour.StartCoroutine(accelerationState());
        this.ExecRoutine(accelerationState());
    }
    public IEnumerator ExecRoutine(IEnumerator cor) { 
        Debug.Log("exec");
        while (cor.MoveNext())

            yield return cor.Current;

    }*/
    public void checkEdges() {
        if (location.x > maxPosition.x)
        {
            location.x -= maxPosition.x - minPosition.x;
        }
        else if (location.x < minPosition.x)
        {
            location.x += maxPosition.x - minPosition.x;
        }
        if (location.y > maxPosition.y)
        {
            location.y -= maxPosition.y - minPosition.y;
        }
        else if (location.y < minPosition.y)
        {
            location.y += maxPosition.y - minPosition.y;
        }
    }
    private void findWindowLimits() {
        Camera.main.orthographic = true;
        // Next we grab the minimum and maximum position for the screen
        minPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    // Update is called once per frame
    
}
