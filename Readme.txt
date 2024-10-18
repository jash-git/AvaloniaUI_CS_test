AvaloniaUI C# 開發測試

教學資料:
https://www.youtube.com/watch?v=1mzM6N4drCU&list=PLJYo8bcmfTDF6ROxC8QMVw9Zr_3Lx4Lgd
https://docs.avaloniaui.net/docs/get-started/
https://docs.avaloniaui.net/zh-Hans/docs/get-started/ [簡中]
	https://docs.avaloniaui.net/zh-Hans/docs/tutorials/music-store-app/


Avalonia 開發環境建置[要在 Visual Studio 安裝 AvaloniaUI 開發環境]
	01.安裝 Avalonia Templates： 開啟 Visual Studio 的終端機，並執行以下命令：
		dotnet new -i Avalonia.Templates
	02.安裝 Avalonia for Visual Studio 擴展
		Visual Studio工具列的「延伸模組」-> 「管理延伸模組」 -> 搜尋列輸入Avalonia並安裝下列模組
			Avalonia for Visual Studio
			Avalonia Toolkit
			Template Studio for Avalonia
			
Avalonia 開發的WINDOWS程式 如果要發行 目的端要有那些環境 [https://github.com/AvaloniaUI/Avalonia/wiki/Runtime-Requirements]
	01.操作系統：Windows 8 或更高版本。Windows 7 也可以，但需要安裝平台更新。
	02..NET 環境：.NET Core 3.1 或更高版本1。
	03.Microsoft Visual C++ 2015 Redistributable：如果您使用 Skia 背景，需要安裝這個元件。			

Avalonia 測試項目
	★可以切換.NET版本 OK
	★可以編譯X64/X32版本 OK
	★全螢幕&隱藏工具列 OK
	★單一空殼專案編譯速度比MAUI 快
	★單一空殼專案編譯後產生檔案數量/複雜度/大小比MAUI 優(X64下 38檔案數/25M)
	★單一空殼專案啟動執行速度比MAUI 快
	★字型大小
	★解析度調整影響
	★動態變更配置UI版面調整大小
	★LISTVIEW 渲染效能
		單一/整批 更新
		改變顏色
			游標在項目上
			內容文字
		圖片
			顯示
			切換
	★彈出視窗
		效能
		多層疊加
	★基本元件
		switch
		checkbox
		comboBox
		image
		配置元件
	★元件開發