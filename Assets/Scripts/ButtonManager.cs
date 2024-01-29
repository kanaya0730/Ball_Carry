using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _startButton.onClick.AsObservable()
            .Subscribe(_ => _sceneLoader.FadeIn(SceneLoader.SceneName.Game))
            .AddTo(this);
    }


}