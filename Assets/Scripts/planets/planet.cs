using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planet : MonoBehaviour
{
    int totalReqs;
    int constellationReq;
    public LayerMask player;

    GameObject reqObj;
    Sprite reqSpr;
    bool delivered;
    
    void Start()
    {
        totalReqs = 3;
        delivered = false;

        GenerateRequest();
        //Debug.Log("Request: " + constellationReq);

        reqObj = this.gameObject.transform.GetChild(0).gameObject;
        reqObj.SetActive(false);
        reqObj.GetComponent<SpriteRenderer>().sprite = reqSpr;
    }

    void GenerateRequest() {
        constellationReq = Random.Range(0, totalReqs);
        reqSpr = Resources.Load<Sprite>("requests/drink"+constellationReq.ToString());
    }

    void Update()
    {
        // If user is within certain radius, display request
        if(Physics2D.OverlapCircle(transform.position, 4.0f, player)) {
            //Debug.Log("Within radius");
            //display request
            if(!reqObj.activeSelf && !delivered)
                reqObj.SetActive(true);

        }
        else {
            if(reqObj.activeSelf)
                reqObj.SetActive(false);
        }
    }

    public bool DeliverDrink(int d) {
        //check for constellation match
        if(d != constellationReq) {
            //no match

            return false;
        }

        //Accept drink
        if(reqObj.activeSelf)
            reqObj.SetActive(false);
            
        return true;
    }
}
