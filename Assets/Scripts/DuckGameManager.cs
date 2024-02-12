using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGameManager : MonoBehaviour
{
    public static DuckGameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
