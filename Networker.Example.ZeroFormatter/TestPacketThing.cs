﻿namespace Networker.Example.ZeroFormatter
{
	[ZeroFormattable]
	public class TestPacketThing : ZeroFormatterPacketBase
	{
		[Index(2)] public virtual string SomeString { get; set; }
	}
}