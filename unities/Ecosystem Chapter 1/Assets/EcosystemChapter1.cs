using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemChapter1 : MonoBehaviour
{
    // Start is called before the first frame update
    private firefly fly;
    [SerializeField] float speed;
    void Start()
    {
        fly = new firefly();
    }
    // Update is called once per frame
    void Update()
    {
        fly.motion(speed);
    }

    public class firefly
    {
        private Vector3 location, velocity, acceleration;
        private float topSpeed;
        private GameObject fireflyGo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        private Vector3 wiggle;
        public firefly()
        {
            location = Vector3.zero;
            velocity = Vector3.zero;
            acceleration = new Vector3(0.1f, .003f, 0.1f);
            topSpeed = 10f;
        }
        public void motion(float speed)
        {
            acceleration= new Vector3(0.1f, .003f, 0.1f);
            wiggle = new Vector3(Mathf.PerlinNoise(location.x, location.y), Mathf.PerlinNoise(location.y, location.z), Mathf.PerlinNoise(location.z, location.x));
            acceleration = wiggle;
            velocity += acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, topSpeed);
            location += velocity * Time.deltaTime * speed;
            fireflyGo.transform.position = new Vector3(location.x, location.y, location.z);
        }
    }

}

