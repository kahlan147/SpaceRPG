using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    [SerializeField]private Transform handPosition;
    [SerializeField]private InteractableView interactableView;

    [HideInInspector]public Chair chair;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (chair == null)
        {
            CheckControlsGround();
        }
        else
        {
            CheckControlsFlying();
        }
	}

    private void CheckControlsGround()
    {
        if (CrossPlatformInputManager.GetButtonDown("Interact")){
            
                interactableView.InteractWithObject();
            
        }
    }

    private void CheckControlsFlying()
    {
        if (CrossPlatformInputManager.GetButtonDown("Interact"))
        {
            chair.Flying(false);
            this.transform.parent = null;
            AllowedToMove(true);
            this.transform.position += new Vector3(0, 1, 0);
            chair = null;
        }
        
    }

    public void HoldObjectInHand(GameObject gameObject)
    {
        gameObject.transform.position = handPosition.position;
        gameObject.transform.rotation = handPosition.rotation;
        gameObject.transform.parent = handPosition;
    }

    public void AllowedToMove(bool state)
    {
        this.gameObject.GetComponent<FirstPersonController>().AllowedToMove = state;
    }
}
