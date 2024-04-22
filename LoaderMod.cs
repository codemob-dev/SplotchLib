using BepInEx;
using UnityEngine.SceneManagement;
using System;

namespace SplotchLib
{
    [BepInSplotch(authors: new string[]{ "Codemob" })]
    [BepInPlugin("com.codemob.splotch", "Splotch", "0.1.0")]
    public class SplotchLoaderMod : BaseUnityPlugin
    {
        public void Awake()
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            SplotchGUI.Load();
            SplotchGUI.ShowPopup(Info.Metadata.Name, $"{Info.Metadata.Name} version {Info.Metadata.Version} is functional!");
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "MainMenu")
            {
                NodMames.AddOverlay();
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class BepInSplotchAttribute : Attribute
    {
        readonly string[] authors;
        public BepInSplotchAttribute(string[] authors)
        {
            this.authors = authors;
        }

        public string[] Authors
        {
            get { return authors; }
        }
    }
}
