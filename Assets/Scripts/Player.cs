using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField]private Transform handPosition;
    [SerializeField]private InteractableView interactableView;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckControls();	
	}

    private void CheckControls()
    {
        if (CrossPlatformInputManager.GetButtonDown("Interact")){
            interactableView.InteractWithObject();
        }
    }

    public void HoldObjectInHand(GameObject gameObject)
    {
        gameObject.transform.position = handPosition.position;
        gameObject.transform.rotation = handPosition.rotation;
        gameObject.transform.parent = handPosition;
    }
}
