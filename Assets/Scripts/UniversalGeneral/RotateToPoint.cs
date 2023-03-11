using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.UniversalGeneral 
{
    public class RotateToPoint : MonoBehaviour
    {
        [SerializeField] Transform PointToRotatetoo;
        [SerializeField] float RotSpeed;
        private void Update()
        {
            var direction = PointToRotatetoo.position - transform.position;
            var angleToRotate = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion AnglgeRotFinalized = Quaternion.AngleAxis(-angleToRotate, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, AnglgeRotFinalized, RotSpeed * Time.deltaTime);



        }


    }
}
