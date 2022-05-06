using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    private List<GameObject> levels = new List<GameObject>();
    // Start is called before the first frame update

    void Start()
    {
        foreach (Transform child in transform) {
            levels.Add(child.gameObject);
        }

        levels[(PersistentManagerScript.Instance.LEVEL-1)].SetActive(true);
    }
}
