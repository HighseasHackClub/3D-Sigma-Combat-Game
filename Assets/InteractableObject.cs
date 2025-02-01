using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject Wand;
    public bool PlayerinRange;
    public string ItemName;
    // Start is called before the first frame update

    public string GetItemName()
    {
        return ItemName;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerinRange)
        {
            Debug.Log("Item Added");
            Destroy(Wand);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerinRange= true;
        } ;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerinRange = false;
        };
    }
}
