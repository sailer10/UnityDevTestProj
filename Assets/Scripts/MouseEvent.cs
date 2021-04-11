using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Description: 마우스 안보이게 하기
 * cursor invisible 사용 결과 Start()에서 사용해도 정상적으로 작동함
 */

public class MouseEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
