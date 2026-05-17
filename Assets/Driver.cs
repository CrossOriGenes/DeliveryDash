using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f, steerSpeed = 2f;

    void Update() {
        float steer = 0f, move = 0f;

        // Move forward 🔼   
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) move = 1f;
        // Move Backward 🔽    
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) move = -1f;
        // Move Left ◀️
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) steer = 1f;
        // Move Right ▶️    
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) steer = -1f;

        float steerAmount = steer * steerSpeed * Time.deltaTime;
        float moveAmount = move * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

}
