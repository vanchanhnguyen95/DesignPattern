#include <Constants.au3>
#include <Date.au3>
#include <ImageSearch.au3>
#include <Array.au3>

;
; AutoIt Version: 3.0
; Language:       English
; Platform:       Win9x/NT
; Author:         Jonathan Bennett (jon at autoitscript dot com)
;
; Script Function:
;   Opens Notepad, types in some text and then quits the application.
;

; vào tầng 3
; vào vị trí 1
; -> mở bản đồ
; -> click tọa độ 1
; -> click chuột trái lên tọa độ cây cờ 1
; -> tự đánh chờ boss
; -> phát hiện boss
; -> lưu time
; -> đánh boss
; -> chờ boss chết ???
; -> chờ 1 or 2s nhặt đồ
; đến vị trí 2
; -> mở bản đồ or tọa độ
; -> click chuột lên cây cờ
; -> tự đánh chờ boss (1 or 2s)
; -> phát hiện boss
; -> đánh boss
; -> chờ boss chết ???
; -> chờ 1 or 2s nhặt đồ
; đến vị trí 3
; -> lặp vị trí 2
; lặp đến vị trí 10

; vào tầng 2
; -> lặp bước tầng 3

; vào tầng 1
; -> lặp bước tầng 3

; out
; -> de bien kinh
; -> ngồi thiền
; -> chờ đến time + 15'
; -> vào lại tầng 3

#b_color1 = 0x93080B
#b_color2 = 0x92080B

$b_left_x = 720
$b_left_y = 342
$b_right_x = 771
$b_right_y = 321

$td1_x = 718
$td1_y = 439
$f1_x = 716
$f1_y = 393

$td2_x = 845
$td2_y = 481
$f2_x = 841
$f2_y = 439

$td3_x = 909
$td3_y = 559
$f3_x = 908
$f3_y = 516

$td4_x = 1021
$td4_y = 509
$f4_x = 1019
$f4_y = 468

$td5_x = 1107
$td5_y = 627
$f5_x = 1106
$f5_y = 587

$td6_x = 1030
$td6_y = 672
$f6_x = 1029
$f6_y = 629

$td7_x = 948
$td7_y = 719
$f7_x = 945
$f7_y = 677

$td8_x = 832
$td8_y = 753
$f8_x = 828
$f8_y = 712

$td9_x = 923
$td9_y = 832
$f9_x = 921
$f9_y = 789

$td10_x = 759
$td10_y = 702
$f10_x = 757
$f10_y = 662

$icon_tl1_x= 1606
$icon_tl1_y = 300
$icon_tl2_x = 1304
$icon_tl2_y = 274

$title_chrome = 'Võ Lâm Truyền Kỳ Web - Google Chrome'
$title_m_edge = "Calculator"
$w_class = '[CLASSnn:ApplicationFrameInputSinkWindow1]'

Global $map_x = 1708, $map_y = 142

Func jpos()
   $jpos = MouseGetPos()
   MsgBox(0, "Tọa độ chuột x,y:", $jpos[0] & "," & $jpos[1])
EndFunc

Func run_boss($td_x, $td_y, $f_x, $f_y)
   ; -> mở bản đồ
   Call('open_map')
   Sleep(1000)
   ; -> click tọa độ
   ;$r = MouseClick('left', $td_x, $td_y)
   $r = ControlClick($title_chrome, "","", "left", 1, $td_x, $td_y)
   Sleep(1000)
   ; -> click chuột trái lên tọa độ cây cờ
   $r = ControlClick($title_chrome, "","", "left", 1, $f_x, $f_y)
   ;$r = MouseClick('left', $f_x, $f_y)
   ; -> đóng bản đồ
   Call('open_map')
   ; -> tự đánh chờ boss (1 or 2s)

   ; -> phát hiện boss
   ; -> đánh boss
   ; -> chờ boss chết ???
   ; -> chờ 1 or 2s nhặt đồ
