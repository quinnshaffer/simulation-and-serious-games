    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class exercisei_5 : MonoBehaviour
    {
    


        // Set a fake creeen height for Unity
        float x=0;
        float y=0;
        [SerializeField] float speed;
        GameObject cube;
        private Vector2 minimumPos, maximumPos;

        // A Variable to represent our mover in the scene

        // Start is called before the first frame update
        void Start()
        {
            Camera.main.orthographic = true;

            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // Next we grab the minimum and maximum position for the screen
            minimumPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
            maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            //We need to create a new material for WebGL
            Renderer r = cube.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Diffuse"));
        }

        // Update is called once per frame
        public void step()
        {
            x = speed*(Random.Range(Random.Range(-1f, 1f), Random.Range(-1f, 1f))*Time.deltaTime);
            y = speed*(Random.Range(Random.Range(-1f, 1f), Random.Range(-1f, 1f))*Time.deltaTime);

        }
        void Update()
        {
            //Create a fake width to maintain our cubes in a reasonable 3D space
            step();
            cube.transform.Translate(new Vector2(x,y));
        }
    }

