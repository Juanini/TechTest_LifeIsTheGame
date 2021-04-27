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

        [Header( "Player Movement" )] [Range( 0.8f, 1f )] public float smoof = 0.99f;
		public float moveSpeed = 1f;
		public float lookSensitivity = 1f;
		float yaw;
		float pitch;
		Vector2 moveInput = Vector2.zero;
		Vector3 moveVel = Vector3.zero;

        void Start()
        {
            
        }

        void Awake() 
        {
			if( Application.isPlaying == false )
            {
				return;
            }

			InputFocus = true;
			StartCoroutine( FixedSteps() );
		}

        IEnumerator FixedSteps() {
			while( true ) {
				FixedUpdateManual();
				yield return new WaitForSeconds( 0.01f ); // 100 fps
			}
		}

        bool InputFocus {
			get => !Cursor.visible;
			set {
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

			if( InputFocus ) 
            {
				// mouselook
				yaw += Input.GetAxis( "Mouse X" ) * lookSensitivity;
				pitch -= Input.GetAxis( "Mouse Y" ) * lookSensitivity;
				pitch = Mathf.Clamp( pitch, -90, 90 );
				head.localRotation = Quaternion.Euler( pitch, yaw, 0f );

				if(Input.GetKey(KeyCode.R))
                {
					// ammoBar.Reload();
                }

				// actions
				if(Input.GetMouseButtonDown(0)) 
                {
					// Fire
					// ammoBar.Fire();
					// crosshair.Fire();

					Ray ray = new Ray( head.position, head.forward );
					if( Physics.Raycast( ray, out RaycastHit hit ) && hit.collider.gameObject.name == "Enemy" )
                    {
						// crosshair.FireHit();
                    }
				}

				// move input
				moveInput = Vector2.zero;

				void DoInput( KeyCode key, Vector2 dir ) 
                {
					if( Input.GetKey( key ) )
                    {
						moveInput += dir;
                    }
				}

				// DoInput( KeyCode.W, Vector2.up );
				// DoInput( KeyCode.S, Vector2.down );
				// DoInput( KeyCode.D, Vector2.right );
				// DoInput( KeyCode.A, Vector2.left );

                DoInput( KeyCode.U,    Vector2.up );
				DoInput( KeyCode.J,  Vector2.down );
				DoInput( KeyCode.K, Vector2.right );
				DoInput( KeyCode.H,  Vector2.left );

				// leave focus mode stuff
				if( Input.GetKeyDown( KeyCode.Escape ) )
					InputFocus = false;
			} else if( Input.GetMouseButtonDown( 0 ) ) {
				InputFocus = true;
			}
		}
    }
}
