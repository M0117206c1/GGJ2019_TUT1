﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassMarker : MonoBehaviour
{   
    private Goal goalObject;

    private void Start()
    {
        goalObject = FindObjectOfType<Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalObject == null) return;
        var direction = (goalObject.transform.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(Vector3.back, direction);
        transform.localRotation = lookRotation;
    }
}
