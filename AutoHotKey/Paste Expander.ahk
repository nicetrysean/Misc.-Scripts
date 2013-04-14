; Created By Sean O'Dowd to transpose and walk through data into Excel and the likes.

^.::
Gui +LastFound +AlwaysOnTop -Caption +ToolWindow
 Gui Color, #40150B
 Gui Font, s60
 Gui Add, Text, Xp+20 Yp+2 W500 Vdisp Cred
 WinSet TransColor, #40150B
 Gui Show, x0 y10 NoActivate, Display


StringSplit, Cell, clipboard, `n, `r
Loop, %Cell0%
{
   Keywait, LCtrl, d
   Keywait, LCtrl ; press and release left control to 'walk through' the data
   SendRaw, % Cell%A_Index%
   Next_Line := A_Index + 1
   
   Send, {tab}
   GuiControl, Text, disp, % Cell%Next_Line%
}
Gui, Destroy
Return 