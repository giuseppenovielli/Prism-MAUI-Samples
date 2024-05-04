#!/bin/sh 
mono /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/confuserex_1.4.1/Confuser.CLI.exe /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/confuserex_1.4.1/project.crproj -debug
cp //Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation.Android/bin/obfuscate/* /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation/bin/Release/netstandard2.0
cp /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation.Android/bin/obfuscate/* /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation/obj/Release/netstandard2.0 
cp /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation.Android/bin/obfuscate/* /Users/hrcoffee2/XF-Prism-Full-Navigation-Example-master/PrismFullNavigation/PrismFullNavigation.Android/bin/Release

