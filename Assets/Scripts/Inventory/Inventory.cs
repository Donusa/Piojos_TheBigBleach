using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items = new List<Item>();
    float capacity = 0.0f;
    float totalCapacity = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Item pickup = new Item();
        pickup = collision.gameObject.GetComponent<Item>();
        if(this.capacity + pickup.Weight > this.totalCapacity)
        {
            this.capacity += pickup.Weight;
            items.Add(pickup);
            Destroy(collision.gameObject);
        }
    }

}
