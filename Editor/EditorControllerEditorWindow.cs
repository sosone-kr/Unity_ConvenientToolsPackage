using UnityEditor;
using UnityEngine;

public class EditorControllerEditorWindow : EditorWindow
{
    [MenuItem("Sosone/Editor Controller")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow(typeof(EditorControllerEditorWindow));
        window.titleContent = new GUIContent("Editor Controller");
    }

    void OnGUI()
    {
        // 버튼 사이즈 조정
        float buttonWidth = 200f;
        float buttonHeight = 50f;

        // 'Refresh' 버튼 생성
        if (GUILayout.Button("Refresh", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
        {
            AssetDatabase.Refresh();
        }

        if (GUILayout.Button("Refresh and Play", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
        {
            AssetDatabase.Refresh();

            // Refresh 후 Play 모드로 전환
            EditorApplication.isPlaying = true;
        }

        // 'Play' 버튼 생성
        if (GUILayout.Button("Play/Stop", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
        {
            // 플레이 모드 시작
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
    }
}
