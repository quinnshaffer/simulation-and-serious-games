using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 2 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        collision.collider.gameObject.SetActive(false);

    }
}
