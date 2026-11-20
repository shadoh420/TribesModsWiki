//
// The mission list is the list of mission displayed to the players
// and admins in the server menu, used on the client side to display
// mission avialable on the Host Server screen, and is is also used
// to initialize the nextMission array which controls which mission
// to load after a mission finishes.
//
// function MissionList::clear();
//
// function MissionList::addMission(%missionName);
//
//    Add a mission to the current mission list.
//    Mission information is extracted from the mission .dsc file.
//    The mission file does not need to be in the base/missions dir.
//
// function MissionList::build()
//
//    Add any missions files that match the missions/*.dsc pattern.
//    This will include any missions in base/misssions/* or missions
//    in mods as long as they are in a missions subdirectory.
//
// function MissionList::initNextMission()
//
//    Initialize the nextMission array based on the current mission list.
//    When a mission changes it references the nextMission array to determin
//    which mission to load next.  The function initializes the array based
//    on mission type, so missions don't cycle to a mission of a different
//    type.
//    The array is easy to initialize manually:
//       $nextMission["CrissCross"] = "Raindance";
//       $nextMission["Raindance"] = "CrissCross";
//

function MissionList::clear()
{
   $MLIST::Count = 0;
   $MLIST::TypeCount = 1;
   $MLIST::Type[0] = "All Types";
   $MLIST::MissionList[0] = "";
}  

function MissionList::addMission(%mission)
{
   $MDESC::Type = "";
   $MDESC::Name = "";
   $MDESC::Text = "";

   if (String::findSubStr(%mission,".dsc") == -1)
      %mission = %mission @ ".dsc";
   exec(%mission);

   if($MDESC::Type == "")
      return false;

   for(%i = 0; %i < $MLIST::TypeCount; %i++) {
      if($MLIST::Type[%i] == $MDESC::Type)
         break;
   }
   if(%i == $MLIST::TypeCount) {
      $MLIST::Type[%i] = $MDESC::Type;
      $MLIST::TypeCount++;
      $MLIST::MissionList[%i] = "";
   }
   %ct = $MLIST::Count;
   $MLIST::Count++;

   $MLIST::EType[%ct] = $MDESC::Type;
   $MLIST::ECondition[%ct] = $MDESC::Condition;
   $MLIST::EName[%ct] = File::getBase(%mission);
   $NameType[$MLIST::ENAME[%ct]] = $MLIST::EType[%ct];
   $MLIST::EText[%ct] = $MDESC::Text;
   if($MDESC::Type != "Training")
      $MLIST::MissionList[0] = %ct @ " " @ $MLIST::MissionList[0];
   $MLIST::MissionList[%i] = %ct @ " " @ $MLIST::MissionList[%i];

   return true;
}

function MissionList::build()
{
   MissionList::clear();

   %file = File::findFirst("missions\\*.dsc");
   while(%file != "") {
      if(String::findSubstr(%file,"DF_") != -1)
	MissionList::addMission(%file);
      %file = File::findNext("missions\\*.dsc");
   }
}

function MissionList::initNextMission()
{
	%ServerSideStart = "";
	%ClientSideStart = "";
	%AIStart = "";

   for(%type = 1; %type < $MLIST::TypeCount; %type++) {
      %prev = getWord($MLIST::MissionList[%type], 0);
      %ml = $MLIST::MissionList[%type] @ %prev;
      %prevName = $MLIST::EName[%prev];
      for(%i = 1; (%mis = getWord(%ml, %i)) != -1; %i++) {
         %misName = $MLIST::EName[%mis];
         $nextMission[%prevName] = %misName;
         %prevName = %misName;

	 if($MLIST::EType[%mis] == "ServerSide")
		 %ServerSideStart = %misName;
	 if($MLIST::EType[%mis] == "ClientSide")
		 %ClientSideStart = %misName;
	 if($MLIST::EType[%mis] == "AI")
		 %AIStart = %misName;

      }
   }
	// User whatever they wanted.
	if($Server::StartingMissionType == "AI")
	  $StartMission = %ServerSideStart;
	else if($Server::StartingMissionType == "ClientSide")
	  $StartMission = %ClientSideStart;
	else if($Server::StartingMissionType == "ServerSide")
	  $StartMission = %AIStart;
	
	// If we failed to find any of the type we wanted, use serverside.
	if($StartMission == "")
	  $StartMission = %ServerSideStart;	

	// If we failed to find any of the type we wanted, and didn't find serverside missions,
	// user AI (less change of being clientside than ClientSide)
	if($StartMission == "")
	  $StartMission = %AIStart;	

	// If we failed to find any of the type we wanted, and didn't find serverside missions,
	// or AI missions, use Clientside
	if($StartMission == "")
	  $StartMission = %ClientSideStart;	
}


// Go ahead and build the list
MissionList::build();
MissionList::initNextMission();
