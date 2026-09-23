using UnityEngine;
using UnityEngine.InputSystem;

public class Inoutsys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame


    void Update()
    {
        if(Keyboard.current.aKey.isPressed)
        {
            // ==getkey 비슷한거
        }
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            // getkeydown
        }
        if(Keyboard.current.aKey.wasReleasedThisFrame)
        {
            // getkeyup 누른 상태에서 뗐다
        }

        if(Mouse.current.leftButton.isPressed)
        {
            //마우스 버트으은~
        }
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            //마우스가 한 번 눌 렸 을 걸
        }
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            //마우스 누른 상태에서 떼기 
        }

        //Vector2 pos = Input.mousePosition;
        Vector2 pos = Mouse.current.position.value;
        //Input.GetAxis("Mouse X")
        //float x = Mouse.current.delta.value.x;
        //float y = Mouse.current.delta.value.y;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

    }
}
