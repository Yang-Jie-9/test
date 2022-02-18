using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public int index;
    public Dictionary<int, Coroutine> coroutines = new Dictionary<int, Coroutine>();

    public static TaskManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int Create(IEnumerator enumerator)
    {
        index++;
        var coroutine = StartCoroutine(enumerator);
        coroutines.Add(index, coroutine);
        return index;
    }
}
