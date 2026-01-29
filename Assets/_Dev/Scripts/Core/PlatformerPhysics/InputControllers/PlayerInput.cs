using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public abstract class PlayerInput : MonoBehaviour
{
	protected Player player;
	protected void Start()
	{
		player = GetComponent<Player>();
	}

	protected void Update()
	{
		// Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 directionalInput = DirectionalInput();
		player.SetDirectionalInput(directionalInput);

		// if (Input.GetKeyDown (KeyCode.Space)) {
		// 	player.OnJumpInputDown ();
		// }
		// if (Input.GetKeyUp (KeyCode.Space)) {
		// 	player.OnJumpInputUp ();
		// }
		HandleJumpInput();
	}
	/// <summary>
	/// Handles the jump input for the player.
	/// </summary>
	protected abstract void HandleJumpInput();
	/// <summary>
	/// Handles the directional input for the player.
	/// </summary>
	protected abstract Vector2 DirectionalInput();
}
