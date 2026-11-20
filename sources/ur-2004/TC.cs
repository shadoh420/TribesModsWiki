function ClientMessage::Start(%playerId)
{
   
   //
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>This mission will provide instruction on basic player movement and your heads-up display.\", 10);", 5);
   schedule("messageAll(0, \"~wshell_click.wav\");", 5);

}
