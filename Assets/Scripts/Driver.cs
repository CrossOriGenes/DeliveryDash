using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{

    [SerializeField] float currentSpeed = 4.5f;
    [SerializeField] float steerSpeed = 70f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 4.5f;
    [SerializeField] TMP_Text boostText;


    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Debug.Log("Speed boosted up!⚡");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
        Debug.Log("Oh oh..You're hit!😥");
    }

    void Update()
    {
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
        float moveAmount = move * currentSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

}
