using UnityEngine;

public class exercise1_7 : MonoBehaviour
{
    //And then we need to create a walker
    private WalkerIntro5 walkeri5;

    // Start is called before the first frame update
    void Start()
    {
        // Create the walker
        walkeri5 = new WalkerIntro5();
    }

    // Update is called once per frame
    void Update()
    {
        //Have the walker move
        walkeri5.step();
    }
}

public class WalkerIntro5
{
    //GameObject
    Vector2 location;

    // The window limits
    private Vector2 minimumPos, maximumPos;

    //Perlin
    float heightScale = 2;
    float widthScale = 1;

    // Start is called before the first frame update
    // Gives the class a GameObject to draw on the screen
    public GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    public WalkerIntro5()
    {
        
        location = Vector2.zero;
        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    public void step()
    {
        widthScale += .02f;
        heightScale += .001f;

        float height = heightScale * Mathf.PerlinNoise(Time.time * .5f, 0.0f);
        float width = widthScale * Mathf.PerlinNoise(Time.time * 1, 0.0f);
        Vector3 pos = mover.transform.position;
        pos.y = height;
        pos.x = width;
        mover.transform.position = pos;
    }


}