﻿
using Stealer;
using System.ComponentModel;

Spy spy = new Spy();
//string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

//string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");

//string result = spy.RevealPrivateMethods("Stealer.Hacker");

string result = spy.CollectGettersAndSetters("Stealer.Hacker");

Console.WriteLine(result);