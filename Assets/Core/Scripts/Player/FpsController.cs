using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class FpsController : MonoBehaviour
    {
        [BoxGroup("Components")] public Transform head;
		[BoxGroup("Components")] public Camera cam;
		[BoxGroup("Components")] public Transform crosshairTransform;

        [BoxGroup("Player Movement")] [Range( 0.8f, 1f )] public float smoof = 0.99f;
		[BoxGroup("Player Movement")]public float moveSpeed = 1f;
		[BoxGroup("Player Movement")]public float lookSensitivity = 1f;

		private float yaw;
		private float pitch;
		private Vector2 moveInput = Vector2.zero;
		private Vector3 moveVel = Vector3.zero;

        void Awake() 
        {
			if(Application.isPlaying == false)
            {
				return;
            }

			InputFocus = true;
			StartCoroutine(FixedSteps());
		}

        IEnumerator FixedSteps() 
		{
			while(true)
			{
				FixedUpdateManual();
				yield return new WaitForSeconds(0.01f);
			}
		}

        bool InputFocus
		{
			get => !Cursor.visible;
			set 
			{
				Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
				Cursor.visible = !value;
			}
		}

        void FixedUpdateManual() 
        {
			if( Application.isPlaying == false )
            {
				return;
            }

			if(InputFocus) 
            {
				Vector3 right = head.right;
				Vector3 forward = head.forward;
				forward.y = 0;
				moveVel += ( moveInput.y * forward + moveInput.x * right ) * ( Time.fixedDeltaTime * moveSpeed );
			}

			transform.position += moveVel * Time.deltaTime; // move
			moveVel *= smoof; // decelerate
		}

        void Update() 
        {	
            if( Application.isPlaying == false )
            {
				return;
            }

			if(InputFocus) 
            {
				// mouselook
				yaw += Input.GetAxis( "Mouse X" ) * lookSensitivity;
				pitch -= Input.GetAxis( "Mouse Y" ) * lookSensitivity;
				pitch = Mathf.Clamp( pitch, -90, 90 );
				head.localRotation = Quaternion.Euler( pitch, yaw, 0f );

				// move input
				moveInput = Vector2.zero;

				void DoInput( KeyCode key, Vector2 dir ) 
                {
					if( Input.GetKey( key ) )
                    {
						moveInput += dir;
                    }
				}

                DoInput( KeyCode.W, Vector2.up );
				DoInput( KeyCode.S, Vector2.down );
				DoInput( KeyCode.D, Vector2.right );
				DoInput( KeyCode.A, Vector2.left );

			} 
			else if(Input.GetMouseButtonDown(0)) 
			{
				InputFocus = true;
			}
		}
    }
}
