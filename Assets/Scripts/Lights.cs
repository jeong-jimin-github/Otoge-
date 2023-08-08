using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    [SerializeField] private int num = 0;
    private Renderer rend;
    private float alfa = 0;
    public GameObject touch1;
    public GameObject touch2;
    public GameObject touch3;
    public GameObject touch4;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {

        if (!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.r, rend.material.color.r, alfa);
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                // Ray를 생성합니다.
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Ray가 어떤 오브젝트와 만났는지 확인합니다.
                if (Physics.Raycast(ray, out hit))
                {
                    if (num == 1)
                    {
                        if (hit.transform == touch1.transform)
                        {

                        colorChange();
                        }
                    }
                    if (num == 2)
                    {
                        if (hit.transform == touch2.transform)
                        {
                            colorChange();
                        }
                    }
                    if (num == 3)
                    {
                        if (hit.transform == touch3.transform)
                        {
                            colorChange();
                        }
                    }
                    if (num == 4)
                    {
                        if (hit.transform == touch4.transform)
                        {
                            colorChange();
                        }
                    }
                }
            }
        }

        if (num == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                colorChange();
            }
        }
        if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                colorChange();
            }
        }
        if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                colorChange();
            }
        }
        if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                colorChange();
            }
        }
        alfa -= Speed * Time.deltaTime;
    }

    void colorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
    }
}