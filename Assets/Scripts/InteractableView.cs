using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableView : MonoBehaviour {

    [SerializeField]private Player player;
    [SerializeField]private Text UIInteractableText;


    private IInteractable HighLightedInteractable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void InteractWithObject()
    {
        if (HighLightedInteractable != null)
        {
            HighLightedInteractable.Interact(player);
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward*2), out hit))
        {
            HighLightedInteractable = CheckForInteractable(hit.transform.gameObject);
            if (HighLightedInteractable != null)
            {
                UIInteractableText.text = HighLightedInteractable.getInteractableName();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable Interactable = CheckForInteractable(gameObject);
        if (Interactable != null)
        {
            HighLightedInteractable = null;
            UIInteractableText.text = "";
        }
    }

    private IInteractable CheckForInteractable(GameObject gameobject)
    {
        IInteractable interactable = null;
        interactable = gameObject.GetComponent<IInteractable>();

        if (interactable == null)
        {
            interactable = gameobject.GetComponentInParent<IInteractable>();
        }

        return interactable;
    }
}
