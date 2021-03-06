﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    private const float LimitMagnitude = 4f;
    private const float DelayLimit = 2f;
    private const float BaseLightTime = 2f;

    [SerializeField]
    private GameObject lightMask;
    private Vector3 basePosition;
    public Vector3 moveVector { private get; set; }
    public float delaySpeed { private get; set; }

    private float delayTime;

    private void OnEnable()
    {
        delayTime = DelayLimit;
        basePosition = transform.position;
    }

    private void Update()
    {
        Move();
        Delete();
    }

    private void Delete()
    {
        if (delayTime <= 0) gameObject.SetActive(false);
    }

    private void Move()
    {
        transform.position += moveVector * delayTime / (2f * delaySpeed) * Time.deltaTime;
        delayTime -= Time.deltaTime;
        delayTime = Mathf.Clamp(delayTime, 0, DelayLimit);
    }

    private void OnTriggerEnter2D(Collider2D other1)
    {
        if (other1.CompareTag("Player")) return;
        if (other1.CompareTag("Sonar")) return;
        if (other1.CompareTag("GoalArea")) return;

        gameObject.SetActive(false);

        var position = transform.position;

        BaseGimmick gimmick;
        if ((gimmick = other1.GetComponent<BaseGimmick>()) != null)
        {
            gimmick.LightUp(BaseLightTime * (LimitMagnitude - (basePosition - position).magnitude) / LimitMagnitude);
            return;
        }

        LightMaskPool.Instance.Generate(position).GetComponent<LightMask>().LimitTime =
            BaseLightTime * (LimitMagnitude - (basePosition - position).magnitude) / LimitMagnitude;
    }
}
