﻿# LuisDispatchBot hosted in ASP.NET Core

This bot demonstrates how to use a LUIS model generated by the Dispatch tool.

See https://aka.ms/bot-dispatch for more information on the Dispatch tool.

This example assumes the LUIS app from Dispatch is generated from two LUIS apps and one QnAMaker service:
 * A LUIS app named "homeautomation", for handling messages about turning lights and appliances on and off
 * A LUIS app named "weather", for handling requests for weather forecasts and conditions
 * A QnA Maker service named "faq", for answering questions about using the hypothetical home automation system.
 
First create the LUIS apps and QnAMaker, then generate a LUIS app from them using the Dispatch tool.

1. Use the https://luis.ai portal to import the included homeautomation.json and weather.json model files or using [LUIS cli tool](https://github.com/Microsoft/botbuilder-tools/tree/master/LUIS).
2. Use the https://qnamaker.ai portal to import the included sampleKnowledgeBase.tsv faq file or using [QnAMaker cli tool](https://github.com/Microsoft/botbuilder-tools/tree/master/QnAMaker).
3. Train and Publish your apps bfore using the Dispatch tool. (For your convenience the resulting dispatchSample.json LUIS model is also included).

The tool creates a LUIS app with one intent for each of the constituent LUIS apps and QnAMaker services: 
"l_homeautomation", "l_weather", "q_faq".
The bot uses the intents to route the user messages to the appropriate LUIS app or QnA Maker.

Dispatching the messages to the original LUIS apps allows the bot to get entities from the these apps. 
The LUIS app generated by the Dispatch tool doesn't contain entity information.

To use the sample, update Startup.cs with the LUIS App ID and Subscription Key for the LUIS app that the Dispatch tool generates. 
Update the subscription keys and app IDs in LuisDispatchBot.cs with the ones for the constituent LUIS apps and QnAMaker service. 