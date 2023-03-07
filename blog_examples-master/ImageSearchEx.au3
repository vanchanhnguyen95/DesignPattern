#include <screencapture.au3>
#include <array.au3>
#include <GUIConstantsEx.au3>
#include <Constants.au3>
#include <WindowsConstants.au3>
#include <MsgBoxConstants.au3>
#include <GDIPlus.au3>
#include <WinAPIGdi.au3>
Func _ImageSearchEx($pathIMG, $title)
	$hwnd = WinGetHandle($title)
	$iWidth = _WinAPI_GetWindowWidth($hwnd)
	$iHeight = _WinAPI_GetWindowHeight($hwnd)
	Return _ImageSearchExArea($hwnd, $pathIMG, $iWidth, $iHeight)
EndFunc   ;==>_ImageSearchEx
Func _ImageSearchExArea($hwnd, $pathIMG, $iWidth, $iHeight)
	Local $p[2]
	_GDIPlus_Startup()
	;Get the hBitmap of the image i want to search for
	$Bitmap = _GDIPlus_BitmapCreateFromFile($pathIMG)
	$hBitmap = _GDIPlus_BitmapCreateHBITMAPFromBitmap($Bitmap)

	;Doing the actual window capture and saving it inside $hBMP
	$iWidth = _WinAPI_GetWindowWidth($hwnd) ; $browser = the handle of the window which I am capturing
	$iHeight = _WinAPI_GetWindowHeight($hwnd)
	$hDDC = _WinAPI_GetDC($hwnd)
	$hCDC = _WinAPI_CreateCompatibleDC($hDDC)
	$hBMP = _WinAPI_CreateCompatibleBitmap($hDDC, $iWidth, $iHeight)
	_WinAPI_SelectObject($hCDC, $hBMP)
	DllCall("User32.dll", "int", "PrintWindow", "hwnd", $hwnd, "hwnd", $hCDC, "int", 0)
	;Searching for the image
	$pos = _BmpSearch($hBMP, $hBitmap, 10)
	If $pos = 0 Then
		$p[0] = 0
		$p[1] = 0
		Return $p
	EndIf
	$p[0] = $pos[1][2]
	$p[1] = $pos[1][3]
	;delete resources
	_WinAPI_ReleaseDC($hwnd, $hDDC)
	_WinAPI_DeleteDC($hCDC)
	_WinAPI_DeleteObject($hBMP)
	_GDIPlus_Shutdown()
	Return $p
EndFunc   ;==>_ImageSearchExArea


