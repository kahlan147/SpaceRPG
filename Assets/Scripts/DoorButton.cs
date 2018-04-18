using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable {

    [SerializeField]private string Name;

    [SerializeField]private Door door;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        
    }

    public string getInteractableName()
    {
        return name;
    }

    public void Interact(Player player)
    {
        door.Interact();
    }
}
