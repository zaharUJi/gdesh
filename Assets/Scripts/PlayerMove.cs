using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private InputAction jumpAction;
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float jumpForqe;
    [SerializeField] private LayerMask layerMask; 
    private float jumpDelay = 0.1f;
    private float jumpStartTime;

    private void Start()
    {
        jumpAction.Enable();
    }

    private void Update()
    {
        player.position = transform.position + Vector3.right * Time.deltaTime;

        if (jumpAction.ReadValue<float>() > 0 && Time.time - jumpStartTime > jumpDelay && Physics2D.Raycast(player.position, Vector2.down,0.6f , layerMask  ) )
        {
             jumpStartTime = Time.time;
             rgb.velocity = Vector2.zero;
             rgb.AddForce(Vector2.up * jumpForqe, ForceMode2D.Impulse);
             
        }     
    }
}  