; #FUNCTION# ====================================================================================================================
; Name ..........: _BmpSearch
; Description ...: Searches for Bitmap in a Bitmap
; Syntax ........: _BmpSearch($hSource, $hFind, $iMax=5000)
; Parameters ....: $hSource             - Handle to bitmap to search
;                  $hFind               - Handle to bitmap to find
;                  $iMax               	- Max matches to find
; Return values .: Success: Returns a 2d array with the following format:
;							$aCords[0][0] = Total Matches found
;							$aCords[$i][0] = Width of bitmap
;							$aCords[$i][1] = Hight of bitmap
;							$aCords[$i][2] = X cordinate
;							$aCords[$i][3] = Y cordinate
;
;					Failure: Returns 0 and sets @error to 1
;
; Author ........: Brian J Christy (Beege)
; ===============================================================================================================================
Func _BmpSearch($hSource, $hFind, $iMax = 5000)

	Static Local $aMemBuff, $tMem, $fStartup = True

	If $fStartup Then
		;####### (BinaryStrLen = 490) #### (Base64StrLen = 328 )####################################################################################################
		Local $Opcode = 'yBAAAFCNRfyJRfSNRfiJRfBYx0X8AAAAAItVDP8yj0X4i10Ii0UYKdiZuQQAAAD38YnBi0X4OQN0CoPDBOL36akAAACDfSgAdB1TA10oO10YD4OVAAAAi1UkORN1A1vrBluDwwTrvVOLVSyLRTADGjtdGHd3iwg5C3UhA1oEi0gEO10Yd2Y5C3USA1oIi0gIO10Yc1c5' & _
				'C3UDW+sGW4PDBOuCi1UUid6LfQyLTRCJ2AHIO0UYczfzp4P5AHcLSoP6AHQNA3Uc6+KDwwTpVP///4tFIIkYg0UgBIPDBP9F/ItVNDlV/HQG6Tj///9bi0X8ycIwAA=='

		Local $aDecode = DllCall("Crypt32.dll", "bool", "CryptStringToBinary", "str", $Opcode, "dword", 0, "dword", 1, "struct*", DllStructCreate("byte[254]"), "dword*", 254, "ptr", 0, "ptr", 0)
		If @error Or (Not $aDecode[0]) Then Return SetError(1, 0, 0)
		$Opcode = BinaryMid(DllStructGetData($aDecode[4], 1), 1, $aDecode[5])

		$aMemBuff = DllCall("kernel32.dll", "ptr", "VirtualAlloc", "ptr", 0, "ulong_ptr", BinaryLen($Opcode), "dword", 4096, "dword", 64)
		$tMem = DllStructCreate('byte[' & BinaryLen($Opcode) & ']', $aMemBuff[0])
		DllStructSetData($tMem, 1, $Opcode)
		;####################################################################################################################################################################################
		$fStartup = False
	EndIf

	Local $iTime = TimerInit()

	Local $tSizeSource = _WinAPI_GetBitmapDimension($hSource)
	Local $tSizeFind = _WinAPI_GetBitmapDimension($hFind)

	Local $iRowInc = ($tSizeSource.X - $tSizeFind.X) * 4

	Local $tSource = _GetBmpPixelStruct($hSource)
	Local $tFind = _GetBmpPixelStruct($hFind)

	Local $aFD = _FindFirstDiff($tFind)
	Local $iFirstDiffIdx = $aFD[0]
	Local $iFirstDiffPix = $aFD[1]

	Local $iFirst_Diff_Inc = _FirstDiffInc($iFirstDiffIdx, $tSizeFind.X, $tSizeSource.X)
	If $iFirst_Diff_Inc < 0 Then $iFirst_Diff_Inc = 0

	Local $tCornerPixs = _CornerPixs($tFind, $tSizeFind.X, $tSizeFind.Y)
	Local $tCornerInc = _CornerInc($tSizeFind.X, $tSizeFind.Y, $tSizeSource.X)

	Local $pStart = DllStructGetPtr($tSource)
	Local $iEndAddress = Int($pStart + DllStructGetSize($tSource))

	Local $tFound = DllStructCreate('dword[' & $iMax & ']')

	Local $ret = DllCallAddress('dword', DllStructGetPtr($tMem), 'struct*', $tSource, 'struct*', $tFind, _
			'dword', $tSizeFind.X, 'dword', $tSizeFind.Y, _
			'dword', $iEndAddress, 'dword', $iRowInc, 'struct*', $tFound, _
			'dword', $iFirstDiffPix, 'dword', $iFirst_Diff_Inc, _
			'struct*', $tCornerInc, 'struct*', $tCornerPixs, _
			'dword', $iMax)

	If Not $ret[0] Then Return SetError(1, 0, 0)

	Local $aCords = _GetCordsArray($ret[0], $tFound, $tSizeSource.X, $pStart, $tSizeFind.X, $tSizeFind.Y)
	Return SetExtended(Int(TimerDiff($iTime) * 1000), $aCords)

EndFunc   ;==>_BmpSearch


#Region Internal Functions
;Returns a Dllstructure will all pixels
Func _GetBmpPixelStruct($hBMP)

	Local $tSize = _WinAPI_GetBitmapDimension($hBMP)
	Local $tBits = DllStructCreate('dword[' & ($tSize.X * $tSize.Y) & ']')

	_WinAPI_GetBitmapBits($hBMP, DllStructGetSize($tBits), DllStructGetPtr($tBits))

	Return $tBits

