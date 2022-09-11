using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    public string Name { get; }
    public string Description { get;  }
    public float Weight { get; }

}
