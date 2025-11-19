AvaloniaUI C# 開發測試

教學資料:
https://www.youtube.com/watch?v=1mzM6N4drCU&list=PLJYo8bcmfTDF6ROxC8QMVw9Zr_3Lx4Lgd
https://docs.avaloniaui.net/docs/get-started/
https://docs.avaloniaui.net/zh-Hans/docs/get-started/ [簡中]
	https://docs.avaloniaui.net/zh-Hans/docs/tutorials/music-store-app/


Avalonia 開發環境建置[要在 Visual Studio 安裝 AvaloniaUI 開發環境]
	01.安裝 Avalonia Templates： 開啟 Visual Studio 的終端機，並執行以下命令：
		dotnet new install Avalonia.Templates [同時也可以更新功能]
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
		private void FullScreenMode()
	★單一空殼專案編譯速度比MAUI 快
	★單一空殼專案編譯後產生檔案數量/複雜度/大小比MAUI 優 (X64下 38檔案數/25M)
	★單一空殼專案啟動執行速度比MAUI 快 (明顯能區別)
	★字型大小
		◇字型大小設定方式
			<TextBlock FontSize="20" FontFamily="Arial" FontWeight="Bold" FontStyle="Italic" Text="{Binding Greeting}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
				裝置無關單位 (dius): dius 是一個相對單位，其大小會根據螢幕解析度和 DPI 而變化，確保文字在不同設備上顯示比例一致。
				單位: 雖然 FontSize 接受 double 值，但實際上你通常會使用整數值。
				樣式優先順序: 如果一個元素同時受到樣式和直接屬性設定的影響，直接屬性設定的優先級更高。			
	★解析度調整影響
		◇解析度是否會直接影響字型大小
			以下測試結果放在【解析度對文字顯示影響】資料夾中
	★指定顯示螢幕 可以
		private void SpecifyScreen(int intIndx=1)
	★Timer/Thread
		◇System.Timers 可以
		◇System.Threading 可以
	★彈出視窗
		◇多層疊加 可以
	★基本元件 [https://docs.avaloniaui.net/zh-Hans/docs/basics/user-interface/controls/builtin-controls]
			  [https://reference.avaloniaui.net/api/Avalonia.Controls/]
		◇ListBox 
			https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/listbox			
			無法改變 選擇背景顏色
		◇ToggleSwitch
		◇ComboBox		
		◇Checkbox
			https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/checkbox
			無法改變 選取框的大小
		◇ScrollViewer+Border
			https://docs.avaloniaui.net/docs/reference/controls/scrollviewer
		◇Button
			https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/buttons/button
		◇圖片元件
			▲Image
				https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/image
			▲image-controls
				https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/image-controls
		◇布局元件
			▲Panel
				https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/panel
			▲StackPanel
				Spacing: 間距
				Orientation: 設定堆疊的方向，可以是 Horizontal（水平）或 Vertical（垂直）。
				Children: 包含所有子元素的集合。
			▲Grid	
				https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/grid/			
			▲Border
				https://docs.avaloniaui.net/zh-Hans/docs/reference/controls/border
	★元件開發
		◇圖片按鈕
			
	★動態變更配置UI版面調整大小

====================
YT: "avalonia c# tutorial"

簡體原廠教學文件: https://docs.avaloniaui.net/zh-Hans/docs/welcome
原廠範例: https://github.com/AvaloniaUI/Avalonia.Samples
https://github.com/AvaloniaUI/AvaloniaUI.QuickGuides

繁體一系列教學(就是要來點 A.I. 的 TopAOAIConnector App 系列):
	https://ithelp.ithome.com.tw/users/20126714/ironman/7900
	https://github.com/JamestsaiTW/TopAOAIConnector	
	
	
====================
avalonia 和Visual Studio 一直更新 會出現 Infinite layout loop detected 錯誤，此時發現 avalonia 更新架構了
	AI資料:	https://chatgpt.com/share/691c37b5-5e14-8009-80f0-cadf4001ae1b
			https://chatgpt.com/share/691c37d2-8034-8009-9e47-3e197bb519b8
			https://chatgpt.com/share/691c37f9-8c84-8009-89f6-a3fe7202465e
			https://chatgpt.com/share/691c3810-705c-8009-94d2-bdd5cc69e32a
	測試範例:
		Avalonia_Infinite-ayout-loop-detected_2026 [Avalonia11+.net10]