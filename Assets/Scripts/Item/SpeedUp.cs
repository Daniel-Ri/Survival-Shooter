using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    ItemManager itemManager;
    public float multiplierSpeed = 1.2f;
    public float duration = 5f;
    public float closeness = 2f;

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
                Debug.Log("Picked up speed");
                StartCoroutine(Pickup(other));
            }

        }
    }

    IEnumerator Pickup(Collider other)
    {
        //Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Mendapatkan komponen player health
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        playerMovement.speed *= multiplierSpeed;
        Debug.Log("Speed up");

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        playerMovement.speed /= multiplierSpeed;

        itemManager.SpeedUpTaken();
        Destroy(gameObject);
    }
}
