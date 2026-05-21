using UnityEngine;

public class Delivery : MonoBehaviour {
    bool hasPackage;
    
    void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("FoodItem")) {
            Debug.Log("📦Package picked up");
            hasPackage = true;
        }
        if (collision.CompareTag("Customer") && hasPackage) {
            Debug.Log("Order delivered🚚");        
            hasPackage = false;    
        }

    }

}
