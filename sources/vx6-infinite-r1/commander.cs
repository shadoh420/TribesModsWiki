// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

function CommandGui::onOpen()
{

	if ($pref::mapFilter & 0x0001) Control::setValue(IDCTG_CMDO_PLAYERS, "TRUE");
	else Control::setValue(IDCTG_CMDO_PLAYERS, "FALSE");

	if ($pref::mapFilter & 0x0002) Control::setValue(IDCTG_CMDO_TURRETS, "TRUE");
	else Control::setValue(IDCTG_CMDO_TURRETS, "FALSE");

	if ($pref::mapFilter & 0x0004) Control::setValue(IDCTG_CMDO_ITEMS, "TRUE");
	else Control::setValue(IDCTG_CMDO_ITEMS, "FALSE");

	if ($pref::mapFilter & 0x0008) Control::setValue(IDCTG_CMDO_OBJECTS, "TRUE");
	else Control::setValue(IDCTG_CMDO_OBJECTS, "FALSE");

	if (String::ICompare($pref::mapSensorRange, "TRUE") == 0) Control::setValue(IDCTG_CMDO_RADAR, "TRUE");
	else Control::setValue(IDCTG_CMDO_RADAR, "FALSE");

	if (String::ICompare($pref::mapNames, "TRUE") == 0) Control::setValue(IDCTG_CMDO_EXTRA, "TRUE");
	else Control::setValue(IDCTG_CMDO_EXTRA, "FALSE");

   Control::setValue("TVButton", false);
}