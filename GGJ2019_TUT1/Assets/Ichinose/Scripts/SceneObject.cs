﻿using UnityEngine;

[System.Serializable]
public class SceneObject
{
    [SerializeField]
    private string m_SceneName;

    public override string ToString()
    {
        return m_SceneName;
    }

    public static implicit operator SceneObject(string sceneName)
    {
        return new SceneObject() { m_SceneName = sceneName };
    }
}
