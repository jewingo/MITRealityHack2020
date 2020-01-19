﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class sledSpawner : MonoBehaviour
{

    public GameObject sled;
    private float timer = 0f;
    public float spawnTime = 1f;
    private MLInputController _controller;
    private bool _enabled = true;
    private bool _bumper = false;
    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if((button == MLInputControllerButton.Bumper && _enabled && _bumper == false))
        {
            spawnSled();
            _bumper = true;
        }
    }

    void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        if((button == MLInputControllerButton.Bumper && _enabled && _bumper == true))
        {
            _bumper = false;
        }
    }

    void spawnSled()
    {
        //Instantiate(sled, transform.position, transform.rotation);
        sled.transform.position = transform.position;
        sled.transform.rotation = transform.rotation;
    }
}
