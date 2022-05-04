using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerCollision : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.name == "TR")
        {
            GetComponent<Animator>().SetTrigger("gotTouchdown");
            FindObjectOfType<AudioManager>().Play("Cheering");

            //pause enemies by deselcting them
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<NavMeshAgent>().isStopped = true;
            }
            StartCoroutine(ScoredPlayingAnimation());//let the winning animation play out
           
        }

    }


    IEnumerator ScoredPlayingAnimation()
    {
        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(4);


        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        GameObject.Find("ScoringManager").GetComponent<Scoring>().touchDown();
    }
}
