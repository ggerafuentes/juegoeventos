using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AjustesMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject panelPrincipal;
    [SerializeField] private GameObject panelAjustes;

    [Header("Controles")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderEfectos;
    [SerializeField] private TMP_Dropdown dropdownGraficos;

    void Start()
    {
        // Gráficos
        dropdownGraficos.ClearOptions();
        dropdownGraficos.AddOptions(new List<string>(QualitySettings.names));
        int calidad = PlayerPrefs.GetInt("Calidad", QualitySettings.GetQualityLevel());
        dropdownGraficos.SetValueWithoutNotify(calidad);
        QualitySettings.SetQualityLevel(calidad);

        // Volumen
        float musica = PlayerPrefs.GetFloat("VolMusica", 0.8f);
        float efectos = PlayerPrefs.GetFloat("VolEfectos", 0.8f);
        sliderMusica.SetValueWithoutNotify(musica);
        sliderEfectos.SetValueWithoutNotify(efectos);
        mixer.SetFloat("VolMusica", ADecibelios(musica));
        mixer.SetFloat("VolEfectos", ADecibelios(efectos));

        dropdownGraficos.onValueChanged.AddListener(CambiarCalidad);
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);

        panelAjustes.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    public void AbrirAjustes()
    {
        panelPrincipal.SetActive(false);
        panelAjustes.SetActive(true);
    }

    public void CerrarAjustes()
    {
        PlayerPrefs.Save();
        panelAjustes.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    void CambiarCalidad(int indice)
    {
        QualitySettings.SetQualityLevel(indice);
        PlayerPrefs.SetInt("Calidad", indice);
    }

    void CambiarVolumenMusica(float valor)
    {
        mixer.SetFloat("VolMusica", ADecibelios(valor));
        PlayerPrefs.SetFloat("VolMusica", valor);
    }

    void CambiarVolumenEfectos(float valor)
    {
        mixer.SetFloat("VolEfectos", ADecibelios(valor));
        PlayerPrefs.SetFloat("VolEfectos", valor);
    }

    float ADecibelios(float valor)
    {
        return Mathf.Log10(Mathf.Max(valor, 0.0001f)) * 20f;
    }
}