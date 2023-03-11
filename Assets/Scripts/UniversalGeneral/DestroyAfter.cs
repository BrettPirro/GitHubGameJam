using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.UniversalGeneral 
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] float Wait = 1f;

        private void Awake()
        {
            Destroy(gameObject, Wait);
        }
    }

}