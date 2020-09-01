using System.IO;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEngine;

namespace Kogane
{
	[CreateAssetMenu( fileName = "BuildScriptUnusedMode.asset", menuName = "Addressables/Content Builders/Unused" )]
	public sealed class BuildScriptUnusedMode : BuildScriptBase
	{
		public override string Name => "Unused";

		public override bool CanBuildData<T>()
		{
			return typeof( T ).IsAssignableFrom( typeof( AddressablesPlayModeBuildResult ) );
		}

		protected override TResult BuildDataImplementation<TResult>( AddressablesDataBuilderInput context )
		{
			/*
			 * 下記の例外が発生することを防ぐために、ここで com.unity.addressables フォルダを作成
			 *
			 * DirectoryNotFoundException: Could not find a part of the path "XXXX\UnityProject\Library\com.unity.addressables\AddressablesBuildTEP.json".
			 * System.IO.FileStream..ctor (System.String path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, System.Int32 bufferSize, System.Boolean anonymous, System.IO.FileOptions options) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * System.IO.FileStream..ctor (System.String path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share, System.Int32 bufferSize, System.IO.FileOptions options, System.String msgPath, System.Boolean bFromProxy, System.Boolean useLongPath, System.Boolean checkHost) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * (wrapper remoting-invoke-with-check) System.IO.FileStream..ctor(string,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,int,System.IO.FileOptions,string,bool,bool,bool)
			 * System.IO.StreamWriter.CreateFile (System.String path, System.Boolean append, System.Boolean checkHost) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * System.IO.StreamWriter..ctor (System.String path, System.Boolean append, System.Text.Encoding encoding, System.Int32 bufferSize, System.Boolean checkHost) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * System.IO.StreamWriter..ctor (System.String path, System.Boolean append, System.Text.Encoding encoding, System.Int32 bufferSize) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * System.IO.StreamWriter..ctor (System.String path, System.Boolean append, System.Text.Encoding encoding) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * (wrapper remoting-invoke-with-check) System.IO.StreamWriter..ctor(string,bool,System.Text.Encoding)
			 * System.IO.File.WriteAllText (System.String path, System.String contents, System.Text.Encoding encoding) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * System.IO.File.WriteAllText (System.String path, System.String contents) (at <437ba245d8404784b9fbab9b439ac908>:0)
			 * UnityEditor.AddressableAssets.Build.DataBuilders.BuildScriptBase.BuildData[TResult] (UnityEditor.AddressableAssets.Build.AddressablesDataBuilderInput builderInput) (at Library/PackageCache/com.unity.addressables@1.8.3/Editor/Build/DataBuilders/BuildScriptBase.cs:80)
			 * UnityEditor.AddressableAssets.Build.AddressablesBuildScriptHooks.OnEditorPlayModeChanged (UnityEditor.PlayModeStateChange state) (at Library/PackageCache/com.unity.addressables@1.8.3/Editor/Build/AddressablesBuildScriptHooks.cs:59)
			 * UnityEditor.EditorApplication.Internal_PlayModeStateChanged (UnityEditor.PlayModeStateChange state) (at <17b72532ee2c4da1b6f632d3f1705fe0>:0)
			 * UnityEngine.GUIUtility:ProcessEvent(Int32, IntPtr)
			 */
			var perfOutputDirectory = Path.GetDirectoryName( Application.dataPath ) + "/Library/com.unity.addressables";
			if ( !Directory.Exists( perfOutputDirectory ) )
			{
				Directory.CreateDirectory( perfOutputDirectory );
			}

			return AddressableAssetBuildResult.CreateResult<TResult>( string.Empty, 0 );
		}
	}
}