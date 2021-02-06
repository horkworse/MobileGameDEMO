using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableScriptForZones : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy"){
            Player.objectSpeed *= 0.5f;
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy"){
            Player.objectSpeed *= 2f;
        }
    }
}
