using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    [SerializeField]
    ScreenInput Input;

    // テスト用
    [SerializeField]
    private Text _testText;
    [SerializeField]
    private GameObject testOBJ;
    [SerializeField]
    private GameObject testOBJ2;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPSに設定
    }

    // Update is called once per frame
    void Update()
    {
        // 文字表示処理
        _testText.text = "Flick:" + Input.GetNowFlick().ToString();
        _testText.text += "\nSwipe:" + Input.GetNowSwipe().ToString();
        _testText.text += "\nRange:" + Input.GetSwipeRange();

        // ひとつ目のオブジェクトを動かす処理
        float _work = Input.GetSwipeRange() * Time.deltaTime * 0.01f;

        switch (Input.GetNowSwipe())
        {
            case ScreenInput.SwipeDirection.UP:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x, testOBJ.transform.localPosition.y + _work);
                break;
            case ScreenInput.SwipeDirection.DOWN:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x, testOBJ.transform.localPosition.y - _work);
                break;
            case ScreenInput.SwipeDirection.LEFT:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x - _work, testOBJ.transform.localPosition.y);
                break;
            case ScreenInput.SwipeDirection.RIGHT:
                testOBJ.transform.localPosition = new Vector3(testOBJ.transform.localPosition.x + _work, testOBJ.transform.localPosition.y);
                break;
        }

        // ふたつ目のオブジェクトを動かす処理
        if (Input.GetNowSwipe() != ScreenInput.SwipeDirection.TAP)
        {
            testOBJ2.transform.localPosition = new Vector3(testOBJ2.transform.localPosition.x + Input.GetSwipeRangeVec().x * Time.deltaTime * 0.01f, testOBJ2.transform.localPosition.y + Input.GetSwipeRangeVec().y * Time.deltaTime * 0.01f);
        }
    }
}
