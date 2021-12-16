using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public Transform dest;
    public LayerMask stop;

    drink heldDrink;

    // Start is called before the first frame update
    void Start()
    {
        heldDrink = null;
        dest.parent = null;
        transform.position = new Vector3(0.5f, 0.5f, -9.0f);
        
    }

    void AddIngredient(int ingredient) {
        //FIXME: implement
    }

    void RemoveIngredient(int ingredient) {
        //FIXME: implement
    }
    
    void CreateDrink(int[] ingredients) {
        drink d = new drink();


        heldDrink = d;
    }

    void DeliverDrink(planet customer) {
        heldDrink = null;

        //give to customer

    }

    // Update is called once per frame
    void Update()
    {
        //handle movement
        Vector3 pos = transform.position;

        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = pos + new Vector3(Horizontal / 2.0f , Vertical / 2.0f, 0.0f);
        
        dest.position = moveTo;

        if((Vector3.Distance(pos, moveTo) > 0.49f) && !Physics2D.OverlapCircle(moveTo, 0.1f, stop)) {
            transform.position = Vector3.MoveTowards(pos, moveTo, moveSpeed * Time.deltaTime);
        }


        //check for item interactions
        
    }

    
}
