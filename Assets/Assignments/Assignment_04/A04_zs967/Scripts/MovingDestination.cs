using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace A04Examples
{
    [RequireComponent(typeof(Collider))]
    public class MovingDestination : MonoBehaviour, IPointerClickHandler
    {
        [Tooltip("How long does the player need to get here")]
        public float RequiredMovingTime;

        private Collider _collider;

		private void Start()
		{
            _collider = GetComponent<Collider>();
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            //if where you're looking at is lesser than 10 units away from your current position
            if (Vector3.Magnitude(eventData.pointerPressRaycast.worldPosition - Camera.main.transform.position) <= 10)
            {
                PlayerController.Instance.MoveToPosition(eventData.pointerPressRaycast.worldPosition, RequiredMovingTime);
            }
        }

		private void OnTriggerEnter(Collider other)
		{
            //Disable the collision detection on this collider when the camera is inside of it, so the casting ray won't be blocked by it.
            if (other.CompareTag("MainCamera")) {
                _collider.isTrigger = true;
            }
		}

		private void OnTriggerExit(Collider other)
		{
            //Re-enable the collision detection when camera exits the collider
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = false;
            }
		}
	}
}
