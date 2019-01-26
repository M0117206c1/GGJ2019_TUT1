﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGimmick : MonoBehaviour
{
    protected GimmickType type;

    void Start()
    {
        Init();
    }

    void Update()
    {
        Action();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 処理
    /// </summary>
    public abstract void Action();

    /// <summary>
    /// アイテム時処理
    /// </summary>
    public abstract void ItemAction();
}

public enum GimmickType
{
    /// <summary>
    /// 倒木
    /// </summary>
    Wood,
}