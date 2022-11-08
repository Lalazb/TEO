using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Medusa : MonoBehaviour
{
    public Transform player;
    public float range;

    private float distToPlayer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, player.position);
        if(distToPlayer<=range)
        {
          //  animator.enabled;
        }
    }
}
