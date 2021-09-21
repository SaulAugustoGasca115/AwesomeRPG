using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Move : MonoBehaviour
    {
        [Header("AI")]
        [SerializeField]
        Transform target;
        Ray lastRay;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if(Input.GetMouseButton(0))
            //{
            //    MoveToCursor();
            //}

            UpdateAnimator();

        }

        void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                MoveTo(hit.point);
            }

            //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawLine(lastRay.origin,lastRay.direction * 100);

            //GetComponent<NavMeshAgent>().destination = target.position;
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }

}