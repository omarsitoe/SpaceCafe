using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public Transform dest;
    public LayerMask stop, drinkLayer, planetLayer;
    public GameObject spawnManager;

    int heldDrink;

    // Start is called before the first frame update
    void Start()
    {
        heldDrink = -1;
        dest.parent = null;
        transform.position = new Vector3(0.5f, 0.5f, -9.0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Collider2D col;

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

        if(Input.GetKeyDown(KeyCode.Z)) {
            //pick up drink
            if(col = Physics2D.OverlapCircle(pos, 1.5f, drinkLayer)) {
                heldDrink = col.gameObject.GetComponent<drink>().GetDrink();
                Debug.Log("Grabbed drink..."+heldDrink.ToString());
            }

            if(col = Physics2D.OverlapCircle(pos, 1.5f, planetLayer)) {
                if(heldDrink == -1) {
                    //FIXME: Error sound effect -> no drink to deliver
                    Debug.Log("No drink held!");
                }
                
            }
        }


        if(heldDrink != -1) {

            if(Input.GetKeyDown(KeyCode.Z)) {
                //deliver
                if(col = Physics2D.OverlapCircle(pos, 1.5f, planetLayer)) {
                    //was drink accepted?
                    if(col.gameObject.GetComponent<planet>().DeliverDrink(heldDrink)) {
                        Debug.Log("Drink successfully delivered!");

                        heldDrink = -1;
                        
                        //destroy planet instance, but let despawn animation play first
                        Destroy(col.gameObject, 5);
                    }
                }
            }
            //drop drink if any are held
            else if(Input.GetKeyDown(KeyCode.X)) {
                Debug.Log("Dropped current drink");
                heldDrink = -1;
            }


        }
        
    }

    
}
