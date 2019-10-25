﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateComponent : MonoBehaviour
{
    public bool isGrounded = false;
    public int shields;
    int orbs;
    int keys;
    GameObject shieldCounter;
    GameObject orbCounter;
    GameObject keyCounter;

    void Start()
    {
        shields = 0;
        shieldCounter = GameObject.Find("ShieldCounter");
        orbCounter = GameObject.Find("OrbCounter");
        keyCounter = GameObject.Find("KeyCounter");
    }

    public void AddOrb()
    {
        orbs += 1;
        if (orbs >= 3)
        {
            orbs = 0;
            AddShield();
        }
        orbCounter.GetComponent<Text>().text = "X "+ orbs;
    }

    public void AddKey()
    {
        keys += 1;
        keyCounter.GetComponent<Text>().text = "X " + keys;
    }

    public void RemoveKey()
    {
        keys -= 1;
        keyCounter.GetComponent<Text>().text = "X " + keys;
    }

    void AddShield()
    {
        shields += 1;
        shieldCounter.GetComponent<Text>().text = "X " + shields;
    }

    public void RemoveShield()
    {
        shields -= 1;
        shieldCounter.GetComponent<Text>().text = "X " + shields;
    }
}
