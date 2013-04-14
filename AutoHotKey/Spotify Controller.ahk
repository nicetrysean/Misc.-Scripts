SetTitleMatchMode 2 

; "CTRL + LEFT"  for previous 
#Left:: 
DetectHiddenWindows, On 
ControlSend, ahk_parent, ^{Left}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 


; "CTRL + RIGHT"  for next 
#Right:: 
{ 
DetectHiddenWindows, On 
ControlSend, ahk_parent, ^{Right}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 
} 

; "CTRL + UP"  for pause
#Space::
{ 
DetectHiddenWindows, On 
ControlSend, ahk_parent, {space}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 
} 

; "CTRL + DOWN"  for info 
#Down:: 
{ 
DetectHiddenWindows, On 
SetTitleMatchMode 2 
WinGetTitle, now_playing, ahk_class SpotifyMainWindow 
StringTrimLeft, playing, now_playing, 10 
DetectHiddenWindows, Off 
clipboard = %playing%`r`n
return 
} 

; "CTRL + PAGE UP"  for volume up
#PgUP::
{ 
DetectHiddenWindows, On 
ControlSend, ahk_parent, ^{Up}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 
} 

; "CTRL + PAGE DOWN"  for volume down
#pgDn::
{ 
DetectHiddenWindows, On 
ControlSend, ahk_parent, ^{Down}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 
} 

; "CTRL + END"  for mute
#End::
{ 
DetectHiddenWindows, On 
ControlSend, ahk_parent, ^+{Down}, ahk_class SpotifyMainWindow 
DetectHiddenWindows, Off 
return 
}