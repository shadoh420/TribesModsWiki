// This was my attempt at setting up different 'priorities' for bottom and centerprinting,
// Alot of center and bottomprints are used and this would make sure that only the most 
// important bottom or centerprint is shown. Development fell threw.

// Level One:
function centerprint(%clientId, %msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "CP", %msg, %timeout); }
}

function bottomprintall(%msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "BP", %msg, %timeout); }
}

function topprintall(%msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "TP", %msg, %timeout); }
} 

// Level Two:
function XCenterPrint(%clientId, %message, %time)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%time == ""){ %time = 5; }
	remoteEval(%clientId, "CP", %message, %time);
	%clientId.importantCP = true;
	Schedule(%clientId @".importantCP = false;", %time);
}
function XBottomPrint(%clientId, %message, %time)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	
	if(%time == "")
	{ %time = 5; }
	remoteEval(%clientId, "BP", %message, %time);
	%clientId.importantBP = true;
	Schedule(%clientId @".importantBP = false;", %time);
}
function XBottomPrintAll(%message, %time)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		remoteEval(%clientId, "BP", %message, %time);
		%clientId.importantBP = true;
		Schedule(%clientId @".importantBP = false;", %time);
	}
}
function XCenterPrintAll(%msg, %timeout)
{
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	
	if(%timeout == "")
	{ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "CP", %msg, %timeout); }
}