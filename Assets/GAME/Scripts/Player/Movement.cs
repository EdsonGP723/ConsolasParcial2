using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	public float speed;
	private PlayerInput playerInput;
	private InputAction movement;
	
	
	// Awake is called when the script instance is being loaded.
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		movement = InputSystem.actions.FindAction("Move");
	}
    // Update is called once per frame
    void Update()
    {
	    CharacterMovement();
    }
    
	public void CharacterMovement(){
		Vector2 moveValue = movement.ReadValue<Vector2>();
		Vector3 movedirection = new Vector3 (moveValue.x,0,0);
		float xmove = movedirection.x * speed * Time.deltaTime;
		transform.Translate(xmove,0f,0f);
	    
		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(clampedPosition.x, -3f, 3f);
		transform.position = clampedPosition;
	}
}