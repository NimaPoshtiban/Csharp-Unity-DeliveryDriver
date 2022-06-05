using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets
{
    public class Delivery : MonoBehaviour
    {
        [SerializeField] private Color32 hasPackageColor = new Color32(214, 53, 115, 1);
        [SerializeField] private Color32 noPackageColor = new Color32(137, 255, 255, 1);
        [SerializeField] private float desteroyDelay = 0.5f;
        private bool hasPickedUpThePackage = false;
        private int numberOfPackages = 3;
        private SpriteRenderer spriteRenderer = new SpriteRenderer();

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D()
        {
            Debug.Log("Collision Works");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Package" && !hasPickedUpThePackage)
            {
                hasPickedUpThePackage = true;
                spriteRenderer.color = hasPackageColor;

                Debug.Log("Package picked up!");
                Destroy(other.gameObject, desteroyDelay);
            }

            if (other.tag == "Customer" && hasPickedUpThePackage)
            {
                Debug.Log("Delivered to customer");
                hasPickedUpThePackage = false;
                if (numberOfPackages == 0)
                {

                }
                numberOfPackages--;
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}
