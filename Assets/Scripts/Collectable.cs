using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    int points;

    public int Points { get => points; }
}
