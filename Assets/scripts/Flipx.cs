using UnityEngine;

public class Flipx : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    SpriteRenderer sr;
    bool isflip = false;

    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
        //다른 방법
        // transform.rotation = Quaternion.Euler(0,180,0);   updaye()  =  identity
        // 다른 방법 2:  transform.localscale = new vector3(-1,1,1);  udate() = vecto3.one

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isflip = !isflip;

        if(isflip)
        {
            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }
     
        
    }
}
