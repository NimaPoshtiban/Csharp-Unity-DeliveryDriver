using UnityEngine;

namespace Assets
{
    public class Driver : MonoBehaviour
    {
        [SerializeField] private float steerSpeed = 300f;

        [SerializeField] private float moveSpeed = 20f;

        [SerializeField] private float slowSpeed = 15f;

        [SerializeField] private float boostSpeed = 30f;
        // Start is called before the first frame update
        void Start()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Booster")
            {
                moveSpeed = boostSpeed;
            }
            else
            {
                moveSpeed = slowSpeed;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            moveSpeed = slowSpeed;
        }
        // Update is called once per frame
        void Update()
        {
            var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);
        }
    }
}
