
using _3.Telephony;
using _3.Telephony.Core;
using _3.Telephony.Core.Interfaces;
using _3.Telephony.IO;
using _3.Telephony.Models;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
engine.Run();