#Tidy_Off
#cs

	This is how the dllstructure index numbers correspond to the pixel cordinates:

	An 5x5 dimension bmp:
		X0	X1	X2	X3	X4
	Y0 	1   2	3	4	5
	Y1	6	7	8	9	10
	Y2	11	12	13	14	15
	Y3	16	17	18	19	20
	Y4	21	22	23	24	25

	An 8x8 dimension bmp:
		X0	X1	X2	X3	X4	X5	X6	X7
	Y0	1	2	3	4	5	6	7	8
	Y1	9	10	11	12	13	14	15	16
	Y2	17	18	19	20	21	22	23	24
	Y3	25	26	27	28	29	30	31	32
	Y4	33	34	35	36	37	38	39	40
	Y5	41	42	43	44	45	46	47	48
	Y6	49	50	51	52	53	54	55	56
	Y7	57	58	59	60	61	62	63	64

#ce
#Tidy_On

EndFunc   ;==>_GetBmpPixelStruct

;Find first pixel that is diffrent than ....the first pixel
Func _FindFirstDiff($tPix)

	;####### (BinaryStrLen = 106) ########################################################################################################################
	Static Local $Opcode = '0xC80000008B5D0C8B1383C3048B4D103913750C83C304E2F7B800000000EB118B5508FF338F028B451029C883C002EB00C9C20C00'
	Static Local $aMemBuff = DllCall("kernel32.dll", "ptr", "VirtualAlloc", "ptr", 0, "ulong_ptr", BinaryLen($Opcode), "dword", 4096, "dword", 64)
	Static Local $tMem = DllStructCreate('byte[' & BinaryLen($Opcode) & ']', $aMemBuff[0])
	Static Local $fSet = DllStructSetData($tMem, 1, $Opcode)
	;#####################################################################################################################################################

	Local $iMaxLoops = (DllStructGetSize($tPix) / 4) - 1
	Local $aRet = DllCallAddress('dword', DllStructGetPtr($tMem), 'dword*', 0, 'struct*', $tPix, 'dword', $iMaxLoops)

	Return $aRet

EndFunc   ;==>_FindFirstDiff

; Calculates the value to increase pointer by to check first different pixel
Func _FirstDiffInc($iDx, $iFind_Xmax, $iSource_Xmax)

	Local $aFirstDiffCords = _IdxToCords($iDx, $iFind_Xmax)
	Local $iXDiff = ($iDx - ($aFirstDiffCords[1] * $iFind_Xmax)) - 1

	Return (($aFirstDiffCords[1] * $iSource_Xmax) + $iXDiff) * 4

EndFunc   ;==>_FirstDiffInc

;Converts the pointer addresses to cordinates
Func _GetCordsArray($iTotalFound, $tFound, $iSource_Xmax, $pSource, $iFind_Xmax, $iFind_Ymax)

	Local $aRet[$iTotalFound + 1][4]
	$aRet[0][0] = $iTotalFound

	For $i = 1 To $iTotalFound
		$iFoundIndex = ((DllStructGetData($tFound, 1, $i) - $pSource) / 4) + 1
		$aRet[$i][0] = $iFind_Xmax
		$aRet[$i][1] = $iFind_Ymax
		$aRet[$i][3] = Int(($iFoundIndex - 1) / $iSource_Xmax) ; Y
		$aRet[$i][2] = ($iFoundIndex - 1) - ($aRet[$i][3] * $iSource_Xmax) ; X
	Next

	Return $aRet

EndFunc   ;==>_GetCordsArray

;converts cordinates to dllstructure index number
Func _CordsToIdx($iX, $iY, $iMaxX)
	Return ($iY * $iMaxX) + $iX + 1
EndFunc   ;==>_CordsToIdx

;convert dllstructure index number to cordinates
Func _IdxToCords($iDx, $iMaxX)

	Local $aCords[2]
	$aCords[1] = Int(($iDx - 1) / $iMaxX) ; Y
	$aCords[0] = ($iDx - 1) - ($aCords[1] * $iMaxX) ; X

	Return $aCords

EndFunc   ;==>_IdxToCords

;Retrieves the Pixel Values of Right Top, Left Bottom, Right Bottom. Returns dllstructure
Func _CornerPixs(ByRef $tFind, $iFind_Xmax, $iFind_Ymax)

	Local $tCornerPixs = DllStructCreate('dword[3]')

	DllStructSetData($tCornerPixs, 1, DllStructGetData($tFind, 1, $iFind_Xmax), 1) ; top right corner
	DllStructSetData($tCornerPixs, 1, DllStructGetData($tFind, 1, ($iFind_Xmax + ($iFind_Xmax * ($iFind_Ymax - 2)) + 1)), 2) ;  bottom left corner
	DllStructSetData($tCornerPixs, 1, DllStructGetData($tFind, 1, ($iFind_Xmax * $iFind_Ymax)), 3) ;	bottom right corner

	Return $tCornerPixs

