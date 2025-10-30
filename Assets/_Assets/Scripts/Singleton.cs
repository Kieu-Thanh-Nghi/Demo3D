﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T instanceInScence = FindObjectOfType<T>();
                RegisterInstance(instanceInScence);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            RegisterInstance((T)(MonoBehaviour)this);
        }
        else if (_instance != this) Destroy(this);
    }

    static void RegisterInstance(T newInstance)
    {
        if (newInstance == null) return;
        _instance = newInstance;
        DontDestroyOnLoad(_instance.transform.root);
    }
}