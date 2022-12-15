using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage; // initialized to false by default
    [SerializeField] float waitOnDestroy;
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasPackageColor = new Color32(0, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("I'm so glad I'm hurting you!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, waitOnDestroy);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Delivered package");
            spriteRenderer.color = noPackageColor;
        }
    }
}
