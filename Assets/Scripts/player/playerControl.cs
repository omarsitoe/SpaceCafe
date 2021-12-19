using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public Transform dest;
    public LayerMask stop;
    public LayerMask drinkLayer;

    drink heldDrink;

    // Start is called before the first frame update
    void Start()
    {
        heldDrink = null;
        dest.parent = null;
        transform.position = new Vector3(0.5f, 0.5f, -9.0f);
       
    }

    void DeliverDrink(planet customer) {
        //give to customer

        //remove drink
        heldDrink = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Collider2D col;
        GameObject d;

        /**********************************
         **       handle movement        **
         **********************************/

        Vector3 moveTo = pos + new Vector3(Horizontal / 2.0f , Vertical / 2.0f, 0.0f);
        dest.position = moveTo;

        if((Vector3.Distance(pos, moveTo) > 0.49f) && !Physics2D.OverlapCircle(moveTo, 0.1f, stop)) {
            transform.position = Vector3.MoveTowards(pos, moveTo, moveSpeed * Time.deltaTime);
        }


        /**********************************
         **  check for user interactions **
         **********************************/

        //pick up and deliver drinks
        if(heldDrink == null && Input.GetKeyDown(KeyCode.Z)) {
            //pick up
            if(col = Physics2D.OverlapCircle(pos, 1.5f, drinkLayer)) {
                d = col.gameObject.GetComponent<drink>().get
            }
            //deliver
            else if(col = Physics2D.OverlapCircle(pos, 1.5f, planet)) {
                d = col.gameObject.GetComponent<drink>().get
            }
        }

        //drop drink if any are held
        if(heldDrink != null && Input.GetKeyDown(KeyCode.X))) {
            
        }
        
    }

    
}
