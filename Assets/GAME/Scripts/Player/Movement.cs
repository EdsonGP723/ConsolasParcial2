using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	private PlayerInput playerInput;
	InputAction movement;
	public float speed;
	
	// Awake is called when the script instance is being loaded.
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		movement = InputSystem.actions.FindAction("Move");
	}
    // Update is called once per frame
    void Update()
    {
	    Vector2 moveValue = movement.ReadValue<Vector2>();
	    Vector3 movedirection = new Vector3 (moveValue.x,0,0);
	    transform.Translate (movedirection * speed * Time.deltaTime);
    }
}
