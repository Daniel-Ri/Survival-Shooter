using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    ItemManager itemManager;
    public int addHealth = 20;
    public float closeness = 2f;
    //public GameObject pickUpEffect;

    private void Awake()
    {
        itemManager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float playerDistance = Vector3.Distance(transform.position, other.transform.position);

            if (playerDistance < closeness)
            {
                Pickup(other);
            }

        }
    }

    void Pickup(Collider other)
    {
        //Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Mendapatkan komponen player health
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        //Menambahkan health
        playerHealth.AddHealth(addHealth);

        //Debug.Log("Power up picked");

        itemManager.HealthUpTaken();
        Destroy(gameObject);
    }
}
