using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }

     void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 4.75f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

}