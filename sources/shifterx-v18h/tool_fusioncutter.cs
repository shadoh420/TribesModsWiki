$InvList[FusionCutterGun] = 1;
$RemoteInvList[FusionCutterGun] = 1;

$AutoUse[FusionCutterGun] = True;

$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = FusionCutterGun;
$NextWeapon[FusionCutterGun] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = FusionCutterGun;
$PrevWeapon[FusionCutterGun] = $temp;

$temp = "";

//$ItemMax[marmor, SAMgun] = 1;
//$ItemMax[mfemale, SAMgun] = 1;

$ItemMax[earmor, FusionCutterGun] = 1;
$ItemMax[efemale, FusionCutterGun] = 1;

$ItemMax[spyarmor, FusionCutterGun] = 1;
$ItemMax[spyfemale, FusionCutterGun] = 1;

$ItemMax[darmor, FusionCutterGun] = 0;
$ItemMax[dfemale, FusionCutterGun] = 0;

$ItemMax[harmor, FusionCutterGun] = 0;
$ItemMax[hfemale, FusionCutterGun] = 0;

$ItemMax[barmor, FusionCutterGun] = 0;
$ItemMax[bfemale, FusionCutterGun] = 0;

$ItemMax[marmor, FusionCutterGun] = 0;
$ItemMax[mfemale, FusionCutterGun] = 0;

$ItemMax[dmarmor, FusionCutterGun] = 0;
$ItemMax[dmfemale, FusionCutterGun] = 0;

$ItemMax[larmor, FusionCutterGun] = 0;
$ItemMax[lfemale, FusionCutterGun] = 0;

$ItemMax[stimarmor, FusionCutterGun] = 0;
$ItemMax[stimfemale, FusionCutterGun] = 0;

$ItemMax[sarmor, FusionCutterGun] = 0;
$ItemMax[sfemale, FusionCutterGun] = 0;

$ItemMax[aarmor, FusionCutterGun] = 1;
$ItemMax[afemale, FusionCutterGun] = 1;

$ItemMax[jarmor, FusionCutterGun] = 0;