EndFunc   ;==>_CornerPixs

;Retrieves the pointer adjust values for Right Top, Left Bottom, Right Bottom. Returns dllstructure
Func _CornerInc($iFind_Xmax, $iFind_Ymax, $iSource_Xmax)

	Local $tCornerInc = DllStructCreate('dword[3]')

	DllStructSetData($tCornerInc, 1, ($iFind_Xmax - 1) * 4, 1)
	DllStructSetData($tCornerInc, 1, (($iSource_Xmax - $iFind_Xmax) + $iSource_Xmax * ($iFind_Ymax - 2) + 1) * 4, 2)
	DllStructSetData($tCornerInc, 1, ($iFind_Xmax - 1) * 4, 3)

	Return $tCornerInc

EndFunc   ;==>_CornerInc
#EndRegion Internal Functions

#cs Test/verify Functions
	Func _TestDiff()

	Local $hFind = _ScreenCapture_Capture('', 80, 250, 140, 280)
	Local $hSource = _ScreenCapture_Capture('', 80, 250, 240, 350)

	Local $tSizeSource = _WinAPI_GetBitmapDimension($hSource)
	Local $tSizeFind = _WinAPI_GetBitmapDimension($hFind)

	Local $iSource_Xmax = DllStructGetData($tSizeSource, 'X')
	Local $iFind_Xmax = DllStructGetData($tSizeFind, 'X')
	Local $iFind_Ymax = DllStructGetData($tSizeFind, 'Y')

	Local $tSource = _GetBmpPixelStruct($hSource)
	Local $tFind = _GetBmpPixelStruct($hFind)

	Local $aFD = _FindFirstDiff($tFind)
	Local $iFirstDiffIdx = $aFD[0]
	Local $iFirstDiffPix = $aFD[1]

	Local $iFirst_Diff_Inc = _FirstDiffInc($iFirstDiffIdx, $iFind_Xmax, $iSource_Xmax)

	$p = DllStructGetPtr($tSource)
	$temp = DllStructCreate('dword', $p + ($iFirst_Diff_Inc))
	$sourcepix = Hex(DllStructGetData($temp, 1), 8)

	_WinAPI_DeleteObject($hSource)
	_WinAPI_DeleteObject($hFind)

	EndFunc

	Func _TestCorners()

	Local $hFind = _ScreenCapture_Capture('', 1, 1, 100, 100)
	Local $hSource = _ScreenCapture_Capture('', 1, 1, 250, 350)

	Local $tSizeSource = _WinAPI_GetBitmapDimension($hSource)
	Local $tSizeFind = _WinAPI_GetBitmapDimension($hFind)

	Local $iSource_Xmax = DllStructGetData($tSizeSource, 'X')
	Local $iFind_Xmax = DllStructGetData($tSizeFind, 'X')
	Local $iFind_Ymax = DllStructGetData($tSizeFind, 'Y')

	Local $tSource = _GetBmpPixelStruct($hSource)
	Local $tFind = _GetBmpPixelStruct($hFind)

	Local $tCornerPixs = _CornerPixs($tFind, $iFind_Xmax, $iFind_Ymax)
	Local $tCornerInc = _CornerInc($iFind_Xmax, $iFind_Ymax, $iSource_Xmax)

	ConsoleWrite('TLC = ' & Hex(DllStructGetData($tFind, 1, 1), 8) & @LF)
	ConsoleWrite('TRC = ' & Hex(DllStructGetData($tCornerPixs, 1, 1), 8) & @LF)
	ConsoleWrite('BLC = ' & Hex(DllStructGetData($tCornerPixs, 1, 2), 8) & @LF)
	ConsoleWrite('BRC = ' & Hex(DllStructGetData($tCornerPixs, 1, 3), 8) & @LF)
	ConsoleWrite(@LF)

	$iFirstInc = DllStructGetData($tCornerInc, 1, 1)
	$iSecond = DllStructGetData($tCornerInc, 1, 2)
	$iThird = DllStructGetData($tCornerInc, 1, 3)

	$p = DllStructGetPtr($tSource)
	$tTLC = DllStructCreate('dword', $p)
	$tTRC = DllStructCreate('dword', $p + ($iFirstInc))
	$tBLC = DllStructCreate('dword', $p + ($iFirstInc+$iSecond))
	$tBRC = DllStructCreate('dword', $p + ($iFirstInc+$iSecond+$iThird))
	ConsoleWrite('TLC = ' & Hex(DllStructGetData($tTLC, 1), 8) & @LF)
	ConsoleWrite('TRC = ' & Hex(DllStructGetData($tTRC, 1), 8) & @LF)
	ConsoleWrite('BLC = ' & Hex(DllStructGetData($tBLC, 1), 8) & @LF)
	ConsoleWrite('BRC = ' & Hex(DllStructGetData($tBRC, 1), 8) & @LF)

	_WinAPI_DeleteObject($hSource)
	_WinAPI_DeleteObject($hFind)

	EndFunc
