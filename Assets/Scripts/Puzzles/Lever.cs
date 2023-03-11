using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.Puzzles 
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Lever : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1f)] float PullSpeed = 0.95f;
        [SerializeField]float distancetomoveup=5;
        Vector2[] ClampPos= new Vector2[2];
        bool SwitchDir;
        Doors doors;

        private void Start()
        {
            InitalPosSetup();
            doors = FindObjectOfType<Doors>();

        }

        private void InitalPosSetup()
        {
            SwitchDir = distancetomoveup > 0;

            if (SwitchDir)
            {
                ClampPos[0] = transform.position;
                ClampPos[1] = new Vector2(transform.position.x, transform.position.y + distancetomoveup);
            }
            else
            {
                ClampPos[1] = transform.position;
                ClampPos[0] = new Vector2(transform.position.x, transform.position.y + distancetomoveup);
            }
        }

        private void OnMouseDrag()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var UpdatedPos =(Vector2.Lerp(new Vector2(transform.position.x, mousePos.y),transform.position, PullSpeed* Mathf.Pow(0.5f, Time.deltaTime)));

            transform.position = new Vector2(UpdatedPos.x,Mathf.Clamp(UpdatedPos.y,ClampPos[0].y,ClampPos[1].y));

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + distancetomoveup,transform.position.z));
        }

        public bool IsSwitchFlippedOn() 
        {
            if (SwitchDir) 
            {
                return ClampPos[1]==new Vector2(transform.position.x,transform.position.y);
            }

            return ClampPos[0] == new Vector2(transform.position.x, transform.position.y);
        }

        public float ReturnProggress() 
        {
            if (SwitchDir)
            {
                return (Vector2.Distance(transform.position,ClampPos[0])/ Vector2.Distance(ClampPos[1], ClampPos[0]));
            }

            return (Vector2.Distance(transform.position, ClampPos[1]) / Vector2.Distance(ClampPos[0], ClampPos[1]));

        }

        private void OnMouseUp()
        {
            doors.DoorCondtion();
        }

    }

}