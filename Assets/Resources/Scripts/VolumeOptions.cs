using UnityEngine;
using UnityEngine.UI;

public class VolumeOptions : MonoBehaviour
{
    public Slider sliderVolumen;
    public GameObject canvasOptions;
    public GameObject canvasMenu;
    public AudioSource music;

    void Start()
    {
        canvasOptions.SetActive(false);

        if (music != null)
        {
            sliderVolumen.value = AudioListener.volume;
            sliderVolumen.onValueChanged.AddListener(CambiarVolumen);

            if (!music.isPlaying)
            {
                music.Play();
            }
        }
        else
        {
            Debug.LogError("No se ha asignado un AudioSource al script VolumeOptions.");
        }
    }

    void Update()
    {
        if (canvasOptions.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarOpciones();
        }
    }

    public void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
    }

    public void AbrirOpciones()
    {
        canvasMenu.SetActive(false);
        canvasOptions.SetActive(true);
    }

    public void CerrarOpciones()
    {
        canvasOptions.SetActive(false); 
        canvasMenu.SetActive(true);
    }
}
