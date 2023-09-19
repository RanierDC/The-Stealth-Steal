using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorDeVolume : MonoBehaviour
{
    [Header("Volume Geral")]
    public Slider volumeSliderGeral = null;

    [Header("Volume Musica")]
    public Slider volumeSliderMusica = null;
    public AudioSource audioMusica;


    private void Start()
    {
        CarregarValores();
    }

    public void SalvarVolume()
    {
        // Linka os valores dos sliders
        float valorVolumeGeral = volumeSliderGeral.value;
        float valorVolumeMusica = volumeSliderMusica.value;

        // Armazena as informa��es
        PlayerPrefs.SetFloat("VolumeGeral", valorVolumeGeral);
        PlayerPrefs.SetFloat("VolumeMusica", valorVolumeMusica);
        CarregarValores();
    }

    void CarregarValores()
    {
        float valorVolumeGeral = PlayerPrefs.GetFloat("VolumeGeral");
        volumeSliderGeral.value = valorVolumeGeral;
        AudioListener.volume = valorVolumeGeral;

        float valorVolumeMusica = PlayerPrefs.GetFloat("VolumeMusica");
        volumeSliderMusica.value = valorVolumeMusica;
        audioMusica.volume = valorVolumeMusica;
    }
}
