using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public Transform dest;
    public LayerMask stop, drinkLayer, planetLayer;
    public Animator anim;
    public GameObject cup;

    public AudioSource acceptSound, rejectSound, cookingSound;
    
    bool mobile;
    int heldDrink;

    void Start()
    {
        heldDrink = -1;
        dest.parent = null;
        transform.position = new Vector3(0.0f, 0.0f, 1.0f);

        anim = gameObject.GetComponent<Animator>();
        cup.SetActive(false);
        mobile = true;

    }

    void Update()
    {
        Vector3 pos = transform.position;
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Collider2D col;
        IEnumerator animWait;

        /**********************************
         **       handle movement        **
         **********************************/

        Vector3 moveTo = pos + new Vector3(Horizontal / 2.0f , Vertical / 2.0f, 0.0f);
        dest.position = moveTo;

        if(mobile)
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
                
                anim.SetTrigger("preparing");
                mobile = false;
                cookingSound.Play();

                animWait = preparingDrink(0.6938776f);
                StartCoroutine(animWait);

            }

            if(col = Physics2D.OverlapCircle(pos, 1.5f, planetLayer)) {
                if(heldDrink == -1) {
                    rejectSound.Play();
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

                        acceptSound.Play();
                        heldDrink = -1;
                        cup.SetActive(false);
                        
                        //destroy planet instance, but let despawn animation play first
                        Destroy(col.gameObject, 1);

                    } else {
                        rejectSound.Play();
                    }
                }
            }
            //drop drink if any are held
            else if(Input.GetKeyDown(KeyCode.X)) {
                Debug.Log("Dropped current drink");
                heldDrink = -1;
                cup.SetActive(false);
            }


        }
        
    }

    private IEnumerator preparingDrink(float duration) {
        //wait before spawning to give a breather
        yield return new WaitForSeconds(duration);
        cup.SetActive(true);
        mobile = true;
    }

    
}
