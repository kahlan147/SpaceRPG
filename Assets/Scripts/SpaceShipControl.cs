using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SpaceShipControl : MonoBehaviour {
    
    [SerializeField]private float m_RunSpeed;
    
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;

    [HideInInspector]public bool IsFlying;

    private bool AllowedToLookAround;

    // Use this for initialization
    void Start () {
        IsFlying = false;
        AllowedToLookAround = false;
        
        m_CharacterController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (IsFlying)
        {
            Move();
            CheckControls();
        }
	}

    private void CheckControls()
    {
        if (CrossPlatformInputManager.GetButtonDown("SwitchLook"))
        {
            SwitchLook();
        }
    }

    private void Move()
    {
        float speed;
        GetInput(out speed);
        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;

        m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
    }

    private void GetInput(out float speed)
    {
        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float Yspeed = 0;
        if (AllowedToLookAround)
        {
            Yspeed = CrossPlatformInputManager.GetAxis("Mouse Y");
            this.transform.Rotate(Vector3.left * Yspeed * 20 *Time.deltaTime);
        }

        Vector3 rotation = new Vector3(0, horizontal * 50, 0);
        this.transform.Rotate(rotation* Time.deltaTime);
        
        // set the desired speed to be walking or running
        speed = m_RunSpeed;
        m_Input = new Vector2(0, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }
    }

    public void SwitchLook()
    {
        if (IsFlying)
        {
            AllowedToLookAround = !AllowedToLookAround;
        }
    }
}
