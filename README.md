# UniAddressablesBuildScriptUnusedMode

Unity 再生時に Addressable Asset System のデータベースの作成を無効化する機能

## 使い方

![2020-09-06_124440](https://user-images.githubusercontent.com/6134875/92317716-fbb80080-f03e-11ea-9a23-181d05944f4f.png)

Project ビューで「+ > Addressables > Content Builders > Unused」を選択して  

![2020-09-06_124748](https://user-images.githubusercontent.com/6134875/92317745-31f58000-f03f-11ea-876d-14e0da324f6a.png)

「BuildScriptUnusedMode」アセットを作成して  

![2020-09-06_124524](https://user-images.githubusercontent.com/6134875/92317718-fce92d80-f03e-11ea-8caa-11f444ab832a.png)

「AddressableAssetSettings」の「Build and Play Mode Scripts」に設定します  

![2020-09-06_124600](https://user-images.githubusercontent.com/6134875/92317719-fce92d80-f03e-11ea-8ea5-508f51ced87a.png)

そして「Addressables Groups」ウィンドウで「Play Mode Script」を「Unused」に変更すると  
Unity 再生時に Addressable のデータベースが作成されないようになります  

## 補足

* Addressable で管理するアセットが増えてくると、  
Unity 再生時のデータベース作成処理に時間がかかるようになったため、  
その時間を短縮するために作成した機能になります  
* データベースの作成がスキップされるため、Addressable のデータが変更されると  
ゲームが正常に動作しなくなります  
* データベースの作成が不要な時のみ「Play Mode Script」を「Unused」にするか、  
「Play Mode Script」が「Unused」の時は Addressable の機能を使用せずに  
AssetDatabase でアセットを読み込んで使用することを想定しています  