#ce

#cs Assembly Source

	Func _BmpSearch($hSource, $hFind, $iMax = 5000)

	Local $iTime = TimerInit()

	Local $tSizeSource = _WinAPI_GetBitmapDimension($hSource)
	Local $tSizeFind = _WinAPI_GetBitmapDimension($hFind)

	Local $iRowInc = ($tSizeSource.X - $tSizeFind.X) * 4

	Local $tSource = _GetBmpPixelStruct($hSource)
	Local $tFind = _GetBmpPixelStruct($hFind)

	Local $aFD = _FindFirstDiff($tFind)
	Local $iFirstDiffIdx = $aFD[0]
	Local $iFirstDiffPix = $aFD[1]

	Local $iFirst_Diff_Inc = _FirstDiffInc($iFirstDiffIdx, $tSizeFind.X, $tSizeSource.X)
	If $iFirst_Diff_Inc < 0 Then $iFirst_Diff_Inc = 0

	Local $tCornerPixs = _CornerPixs($tFind, $tSizeFind.X, $tSizeFind.Y)
	Local $tCornerInc = _CornerInc($tSizeFind.X, $tSizeFind.Y, $tSizeSource.X)

	Local $pStart = DllStructGetPtr($tSource)
	Local $iEndAddress = Int($pStart + DllStructGetSize($tSource))

	_FasmFunc("'struct*', $pSource, 'struct*', $pFind, " & _
	"'dword', $iFind_Xmax, 'dword', $iFind_Ymax, " & _
	"'dword', $iEndAddress, 'dword', $iRowInc, 'struct*', $pFound, " & _
	"'dword', $iFirstDiffPix, 'dword', $iFirst_Diff_Inc, " & _
	"'struct*', $pCornerInc, 'struct*', $pCornerPixs, " & _
	"'dword', $iMax")

	_FasmLocalVar('$iTotalFound = 0') ; create var to hold total found matches

	_FasmAdd("mov edx, $pFind") ; set edx to address of $tFind
	_FasmLocalVar('$iFirstPixel = dword[edx]'); first pixel to find

	_FasmAdd("mov ebx, $pSource") ; set ebx to address of $tSource. As we walk through the bitmap, ebx will hold are current postion throughout the whole function.

	; Start of main loop
	_FasmAdd("FindFistPixel:")
	_FasmAdd("		mov eax, $iEndAddress") ; set eax to $iEndaddress.
	_FasmAdd("		sub eax, ebx") ; subtract current address -
	_FasmAdd('		cdq') ; convert dword in eax to qword. the value is placed in edx:eax  - (needed for division below)
	_FasmAdd('		mov ecx, 4') ; ecx = 4 - ecx is the divisor for "div" instruction
	_FasmAdd('		div ecx') ; eax = (edx:eax)/ecx   (fyi - remainder is placed in edx if ever needed)
	_FasmAdd('		mov ecx, eax');  Set Max Loops --  ecx = ($iEndAddress-$iCurrentAddress) / 4
	_FasmAdd("		mov eax, $iFirstPixel")
	_FasmAdd("		CheckNextPixel:")
	_FasmJumpIf('		dword[ebx] = eax, CheckFirstDiff') ; Pixels match. Check if first diff pixels match.
	_FasmAdd("			add ebx, 4") ; increse current address to next pixel
	_FasmAdd("			loop CheckNextPixel") ; "loop" instruction will decrease ecx each loop and exit when ecx = 0
	_FasmAdd("jmp Finished")

	_FasmAdd("CheckFirstDiff:")
	_FasmJumpIf('	$iFirst_Diff_Inc = 0, CheckCorners') ; if inc is 0 then 'find' pic is all one color. must skip the diff check.
	_FasmAdd("		push ebx") ; save current are current address ( position)
	_FasmAdd("		add ebx, $iFirst_Diff_Inc") ; increase current address to first pixel that is different
	_FasmJumpIf("	ebx >= $iEndAddress, PopFinished")
	_FasmAdd("		mov edx, $iFirstDiffPix") ; set edx to pixel value to check
	_FasmJumpIf("	dword[ebx] <> edx, FirstDiffFail") ; compare pixels. jump to FirstDiffFail if not equal
	_FasmAdd("		pop ebx") ; restore address
	_FasmAdd("		jmp CheckCorners") ;

	_FasmAdd("FirstDiffFail:")
	_FasmAdd("		pop ebx") ; restore address
	_FasmAdd("		add ebx, 4") ; increase current address
	_FasmAdd("		jmp FindFistPixel") ; start over

	_FasmAdd("CheckCorners:")
	_FasmAdd("		push ebx")
	_FasmAdd("		mov edx, $pCornerInc") ; set edx to structure that holds are values to adjust pointer to corners
	_FasmAdd("		mov eax, $pCornerPixs") ; set ebx to struct that holds pixel values
	_FasmAdd("		add ebx, dword[edx]") ; increase address to top right corner
	_FasmJumpIf("	ebx > $iEndAddress, PopFinished")
	_FasmAdd("		mov ecx, dword[eax]") ; set ecx to pixel value
	_FasmJumpIf('	dword[ebx] <> ecx, CornerFail') ; compare
	_FasmAdd("		add ebx, dword[edx+4]") ; increase address to bottom left corner
	_FasmAdd("		mov ecx, dword[eax+4]") ; set ecx to bottom left pixel value
	_FasmJumpIf("	ebx > $iEndAddress, PopFinished")
	_FasmJumpIf('	dword[ebx] <> ecx, CornerFail') ; compare
	_FasmAdd("		add ebx, dword[edx+8]") ; increase address to bottom right corner
	_FasmAdd("		mov ecx, dword[eax+8]") ; set pixel value
	_FasmJumpIf("	ebx >= $iEndAddress, PopFinished")
	_FasmJumpIf('	dword[ebx] <> ecx, CornerFail') ; compare
	_FasmAdd("		pop ebx") ; restore orignal address
	_FasmAdd("		jmp CheckMatch") ; if we are here all corners matched. Now do a full check

	_FasmAdd("CornerFail:")
	_FasmAdd("		pop ebx") ; restore address
	_FasmAdd("		add ebx, 4") ; increase address to next pixel
	_FasmAdd("		jmp FindFistPixel") ; start over

	_FasmAdd("CheckMatch:")
	_FasmAdd("		mov edx, $iFind_Ymax") ; set edx to max number of rows to check
	_FasmAdd("		mov esi, ebx") ; set esi to current address. esi and edi must be used for the "repe cmpsd" command below
	_FasmAdd("		mov edi, $pFind") ;	set edi to address of find pic
	_FasmAdd("		NextRow:")
	_FasmAdd("			mov ecx, $iFind_Xmax") ; set max number of compares
	_FasmAdd("			mov eax, ebx") ; move current address to ebx
	_FasmAdd("			add eax, ecx") ; add max compares.
	_FasmJumpIf("	    eax >= $iEndAddress, Finished") ; verify we will not go past end address
	_FasmAdd("			repe cmpsd") ; 			repeats comparing bits in edi and esi until bits are not equal or ecx is 0
	_FasmJumpIf("		ecx > 0, NextPixel") ; if ecx is > 0 then we found a bits not equal, else the whole row matched
	_FasmAdd("			dec edx") ; dec row count
	_FasmJumpIf("		edx = 0, FoundMatch") ; if row count reaches 0 the we have a match. exit loop
	_FasmAdd("			add esi, $iRowInc") ; increase source address to next row
	_FasmAdd("			jmp NextRow") ; check next row

	_FasmAdd("NextPixel:")
	_FasmAdd("		add ebx, 4"); ; increase address
	_FasmAdd("		jmp FindFistPixel") ; start over

	_FasmAdd("FoundMatch:")
	_FasmAdd("		mov eax, $pFound") ; move pointer of $tFound to eax
	_FasmAdd("		mov dword[eax], ebx") ; set with address found
	_FasmAdd("		add $pFound, 4") ; increase address of $pfound.
	_FasmAdd("		add ebx, 4") ; increase current address
	_FasmAdd("		inc $iTotalFound") ; increase iTotalfound
	_FasmAdd("		mov edx, $iMax") ; set edx to max found
	_FasmJumpIf('	$iTotalFound = edx, Finished') ; verify we are not over are limit. if we are exit
	_FasmAdd("		jmp FindFistPixel") ; start over
	;End main loop

	_FasmAdd("PopFinished:")
	_FasmAdd("pop ebx")

	_FasmAdd("Finished:")
	_FasmAdd("mov eax, $iTotalFound")
	_FasmEndFunc()

	Return _FasmCompileMC('_BmpSearch')
	Local $pMem = _FasmGetFuncPtr()

	Local $tFound = DllStructCreate('dword[' & $iMax & ']')

	Local $ret = DllCallAddress('dword', $pMem, 'struct*', $tSource, 'struct*', $tFind, _
	'dword', $tSizeFind.X, 'dword', $tSizeFind.Y, _
	'dword', $iEndAddress, 'dword', $iRowInc, 'struct*', $tFound, _
	'dword', $iFirstDiffPix, 'dword', $iFirst_Diff_Inc, _
	'struct*', $tCornerInc, 'struct*', $tCornerPixs, _
	'dword', $iMax)

	If Not $ret[0] Then Return SetError(1, 0, 0)

	Local $aCords = _GetCordsArray($ret[0], $tFound, $tSizeSource.X, $pStart, $tSizeFind.X, $tSizeFind.Y)
	Return SetExtended(Int(TimerDiff($iTime) * 1000), $aCords)

	EndFunc   ;==>_BmpSearch


	Func __FindFirstDiff($tPix)
	_FasmFunc("'dword*', $iPixFound, 'struct*', $tPix, 'dword', $iMaxLoops")

	_FasmAdd("mov ebx, $tPix")
	_FasmAdd("mov edx, dword[ebx]")
	_FasmAdd("add ebx, 4")
	_FasmAdd("mov ecx, $iMaxLoops")

	_FasmAdd("CheckNext:")
	_FasmJumpIf('	dword[ebx] <> edx, Found')
	_FasmAdd("		add ebx, 4")
	_FasmAdd("		loop CheckNext")

	_FasmAdd("mov eax, 0")
	_FasmAdd("jmp Finished")

	_FasmAdd("Found:")
	_FasmAdd("		mov edx, $iPixFound")
	_FasmAdd("		push dword[ebx]")
	_FasmAdd("		pop dword[edx]")
	_FasmAdd("		mov eax, $iMaxLoops")
	_FasmAdd("		sub eax, ecx")
	_FasmAdd("		add eax, 2")
	_FasmAdd("		jmp Finished")

	_FasmAdd("Finished:")

	_FasmEndFunc()

	_FasmCompileMC('_FindFirstDiff')

	Local $pMem = _FasmGetFuncPtr()

	Local $iMaxLoops = (DllStructGetSize($tPix) / 4) - 1
	Local $iDx = DllCallAddress('dword', $pMem, 'dword*', 0, 'struct*', $tPix, 'dword', $iMaxLoops)

	Return $iDx
	EndFunc   ;==>__FindFirstDiff
#ce
