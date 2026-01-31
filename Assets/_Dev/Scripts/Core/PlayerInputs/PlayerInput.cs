using UnityEngine;
using System.Collections;
using Barongslay.Core.PlayerLocomotion;
using Barongslay.Core.VictoryDefeat;
namespace Barongslay.Core.PlayerInputs
{
	public abstract class PlayerInput : MonoBehaviour
	{
		// protected Player player;
		[SerializeField] protected PlayerMovement playerMovement;
		protected void Start()
		{
		}

		protected void Update()
		{
			if (!VictoryDefeatManager.Instance.AllowKeyboardInput)
			{
				return;
			}
			// Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			Vector2 directionalInput = DirectionalInput();
			playerMovement.SetHorizontalInput(directionalInput.x);

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
		public abstract Vector2 DirectionalInput();
	}
}