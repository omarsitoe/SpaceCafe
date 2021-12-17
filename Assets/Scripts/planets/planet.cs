using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planet : MonoBehaviour
{
    List<string> totalReqs;
    string constellationReq;
    public LayerMask player;

    GameObject reqObj;
    Sprite reqSpr;
    

    // Start is called before the first frame update
    void Start()
    {
        totalReqs = new List<string>();
        totalReqs.Add("test0");
        totalReqs.Add("test1");
        totalReqs.Add("test2");

        GenerateRequest();
        Debug.Log("Request: " + constellationReq);

        reqObj = this.gameObject.transform.GetChild(0).gameObject;
        reqObj.SetActive(false);
        reqObj.GetComponent<SpriteRenderer>().sprite = reqSpr;
    }

    void GenerateRequest() {
        int indx = Random.Range(0, totalReqs.Count);
        string gen = totalReqs[indx];
        constellationReq = gen;

        reqSpr = Resources.Load<Sprite>("testReq/"+constellationReq);
    }

    // Update is called once per frame
    void Update()
    {
        // If user is within certain radius, display request
        if(Physics2D.OverlapCircle(transform.position, 4.0f, player)) {
            Debug.Log("Within radius");
            //display request
            if(!reqObj.activeSelf)
                reqObj.SetActive(true);

        }
        else {
            if(reqObj.activeSelf)
                reqObj.SetActive(false);
        }
    }

    void RecieveDrink(drink d) {
        //check for constellation match

        //save happiness score from drink to give feedback
    }
}
