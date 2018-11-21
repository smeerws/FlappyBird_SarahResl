﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public float tapForce = 200;
    public float tiltSmooth = 2;
    public Vector3 startPos;

    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;


    void start() {

        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
        // rigidbody.simulated = false;

    }

    void Update() {

        if (Input.GetMouseButtonDown(0)){
            Debug.Log("in mouse down");

            transform.rotation = forwardRotation;
            if(rigidbody == null)
            {
                Debug.Log("RB null");
            }
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag == "ScoreZone") {

            // register a score event
            // play a sound

        }

        if(col.gameObject.tag == "DeadZone") {

           //rigidbody.simulated = false;

            // register a dead event
            // play a sound
        }

    }

}