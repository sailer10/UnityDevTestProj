using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 입력 처리
public class PlayerController : MonoBehaviour
{
    public enum Ability
    {
        magnetism       = 0,    // 자성
        gravity         = 1,    // 역중력
        acceleration    = 2,    // 가속
        invisible       = 3,    // 투명
        elasticity      = 4,    // 탄성
        gunfire         = 5     // 총쏘기
    }

    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private CameraController cameraController;
    private Movement3D movement3D;
    private CharacterController characterController;

    public Ability ability = Ability.gravity;


    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 방향키 좌/우 움직임
        float z = Input.GetAxisRaw("Vertical");     // 방향키 상/하 움직임

        movement3D.MoveTo(new Vector3(x, 0, z));

        // 점프키를 눌러 y축 방향으로 점프
        if (Input.GetKeyDown(jumpKeyCode) && characterController.isGrounded)
        {
            movement3D.JumpTo(); 
        }

        float mouseX = Input.GetAxis("Mouse X");    // 마우스 좌/우 움직임
        float mouseY = Input.GetAxis("Mouse Y");    // 마우스 상/하 움직임
        cameraController.RotateTo(mouseX, mouseY);

        // 능력 선택
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ability = Ability.magnetism;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ability = Ability.gravity;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ability = Ability.acceleration;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ability = Ability.invisible;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ability = Ability.elasticity;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            ability = Ability.gunfire;
        }

        // 플레이어 바라보는 방향으로 레이발사. 이걸로 물체 제어할거임
        Ray ray = new Ray(transform.position, cameraController.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        // 물체 상호작용
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo; // ray와 충돌한 물체 정보
            Physics.Raycast(ray, out hitInfo);
            GameObject hitObject = hitInfo.transform.gameObject;
            Debug.Log(ability);


            //물체를 클릭했고 그것이 Cube라면
            if (hitInfo.collider != null && hitObject.CompareTag("Cube"))
            {
                
                switch (ability)
                {
                    case Ability.magnetism:
                        break;

                    case Ability.gravity:
                        hitObject.GetComponent<ActBoxController>().reverseGravity = 
                            !hitObject.GetComponent<ActBoxController>().reverseGravity;
                        break;

                    case Ability.acceleration:
                        break;

                    case Ability.invisible:
                        hitObject.GetComponent<MeshRenderer>().enabled =
                            !hitObject.GetComponent<MeshRenderer>().enabled;
                        break;
                    case Ability.elasticity:
                        break;

                    default:
                        Debug.Log("player ability select error!");
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("COIN"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("FLOOR"))
        {
            transform.position = new Vector3(0, 3, 0);
            Debug.Log("투명바닥충돌. 플레이어 위치 이동시킴");
        }
    }
    /*  characterController 는 다음 함수로 충돌처리 해야함
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("FLOOR"))
        {
            transform.position = new Vector3(0, 3, 0);
            Debug.Log("투명바닥충돌. 플레이어 위치 이동시킴");
        }
    }
    */

}

