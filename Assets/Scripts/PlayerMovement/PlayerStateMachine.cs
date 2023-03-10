using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 velocity;
    public float movementSpeed { get; private set; } = 5f;
    public float jumpForce { get; private set; } = 5f;
    public float lookRotationDampFactor { get; private set; } = 10f;
    public Transform mainCamera { get; private set; }
    public InputReader inputReader { get; private set; }
    public Animator animator { get; private set; }
    public CharacterController controller { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main.transform;
        inputReader = GetComponent<InputReader>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        SwitchState(new PlayerMoveState(this));
    }
}
