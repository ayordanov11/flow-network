﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PumpSink : Component
{
	private int maxFlow
	{
		get;
		set;
	}

	private int currentFlow
	{
		get;
		set;
	}

	private bool isSink
	{
		get;
		set;
	}

	private bool inOutState
	{
		get;
		set;
	}

	public bool changeCurrentFlow(int newFlow)
	{
		throw new System.NotImplementedException();
	}

	public void changeMaxFlow(int newMaxFlow)
	{
		throw new System.NotImplementedException();
	}

	public PumpSink(int currentFlow, int maxFlow, bool isSink)
	{
	}

}
