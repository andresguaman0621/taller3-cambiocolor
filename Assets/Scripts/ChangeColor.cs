//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ChangeColor : MonoBehaviour
//{
//    [SerializeField] private GameObject sphere;
//    private Renderer sphereRenderer;
//    private Color newSphereColor;
//    private float randomChannelOne, randomChannelTwo, randomChannelThree;
//    // Start is called before the first frame update
//    void Start()
//    {
//        sphereRenderer = sphere.GetComponent<Renderer>();
//        gameObject.GetComponent<Button>().onClick.AddListener(ChangeSpereColor);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void ChangeSpereColor()
//    {
//        randomChannelOne = Random.Range(0f, 1f);
//        randomChannelTwo = Random.Range(0f, 1f);
//        randomChannelThree = Random.Range(0f, 1f);

//        newSphereColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree, 1f);

//        sphereRenderer.material.SetColor("_Color", newSphereColor);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject targetObject; // Referencia al objeto target
    private Renderer sphereRenderer;
    private Color newSphereColor;
    public int playerSpeed = 10;
    [SerializeField] public AudioSource sphereAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = sphere.GetComponent<Renderer>();
        // Asignar la tecla C para cambiar de color
        // Puedes cambiar la tecla a la que desees
        if (targetObject != null)
        {
            // Cambiar el color inicial del objeto target al color de la esfera
            targetObject.GetComponent<Renderer>().material.color = sphereRenderer.material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar cuando se presiona la tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeSphereColor(); // Cambiar el color de la esfera
            ChangeTargetColor(); // Cambiar el color del objeto target al color de la esfera
            sphereAudioSource.Play();
        }

        //Funciones de movimiento
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

    }

    private void ChangeSphereColor()
    {
        float randomChannelOne = Random.Range(0f, 1f);
        float randomChannelTwo = Random.Range(0f, 1f);
        float randomChannelThree = Random.Range(0f, 1f);

        newSphereColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree, 1f);

        sphereRenderer.material.color = newSphereColor;
    }

    private void ChangeTargetColor()
    {
        if (targetObject != null)
        {
            targetObject.GetComponent<Renderer>().material.color = sphereRenderer.material.color;
        }
    }
}


