﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float speed;
    Vector3 startPOS;

    // Start is called before the first frame update
    void Start()
    {
        startPOS = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);

        if (transform.position.x < -29.77551)
            transform.position = startPOS;
    }
}
