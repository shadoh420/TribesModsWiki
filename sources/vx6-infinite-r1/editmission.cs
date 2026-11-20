// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

function MEModeMission()
{
   focus( MissionEditor );
   unfocus( TedObject );

   winMouse();
   cursorOn( MainWindow );
   unfocus( "2048\\PlayerPSC" );

   GuiNewContentCtrl(MainWindow, SimGui::TSControl);
   focus(editCamera);
   postAction(TS_0, Attach, editCamera);
}

function MEModeTed()
{
   focus( TedObject );
   unfocus( MissionEditor );

   winMouse();
   cursorOn( MainWindow );
   unfocus( "2048\\PlayerPSC" );

   GuiNewContentCtrl(MainWindow, SimGui::TSControl);
   focus(editCamera);
   postAction(TS_0, Attach, editCamera);
}

function MEModeGame()
{
   unfocus( TedObject );
   unfocus( MissionEditor );

   dirMouse();
   cursorOff( MainWindow );
   unfocus(editCamera);
	GuiLoadContentCtrl( MainWindow, "gui\\play.gui" );
   focus( "2048\\PlayerPSC" );
   postAction( playGui, Attach, "2048\\PlayerPSC" );
}

exec( "med.cs" );
exec( "ted.cs" );
move();
ted();

addMissionButton( SetGame, "SetPlayingGame.bmp", "Resume play", "MEModeGame();" );
addMissionButton( SetMission, "SetEditingMission.bmp", "Mission Edit Mode", "MEModeMission();" );
addMissionButton( SetTerrain, "SetEditingTerrain.bmp", "Terain Edit mode", "MEModeTed();" );
addMissionButton( Space1 );
addMissionButton( Pause, "SetPauseGame.bmp", "Pause game", "$SimGame::TimeScale = 0.0;", "$SimGame::TimeScale = 1.0;" );
addMissionButton( Space2 );
addMissionButton( Undo, "Undo.bmp", "Undo move/rotate", "missionUndoMoveRotate();" );
addMissionButton( Space3 );
addMissionButton( MovementMethod, "Temp.bmp", "New movement?", "$MED::useOldMovementMethod = false;", "$MED::useOldMovementMethod = true;" );

bind(keyboard, make, Escape, to, "winMouse();" );

bind(keyboard, make, f9, to, "MEModeGame();" );
bind(keyboard, make, f10, to, "MEModeMission();" );
bind(keyboard, make, f11, to, "MEModeTed();" );

MEModeMission();
