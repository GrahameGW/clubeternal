using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClubEternal
{

    public enum NeedType {
        Thirst,
        Mood,
        Bladder,
        Tiredness
    }

    public class PeonNeeds : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public NeedType getTopNeed() {
            //TODO:
            return NeedType.Mood;
        }
    }
}
