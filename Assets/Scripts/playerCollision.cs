using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.name == "TR")
        {
            //pause enemies by deselcting them
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<NavMeshAgent>().isStopped = true;
                enemy.GetComponent<EnemyCollision>().playing = false;
                enemy.GetComponent<Enemy_Follow>().playing = false;

            }

            GetComponent<CharacterMove>().enabled = false;
            FindObjectOfType<AudioManager>().Stop("Running");
            GetComponent<Animator>().SetTrigger("gotTouchdown");
            FindObjectOfType<AudioManager>().Play("Cheering");

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