using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private InputAction jumpAction;

    private float jumpDelay = 0.1f;
    private float jumpStartTime;

    private void Start()
    {
        jumpAction.Enable();
    }

    private void Update()
    {
        player.position = transform.position + Vector3.right * Time.deltaTime;

        if (jumpAction.ReadValue<float>() > 0 && Time.time - jumpStartTime > jumpDelay   ) 
        {
             jumpStartTime = Time.time;
            Debug.Log("jump");
        }
    }
}  
