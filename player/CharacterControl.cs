using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody2D myRigidbody2D;
    
    public Vector2 CurrentMovement { get; set; }
    public bool normalMovement { get; set; }

    void Start()
    {
        normalMovement = true;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (normalMovement)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
          Vector2 currentMovePosition = myRigidbody2D.position + CurrentMovement * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(currentMovePosition);
    }

    public void MovePosition(Vector2 newPosition)
    {
        myRigidbody2D.MovePosition(newPosition);
    }

    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition;
    }

}
