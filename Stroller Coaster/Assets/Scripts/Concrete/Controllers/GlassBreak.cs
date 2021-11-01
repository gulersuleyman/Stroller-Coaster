using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreak : MonoBehaviour
{
    public Transform _brokenObject;
    public float _magnitudeCol, _radius, _power, _upwards;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >_magnitudeCol)
        {
            Destroy(gameObject);
            Instantiate(_brokenObject, transform.position, transform.rotation);
            _brokenObject.localScale = transform.localScale;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);

            foreach(Collider hit in colliders)
            {
                if(hit.attachedRigidbody)
                {
                    hit.attachedRigidbody.AddExplosionForce(_power * collision.relativeVelocity.magnitude, explosionPos, _radius, _upwards);
                }
            }
        }
    }
}
