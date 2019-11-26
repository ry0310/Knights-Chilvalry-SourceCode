using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour
{
    public GameObject interactText;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void interactable()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.gold += 1;
            Destroy(this.gameObject);
        }
            
    }
}
