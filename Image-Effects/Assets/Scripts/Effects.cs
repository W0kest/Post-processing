using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    Bloom BloomLayer = null;
    AmbientOcclusion AmbientLayer = null;
    ColorGrading ColoredLayer = null;
    MotionBlur MB = null;
    LensDistortion LD = null;

    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out BloomLayer);
        volume.profile.TryGetSettings(out AmbientLayer);
        volume.profile.TryGetSettings(out ColoredLayer);
        volume.profile.TryGetSettings(out MB);
        volume.profile.TryGetSettings(out LD);
    }

    //Clears effects
    public void ClearEffects()
    {
        BloomLayer.intensity.value = 0;
        BloomLayer.enabled.value = false;

        AmbientLayer.intensity.value = 0.5f;
        AmbientLayer.thicknessModifier.value = 0;
        AmbientLayer.enabled.value = false;

        ColoredLayer.saturation.value = 0;
        ColoredLayer.tint.value = 0;
        ColoredLayer.temperature.value = 0;

        ColoredLayer.mixerGreenOutGreenIn.value = 100;
        ColoredLayer.mixerBlueOutBlueIn.value = 100;
        ColoredLayer.enabled.value = false;

        LD.intensity.value = 0;
        LD.scale.value = 1;
        LD.enabled.value = false;
    }

    public void NightVision()
    {
        ClearEffects();

        BloomLayer.enabled.value = true;
        BloomLayer.intensity.value = 20;


        AmbientLayer.enabled.value = true;
        AmbientLayer.intensity.value = 1.6f;
        AmbientLayer.thicknessModifier.value = 5.15f;

        ColoredLayer.enabled.value = true;
        ColoredLayer.temperature.value = 90;
        ColoredLayer.tint.value = -100;
        ColoredLayer.saturation.value = 30;
    }

    public void ColorGraded()
    {
        ClearEffects();

        BloomLayer.enabled.value = true;
        BloomLayer.intensity.value = 10;

        ColoredLayer.enabled.value = true;
        ColoredLayer.saturation.value = 10;

        ColoredLayer.mixerGreenOutGreenIn.value = 40;
        ColoredLayer.mixerBlueOutBlueIn.value = 120;
    }

    public void Distortion()
    {
        ClearEffects();
        LD.enabled.value = true;
        LD.intensity.value = 70;
        LD.scale.value = 0.9f;
    }

    void MotionBlurring()
    {
        MB.enabled.value = true;
        MB.shutterAngle.value = 270;
        MB.sampleCount.value = 20;
    }
}
