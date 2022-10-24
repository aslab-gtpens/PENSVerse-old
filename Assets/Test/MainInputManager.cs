using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MainInputManager : MonoBehaviour
{

    [SerializeField] private VRInputReader vrInput;
    OtherPlayerControler playerControler;

    private Vector2 _moveAxis;
    public Vector2 moveAxis=>moveAxis;
    private Vector2 _lookAxis;
    public Vector2 lookAxis=>lookAxis;
    //public Vector2 moveAxis => _moveAxis;

    public InputLookType lookType;
    public enum InputLookType
    {
        GamePad,
        Mouse,
        VR
    }

    private void Awake()
    {
        //generate inputaction instance
        if(playerControler == null)
            playerControler = new OtherPlayerControler();

        // listen to input
        playerControler.FlyMovement.MoveDirection.performed += i => _moveAxis = i.ReadValue<Vector2>();
        playerControler.FlyMovement.LookDirection.performed += i => _lookAxis = i.ReadValue<Vector2>();

        
        //enable input acti
        playerControler.Enable();
    }

    private void Update()
    {

        //lookAxis = _lookAxis;
    }
}