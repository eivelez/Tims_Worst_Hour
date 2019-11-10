﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallMovement : MonoBehaviour
{
    private Rigidbody2D iceBallRB;

    public float iceBallLife;

    public GameObject newiceBall;

    public float iceBallSpeed;

    private Transform playerTrans;

    private GameObject player;
    private void Awake()
    {
        iceBallRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }
    void Start()
    {
        if(playerTrans.localRotation == Quaternion.Euler(0, 0, 0))
        {
            iceBallRB.velocity = new Vector2(iceBallSpeed, iceBallRB.velocity.y);
        }
        
        else
        {
            iceBallRB.velocity = new Vector2(-iceBallSpeed, iceBallRB.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled)
        {
            Destroy(newiceBall);
        }
    }

    public bool UpdateIceaBall(bool facingRight, float moving)
    {
        if (moving != 0)
        {
            if (facingRight && moving < 0)
            {
                iceBallRB.velocity = new Vector2(iceBallSpeed, iceBallRB.velocity.y);
                facingRight = !facingRight;
            }
            else if (!facingRight && moving > 0)
            {
                iceBallRB.velocity = new Vector2(iceBallSpeed*-1, iceBallRB.velocity.y);
                facingRight = !facingRight;
            }
        }
        return facingRight;
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(newiceBall,iceBallLife);
    }
}
