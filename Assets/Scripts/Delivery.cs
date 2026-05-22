using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class Delivery : MonoBehaviour {
    bool hasPackage;
    [SerializeField] float delay = 0.4f;
    
    void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("FoodItem") && !hasPackage) {
            Debug.Log("📦Package picked up");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }
        if (collision.CompareTag("Customer") && hasPackage) {
            Debug.Log("Order delivered🚚");        
            hasPackage = false;    
            GetComponent<ParticleSystem>().Stop();
        }

    }

}
