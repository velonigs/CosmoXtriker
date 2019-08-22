using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///Requires Transparent Material///
///マテリアルの出現エフェクト///

public class AppearEffect : MonoBehaviour
{

    [SerializeField]
    protected bool isPaused = false;
    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }

    private enum EffectType
    {
        None,
        Fade,
        Flash
    }
    [SerializeField]
    private EffectType appearEffectType = EffectType.None; //出現時の演出//
    public float appearTime = 2f; //出現演出にかける時間//

    [SerializeField]
    private EffectType disappearEffectType = EffectType.None; //消滅時の演出//
    public float disappearTime = 2f; //消滅演出にかける時間//

    private float effectTimer;
    public float flashIntervalTime = 0.2f;//点滅間隔//
    private float flashIntervalTimer;

    private enum State
    {
        Invisible,
        Appear,
        Visible,
        Disappear

    }

    [SerializeField]
    private State state = State.Invisible;
    private bool isBodyRenderersEnabled = true;

    const float defaultColorAlpha = 1f;
    private float currentColorAlpha;

    private List<Renderer> bodyRenderers = new List<Renderer>();

    public delegate void OnComplete();//処理完了時のコールバック//
    OnComplete onComplete;

    public bool dontOverrideShaders = false;
    public Shader transparentShader;

    public void Awake()
    {

        if (transparentShader == null)
            transparentShader = Shader.Find("Transparent/Diffuse");

        //自分と子供のRendererを取得 Awake内必須//
        Renderer[] rendererList = this.gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in rendererList)
        {
            if (dontOverrideShaders == false)
                renderer.material.shader = transparentShader;

            bodyRenderers.Add(renderer);
        }

        if (bodyRenderers.Count == 0)
            Debug.LogWarning("NotFoundTransParentShader");

        if (state == State.Invisible)
            SethRenderersEnable(bodyRenderers, false);
    }

    public void StartAppear()
    {
        StartAppear(CompleteAppear);
    }

    public void StartAppear(OnComplete callback)
    {
        if (state == State.Visible)
            Debug.LogWarning("AlreadyVisible " + gameObject.name);

        onComplete = callback;
        state = State.Appear;

        switch (appearEffectType)
        {
            case EffectType.None:
                state = State.Visible;
                currentColorAlpha = 1f;
                SethRenderersEnable(bodyRenderers, true);
                onComplete();
                break;

            case EffectType.Fade:
                //Debug.Log("numof bodyRenderers"+ bodyRenderers.Count);
                SethRenderersEnable(bodyRenderers, true);
                SetRenderersAlpha(bodyRenderers, 0f);
                currentColorAlpha = 0.0f;
                break;

            case EffectType.Flash:
                SetRenderersAlpha(bodyRenderers, defaultColorAlpha);
                isBodyRenderersEnabled = false;
                break;
        }
    }

    public void StartDisappear()
    {
        StartDisappear(CompleteDisappear);
    }

    public void StartDisappear(OnComplete callback)
    {
        if (state == State.Invisible)
            Debug.LogWarning("AlreadyInvisible");

        onComplete = callback;

        state = State.Disappear;

        switch (disappearEffectType)
        {
            case EffectType.None:
                state = State.Invisible;

                currentColorAlpha = 0f;
                SethRenderersEnable(bodyRenderers, false);
                onComplete();

                break;

            case EffectType.Fade:
                SetRenderersAlpha(bodyRenderers, 1f);
                currentColorAlpha = 1.0f;
                break;

            case EffectType.Flash:
                SetRenderersAlpha(bodyRenderers, defaultColorAlpha);
                isBodyRenderersEnabled = true;
                break;
        }
    }

    void Update()
    {
        if (isPaused == true)
            return;

        switch (state)
        {
            case State.Invisible:
                break;
            case State.Appear:
                UpdateApper();
                break;
            case State.Visible:
                break;
            case State.Disappear:
                UpdateDisappear();
                break;
            default:
                break;
        }
    }

    void UpdateApper()
    {
        switch (appearEffectType)
        {
            case EffectType.None:

                break;

            case EffectType.Fade:
                currentColorAlpha += Time.deltaTime / appearTime;
                SetRenderersAlpha(bodyRenderers, currentColorAlpha);

                if (currentColorAlpha >= defaultColorAlpha)
                {
                    currentColorAlpha = defaultColorAlpha;
                    state = State.Visible;
                    onComplete();
                }
                break;

            case EffectType.Flash:
                flashIntervalTimer += Time.deltaTime;
                if (flashIntervalTimer > flashIntervalTime)
                {
                    flashIntervalTimer = 0f;
                    isBodyRenderersEnabled = !isBodyRenderersEnabled;
                    SethRenderersEnable(bodyRenderers, isBodyRenderersEnabled);
                }

                effectTimer += Time.deltaTime;
                if (effectTimer > appearTime)
                {
                    effectTimer = 0f;
                    SethRenderersEnable(bodyRenderers, true);
                    state = State.Visible;
                    onComplete();
                }
                break;
        }
    }

    void UpdateDisappear()
    {
        switch (disappearEffectType)
        {
            case EffectType.None:

                break;

            case EffectType.Fade:
                currentColorAlpha -= Time.deltaTime / disappearTime;
                SetRenderersAlpha(bodyRenderers, currentColorAlpha);

                if (currentColorAlpha <= 0f)
                {
                    currentColorAlpha = 0f;
                    SethRenderersEnable(bodyRenderers, false);

                    state = State.Invisible;
                    onComplete();
                }


                break;
            case EffectType.Flash:
                flashIntervalTimer += Time.deltaTime;
                if (flashIntervalTimer > flashIntervalTime)
                {
                    flashIntervalTimer = 0f;
                    isBodyRenderersEnabled = !isBodyRenderersEnabled;
                    SethRenderersEnable(bodyRenderers, isBodyRenderersEnabled);
                }

                effectTimer += Time.deltaTime;
                if (effectTimer > disappearTime)
                {
                    effectTimer = 0f;
                    SethRenderersEnable(bodyRenderers, false);

                    state = State.Invisible;
                    onComplete();
                }
                break;
        }
    }

    //Rendererのリストに指定のアルファ値を設定する//
    void SetRenderersAlpha(List<Renderer> renderers, float alpha)
    {
        foreach (Renderer r in renderers)
        {
            Color current = r.material.color;
            r.material.color = new Color(current.r, current.g, current.b, alpha);
        }
    }

    //RendererのリストにEnabled設定を行う//
    void SethRenderersEnable(List<Renderer> renderers, bool bodyRenderersEnabled)
    {
        foreach (Renderer r in renderers)
        {
            r.enabled = bodyRenderersEnabled;
        }
    }

    public void SetAppearEffectType(string effectType)
    {
        if (effectType.ToLower() == "fade")
        {
            appearEffectType = EffectType.Fade;
        }

        if (effectType.ToLower() == "flash")
        {
            appearEffectType = EffectType.Flash;
        }
    }

    public void SetDisappearEffectType(string effectType)
    {
        if (effectType.ToLower() == "fade")
        {
            disappearEffectType = EffectType.Fade;
        }

        if (effectType.ToLower() == "flash")
        {
            disappearEffectType = EffectType.Flash;
        }
    }

    void CompleteAppear()
    {
        //コールバックを指定せずにStartAppearを呼び出した場合実行される//
    }

    void CompleteDisappear()
    {
        //コールバックを指定せずにStartDisappearを呼び出した場合実行される//
    }

    public void OnPause()
    {
        isPaused = true;
    }

    public void OnResume()
    {
        isPaused = false;
    }
}