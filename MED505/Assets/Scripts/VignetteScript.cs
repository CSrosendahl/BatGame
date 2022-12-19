using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class VignetteScript : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette _DeathSides;
    public float duration = 1f;
    public bool death;
    // Start is called before the first frame update

    void Start()
    {
        volume.profile.TryGetSettings(out _DeathSides);
        _DeathSides.intensity.value = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerDead) {

           

            AudioManager.instance.SwapTrack(AudioManager.instance.bigCitySound);

            _DeathSides.intensity.value = Mathf.Lerp(_DeathSides.intensity.value, 5, 0.5f * Time.deltaTime); 
        } else
        {
            _DeathSides.intensity.value = 0;
        }

    }


}
