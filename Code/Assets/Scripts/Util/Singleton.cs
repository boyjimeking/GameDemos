﻿using UnityEngine;
using System.Collections;

public class Singleton<T> where T : new()
{
    private static T instance = default(T);
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}


