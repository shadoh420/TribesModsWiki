

//------------------------------------------------------------------------------------------------------------------------------// 
//------------------------------------------------------------------------------------------------------------------------------//
//-----This is a list of people that have proven to be pricks and assholes, if you want them on your server modify accordingly--//
//-----------if you would like for me to add some smuck to this shitlist e-mail me at URG_thrash@planetstarsiege.com------------//
//------------------------------------------------------------------------------------------------------------------------------//
//------------------------------------------------------------------------------------------------------------------------------//
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
 function Kickabitch(%clientId) { Net::kick(%clientId, "Guess you thought you where gonna be cute and slam me eh bitch? Well I have banned your Bitch ass from ultra!."); } 
 function Kickaasshole(%clientId) { Net::kick(%clientId, "HotRod ,It Never Pays To Be A Asshole. You Are Banned From Ultra"); }
 function Kickaasshole1(%clientId) {  Net::kick(%clientId, "FK thrasher, You Are Banned From Ultra_Renegades3 and every mod i put out in the future."); }
 function Kickaasshole2(%clientId) { Net::kick(%clientId, "Improper Name, Join under a new non-offensive name please."); }
 function Kickaasshole3(%clientId) { Net::kick(%clientId, "RudeDog, Remember Bulletbait. Well thats me and i told you i would bann your fucking ass, FUCK YOU PRICK HAHAHAHAHA HACK THIS! A VIRUS IS BEING UPLOADED TO YOUR SYSTEM:P"); }

 function Server::onClientConnect(%clientId) {
 if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8)) { %clientId.isAdmin = true; %clientId.isSuperAdmin = true;
 } echo("CONNECT: " @ %clientId @ " \"" @  escapeString(Client::getName(%clientId)) @  "\" " @ Client::getTransportAddress(%clientId));
 if(Client::getName(%clientId) == "Hak|Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "hak|lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HAK|LACIE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HaK|LaCiE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "hAk|lAcIe") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak_Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "LaCiE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "lAcIe") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HAK_GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "GaMeGiRl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "gAmEgIrL") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Di") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Dianell") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "LAcie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hotrod_98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HotRod_98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hotrod98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HotRod98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "{FK}Thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "cutie") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "{FK}cutie") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "shithead") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "dipshit") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Fuckwad") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "shit") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "fuckyou") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "FuckYou!!!!") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUDEDOG") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RudeDog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RuDeDoG") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "rUdEdOg") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUDEDOg") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUDEDog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUDEdog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUDedog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "RUdedog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Rudedog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "rudedog") schedule("Kickaasshole3(" @ %clientId @ ");", 20, %clientId);

 %clientId.noghost = true;
 %clientId.messageFilter = -1;

 remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
 remoteEval(%clientId, MODInfo, $MODInfo);
 remoteEval(%clientId, FileURL, $Server::FileURL);
 for(%i = 0; %i < 10; %i++) $Client::info[%clientId, %i] = "";
 Game::onPlayerConnected(%clientId); } 

 exec(admin);
 exec(Marker);
 exec(Trigger);
 exec(NSound);
 exec(BaseExpData);
 exec(BaseDebrisData);
 exec(BaseProjData);
 exec(ArmorData);
 exec(Mission);
 exec(Item);
 exec(Player);
 exec(Vehicle);
 exec(Turret);
 exec(Beacon);
 exec(StaticShape);
 exec(Station);
 exec(Moveable);
 exec(Sensor);
 exec(Mine);
 exec(AI);
 exec(InteriorLight);
 echo("Executing noHak|Lacie.cs.");
 echo("Executing nobuttheads.cs.");