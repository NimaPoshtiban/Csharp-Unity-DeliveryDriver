using UnityEngine;

namespace Assets
{
    // the camera position should be the same as car position
    public class FlowCamera : MonoBehaviour
    {
        [SerializeField] private GameObject thingToFollow;
        
        void LateUpdate()
        {
            transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
        }
    }
}
