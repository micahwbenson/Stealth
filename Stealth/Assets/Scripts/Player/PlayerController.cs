using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Just copying the player controller for now, because it's not my current focus on this work -- HAHA nvm, this is for 3d movement, lmao -- that also explains why my bool for CanBeHear wasn't working correctly

    public float MoveSpeed = 6f;

    private Detectable detectable;

    private void Start()
    {
        detectable = GetComponent<Detectable>();
    }

    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        detectable.CanBeHear = verticalAxis != 0f || horizontalAxis != 0f;

        transform.Translate(Vector2.up * verticalAxis * MoveSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.right * horizontalAxis * MoveSpeed * Time.deltaTime);
    }
}
