using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelecter : MonoBehaviour
{
    // 武器名を表示するテキスト
    [SerializeField]
    private Text _weaponNameText;

    // 武器の威力を表示するテキスト
    [SerializeField]
    private Text _weaponImpactText;

    // 武器名の配列
    [SerializeField]
    private WeaponData[] _weaponData;

    // 選択している武器番号
    [SerializeField]
    private int _currentSelectNum;

    [SerializeField]
    private GameObject _equipment;

    [SerializeField]
    private GameObject _weaponSelecter;

    [SerializeField]
    private Tutorial _tutorial;

    // 1フレーム前に選択していた武器番号
    private int _prevSelectNum = -1;

    // プレビュー用モデル
    private GameObject _previewModel;

    // 選択済みか？
    private bool _isSelected = false;
    public bool IsSelected {
        get { return _isSelected; }
    }
    void Update() {
        // Wで次の装備、Sで前の装備に進める
        // TODO: WとSをトラックパッドの入力に切り替える
        if (Input.GetKeyDown(KeyCode.W)) {
            _currentSelectNum++;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            _currentSelectNum--;
        }

        // 範囲外のときは1周する
        // 武器総数より数値が大きい場合は0番目の武器に変更する
        if (_currentSelectNum >= _weaponData.Length) {
            _currentSelectNum = 0;
            // 数値がマイナスの値の場合は武器総数-1番目の武器に変更する
        } else if (_currentSelectNum < 0) {
            _currentSelectNum = _weaponData.Length - 1;
        }

        // 選択している武器が変わっていたら
        // (前回選択した番号と現在選択している番号が違ったら)
        if (_prevSelectNum != _currentSelectNum) {
            // 武器パネルの更新
            UpdateWeaponPanel();
            // 武器モデルの更新
            UpdateWeaponPreview();
        }

        // 武器が決定されたら選択済みフラグを立てる
        if (Input.GetKeyDown(KeyCode.Return)) {
            _isSelected = true;
            _equipment.SetActive(false);
            _weaponSelecter.SetActive(false);
            _tutorial.StartTutorial();
        }

        // 今回選択した番号を記録する
        _prevSelectNum = _currentSelectNum;
    }

    /// <summary>
    /// 武器パネルの更新
    /// </summary>
    private void UpdateWeaponPanel() {
        // 現在装備している武器のデータ
        WeaponData currentWeapon = _weaponData[_currentSelectNum];
        // 表示テキストをに武器データで更新
        _weaponNameText.text = currentWeapon.Name;
        _weaponImpactText.text = "威力 : " + currentWeapon.Impact;
    }

    /// <summary>
    /// プレビューモデルの更新
    /// </summary>
    private void UpdateWeaponPreview() {
        float oldRotationY = _previewModel?_previewModel.transform.rotation.y:0.0f;
        // プレビューモデルがあればを削除
        if (_previewModel) {
            Destroy(_previewModel);
        }
        // プレビューモデルを作成
        WeaponData weaponData = _weaponData[_currentSelectNum];
        // このゲームオブジェクトを親としてモデルを生成
        _previewModel = Instantiate(weaponData.PreviewModel, transform.position, Quaternion.Euler(weaponData.PreviewModel.transform.rotation.eulerAngles + Vector3.up * oldRotationY));
        _previewModel.transform.parent = this.transform;
        
    }

    private void OnEnable() {
        _equipment.SetActive(true);
    }

}
