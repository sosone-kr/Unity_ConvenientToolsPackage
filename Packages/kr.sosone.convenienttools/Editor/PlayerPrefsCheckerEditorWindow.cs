using UnityEditor;
using UnityEngine;

public class PlayerPrefsCheckerEditorWindow : EditorWindow
{
    private string keyInput = "";
    private string valueInput = "";
    private string displayText = "";

    [MenuItem("Sosone/PlayerPrefs Checker")]
    public static void ShowWindow()
    {
        GetWindow<PlayerPrefsCheckerEditorWindow>("PlayerPrefs Checker");
    }

    private void OnGUI()
    {
        GUILayout.Label("PlayerPrefs Checker", EditorStyles.boldLabel);

        // PlayerPrefs 키 입력 받기
        GUILayout.BeginHorizontal();
        GUILayout.Label("PlayerPrefs Key:");
        keyInput = EditorGUILayout.TextField(keyInput);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        // PlayerPrefs 값 확인
        if (GUILayout.Button("Check Value"))
        {
            if (PlayerPrefs.HasKey(keyInput))
            {
                int intValue = PlayerPrefs.GetInt(keyInput);
                float floatValue = PlayerPrefs.GetFloat(keyInput);
                string stringValue = PlayerPrefs.GetString(keyInput);

                displayText = "Int Value: " + intValue + "\n" +
                              "Float Value: " + floatValue + "\n" +
                              "String Value: " + stringValue;
            }
            else
            {
                displayText = "Key not found!";
            }
        }

        // PlayerPrefs 값 수정
        GUILayout.Space(20);
        GUILayout.Label("Set PlayerPrefs Value:", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Value:");
        valueInput = EditorGUILayout.TextField(valueInput);
        GUILayout.EndHorizontal();

        // 각 타입별로 저장하는 버튼
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save Int"))
        {
            int intValue;
            if (int.TryParse(valueInput, out intValue))
            {
                PlayerPrefs.SetInt(keyInput, intValue);
                displayText = "Int value saved.";
            }
            else
            {
                displayText = "Invalid input for Int!";
            }
        }

        if (GUILayout.Button("Save Float"))
        {
            float floatValue;
            if (float.TryParse(valueInput, out floatValue))
            {
                PlayerPrefs.SetFloat(keyInput, floatValue);
                displayText = "Float value saved.";
            }
            else
            {
                displayText = "Invalid input for Float!";
            }
        }

        if (GUILayout.Button("Save String"))
        {
            PlayerPrefs.SetString(keyInput, valueInput);
            displayText = "String value saved.";
        }
        GUILayout.EndHorizontal();

        // 결과 텍스트 표시
        GUILayout.Space(20);
        GUILayout.Label("Result:", EditorStyles.boldLabel);
        EditorGUILayout.TextArea(displayText);
    }
}
