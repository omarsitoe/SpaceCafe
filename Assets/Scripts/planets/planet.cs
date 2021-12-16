using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class planet : MonoBehaviour
{
    List<string> totalReqs;
    string constellationReq;

    // Start is called before the first frame update
    void Start()
    {
        totalReqs = new List<string>();
        totalReqs.Add("test0");
        totalReqs.Add("test1");
        totalReqs.Add("test2");

        GenerateRequest();
        Debug.Log("Request: " + constellationReq);
    }

    void GenerateRequest() {
        int indx = Random.Range(0, totalReqs.Count);
        string gen = totalReqs[indx];
        constellationReq = gen;
    }

    // Update is called once per frame
    void Update()
    {
        // If user is within certain radius, display request
    }

    void RecieveDrink(drink d) {
        //check for constellation match

        //save happiness score from drink to give feedback
    }
}