EndFunc

Global $b_found = False

Func reset_b_found()
   $b_found = False
EndFunc

Func open_map()
   ;$r = MouseClick('left', $map_x, $map_y)
   $r = ControlClick($title_chrome, "","", "left", 1, $map_x, $map_y)
EndFunc

Global $close_x = 0, $close_y = 0
Func kill_boss()
   ; khi boss chưa xuất hiện
   While 1

	  Local $btn_close = _ImageSearch(@ScriptDir&'\dungngay.jpg', 1, $close_x, $close_y, 0)
	  If $btn_close = 1 Then
		 MsgBox('','','found')
		 MouseClick("left", $close_x, $close_y)
	  EndIf

	  $b = PixelSearch($b_left_x,$b_left_y,$b_right_x,$b_right_y, 0xFFFEE9)
	  Sleep(500)
	  ; -> đánh boss
	  If Not @error and IsArray($b) Then
		 $b_found = True
		 MsgBox('','','found')
		 MsgBox('','',"X and Y are: " & $b[0] & "," & $b[1])
		 Sleep(500)
		 MouseClick("left", $b[0], $b[1], 1, 0)
		 Sleep(500)
		 ; -> đánh boss
		 Send('{z}')

		 ; -> chờ boss chết ???
		 Sleep(10000)

		 ; -> chờ 1 or 2s nhặt đồ
		 Sleep(3000)

		 ExitLoop
	  EndIf
   WEnd
EndFunc

; Thoát chương trình
Func ExitApp()
   Exit
EndFunc


Func test()
   WinActivate($title_chrome)
   Sleep(1000)

   ;$r = MouseClick('left', 1363, 435)
   $r = ControlClick($title_chrome, "","", "left", 1, 1606, 300)

;$handle = WinGetHandle("Võ Lâm Truyền Kỳ Web - Google Chrome", "")
;ControlClick($handle,"","","",1,1606, 300)
EndFunc

Func go()
   ; vào tầng 3
   WinActivate($title_m_edge)
   $r = ControlClick($title_chrome, "","", "left", 1, $icon_tl1_x, $icon_tl1_y)
   ;$r = MouseClick('left', $icon_tl1_x, $icon_tl1_y)
   Sleep(1000)
EndFunc

Func Start()

   ; vào tầng
   ; vào tầng 3
   WinActivate($title_chrome)
   Sleep(1000)

   Call('reset_b_found')

   ; vào vị trí 1
   Call("run_boss", $td1_x, $td1_y, $f1_x, $f1_y)
   Sleep(15000)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   ; -> lưu time boss đầu
   $current_dt = _Now()

   ; đến vị trí 2
   Call("run_boss", $td2_x, $td2_y, $f2_x, $f2_y)
   ; kill boss
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)

   ; đến vị trí 3
   Call("run_boss", $td3_x, $td3_y, $f3_x, $f3_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)

   ; đến vị trí 4
   Call("run_boss", $td4_x, $td4_y, $f4_x, $f4_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)

   ; đến vị trí 5
   Call("run_boss", $td5_x, $td5_y, $f5_x, $f5_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)
   ; đến vị trí 6
   Call("run_boss", $td6_x, $td6_y, $f6_x, $f6_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)
   ; đến vị trí 7
   Call("run_boss", $td7_x, $td7_y, $f7_x, $f7_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)
   ; đến vị trí 8
   Call("run_boss", $td8_x, $td8_y, $f8_x, $f8_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)
   ; đến vị trí 9
   Call("run_boss", $td9_x, $td9_y, $f9_x, $f9_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')
   Sleep(5000)
   ; đến vị trí 10
   Call("run_boss", $td10_x, $td10_y, $f10_x, $f10_y)
   ; kill boss
   ;Call('kill_boss')
   ; reset trạng thái boss sau khi kill xong
   Call('reset_b_found')

EndFunc

Call("Start")