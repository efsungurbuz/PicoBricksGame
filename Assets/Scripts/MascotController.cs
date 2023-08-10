using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascotController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput);
        float playerVelocity = inputDirection.magnitude;

        animator.SetFloat("playerVelocity", playerVelocity);
       // Debug.Log("made by Efsun Gürbüz");
    }
}
