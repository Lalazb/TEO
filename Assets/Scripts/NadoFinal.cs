using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadoFinal : MonoBehaviour
{
    public GameObject player;
    public Vector2 jumpCoordinates;
    public float maxHeight = 5f;
    public float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Advance();
        }
            
    }

    void Advance()
    {
        jumpCoordinates = new Vector2(transform.position.x + maxDistance, transform.position.y + maxHeight);

        float vY = Mathf.Sqrt(2f * (jumpCoordinates.y - transform.position.y) * -Physics.gravity.y);
        float t = 2f * vY / -Physics.gravity.y;
        float vX = (jumpCoordinates.x - transform.position.x) / t;
        player.GetComponent<Rigidbody>().velocity = new Vector2(vX, vY);
    }
}
