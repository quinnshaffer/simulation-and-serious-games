using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecosystemEngine : MonoBehaviour
{
    // Start is called before the first frame update
    chapter1Creature octopus;
    List<Mover2_7> movers = new List<Mover2_7>(); // Now we have multiple Movers!
    Attractor2_7 a;
    void Start()
    {
        octopus = new chapter1Creature();
        int numberOfMovers = 30;
        for (int i = 0; i < numberOfMovers; i++)
        {
            //Vector2 randomLocation = new Vector2(Random.Range(-7f, 7f), Random.Range(-7f, 7f));
            //Vector2 randomVelocity = new Vector2(Random.Range(0f, 5f), Random.Range(0f, 5f));
            //Mover2_7 m = new Mover2_7(Random.Range(0.2f, 1f), randomVelocity, randomLocation); //Each Mover is initialized randomly.
           // movers.Add(m);
        }
        //a = new Attractor2_7();
    }

    // Update is called once per frame
    void Update()
    {
        octopus.move();
        octopus.checkEdges();

        foreach (Mover2_7 m in movers)
        {
            Rigidbody body = m.body;
            Vector2 force = a.Attract(body); // Apply the attraction from the Attractor on each Mover object

            m.ApplyForce(force);
            m.Update();
        }
    }
}
