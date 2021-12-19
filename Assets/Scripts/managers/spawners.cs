using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawners : MonoBehaviour
{
    public GameObject spawnManager;
    bool hadChildren;
    
    void Start() {
        spawnManager = transform.parent.gameObject;
        hadChildren = false;
    }

    // Update is called once per frame
    void Update() {
        if(transform.childCount > 0) {
            hadChildren = true;
        } else if (hadChildren) {
            spawnManager.GetComponent<planetSpawning>().DecrementCount();
            hadChildren = false;
        }
    }
}
