using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace Ucmd.BuildPlayer
{
    public class PerformBuildIOS : BuildBase
    {
        private static bool isNewCreate = true;
        
        /// <summary>
        /// Ucmd外部调用函数入口
        /// </summary>
        public static void Run()
        {   
            var scenes = GetScenes();
            var path = BuildHelper.CheckBuildPath(OutputPath);
            //是否是测试包
            EditorUserBuildSettings.development = IsRelease;
            //是否有额外编译宏
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, BuildSymbols);
            var option = isNewCreate ? BuildOptions.None : BuildOptions.AcceptExternalModificationsToPlayer; //is append
            BuildPipeline.BuildPlayer(scenes, path, BuildTarget.iOS, option);
            ExecuteHook(HookType.Finish);
        }
    }
}