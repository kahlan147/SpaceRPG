using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Transform ClosedPosition;
    public Transform OpenPosition;

    private bool Condition;
    private bool Busy;

	// Use this for initialization
	void Start () {
        Condition = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        if (!Busy)
        {
            if (Condition)
            {
                StartCoroutine(MoveToPosition(OpenPosition));
                Condition = false;
            }
            else
            {
                StartCoroutine(MoveToPosition(ClosedPosition));
                Condition = true;
            }
        }
    }

    private IEnumerator MoveToPosition(Transform position)
    {
        Busy = true;
        while (!SamePosition(this.transform.position,position.position))
        {
        this.transform.position = Vector3.MoveTowards(this.transform.position, position.position, 0.2f);
            yield return new WaitForSeconds(.5f);
        }

        Busy = false;
        yield return null;
    }

    private bool SamePosition(Vector3 position1, Vector3 position2)
    {
        if (position1.x != position2.x)
        {
            return false;
        }
        if (position1.y != position2.y)
        {
            return false;
        }
        if (position1.z != position2.z)
        {
            return false;
        }
        return true;
    }
}
