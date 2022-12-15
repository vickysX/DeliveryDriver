using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    
    void LateUpdate() // set camera position at a later stage in execution order to avoid conflicts with the positioning of thingToFollow
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
