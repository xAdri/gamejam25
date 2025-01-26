using UnityEngine;
using UnityEngine.UI;

public class CamRecorder : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject medusa;
    public GameObject delfin;
    public Camera targetCamera; // C�mara espec�fica a usar
    public bool isVisibleDelfin;
    public GameObject imgDelfin;
    public GameObject imgMedusa;

    private Renderer delfinRenderer;
    private Renderer medusaRenderer;

    private void Start()
    {
        // Obtenemos el componente Renderer del delf�n y ajolote
        delfinRenderer = delfin.GetComponent<Renderer>();
        medusaRenderer = medusa.GetComponent<Renderer>();

        InvokeRepeating("ShowAnimal", 5f, 5f);
    }

    public void ShowAnimal()
    {
        isVisibleDelfin = Random.Range(0, 2) == 0;
    }

    private void Update()
    {
        if (isVisibleDelfin)
        {
            imgDelfin.SetActive(true);
            imgMedusa.SetActive(false);
        }
        else
        {
            imgDelfin.SetActive(false);
            imgMedusa.SetActive(true);
        }
        slider.value = sliderValue;

        // Verifica si el delf�n est� en la vista de la c�mara especificada
        if (IsVisibleInCamera(delfin, targetCamera) && isVisibleDelfin)
        {
            IsOnCamera();

            if (sliderValue > 1.1f)
            {
                slider.value = 1f;
                sliderValue = 1f;
            }
        }
        else
        {
            IsNotOnCamera();

            if (sliderValue < -0.1f)
            {
                slider.value = 0f;
                sliderValue = 0f;
            }
        }

        // Verifica si el delf�n est� en la vista de la c�mara especificada
        if (IsVisibleInCamera(medusa, targetCamera) && !isVisibleDelfin)
        {
            IsOnCamera();

            if (sliderValue > 1.1f)
            {
                slider.value = 1f;
                sliderValue = 1f;
            }
        }
        else
        {
            IsNotOnCamera();

            if (sliderValue < -0.1f)
            {
                slider.value = 0f;
                sliderValue = 0f;
            }
        }
    }

    private bool IsVisibleInCamera(GameObject obj, Camera cam)
    {
        // Convierte la posici�n del objeto a coordenadas de la c�mara
        Vector3 viewportPos = cam.WorldToViewportPoint(obj.transform.position);

        // Comprueba si el objeto est� dentro del rango visible (0 a 1 en viewport)
        return viewportPos.x >= 0 && viewportPos.x <= 1 &&
               viewportPos.y >= 0 && viewportPos.y <= 1 &&
               viewportPos.z > 0; // Debe estar delante de la c�mara
    }

    public void IsOnCamera()
    {
        sliderValue += 0.002f;
    }

    public void IsNotOnCamera()
    {
        sliderValue -= 0.001f;
    }
}
