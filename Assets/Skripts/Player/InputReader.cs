using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;
    public event Action ShootKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            JumpButtonPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse1))
            ShootKeyPressed?.Invoke();
    }
}
