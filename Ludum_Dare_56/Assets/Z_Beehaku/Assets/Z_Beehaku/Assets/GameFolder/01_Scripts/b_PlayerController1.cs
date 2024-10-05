using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class b_PlayerController1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector2 moveInput;

    private B_PlayerController playerControls;

    private void Awake()
    {
        playerControls = new B_PlayerController();
        playerControls.PlayerBaseController.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.PlayerBaseController.Move.canceled += ctx => moveInput = Vector2.zero;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
