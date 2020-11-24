﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Fig2 : MonoBehaviour
{
    // Geometry defined in the inspector.
    public float floorY;
    public float leftWallX;
    public float rightWallX;
    public Transform moverSpawnTransform;

    private List<Mover2_2> Movers = new List<Mover2_2>();
    // Define constant forces in our environment
    private Vector3 wind = new Vector3(0.004f, 0f, 0f);
    private Vector3 gravity = new Vector3(0, -0.04f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        // Create copys of our mover and add them to our list
        while (Movers.Count < 30)
        {

            Movers.Add(new Mover2_2(
                        moverSpawnTransform.position,
                        leftWallX,
                        rightWallX,
                        floorY
                    ));
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply the forces to each of the Movers
        foreach (Mover2_2 mover in Movers)
        {
            // ForceMode.Impulse takes mass into account
            Vector3 repelFoce = new Vector3(.01f/(mover.body.transform.position.x-rightWallX), 0,0);
            mover.body.AddForce(wind, ForceMode.Impulse);
            mover.body.AddForce(gravity, ForceMode.Force);
            mover.body.AddForce(repelFoce,ForceMode.Impulse);
            mover.CheckBoundaries();
            Debug.Log(repelFoce);
        }
    }
}

public class Mover2_2
{
    public Rigidbody body;
    private GameObject gameObject;
    private float radius;

    private float xMin;
    private float xMax;
    private float yMin;

    public Mover2_2(Vector3 position, float xMin, float xMax, float yMin)
    {
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;

        // Create the components required for the mover
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body = gameObject.AddComponent<Rigidbody>();
        // Remove functionality that come with the primitive that we don't want
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Object.Destroy(gameObject.GetComponent<SphereCollider>());

        //using our own version of gravity
        body.useGravity = false;

        // Generate random properties for this mover
        radius = Random.Range(0.1f, 0.4f);

        // Place our mover at the specified spawn position relative
        // to the bottom of the sphere
        gameObject.transform.position = position + Vector3.up * radius;

        // The default diameter of the sphere is one unit
        // This means we have to multiple the radius by two when scaling it up
        gameObject.transform.localScale = 2 * radius * Vector3.one;

        // We need to calculate the mass of the sphere.
        // Assuming the sphere is of even density throughout,
        // the mass will be proportional to the volume.
        body.mass = (4f / 3f) * Mathf.PI * radius * radius * radius;
    }

    // Checks to ensure the body stays within the boundaries
    public void CheckBoundaries()
    {
        Vector3 restrainedVelocity = body.velocity;
        if (body.position.y - radius < yMin)
        {
            // Using the absolute value here is an important safe
            // guard for the scenario that it takes multiple ticks
            // of FixedUpdate for the mover to return to its boundaries.
            // The intuitive solution of flipping the velocity may result
            // in the mover not returning to the boundaries and flipping
            // direction on every tick.
            restrainedVelocity.y = Mathf.Abs(restrainedVelocity.y);
        }
        if (body.position.x - radius < xMin)
        {
            restrainedVelocity.x = Mathf.Abs(restrainedVelocity.x);
        }
        else if (body.position.x + radius > xMax)
        {
            restrainedVelocity.x = -Mathf.Abs(restrainedVelocity.x);

        }
        body.velocity = restrainedVelocity;
    }
}