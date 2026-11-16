using UnityEngine;
using UnityEngine.Audio;

public static class ReproductorSonido
{
    public static void Reproducir(AudioClip clip, Vector3 posicion, AudioMixerGroup grupo, float volumen = 1f)
    {
        GameObject temporal = new GameObject("SonidoTemporal");
        temporal.transform.position = posicion;

        AudioSource fuente = temporal.AddComponent<AudioSource>();
        fuente.clip = clip;
        fuente.outputAudioMixerGroup = grupo;
        fuente.spatialBlend = 0f;
        fuente.volume = volumen;
        fuente.Play();

        Object.Destroy(temporal, clip.length);
    }
}