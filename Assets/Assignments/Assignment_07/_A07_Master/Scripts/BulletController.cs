using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A07Examples
{
    public class BulletController : MonoBehaviour
    {

        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var nhealth = hit.GetComponent<NetworkedHealth>();
            if (nhealth != null)
            {
                nhealth.TakeDamage(10);
            }

            Destroy(gameObject);
        }
    }
}
