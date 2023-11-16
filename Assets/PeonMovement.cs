using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ClubEternal
{
    public class PeonMovement : MonoBehaviour
    {
        /// <summary>
        /// Target game object ie. what they want to move to.
        /// </summary>
        [SerializeField]
        GameObject goal;
        /// <summary>
        /// target position ie. where they want to go
        /// </summary>
        private Vector3 target;

        /// <summary>
        /// override with manual control
        /// </summary>
        [SerializeField]
        bool controlled;

        /// <summary>
        /// How often do they change their path
        /// </summary>
        [SerializeField]
        float reactionTime = 0.2f;

        /// <summary>
        /// How offten do they check their needs to change their behavior
        /// </summary>
        [SerializeField]
        float decisionTime = 1.0f;

        private float time = 0.0f;
        NavMeshAgent agent;


        private void Awake() {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        // Update is called once per frame
        void Update()
        {
            if ( !controlled ) {
                time += Time.deltaTime;
                if ( time % decisionTime == 0 ) {
                    decisionCheck();
                    setPath();
                } else if ( time % reactionTime == 0 ) {
                    setPath();
                }
            } else {
                if ( Input.GetMouseButtonDown( 0 ) ) {
                    manualTarget();
                }
            }
        }

        void decisionCheck() {
            //TODO:
            /* NeedType need = PeonNeeds.getTopNeed();
             * 
             * --find location for that need
             * --get a position from location
             * --go to position
             */
        }

        void manualTarget() {
            // try selecting a game object
            if ( true ) {
                //TODO:
         
            } else {
                // otherwise go to point
                Vector3 point = Camera.main.ScreenToWorldPoint( Input.mousePosition );
                NavMeshHit hit;
                if (NavMesh.SamplePosition(point, out hit , 0.1f, NavMesh.AllAreas )){
                    target = point;
                }
            }
        }

        void setPath() {
            agent.SetDestination( new Vector3( target.x, target.y, transform.position.z ) );
        }
    }
}
