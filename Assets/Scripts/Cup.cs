using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour, IInteractable {

    [SerializeField]private string Name;

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
        return Name;
    }

    public void Interact(Player player)
    {
        player.HoldObjectInHand(this.gameObject);
    }

}
