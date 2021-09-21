using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        public void InteractWithCombat()
        {
            RaycastHit[] hits =  Physics.RaycastAll(GetMouseRay());

            foreach(RaycastHit hit in hits)
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if(target == null)
                {
                    continue;
                }
                
                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
            }
        }

        private void MoveToCursor()
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray = GetMouseRay();
            RaycastHit hit;

            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                GetComponent<Move>().MoveTo(hit.point);
            }

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }

}