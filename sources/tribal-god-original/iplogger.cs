// Admin List:
// Disabled for security reasons... and im to lazy to fix these 'security issues' 
// so use the passwords.
//$TG::AdminList:Name[0] = "[TG]-X-Ecutioner";
//$TG::AdminList:Name[1] = "[TG]-FAH-Q";
//$TG::AdminList:Name[2] = "[TG]-PheoniX";
//$TG::AdminList:Name[3] = "[TG]-CLOUD";
//$TG::AdminList:Name[4] = "";
//$TG::AdminList:Name[5] = "";
//$TG::AdminList:Name[6] = "";
//$TG::AdminList:Name[7] = "";
//$TG::AdminList:Name[8] = "";
//$TG::AdminList:Name[9] = "";



//===================================CODE STARTS HERE=======================================
function IpLogger::Check(%clientId, %ip)
{
	%Name = Client::getName(%clientId);
	%NewIp = X::HackIp(%ip);
	
	// Bring In All Variables From IpLoggs.cs File.
	if(isFile("config\\IpLoggs.cs"))
	{ exec(IpLoggs); }
	
	
	// Save Ip And Name, If Neccecary
	if($IpLogger::New[%NewIp] == "")
	{
		$IpLogger::New["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::New[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] == "" && %Name != $IpLogger::New[%NewIp])
	{
		$IpLogger::Alias["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::Alias[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] != "" && $IpLogger::AliasAlt[%NewIp] == "" && %Name != $IpLogger::New[%NewIp] && %Name != $IpLogger::Alias[%NewIp])
	{
		$IpLogger::AliasAlt["[\""@ %NewIp @"\"]"] = ""@ %Name @"";
		Export("$IpLogger::AliasAlt[\""@ %NewIp @"\"*", "config\\IpLoggs.cs", true);
	}
	else if($IpLogger::New[%NewIp] != "" && $IpLogger::Alias[%NewIp] != "" && $IpLogger::AliasAlt[%NewIp] != "" && %Name != $IpLogger::New[%NewIp] && %Name != $IpLogger::Alias[%NewIp] && %Name != $IpLogger::AliasAlt[%NewIp])
	{ Schedule("TG::Kick(-1, "@ %clientId @");", 20, %clientId); }
	
	
	// Check For Name Change, For Announcing To Anyone In Game.
	if(%Name != $IpLogger::New[%NewIp] && $IpLogger::New[%NewIp] != "")
	{
		MessageAll(0, "User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".");
		XCenterPrintAll("<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".", 15);
		Schedule("XCenterPrintAll(\"<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".\", 14);", 1);
		Schedule("XCenterPrintAll(\"<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".\", 13);", 2);
		Schedule("XCenterPrintAll(\"<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".\", 12);", 3);
		Schedule("XCenterPrintAll(\"<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".\", 11);", 4);
		Schedule("XCenterPrintAll(\"<jc><f1>User: "@ %Name @" Has Changed Their Name From "@ $IpLogger::New[%NewIp] @".\", 10);", 5);
	}
	
	// Check For AutoAdmin. Disabled for security reasons.
//	for(%x = 0; (%autoaname = $TG::AdminList:Name[%x]) != ""; %x++)
//	{
//		if($IpLogger::New[%NewIp] == %autoaname)
//		{
//			%clientId.isAdmin = true;
//			%clientId.isSuperAdmin = true;
//			%clientId.isGodAdmin = true;
//			MessageAll(0, %Name @" Is Now A Tribal_God!~wforceopen.wav");
//			break;
//		}
//	}
	
	// Check For AutoBan.
	for(%i = 0; (%autobname = $TG::BanList:Name[%i]) != ""; %i++)
	{
		if(%autobname == %Name || $IpLogger::New[%NewIp] == %autobname)
		{
			Schedule("TG::Bann(-1, "@ %clientId @");", 15); 
			Schedule("XCenterPrint("@ %clientId @", \"<jc><f1>Hey "@ $IpLogger::New[%newIp] @",\\nI know it's you, changed the name, email me if you want to come back.\\n <f2>dustin8420@adelphia.net.\", 10);", 15);
			Schedule("XClient::sendMessage("@ %clientId @", 0, \"~wmale5.wbye.wav\");", 10);
			break;
		}
	}
}

function IpLogger::DisplayAlias(%admin, %clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	%ip = X::HackIp(%ip);
	
	XBottomPrint(%admin, "<jc><f1>Current Name: "@ Client::getName(%clientId) @"\nOriginal Name: "@ $IpLogger::New[%ip] @"\nAlias: "@ $IpLogger::Alias[%ip] @"\nAliasAlt: "@ $IpLogger::AliasAlt[%ip], 2);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 1);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 2);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 3);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 4);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 5);
	Schedule("XBottomPrint("@ %admin @", \"<jc><f1>Current Name: "@ Client::getName(%clientId) @"\\nOriginal Name: "@ $IpLogger::New[%ip] @"\\nAlias: "@ $IpLogger::Alias[%ip] @"\\nAliasAlt: "@ $IpLogger::AliasAlt[%ip] @"\", 2);", 6);
}

// special function to 'hack' off the port that shows up at the end up client's ips..
// had to make this since i think the port changes, don't wanna take any chances.
function X::HackIp(%ip)
{for(%i=3;%i<22;%i++){if(string::getsubStr(%ip,%i,1)==":"){%hackedIp=string::getsubStr(%ip,0,%i);return %hackedIp;}}}