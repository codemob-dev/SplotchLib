using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using BepInEx.Bootstrap;

namespace SplotchLib
{
    internal static class ModNames
    {
        public static void AddOverlay()
        {
            // Create a new canvas
            var mainMenuOverlayObject = new GameObject();
            Canvas canvas = mainMenuOverlayObject.AddComponent<Canvas>();
            CanvasScaler scaler = mainMenuOverlayObject.AddComponent<CanvasScaler>();

            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.current;

            canvas.sortingLayerName = "behind Walls Infront of everything else";
            canvas.sortingOrder = 1;

            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            // create the version info GameObject and set the parent to the canvas
            GameObject versionInfoText = new GameObject("Splotch_Version_info", typeof(RectTransform), typeof(TextMeshProUGUI));
            TextMeshProUGUI textComponent = versionInfoText.GetComponent<TextMeshProUGUI>();
            versionInfoText.transform.SetParent(canvas.transform);

            textComponent.text = LoadInfoText();

            // change settings
            textComponent.font = LocalizedText.localizationTable.GetFont(Settings.Get().Language, false);
            textComponent.color = Color.Lerp(Color.blue, Color.black, 0.6f);
            textComponent.fontSize = 13;

            // Allow the text to be clicked through
            textComponent.raycastTarget = false;

            // Align to bottom right
            textComponent.alignment = TextAlignmentOptions.BottomRight;

            // set the position of the text to the bottom right of the screen
            RectTransform rectTransform = versionInfoText.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(1f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 0f);
            rectTransform.pivot = new Vector2(1, 0);
            rectTransform.sizeDelta = new Vector2(1200, 0);
            rectTransform.anchoredPosition = new Vector2(-10, 30);
        }

        private static string LoadInfoText()
        {
            string infoText = string.Empty;
            foreach (var plugin in Chainloader.PluginInfos)
            {
                infoText += $"{plugin.Value.Metadata.Name} version {plugin.Value.Metadata.Version} by ";
                var bepInSplotch = Attribute.GetCustomAttribute(plugin.Value.Instance.GetType(), typeof(BepInSplotchAttribute)) as BepInSplotchAttribute;
                if (bepInSplotch == null) {
                    if (plugin.Key.Split('.').Length == 3)
                    {
                        infoText += plugin.Key.Split('.')[1];
                    }
                    else if (plugin.Key.Split('.').Length == 2)
                    {
                        infoText += plugin.Key.Split('.')[0];
                    }
                    else
                    {
                        infoText += "Unknown";
                    }
                } else
                {
                    infoText += string.Join(", ", bepInSplotch.Authors);
                }
                infoText += "\n";
            }
            return infoText.Trim();
        }
    }
}
