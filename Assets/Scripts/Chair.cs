using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable {

    [SerializeField]private string Name;
    [SerializeField]private SpaceShipControl spaceshipControl;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        throw new NotImplementedException();
    }

    public string getInteractableName()
    {
        return Name;
    }

    public void Interact(Player player)
    {
        player.transform.position = this.transform.position;
        player.transform.rotation = this.transform.rotation;
        player.transform.parent = this.transform;
        player.AllowedToMove(false);
        player.chair = this;
        Flying(true);
    }

    public void Flying(bool state)
    {
        this.spaceshipControl.IsFlying = state;
    }
}
