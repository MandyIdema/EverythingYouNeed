using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class safeZoneScript : MonoBehaviour
{
    [SerializeField] private GameObject safeZone;
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Enemy;

    [SerializeField] public GameObject pointsHandler;
    [SerializeField] private IntVariable gameScore;
    [SerializeField] private CustomGameEvent OnCollectBlob;
    // temp
    [SerializeField] private IntVariable blobValue;

    [SerializeField] private float moveAwayTime;

    [SerializeField] float moveAwaySpeed;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //The player is safe in the safe zone
            Debug.Log("Player has entered safe zone");
        }

        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy entered safe zone");
            //The enemies move away if they try to get into the safe zone
            other.GetComponent<AIBehaviour>().agent.speed = moveAwaySpeed;
            StartCoroutine(waitTime(moveAwayTime, other.gameObject));
        }

        if(other.gameObject.tag == "Friend")
        {
            //add a point if a friend has been returned safely
            Destroy(other.gameObject);
            //
            //pointsHandler.GetComponent<pointScript>().points += 1;
            
            
            OnCollectBlob.Invoke(this,blobValue);
        }
    }
   

    IEnumerator waitTime(float time, GameObject Enemy)
    {
        yield return new WaitForSeconds(time);
        Enemy.GetComponent<AIBehaviour>().agent.speed = Enemy.GetComponent<AIBehaviour>().originalSpeed;
    }


}
